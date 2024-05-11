using DataAccessLayer.Repositories.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Product_Management_MVC.Areas.Admin.Controllers;

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
    [HttpPost]
    public async Task<IActionResult> UpdateCustomer(Customer customer)
    {
        await _customerRepository.UpdateAsync(customer);
        return RedirectToAction("GetAllCustomers");
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _customerRepository.GetAllAsync();
        ViewBag.customers = customers;
        return View();
    }
}