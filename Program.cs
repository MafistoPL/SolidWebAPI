﻿var dbConnector = new DbConnector();
var webServiceConnector = new WebServiceConnector();

Console.WriteLine("Starting fetching data...");

var dbTask = dbConnector.GetResultAsync();
var wsTask = webServiceConnector.GetResultAsync();

var results = await Task.WhenAll(dbTask, wsTask);

Console.WriteLine("Fetching data completed");
Console.WriteLine(results.Sum(x => x.Value));

// C# 1.0 Begin/Invoke
// C# events: += args => { ... }
// C# async/await

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
