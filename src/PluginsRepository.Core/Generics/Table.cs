namespace PluginsRepository.Core.Generics;

public class Table<T> : ITable<T> where T : TableItem<T>
{
    private readonly IConnection _connection;
    private Dictionary<Guid, T>? _cache;

    public Dictionary<Guid, T> Cache => _cache
        ?? throw new InvalidOperationException($"{nameof(Cache)} returned null. Call ITable<T>.Load() to load the cache asynchronously");

    public Table(IConnection connection)
    {
        _connection = connection;
    }

    public async Task Load()
    {
        _cache ??= await _connection.LoadResource<T>();
    }

    public async Task Save()
    {
        await _connection.SaveResource(Cache);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await Task.FromResult(
            Cache.Values.AsEnumerable());
    }

    public async Task<IEnumerable<T>> GetAll(Func<T, bool> filter)
    {
        return await Task.FromResult(
            Cache.Values.Where(filter));
    }

    public async Task<T?> Get(Func<T, bool> filter)
    {
        return await Task.FromResult(
            Cache.Values.Where(filter).FirstOrDefault());
    }

    public async Task Add(T item)
    {
        await Task.Run(() => {
            Cache.Add(item.Id, item);
        });
    }

    public async Task Update(T item)
    {
        await Task.Run(() => {
            Cache[item.Id] = item;
        });
    }

    public async Task<bool> Remove(T item)
    {
        return await Task.FromResult(
            Cache.Remove(item.Id));
    }
}
