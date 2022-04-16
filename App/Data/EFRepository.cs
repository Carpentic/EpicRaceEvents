using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.Data;

public class EFRepository<_Ty> : IRepository<_Ty> where _Ty : class
{
    private readonly AppDbContext _context;

    public EFRepository(AppDbContext dbContext)
    {
        _context = dbContext;
    }

    public void Add(_Ty entity)
    {
        _context.Set<_Ty>().Add(entity);
    }

    public bool Any(Expression<Func<_Ty, bool>> predicate)
    {
        return _context.Set<_Ty>().Any(predicate);
    }

    public void Delete(_Ty entity)
    {
        _context.Set<_Ty>().Remove(entity);
    }

    public void DeleteBy(Expression<Func<_Ty, bool>> predicate)
    {
        _context.Remove(predicate);
    }

    public void Edit(_Ty entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public IQueryable<_Ty> GetAll()
    {
        return _context.Set<_Ty>().AsQueryable();
    }

    public IQueryable<_Ty> GetBy(Expression<Func<_Ty, bool>> predicate)
    {
        return _context.Set<_Ty>().Where(predicate);
    }

    public void Update()
    {
        _context.SaveChanges();
    }

    public Task UpdateAsync()
    {
        return _context.SaveChangesAsync();
    }
}
