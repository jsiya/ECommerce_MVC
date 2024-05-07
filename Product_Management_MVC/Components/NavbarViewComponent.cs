using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Product_Management_MVC.Components;

public class NavbarViewComponent : ViewComponent
{
    public ViewViewComponentResult Invoke()
    {
        return View();
    }
}