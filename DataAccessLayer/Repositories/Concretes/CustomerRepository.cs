using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories.Abstracts;
using Entities.Concretes;

namespace DataAccessLayer.Repositories.Concretes;

public class CustomerRepository : GenericRepository<Customer>
{
    public CustomerRepository(AppDbContext context) : base(context)
    {
    }
}