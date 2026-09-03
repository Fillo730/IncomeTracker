using TutorTrackApi.Dtos;
using TutorTrackApi.DTOs;
using TutorTrackApi.IMappers;
using TutorTrackApi.Models;

namespace TutorTrackApi.Mapper;

public class IncomeMapper : IIncomeMapper
{
    public IncomeEntryDto MapToDto(IncomeEntry e, string lang)
    {
        return new IncomeEntryDto
        {
            Id = e.Id,
            Description = e.Description,
            Amount = (double)e.Amount,
            Hours = e.Hours,
            Date = e.Date,
            CategoryKey = e.IncomeType.Key ?? "N/A",
            CategoryName = e.IncomeType.Translations
                .FirstOrDefault(t => t.Language.Code == lang)?.Name ?? e.IncomeType.Key ?? "N/A",
            StudentId = e.StudentId,
            StudentName = e.Student?.Name
        };
    }

    public IEnumerable<IncomeEntryDto> MapToListDto(IEnumerable<IncomeEntry> e, string lang)
    {
        return e.Select(entity => MapToDto(entity, lang));
    }

    public IncomeEntry MapToEntity(IncomeEntryDto dto, int incomeTypeId)
    {
        return new IncomeEntry
        {
            Description = dto.Description,
            Amount = (decimal)dto.Amount,
            Hours = dto.Hours,
            Date = dto.Date,
            IncomeTypeId = incomeTypeId,
            StudentId = dto.StudentId
        };
    }

    public IncomeTypeDto MapTypeToDto(IncomeType e, string lang)
    {
        return new IncomeTypeDto 
        {
            Id = e.Id, 
            Key = e.Key,
            Name = e.Translations
                .FirstOrDefault(tr => tr.Language.Code.Equals(lang, StringComparison.OrdinalIgnoreCase))
                ?.Name ?? e.Key
        };
    }

    public IEnumerable<IncomeTypeDto> MapTypeToDtoList(IEnumerable<IncomeType> e, string lang)
    {
        return e.Select(en => MapTypeToDto(en,lang));
    }
}