using System.Net.Http.Json;
using CorrectionExercice3.DTOs;

namespace CorrectionExercice3.Services.Impl;

public class ProductApiService : IProductApiService
{
    private readonly HttpClient _httpClient;
    private string baseURL = "https://world.openfoodfacts.org/api/v2/";
    public ProductApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(baseURL);
    }

    public async Task<FoodFacts?> Get(string code)
    {
        return await _httpClient.GetFromJsonAsync<FoodFacts>($"product/{code}.json");
    }
}