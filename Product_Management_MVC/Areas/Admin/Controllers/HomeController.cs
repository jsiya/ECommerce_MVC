using DataAccessLayer.Repositories.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Product_Management_MVC.Areas.Admin.Controllers;


[Area("Admin")]
public class HomeController: Controller
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ISellerRepository _sellerRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICustomerRepository _customerRepository;


    public HomeController(ICategoryRepository categoryRepository, 
        ISellerRepository sellerRepository,
        ICustomerRepository customerRepository,
        IProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _sellerRepository = sellerRepository;
        _customerRepository = customerRepository;
        _productRepository = productRepository;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
}