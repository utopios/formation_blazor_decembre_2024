namespace FormationBlazor.Components.Services;

public class SharedService
{
    public event Action<string> NotifyMessage;
    public string Message {
        set
        {
                NotifyMessage.Invoke(value);
        }
    }
    
    
}