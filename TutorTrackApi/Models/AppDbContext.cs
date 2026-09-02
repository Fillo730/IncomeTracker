using Microsoft.EntityFrameworkCore;
using TutorTrackApi.Models;

namespace TutorTrackApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Language> Languages { get; set; } = null!;
    public DbSet<IncomeType> IncomeTypes { get; set; } = null!;
    public DbSet<IncomeTypeTranslation> IncomeTypeTranslations { get; set; } = null!;
    public DbSet<IncomeEntry> IncomeEntries { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Language>(entity => {
            entity.HasIndex(e => e.Code).IsUnique();
        });

        modelBuilder.Entity<IncomeTypeTranslation>(entity => {
            entity.HasIndex(e => new { e.IncomeTypeId, e.LanguageId }).IsUnique();
        });

        modelBuilder.Entity<IncomeEntry>(entity => {
            entity.Property(e => e.Amount).HasConversion<double>();
        });

        modelBuilder.Entity<Language>().HasData(
            new Language { Id = 1, Code = "it", Name = "Italiano" },
            new Language { Id = 2, Code = "en", Name = "English" }
        );

        modelBuilder.Entity<IncomeType>().HasData(
            new IncomeType { Id = 1, Key = "TUTORING" },
            new IncomeType { Id = 2, Key = "OTHER" }
        );

        modelBuilder.Entity<IncomeTypeTranslation>().HasData(
            new IncomeTypeTranslation { Id = 1, IncomeTypeId = 1, LanguageId = 1, Name = "Ripetizioni" },
            new IncomeTypeTranslation { Id = 2, IncomeTypeId = 1, LanguageId = 2, Name = "Tutoring" },
            
            new IncomeTypeTranslation { Id = 3, IncomeTypeId = 2, LanguageId = 1, Name = "Traslochi" },
            new IncomeTypeTranslation { Id = 4, IncomeTypeId = 2, LanguageId = 2, Name = "Moving" },
            
            new IncomeTypeTranslation { Id = 5, IncomeTypeId = 3, LanguageId = 1, Name = "Altro" },
            new IncomeTypeTranslation { Id = 6, IncomeTypeId = 3, LanguageId = 2, Name = "Other" }
        );
    }
}