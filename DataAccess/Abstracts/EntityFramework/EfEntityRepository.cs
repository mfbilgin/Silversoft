using System.Linq.Expressions;
using Core.Extensions.Paging;
using Entities.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Abstracts.EntityFramework;

public abstract class EfEntityRepository<T>(DbContext context) : IEntityRepository<T>
    where T : class, IEntity
{ public void Add(T entity)
    {
        context.Set<T>().Add(entity);
        context.SaveChanges();
    }

    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
        context.SaveChanges();
    }

    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
        context.SaveChanges();
    }

    public T? Get(Expression<Func<T, bool>> filter)
    {
        return context.Set<T>().AsNoTracking().SingleOrDefault(filter);
    }

    public T? GetById(Guid id)
    {
        return context.Set<T>().AsNoTracking().SingleOrDefault(t => t.Id == id);
    }

    public PageableModel<T> GetList(int index, int size, Expression<Func<T, bool>>? filter = null)
    {
        var queryable = filter is null
            ? context.Set<T>().AsNoTracking()
            : context.Set<T>().AsNoTracking().Where(filter);
        return queryable.ToPaginate(index, size);
    }
}