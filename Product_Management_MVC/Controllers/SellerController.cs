using DataAccessLayer.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Product_Management_MVC.Controllers;

public class SellerController: Controller
{
    private readonly ISellerRepository _sellerRepository;

    public SellerController(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }
}