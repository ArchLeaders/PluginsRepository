namespace PluginsRepository.Core.Components;

public interface IConnection
{
    Dictionary<Guid, T> GetResource<T>() where T : TableItem<T>;
}