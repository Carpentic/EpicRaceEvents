using System.Linq.Expressions;

namespace App.Data;

public interface IRepository<_Ty> where _Ty : class
{
    IQueryable<_Ty> GetAll();
    IQueryable<_Ty> GetBy(Expression<Func<_Ty, bool>> predicate);
    bool Any(Expression<Func<_Ty, bool>> predicate);

    void Add(_Ty entity);
    void Edit(_Ty entity);
    void Delete(_Ty entity);
    void DeleteBy(Expression<Func<_Ty, bool>> predicate);

    void Update();
    Task UpdateAsync();
}
