using System.Linq.Expressions;

namespace App.Data;

public interface IRepository
{
    IQueryable<_Ty> GetAll<_Ty>() where _Ty : class;
    IQueryable<_Ty> GetBy<_Ty>(Expression<Func<_Ty, bool>> predicate) where _Ty : class;
    bool Any<_Ty>(Expression<Func<_Ty, bool>> predicate) where _Ty : class;

    void Add<_Ty>(_Ty entity) where _Ty : class;
    void Edit<_Ty>(_Ty entity) where _Ty : class;
    void Delete<_Ty>(_Ty entity) where _Ty : class;
    void DeleteBy<_Ty>(Expression<Func<_Ty, bool>> predicate) where _Ty : class;

    void Update<_Ty>();
    Task UpdateAsync<_Ty>();
}
