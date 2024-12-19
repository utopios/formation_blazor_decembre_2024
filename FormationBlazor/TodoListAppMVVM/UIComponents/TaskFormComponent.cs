using Microsoft.AspNetCore.Components;

namespace TodoListAppMVVM.UIComponents;

public partial class TaskFormComponent
{
    [Parameter] public EventCallback<string> OnTaskAdded { get; set; }
    private string newTaskTitle;

    private void AddTask()
    {
        if (!string.IsNullOrWhiteSpace(newTaskTitle))
        {
            OnTaskAdded.InvokeAsync(newTaskTitle);
            newTaskTitle = string.Empty;
            StateHasChanged();
        }
    }
}