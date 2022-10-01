namespace Domain.Interfaces.Generics;

public interface IGeneric<T>where T : class
{
    Task Add(T entity);
    Task Delete(T entity);
    Task Update(T entity);
    Task<T> GetEntityById(int id);
    Task<List<T>> GetAll();
}
