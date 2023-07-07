namespace PluginsRepository.Core.Generics;

public interface ITable<T> where T : TableItem<T>
{
    Task Add(T item);
    Task<T?> Get(Func<T, bool> filter);
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> GetAll(Func<T, bool> filter);
    Task<bool> Remove(T item);
    Task Update(T item);
}