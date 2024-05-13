using DataAccessLayer.Repositories.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Product_Management_MVC.Areas.Admin.Controllers;

[Area("Admin")]

public class CustomerController: Controller
{
    private readonly ICustomerRepository _customerRepository;
    
    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
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
        ViewBag.customer = customer;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateCustomer(Entities.Concretes.Customer customer)
    {
        var updatedCustomer = await  _customerRepository.GetByIdAsync(customer.Id);
        if (updatedCustomer is not null)
        {
            await _customerRepository.UpdateAsync(customer);
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