using DataAccessLayer.Repositories.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using Product_Management_MVC.ViewModels;

namespace Product_Management_MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class SellerController : Controller
{
    private readonly ISellerRepository _sellerRepository;
    
    public SellerController(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }
    
    [HttpGet]
    public IActionResult CreateSeller()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateSeller(SellerViewModel seller)
    {
        Entities.Concretes.Seller newSeller = new()
        {
            Id = seller.Id,
            FirstName = seller.FirstName,
            LastName = seller.LastName,
            Address = seller.Address,
            Password = seller.Password,
            Username = seller.Username
        };
        await _sellerRepository.AddAsync(newSeller);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteSeller(int id)
    {
        await _sellerRepository.DeleteAsync(id);
        return RedirectToAction("");
    }
    [HttpPost]
    [HttpGet]
    public async Task<IActionResult> EditSeller(int id)
    {
        var seller = await _sellerRepository.GetByIdAsync(id);
        SellerViewModel sellerViewModel = new()
        {
            Id = seller.Id,
            FirstName = seller.FirstName,
            LastName = seller.LastName,
            Address = seller.Address,
            UserRole = seller.UserRole,
            Username = seller.Username,
            Password = seller.Password
        };
        ViewBag.Seller = sellerViewModel;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateSeller(SellerViewModel seller)
    {
        var updatedSeller = await  _sellerRepository.GetByIdAsync(seller.Id);
        if (updatedSeller is not null)
        {
            updatedSeller.FirstName = seller.FirstName;
            updatedSeller.LastName = seller.LastName;
            updatedSeller.Username = seller.Username;
            updatedSeller.Address = seller.Address;
            await _sellerRepository.UpdateAsync(updatedSeller);
            return RedirectToAction("GetAllSellers");
        }
        return RedirectToAction("EditSeller", seller.Id);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllSellers()
    {
        var sellers = await _sellerRepository.GetAllAsync();
        ViewBag.Sellers = sellers;
        return View();
    }
}