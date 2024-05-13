using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories.Abstracts;
using Entities.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Concretes;

public class GenericRepository<T> : IGenericRepository<T> where T : Entity, new()
{
    protected readonly AppDbContext Context;

    public GenericRepository(AppDbContext context)
    {
        Context = context;
    }
    
    public async Task AddAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        Context.Set<T>().Remove(entity!);
        await Context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await Context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        Context.ChangeTracker.Clear();
        Context.Set<T>().Update(entity);
        await Context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}