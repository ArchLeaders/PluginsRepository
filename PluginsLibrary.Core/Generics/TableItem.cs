namespace PluginsRepository.Core.Generics;

public partial class TableItem<T> : ObservableObject where T : TableItem<T>
{
    [ObservableProperty]
    private Guid _id = Guid.NewGuid();
}
