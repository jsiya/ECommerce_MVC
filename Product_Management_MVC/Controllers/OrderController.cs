using DataAccessLayer.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Product_Management_MVC.Controllers;

public class OrderController : Controller
{
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
}