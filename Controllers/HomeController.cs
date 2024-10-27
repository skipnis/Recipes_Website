using Microsoft.AspNetCore.Mvc;
using WebCooking.Data;

namespace WebCooking.Controllers;

public class HomeController : Controller
{
    
    // GET
    public IActionResult Home()
    {
        return View();
    }
}