using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories.Abstracts;
using Entities.Concretes;

namespace DataAccessLayer.Repositories.Concretes;

public class OrderRepository : GenericRepository<Order>
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }
}