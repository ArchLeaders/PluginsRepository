using System.Text.Json;

namespace PluginsRepository.Core.Generics;

public class Table<T> : ITable<T> where T : TableItem<T>
{
    private readonly Dictionary<Guid, T> _cache;

    public Table(IConnection connection)
    {
        _cache = connection.GetResource<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await Task.FromResult(
            _cache.Values.AsEnumerable());
    }

    public async Task<IEnumerable<T>> GetAll(Func<T, bool> filter)
    {
        return await Task.FromResult(
            _cache.Values.Where(filter));
    }

    public async Task<T?> Get(Func<T, bool> filter)
    {
        return await Task.FromResult(
            _cache.Values.Where(filter).FirstOrDefault());
    }

    public async Task Add(T item)
    {
        await Task.Run(() => {
            _cache.Add(item.Id, item);
        });
    }

    public async Task Update(T item)
    {
        await Task.Run(() => {
            _cache[item.Id] = item;
        });
    }

    public async Task<bool> Remove(T item)
    {
        return await Task.FromResult(
            _cache.Remove(item.Id));
    }

    public async Task Serialize(Stream output)
    {
        await JsonSerializer.SerializeAsync(output, _cache);
    }
}
