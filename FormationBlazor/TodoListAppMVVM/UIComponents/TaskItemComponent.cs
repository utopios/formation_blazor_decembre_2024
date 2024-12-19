using Microsoft.AspNetCore.Components;
using TodoListAppMVVM.Models;
using TodoListAppMVVM.Services;

namespace TodoListAppMVVM.UIComponents;

public partial class TaskItemComponent
{
    [Parameter] public TaskItem Task { get; set; }
    // [Parameter] public EventCallback<TaskItem> OnTaskToggled { get; set; }
    // [Parameter] public EventCallback<TaskItem> OnTaskRemoved { get; set; }
    
    [Inject] public TaskState TaskState { get; set; }

    private void ToggleCompletion()
    {
        TaskState.ToggleTaskCompletion(Task);
    }

    private void RemoveTask()
    {
        TaskState.RemoveTask(Task);
    }
}