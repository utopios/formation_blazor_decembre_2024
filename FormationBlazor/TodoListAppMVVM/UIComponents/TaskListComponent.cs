using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Components;
using TodoListAppMVVM.Models;
using TodoListAppMVVM.Services;

namespace TodoListAppMVVM.UIComponents;

public partial class TaskListComponent
{
    // [Parameter] public ObservableCollection<TaskItem> Tasks { get; set; }
    // [Parameter] public EventCallback<TaskItem> OnTaskToggled { get; set; }
    // [Parameter] public EventCallback<TaskItem> OnTaskRemoved { get; set; }
    
    [Inject] public TaskState TaskState { get; set; }

    protected override void OnInitialized()
    {
        TaskState.OnChange += () => { InvokeAsync(() => StateHasChanged()); };
    }
}