using DataAccessLayer.Repositories.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using Product_Management_MVC.ViewModels;

namespace Product_Management_MVC.Areas.Admin.Controllers;

[Area("Admin")]

public class CustomerController: Controller
{
    private readonly ICustomerRepository _customerRepository;
    
    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet]
    public IActionResult CreateCustomer()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CustomerViewModel customer)
    {
        Entities.Concretes.Customer newCustomer = new()
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Address = customer.Address,
            Password = customer.Password,
            Username = customer.Username
        };
        await _customerRepository.AddAsync(newCustomer);
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        await _customerRepository.DeleteAsync(id);
        return RedirectToAction("GetAllCustomers");
    }
    
    [HttpGet]
    public async Task<IActionResult> EditCustomer(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        CustomerViewModel customerViewModel = new()
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Address = customer.Address,
            Username = customer.Username,
            Password = customer.Password,
            UserRole = customer.UserRole
        };
        
        ViewBag.Customer = customerViewModel;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateCustomer(CustomerViewModel customer)
    {
        var updatedCustomer = await  _customerRepository.GetByIdAsync(customer.Id);
        if (updatedCustomer is not null)
        {
            updatedCustomer.Username = customer.Username;
            updatedCustomer.Address = customer.Address;
            updatedCustomer.LastName = customer.LastName;
            updatedCustomer.FirstName = customer.FirstName;
            
            await _customerRepository.UpdateAsync(updatedCustomer);
            return RedirectToAction("GetAllCustomers");
        }
        return RedirectToAction("EditCustomer", customer.Id);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _customerRepository.GetAllAsync();
        ViewBag.customers = customers;
        return View();
    }
}