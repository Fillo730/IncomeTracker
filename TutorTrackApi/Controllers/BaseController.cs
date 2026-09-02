using Microsoft.AspNetCore.Mvc;

namespace TutorTrackApi.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected string GetLang(string? lang)
    {
        if (!string.IsNullOrWhiteSpace(lang))
        {
            return lang.ToLower();
        }

        var headerLang = Request.Headers["Accept-Language"].ToString();

        if (!string.IsNullOrWhiteSpace(headerLang))
        {
            return headerLang.Substring(0, 2).ToLower();
        }
        
        return "it"; 
    }

    protected (int year, int month) GetYearMonth(int? year, int? month)
    {
        var now = DateTime.Now;
        
        int finalYear = year ?? now.Year;
        
        int finalMonth = month ?? now.Month;

        return (finalYear, finalMonth);
    }
}