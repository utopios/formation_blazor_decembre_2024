using CorrectionExercice1.Services;
using Microsoft.AspNetCore.Components;

namespace CorrectionExercice1.Components;

public partial class CorrectPrice
{
    [Inject]
    public RandomService RandomService { get; set; }
    private int Price { get; set; }
    private int? _hidePrice;

    // public CorrectPrice()
    // {
    //     
    // }
    
    // public CorrectPrice(RandomService randomService)
    // {
    //     _randomService = randomService;
    //     _hidePrice = _randomService.GetRandom();
    // }
    private string? Message { get; set; }

    private void CheckPrice()
    {
        if (!_hidePrice.HasValue)
            _hidePrice = RandomService.GetRandom();
        if (Price < _hidePrice)
        {
            Message = "Plus";
        } else if (Price > _hidePrice)
        {
            Message = "Moins";
        }
        else
        {
            Message = "Correct";
        }
    } 
}