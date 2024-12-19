using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Components;
using TodoListAppMVVM.Models;

namespace TodoListAppMVVM.UIComponents;

public partial class TaskListComponent
{
    [Parameter] public ObservableCollection<TaskItem> Tasks { get; set; }
    [Parameter] public EventCallback<TaskItem> OnTaskToggled { get; set; }
    [Parameter] public EventCallback<TaskItem> OnTaskRemoved { get; set; }
}