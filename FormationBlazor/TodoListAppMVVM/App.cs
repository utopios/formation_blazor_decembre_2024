using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using TodoListAppMVVM.Models;
using TodoListAppMVVM.Services;

namespace TodoListAppMVVM;

public partial class App
{
    [Inject]
    public TaskState TaskState { get; set; }
    [Inject]
    public HubConnection HubConnection { get; set; }
    protected override async Task OnInitializedAsync()
    {
        HubConnection.On<TaskItem>("TaskAdded", task => TaskState.AddTask(task.Title));

        //Autre ecouteur
        await HubConnection.StartAsync();
        
    }
}