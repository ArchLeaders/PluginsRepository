namespace PluginsRepository.Core.Models;

public partial class Comment : ObservableObject
{
    [ObservableProperty]
    private string _content = string.Empty;

    [ObservableProperty]
    private long _authorId;

    [ObservableProperty]
    private DateTimeOffset _createdAt = DateTimeOffset.UtcNow;
}
