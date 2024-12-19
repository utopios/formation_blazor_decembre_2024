using Microsoft.AspNetCore.Components;
using TodoListAppMVVM.ViewModels;

namespace TodoListAppMVVM.Views;

public partial class TaskView
{
    [Inject]
    public TaskViewModel ViewModel { get; set; }

    protected override Task OnInitializedAsync()
    {
        ViewModel.PropertyChanged += async (sender, e) =>
        {
            await InvokeAsync(StateHasChanged);
        };
        return base.OnInitializedAsync();
    }
}