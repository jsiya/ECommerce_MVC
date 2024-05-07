using DataAccessLayer.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Product_Management_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ICategoryRepository _categoryRepository;

    

    public HomeController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IActionResult> Index()
    {
       // await _categoryRepository.AddAsync(new() { Name = "Shirt" });
        return View();
    }
}