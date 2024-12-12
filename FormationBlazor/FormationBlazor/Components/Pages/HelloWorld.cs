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

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }

    // protected override void OnInitialized()
    // {
    //     base.OnInitialized();
    //     Console.WriteLine("Initialisation");
    // }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        Console.WriteLine("OnAfterRender");
    }

    protected override bool ShouldRender()
    {
        Console.WriteLine("Should render");
        return base.ShouldRender();
    }

    protected override async Task OnParametersSetAsync()
    {
        Console.WriteLine("Set parameter");
        await base.OnParametersSetAsync();
    }
}