using System.Linq.Expressions;
using Core.Extensions.Paging;
using DataAccess.Abstracts;
using Entities.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework;

public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
{
    public void Add(TEntity entity)
    {
        using var context = new TContext();
        var addedEntity = context.Entry(entity);
        addedEntity.State = EntityState.Added;
        context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        using var context = new TContext();
        var updatedEntity = context.Entry(entity);
        updatedEntity.State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        using var context = new TContext();
        var deletedEntity = context.Entry(entity);
        deletedEntity.State = EntityState.Deleted;
        context.SaveChanges();
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> filter)
    {
        using var context = new TContext();
        return context.Set<TEntity>().SingleOrDefault(filter);
    }

    public PageableModel<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null,int index=1, int size=10)
    {
        using var context = new TContext();
        var queryable = filter is null
            ? context.Set<TEntity>()
            : context.Set<TEntity>().Where(filter);
        return queryable.ToPaginate(index, size);
    }
}