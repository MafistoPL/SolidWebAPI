var service = new DataService();
var result = await service.GetDataAsync();

Console.WriteLine(result);

// C# 1.0 Begin/Invoke
// C# events: += args => { ... }
// C# async/await

public class DataService
{
    private readonly WebServiceConnector _wsConnector = new();

    public Task<Result> GetDataAsync()
        => _wsConnector.GetResultAsync();
}

public class DbConnector
{
    public async Task<Result> GetResultAsync()
    {
        Console.WriteLine("Starting processing DB...");
        await Task.Delay(5_000);
        Console.WriteLine("Finished processing DB...");

        return new Result(1);
    }
}

public class WebServiceConnector
{
    public async Task<Result> GetResultAsync()
    {
        Console.WriteLine("Starting processing WS...");
        Thread.Sleep(3_000);
        Console.WriteLine("Finished processing WS...");

        return new Result(3);
    }
}

public record Result(int Value);
