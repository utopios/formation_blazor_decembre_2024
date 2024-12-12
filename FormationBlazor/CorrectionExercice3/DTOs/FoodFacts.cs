using System.Text.Json.Serialization;

namespace CorrectionExercice3.DTOs;

public class FoodFacts
{
    [JsonPropertyName("code")]
    public string Code { get; set; }
    
    [JsonPropertyName("product")]
    public Product Product { get; set; }
}