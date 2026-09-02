namespace TutorTrackApi.Dtos.Enum;

public enum AppStatusCode
{
    Success = 100,
    Created = 101,
    ValidationError = 400,
    NotFound = 404,
    DatabaseError = 500,
    GenericError = 999
}