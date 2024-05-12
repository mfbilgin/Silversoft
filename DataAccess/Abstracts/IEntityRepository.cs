using System.Linq.Expressions;
using Core.Extensions.Paging;
using Entities.Abstracts;

namespace DataAccess.Abstracts;

public interface IEntityRepository<T> where T : class, IEntity, new()
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    T? Get(Expression<Func<T, bool>> filter);
    T? GetById(Guid id);
    PageableModel<T> GetList(int index, int size, Expression<Func<T, bool>>? filter = null);
}