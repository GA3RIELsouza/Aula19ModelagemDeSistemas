using System.Text.Json;
using System.Text.Json.Serialization;

var token = "SEU_TOKEN_AQUI";

using var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);
httpClient.DefaultRequestHeaders.Add("User-Agent", "C#");

var response01 = await httpClient.GetAsync("https://api.github.com/user");
var response01Dto = JsonSerializer.Deserialize<GitHubUserDto>(await response01.Content.ReadAsStringAsync()) ?? throw new Exception("Problemas com a resposta da API");

Console.WriteLine("----------------------");

Console.WriteLine($"""
    - DADOS DO USUÁRIO AUTENTICADO
    ----------------------
    ID: {response01Dto.Id}
    Login: {response01Dto.Login}
    Nome: {response01Dto.Name}
    Bio: {response01Dto.Bio}
    Perfil: {response01Dto.HtmlUrl}
    """);

Console.WriteLine("----------------------");

var nomeUsuario = "GA3RIELsouza";
var response02 = await httpClient.GetAsync($"https://api.github.com/users/{nomeUsuario}");
var response02Dto = JsonSerializer.Deserialize<GitHubUserDto>(await response02.Content.ReadAsStringAsync()) ?? throw new Exception("Problemas com a resposta da API");

Console.WriteLine($"""
    - DADOS DO USUÁRIO {nomeUsuario}
    ----------------------
    ID: {response02Dto.Id}
    Login: {response02Dto.Login}
    Nome: {response02Dto.Name}
    Bio: {response02Dto.Bio}
    Perfil: {response02Dto.HtmlUrl}
    """);

Console.WriteLine("----------------------");

var response03 = await httpClient.GetAsync($"https://api.github.com/users");
var response03Dto = JsonSerializer.Deserialize<List<GitHubUserDto>>(await response03.Content.ReadAsStringAsync()) ?? throw new Exception("Problemas com a resposta da API");

Console.WriteLine("- DADOS DOS PRIMEIROS USUÁRIOS DO GITHUB");
foreach (var user in response03Dto)
{
    Console.WriteLine($"""
    ----------------------
    ID: {user.Id}
    Login: {user.Login}
    Perfil: {user.HtmlUrl}
    """);
}

public class GitHubUserDto
{
    [JsonPropertyName("login")]
    public string Login { get; set; } = String.Empty;

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; set; } = String.Empty;

    [JsonPropertyName("avatar_url")]
    public string AvatarUrl { get; set; } = String.Empty;

    [JsonPropertyName("gravatar_id")]
    public string GravatarId { get; set; } = String.Empty;

    [JsonPropertyName("url")]
    public string Url { get; set; } = String.Empty;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; set; } = String.Empty;

    [JsonPropertyName("followers_url")]
    public string FollowersUrl { get; set; } = String.Empty;

    [JsonPropertyName("following_url")]
    public string FollowingUrl { get; set; } = String.Empty;

    [JsonPropertyName("gists_url")]
    public string GistsUrl { get; set; } = String.Empty;

    [JsonPropertyName("starred_url")]
    public string StarredUrl { get; set; } = String.Empty;

    [JsonPropertyName("subscriptions_url")]
    public string SubscriptionsUrl { get; set; } = String.Empty;

    [JsonPropertyName("organizations_url")]
    public string OrganizationsUrl { get; set; } = String.Empty;

    [JsonPropertyName("repos_url")]
    public string ReposUrl { get; set; } = String.Empty;

    [JsonPropertyName("events_url")]
    public string EventsUrl { get; set; } = String.Empty;

    [JsonPropertyName("received_events_url")]
    public string ReceivedEventsUrl { get; set; } = String.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("user_view_type")]
    public string UserViewType { get; set; } = String.Empty;

    [JsonPropertyName("site_admin")]
    public bool SiteAdmin { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = String.Empty;

    [JsonPropertyName("company")]
    public string Company { get; set; } = String.Empty;

    [JsonPropertyName("blog")]
    public string Blog { get; set; } = String.Empty;

    [JsonPropertyName("location")]
    public string Location { get; set; } = String.Empty;

    [JsonPropertyName("email")]
    public string Email { get; set; } = String.Empty;

    [JsonPropertyName("hireable")]
    public bool? Hireable { get; set; }

    [JsonPropertyName("bio")]
    public string Bio { get; set; } = String.Empty;

    [JsonPropertyName("twitter_username")]
    public string TwitterUsername { get; set; } = String.Empty;

    [JsonPropertyName("notification_email")]
    public string NotificationEmail { get; set; } = String.Empty;

    [JsonPropertyName("public_repos")]
    public int PublicRepos { get; set; }

    [JsonPropertyName("public_gists")]
    public int PublicGists { get; set; }

    [JsonPropertyName("followers")]
    public int Followers { get; set; }

    [JsonPropertyName("following")]
    public int Following { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
