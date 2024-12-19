using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TodoListAppMVVM.Models;

namespace TodoListAppMVVM.ViewModels;

public class TaskViewModel : INotifyPropertyChanged
{
    private string _newTaskTitle = string.Empty;
    public string NewTaskTitle
    {
        get => _newTaskTitle;
        set
        {
            _newTaskTitle = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();

    public void AddTask(string newTaskTitle)
    {
        if (!string.IsNullOrWhiteSpace(newTaskTitle))
        {
            Tasks.Add(new TaskItem { Title = newTaskTitle });
            //NewTaskTitle = string.Empty;
        }
    }

    public void RemoveTask(TaskItem task)
    {
        if (Tasks.Contains(task))
        {
            Tasks.Remove(task);
        }
    }

    public void ToggleTaskCompletion(TaskItem task)
    {
        task.IsCompleted = !task.IsCompleted;
        OnPropertyChanged(nameof(Tasks));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}