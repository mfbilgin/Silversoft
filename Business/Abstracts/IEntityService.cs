using Core.Extensions.Paging;

namespace Business.Abstracts;

public interface IEntityService<T>
{
    public void Add(T role);
    public void Update(T entity);
    public void Delete(T entity);
    public T? GetById(Guid id);
    public PageableModel<T> GetAll(int index = 1, int size = 10);
}