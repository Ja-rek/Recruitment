using RestSharp;
using System.Text;

namespace Task1.Infrastructure.BilingEntryAllegro;

public class HttpRestClient(string clientId,
    string clientSecret,
    IRestClient client) : IHttpRestClient
{
    private readonly string clientId = clientId;
    private readonly string clientSecret = clientSecret;
    private readonly IRestClient client = client;

    public async Task<BillingEntryAllegroRootDto?> GetBillingEntry(Guid id, int offset, string? token)
    {
        var request = new RestRequest($"/billing/billing-entries?order.id={id}&limit=100&offset={offset}");

        request.AddHeader("Authorization", "Bearer " + token);
        request.AddHeader("Accept", "application/vnd.allegro.public.v1+json");

        return await client.GetAsync<BillingEntryAllegroRootDto>(request);
    }

    public async Task<T?> Post<T>(string url, string content) where T : class
    {
        var request = new RestRequest(url);

        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddParameter("application/x-www-form-urlencoded", content, ParameterType.RequestBody);

        var authHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
        request.AddHeader("Authorization", $"Basic {authHeader}");

        var response = await client.ExecutePostAsync<T>(request);
        return response.Data;
    }
}

