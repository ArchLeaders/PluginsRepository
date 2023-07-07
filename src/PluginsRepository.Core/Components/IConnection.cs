namespace PluginsRepository.Core.Components;

public interface IConnection
{
    Task<Dictionary<Guid, T>> LoadResource<T>() where T : TableItem<T>;
    Task SaveResource<T>(Dictionary<Guid, T> payload) where T : TableItem<T>;
}