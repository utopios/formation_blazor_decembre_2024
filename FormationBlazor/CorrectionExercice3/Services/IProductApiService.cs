using CorrectionExercice3.DTOs;

namespace CorrectionExercice3.Services;

public interface IProductApiService
{
    public Task<FoodFacts?> Get(string code);
}