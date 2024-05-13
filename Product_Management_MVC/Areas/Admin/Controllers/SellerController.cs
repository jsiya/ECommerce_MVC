using DataAccessLayer.Repositories.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Product_Management_MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class SellerController : Controller
{
    private readonly ISellerRepository _sellerRepository;
    
    public SellerController(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
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
        ViewBag.Seller = seller;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateSeller(Entities.Concretes.Seller seller)
    {
        var updatedSeller = await  _sellerRepository.GetByIdAsync(seller.Id);
        if (updatedSeller is not null)
        {
            await _sellerRepository.UpdateAsync(seller);
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