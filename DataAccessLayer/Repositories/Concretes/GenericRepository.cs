using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories.Abstracts;
using Entities.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Concretes;

public class GenericRepository<T> : IGenericRepository<T> where T : Entity, new()
{
    protected readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        _context.Set<T>().Remove(entity!);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}