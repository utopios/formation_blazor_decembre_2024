namespace FormationBlazor.Services;

public class GreetingService : IGreetingService
{
    public string SayHello(string name)
    {
        return "Hello " + name;
    }
}