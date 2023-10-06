namespace PlatzyAPI.Services;

public class HellowWorldServices : IHelloWorldServices
{
    public string GetHelloWorld()
    {
        return "Hello world";
    }
}

public interface IHelloWorldServices
{
    string GetHelloWorld();
}
