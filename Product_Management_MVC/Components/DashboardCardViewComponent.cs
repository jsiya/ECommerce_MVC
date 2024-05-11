using DataAccessLayer.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Product_Management_MVC.Components;

public class DashboardCardViewComponent: ViewComponent
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ISellerRepository _sellerRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;

    public DashboardCardViewComponent(ICategoryRepository categoryRepository, 
        ISellerRepository sellerRepository, 
        ICustomerRepository customerRepository, 
        IProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _sellerRepository = sellerRepository; 
        _customerRepository = customerRepository;
        _productRepository = productRepository;
    }
    
    public async Task<IViewComponentResult>  InvokeAsync()
    {
        ViewBag.CategoryCount = _categoryRepository.GetAllAsync()!.Result.Count;
        ViewBag.ProductCount = _productRepository.GetAllAsync()!.Result.Count;
        ViewBag.SellerCount = _sellerRepository.GetAllAsync()!.Result.Count;
        ViewBag.CustomerCount = _customerRepository.GetAllAsync()!.Result.Count;

        return await Task.FromResult<IViewComponentResult>(View());
    }
}