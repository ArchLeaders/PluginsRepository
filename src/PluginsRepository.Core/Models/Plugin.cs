namespace PluginsRepository.Core.Models;

public partial class Plugin : TableItem<Plugin>
{
    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _description = string.Empty;

    [ObservableProperty]
    private string _assemblyName = string.Empty;

    [ObservableProperty]
    private string _organization = string.Empty;

    [ObservableProperty]
    private string _repository = string.Empty;

    [ObservableProperty]
    private List<Comment> _comments = new();

    [ObservableProperty]
    private DateTimeOffset _createdAt = DateTimeOffset.UtcNow;

    [ObservableProperty]
    private long _authorId;

    [ObservableProperty]
    private long _issueId;
}
