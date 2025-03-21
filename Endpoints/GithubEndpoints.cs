using REST_API_för_CV_hantering.DTOs.GithubDTOs;
using REST_API_för_CV_hantering.Models;
using System.Text.Json;

namespace REST_API_för_CV_hantering.Endpoints
{
    public class GithubEndpoints
    {
        private static readonly HttpClient httpClient = new();

        public static void RegisterEndpoints(WebApplication app)
        {
            app.MapGet("/github/{username}", async (string username) =>
            {

                if (string.IsNullOrEmpty(username))
                    return Results.BadRequest(new { message = "GitHub username is required and can't be null or empty" });

                try
                {
                    var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://api.github.com/users/{username}/repos");

                    requestMessage.Headers.UserAgent.ParseAdd("Cv-Labb/1.0");

                    var response = await httpClient.SendAsync(requestMessage);

                    if (!response.IsSuccessStatusCode)
                    {
                        return Results.Json(new { message = $"GitHub API returned {response.StatusCode}" }, statusCode: (int)response.StatusCode);
                    }

                    var responseContent = await response.Content.ReadAsStringAsync();
                    var repositories = JsonSerializer.Deserialize<List<GithubRepos>>(responseContent);

                    if (repositories == null || repositories.Count == 0)
                    {
                        return Results.NotFound(new { message = "No repositories found for this username, please try another one." });
                    }

                    var repoDtos = repositories.Select(repo => new GithubReposDTOs
                    {
                        RepositoryName = repo.Name,
                        Language = string.IsNullOrEmpty(repo.Language) ? "unknown" : repo.Language,
                        Description = string.IsNullOrEmpty(repo.Description) ? "missing" : repo.Description,
                        RepositoryLink = repo.HtmlUrl
                    }).ToList();

                    return Results.Ok(repoDtos);

                }
                // Catch exceptions
                catch (JsonException)
                {
                    return Results.BadRequest(new { message = "Failed to parse JSON from GitHub API" });
                }
                catch (HttpRequestException)
                {
                    return Results.Json(new { message = "Failed to connect to GitHub API" }, statusCode: 500);
                }
                catch (Exception)
                {
                    return Results.Json(new { message = "An unexpected error occurred" }, statusCode: 500);
                }

            }).WithName("GetGithubRepositories");
        }
    }
}
