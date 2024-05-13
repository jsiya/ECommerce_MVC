using DataAccessLayer.Repositories.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Product_Management_MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;
    
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpPost]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productRepository.DeleteAsync(id);
        return RedirectToAction("");
    }
    [HttpGet]
    public async Task<IActionResult> EditProduct(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        ViewBag.Product = product;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateProduct(Entities.Concretes.Product product)
    {
        var updatedProduct = await  _productRepository.GetByIdAsync(product.Id);
        if (updatedProduct is not null)
        {
            await _productRepository.UpdateAsync(product);
            return RedirectToAction("GetAllProducts");
        }
        return RedirectToAction("EditProduct", product.Id);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productRepository.GetAllAsync();
        ViewBag.Products = products;
        return View();
    }
}