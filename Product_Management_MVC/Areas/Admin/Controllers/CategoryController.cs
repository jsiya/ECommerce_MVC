using DataAccessLayer.Repositories.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using Product_Management_MVC.ViewModels;

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
    public async Task<IActionResult> CreateCategory(CategoryViewModel category)
    {
        Category newCategory = new()
        {
            Id = category.Id,
            Name = category.Name
        };
        await _categoryRepository.AddAsync(newCategory);
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
        CategoryViewModel categoryViewModel = new()
        {
            Id = category.Id,
            Name = category.Name
        };
        ViewBag.Category = categoryViewModel;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateCategory(CategoryViewModel category)
    {
        var updatedCategory = await  _categoryRepository.GetByIdAsync(category.Id);
        if (updatedCategory is not null)
        {
            updatedCategory.Name = category.Name;
            await _categoryRepository.UpdateAsync(updatedCategory);
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