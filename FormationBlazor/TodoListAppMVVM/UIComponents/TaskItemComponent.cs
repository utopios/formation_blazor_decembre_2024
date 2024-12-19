using Microsoft.AspNetCore.Components;
using TodoListAppMVVM.Models;

namespace TodoListAppMVVM.UIComponents;

public partial class TaskItemComponent
{
    [Parameter] public TaskItem Task { get; set; }
    [Parameter] public EventCallback<TaskItem> OnTaskToggled { get; set; }
    [Parameter] public EventCallback<TaskItem> OnTaskRemoved { get; set; }

    private void ToggleCompletion()
    {
        OnTaskToggled.InvokeAsync(Task);
    }

    private void RemoveTask()
    {
        OnTaskRemoved.InvokeAsync(Task);
    }
}