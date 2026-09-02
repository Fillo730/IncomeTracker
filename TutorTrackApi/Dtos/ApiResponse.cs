using TutorTrackApi.Dtos.Enum;

namespace TutorTrackApi.Models.Responses;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public AppStatusCode Code { get; set; }

    public static ApiResponse<T> Ok(T data, string message = "Operazione completata") 
        => new() { Success = true, Data = data, Message = message, Code = AppStatusCode.Success };

    public static ApiResponse<T> Fail(AppStatusCode code, string message) 
        => new() { Success = false, Message = message, Code = code };
}