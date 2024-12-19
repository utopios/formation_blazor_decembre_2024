using Microsoft.AspNetCore.Components;
using TodoListAppMVVM.Services;

namespace TodoListAppMVVM.UIComponents;

public partial class TaskFormComponent
{
    [Parameter] public EventCallback<string> OnTaskAdded { get; set; }
    [Inject] public TaskState TaskState { get; set; }
    
    private string newTaskTitle;

    private void AddTask()
    {
        if (!string.IsNullOrWhiteSpace(newTaskTitle))
        {
            TaskState.AddTask(newTaskTitle);
            newTaskTitle = string.Empty;
        }
    }
}