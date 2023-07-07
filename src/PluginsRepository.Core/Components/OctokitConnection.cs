using Octokit;
using System.Security.Cryptography;
using System.Text.Json;

namespace PluginsRepository.Core.Components;

public class OctokitConnection : IConnection
{
    private readonly GitHubClient _githubClient = new(new ProductHeaderValue("public-plugins-repository"));

    private const string Organization = "ArchLeaders";
    private const string Repository = "PluginsRepository";
    private const string DataRoot = "data";

    public async Task<Dictionary<Guid, T>> LoadResource<T>() where T : TableItem<T>
    {
        string tableName = $"{typeof(T).Name}Table.json";
        byte[] buffer = await _githubClient.Repository.Content
            .GetRawContent(Organization, Repository, $"{DataRoot}/{tableName}");
        return JsonSerializer.Deserialize<Dictionary<Guid, T>>(buffer)
            ?? throw new InvalidDataException($"Could not parse '{typeof(T).Name}Table': the deserializer returned null");
    }

    public async Task SaveResource<T>(Dictionary<Guid, T> payload) where T : TableItem<T>
    {
        string tableName = $"{typeof(T).Name}Table.json";
        byte[] buffer = JsonSerializer.SerializeToUtf8Bytes(payload);

        await _githubClient.Repository.Content.UpdateFile(
            Organization, Repository, $"{DataRoot}/{tableName}",
            new UpdateFileRequest($"[`System`] Update {tableName}", Convert.ToBase64String(buffer), Convert.ToHexString(SHA512.HashData(buffer))) {
                Committer = new Committer("System", string.Empty, DateTimeOffset.UtcNow),
                Branch = "master"
            }
        );
    }
}
