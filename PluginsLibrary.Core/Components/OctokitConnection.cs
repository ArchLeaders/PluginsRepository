using Octokit;

namespace PluginsRepository.Core.Components;

public class OctokitConnection : IConnection
{
    private readonly HttpClient _client = new();
    private readonly GitHubClient _githubClient = new(new ProductHeaderValue("public-plugins-repository"));

    private const string Organization = "ArchLeaders";
    private const string Repository = "PluginsRepository";

    /// <summary>
    /// Looks 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Dictionary<Guid, T> GetResource<T>() where T : TableItem<T>
    {
        throw new NotImplementedException();
    }
}
