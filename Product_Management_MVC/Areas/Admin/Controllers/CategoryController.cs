using DataAccessLayer.Repositories.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Product_Management_MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepository;
    
    public CategoryController(ICategoryRepository categoryRepository)
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
    
    [HttpGet]
    public async Task<IActionResult> EditCategory(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        ViewBag.Category = category;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateCategory(Category category)
    {
        var updatedCategory = await  _categoryRepository.GetByIdAsync(category.Id);
        if (updatedCategory is not null)
        {
            await _categoryRepository.UpdateAsync(category);
            return RedirectToAction("GetAllCategories");
        }
        return RedirectToAction("EditCategory", category.Id);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAllAsync();
        ViewBag.categories = categories;
        return View();
    }
}