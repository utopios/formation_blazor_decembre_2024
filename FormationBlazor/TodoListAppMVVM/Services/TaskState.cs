using System.Collections.ObjectModel;
using TodoListAppMVVM.Models;

namespace TodoListAppMVVM.Services;

public class TaskState
{
    public ObservableCollection<TaskItem> Tasks { get; private set; } = new ObservableCollection<TaskItem>();

    public event Action OnChange;

    public void AddTask(string title)
    {
        if (!string.IsNullOrWhiteSpace(title))
        {
            Tasks.Add(new TaskItem { Title = title });
            NotifyStateChanged();
        }
    }

    public void RemoveTask(TaskItem task)
    {
        if (Tasks.Contains(task))
        {
            Tasks.Remove(task);
            NotifyStateChanged();
        }
    }

    public void ToggleTaskCompletion(TaskItem task)
    {
        task.IsCompleted = !task.IsCompleted;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}