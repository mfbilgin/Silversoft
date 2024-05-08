using Core.Extensions.Paging;

namespace Business.Abstracts;

public interface IEntityService<T>
{
    public void Add(T entity);
    public void Update(T entity);
    public void Delete(T entity);
    public T? GetById(int id);
    public PageableModel<T> GetAll();
}