using TutorTrackApi.Dtos;
using TutorTrackApi.DTOs;
using TutorTrackApi.Models;

namespace TutorTrackApi.IMappers;

public interface IIncomeMapper
{
    IncomeEntryDto MapToDto(IncomeEntry e, string lang);

    IEnumerable<IncomeEntryDto> MapToListDto(IEnumerable<IncomeEntry> e, string lang);

    IncomeEntry MapToEntity(IncomeEntryDto dto, int incomeTypeId);

    IncomeTypeDto MapTypeToDto(IncomeType e, string lang);

    IEnumerable<IncomeTypeDto> MapTypeToDtoList(IEnumerable<IncomeType> e, string lang);
}