using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace EMSI.Fuga.WebAPI.Controllers;

public abstract class ControllerBase : Controller
{
    protected IActionResult OkEncapsulated<T>(T result, int? totalItems = null)
    {
        return Ok(new 
        {
            Result = result,
            TotalItems = totalItems
        });
    }
}