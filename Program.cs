var dbConnector = new DbConnector();
var webServiceConnector = new WebServiceConnector();

Console.WriteLine("Starting fetching data...");

var dbResult = dbConnector.GetResult();
var webServiceResult = webServiceConnector.GetResult();

Console.WriteLine("Fetching data completed");

Console.WriteLine(dbResult.Value + webServiceResult.Value);

// C# 1.0 Begin/Invoke
// C# events: += args => { ... }
// C# async/await

public class DbConnector
{
    public Result GetResult()
    {
        Console.WriteLine("Starting processing DB...");
        Thread.Sleep(2_000);
        Console.WriteLine("Finished processing DB...");

        return new Result(1);
    }
}

public class WebServiceConnector
{
    public Result GetResult()
    {
        Console.WriteLine("Starting processing WS...");
        Thread.Sleep(300);
        Console.WriteLine("Starting processing WS...");

        return new Result(3);
    }
}

public record Result(int Value);
