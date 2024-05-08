using DataAccessLayer.Repositories.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Product_Management_MVC.Controllers;

public class AdminController : Controller
{
    private readonly ICategoryRepository _categoryRepository;

    public AdminController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    [HttpGet]
    public IActionResult CreateCategory()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCategory(Category category)
    {
        await _categoryRepository.AddAsync(category);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteCategoryById(int id)
    {
        await _categoryRepository.DeleteAsync(id);
        return RedirectToAction("GetAllCategories");
    }
    [HttpPost]
    public async Task<IActionResult> UpdateCategory(Category category)
    {
        await _categoryRepository.UpdateAsync(category);
        return RedirectToAction("GetAllCategories");
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAllAsync();
        ViewBag.categories = categories;
        return View();
    }
    
}