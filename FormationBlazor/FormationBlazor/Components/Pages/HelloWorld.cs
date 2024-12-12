using FormationBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace FormationBlazor.Components.Pages;

public partial class HelloWorld
{
    [Inject]
    private IGreetingService? GreetingService { get; set; }
    [Parameter]
    public string Name { get; set; } = "Default Name";
    
    [Parameter]
    public int Age { get; set; } = 30;

    private string? _inputValue;

    public void ClickDisplay()
    {
        _inputValue = GreetingService.SayHello(Name);
        Console.WriteLine("Click display button");
        StateHasChanged();
        
    }
    
}