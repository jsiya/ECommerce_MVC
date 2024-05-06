using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories.Abstracts;
using Entities.Concretes;

namespace DataAccessLayer.Repositories.Concretes;

public class CategoryRepository: GenericRepository<Category>
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}