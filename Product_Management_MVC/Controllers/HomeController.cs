using DataAccessLayer.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Product_Management_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ISellerRepository _sellerRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IAdminRepository _adminRepository;


    public HomeController(ISellerRepository sellerRepository, IAdminRepository adminRepository, ICustomerRepository customerRepository)
    {
        _sellerRepository = sellerRepository;
        _customerRepository = customerRepository;
        _adminRepository = adminRepository;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }
}