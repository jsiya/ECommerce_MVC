using DataAccessLayer.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Product_Management_MVC.Controllers;

public class CustomerController: Controller
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
}