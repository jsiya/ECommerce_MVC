using DataAccessLayer.Repositories.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using Product_Management_MVC.ViewModels;

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
        ProductViewModel productVm = new()
        {
            Category = product.Category.Name,
            Description = product.Description,
            Id = product.Id,
            ImageUrl = product.ImageUrl,
            Name = product.Name,
            Price = product.Price,
            SellerUsername = product.Seller.Username,
            Stock = product.Stock
        };
        ViewBag.Product = productVm;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateProduct(ProductViewModel product)
    {
        var updatedProduct = await  _productRepository.GetByIdAsync(product.Id);
        if (updatedProduct is not null)
        {
            updatedProduct.Name = product.Name;
            updatedProduct.Description = product.Description;
            updatedProduct.Stock = product.Stock;
            
            await _productRepository.UpdateAsync(updatedProduct);
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