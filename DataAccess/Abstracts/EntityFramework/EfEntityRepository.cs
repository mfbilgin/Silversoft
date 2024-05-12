using System.Linq.Expressions;
using Core.Extensions.Paging;
using Entities.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Abstracts.EntityFramework;

public abstract class EfEntityRepository<T>(DbContext context) : IEntityRepository<T>
    where T : class, IEntity, new()
{
    private readonly DbSet<T> _entities = context.Set<T>();
    public void Add(T entity)
    {
        var addedEntity = context.Entry(entity);
        addedEntity.State = EntityState.Added;
        context.SaveChanges();
    }

    public void Update(T entity)
    {
        var updatedEntity = context.Entry(entity);
        updatedEntity.State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(T entity)
    {
        var deletedEntity = context.Entry(entity);
        deletedEntity.State = EntityState.Deleted;
        context.SaveChanges();
    }

    public T? Get(Expression<Func<T, bool>> filter)
    {
        return _entities.SingleOrDefault(filter);
    }

    public T? GetById(Guid id)
    {
        return _entities.Find(id);
    }

    public PageableModel<T> GetList(int index, int size, Expression<Func<T, bool>>? filter = null)
    {
        var queryable = filter is null
            ? _entities
            : _entities.Where(filter);
        return queryable.ToPaginate(index, size);
    }
}