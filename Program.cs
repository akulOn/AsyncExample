using System.Diagnostics;

var client = new HttpClient();
var stopwatch = new Stopwatch();

stopwatch.Start();

var requests = Enumerable
    .Range(1, 1000)
    .Select(x => Task.Run(async () =>
    {
        var response = await client.GetAsync("http://www.google.com");
        var responseContent = await response.Content.ReadAsStringAsync();
    }));

await Task.WhenAll(requests);

Console.WriteLine($"Zahtevi su gotovi za: {stopwatch.Elapsed.TotalMilliseconds}");

System.Console.WriteLine("Hello!");