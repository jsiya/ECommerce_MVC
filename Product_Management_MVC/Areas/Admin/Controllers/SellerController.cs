using DataAccessLayer.Repositories.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Product_Management_MVC.Areas.Admin.Controllers;

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
    public async Task<IActionResult> UpdateSeller(Seller seller)
    {
        await _sellerRepository.UpdateAsync(seller);
        return RedirectToAction("GetAllSellers");
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllSellers()
    {
        var sellers = await _sellerRepository.GetAllAsync();
        ViewBag.sellers = sellers;
        return View();
    }
}