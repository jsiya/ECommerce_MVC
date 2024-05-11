using Microsoft.AspNetCore.Mvc;

namespace Product_Management_MVC.Controllers;

public class HomeController: Controller
{
    public IActionResult Index()
    {
        return View();
    }
}