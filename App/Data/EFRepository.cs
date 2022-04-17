using System.Linq.Expressions;

namespace App.Data;

public class EFRepository : IRepository
{
    private readonly AppDbContext _context;

    public EFRepository(AppDbContext dbContext)
    {
        _context = dbContext;
    }

    public void Add<_Ty>(_Ty entity) where _Ty : class
    {
        _context.Add(entity);
    }

    public bool Any<_Ty>(Expression<Func<_Ty, bool>> predicate) where _Ty : class
    {
        return _context.Set<_Ty>().Any(predicate);
    }

    public void Delete<_Ty>(_Ty entity) where _Ty : class
    {
        _context.Remove(entity);
    }

    public void DeleteBy<_Ty>(Expression<Func<_Ty, bool>> predicate) where _Ty : class
    {
        var entities = _context.Set<_Ty>().Where(predicate);
        foreach (var entity in entities)
            _context.Remove(entity);
    }

    public void Edit<_Ty>(_Ty entity) where _Ty : class
    {
        _context.Update(entity);
    }

    public IQueryable<_Ty> GetAll<_Ty>() where _Ty : class
    {
        return _context.Set<_Ty>().AsQueryable();
    }

    public IQueryable<_Ty> GetBy<_Ty>(Expression<Func<_Ty, bool>> predicate) where _Ty : class
    {
        return _context.Set<_Ty>().Where(predicate);
    }

    public void Update<_Ty>()
    {
        _context.SaveChanges();
    }

    public Task UpdateAsync<_Ty>()
    {
        return _context.SaveChangesAsync();
    }
}
