using Microsoft.EntityFrameworkCore;
using TutorTrackApi.Data;
using TutorTrackApi.Dtos.Filters;
using TutorTrackApi.Dtos.Stats;
using TutorTrackApi.IRepositories;
using TutorTrackApi.Models;

public class IncomeRepository (AppDbContext context) : IIncomeRepository
{
    private readonly AppDbContext _context = context;

    public async Task<(IEnumerable<IncomeEntry> Items, int TotalCount)> GetAllAsync(string lang, int pageSize, int pageNumber, IncomesFilterDto filters)
    {
        var query = _context.IncomeEntries.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filters.Query))
        {
            query = query.Where(x => x.Description.ToLower().Contains(filters.Query.ToLower()));
        }

        if (filters.Year.HasValue)
        {
            query = query.Where(x => x.Date.Year == filters.Year.Value);
        }

        if (filters.Month.HasValue)
        {
            query = query.Where(x => x.Date.Month == filters.Month.Value);
        }

        if (filters.IncomeTypeId is not null && filters.IncomeTypeId > 0)
        {
            query = query.Where(x => x.IncomeType.Id == filters.IncomeTypeId);
        }

        var totalCount = await query.CountAsync();

        var items = await query
            .Include(e => e.IncomeType)
                .ThenInclude(t => t.Translations)
                .ThenInclude(tr => tr.Language)
            .AsNoTracking()
            .OrderByDescending(e => e.Date)
            .Skip((pageNumber - 1) * pageSize) 
            .Take(pageSize)                
            .ToListAsync();

        return (items, totalCount);
    }

    public async Task AddAsync(IncomeEntry entry)
    {
        await _context.IncomeEntries.AddAsync(entry);
    }

    public async Task<double> GetIncomeForMonth(int year, int month)
    {
        return await _context.IncomeEntries
        .Where(ie => ie.Date.Year == year && ie.Date.Month == month)
        .SumAsync(ie => (double)ie.Amount);
    }

    public async Task<double> GetHoursWorkenForMonth(int year, int month)
    {
        return await _context.IncomeEntries

        .Where(ie => ie.Date.Year == year && ie.Date.Month == month)
        
        .SumAsync(ie => ie.Hours ?? 0);
    }

    public async Task<IEnumerable<CategoryIncomeDto>> GetIncomeByCategoryAsync(int year, int month, string lang)
    {
        return await _context.IncomeTypes
        .Select(type => new CategoryIncomeDto
        {
            CategoryName = type.Translations
                .Where(t => t.Language.Code == lang)
                .Select(t => t.Name)
                .FirstOrDefault() ?? type.Key,

            TotalAmount = type.Entries
                .Where(e => e.Date.Year == year && e.Date.Month == month)
                .Sum(e => e.Amount)
        })

        .Where(x => x.TotalAmount > 0)
        .ToListAsync();
    }

    public async Task<IEnumerable<IncomeType>> GetAllIncomeTypes(string lang)
    {
        return await _context.IncomeTypes
            .Include(t => t.Translations)
                .ThenInclude(tr => tr.Language)
        .ToListAsync();
    }

    public async Task<IncomeType?> GetIncomeTypeByKeyAsync(string key)
    {
        return await _context.IncomeTypes
            .FirstOrDefaultAsync(t => t.Key == key);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}