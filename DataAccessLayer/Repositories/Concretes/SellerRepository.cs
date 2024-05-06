using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories.Abstracts;
using Entities.Concretes;

namespace DataAccessLayer.Repositories.Concretes;

public class SellerRepository: GenericRepository<Seller>
{
    public SellerRepository(AppDbContext context) : base(context)
    {
    }
}