using Microsoft.AspNetCore.Mvc;

namespace EMSI.Fuga.WebAPI.Controllers;

[Route("")]
public class InfoController : ControllerBase
{
    [HttpGet]
    [HttpGet("info")]
    public IActionResult GetInfo()
    {
        return OkEncapsulated(new
        {
            AppName = "gestion Absences",
            AppVersion = "1.0.0",
            Corporate = "EMSI",
            CurrentServerTime = DateTime.UtcNow,
            Scope = "Public, Front Office"
        });
    }
}