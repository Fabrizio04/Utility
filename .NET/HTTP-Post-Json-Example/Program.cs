using System.Net.Http.Headers;
using System.Text;

string method = "";

if (args.Length > 0)
    method = args[0];
else
    Environment.Exit(0);

switch (method)
{

    case "GET": await DoGet(); break;

    case "POST": await DoPost(); break;

    default: Console.WriteLine("Method not found."); break;
}

//HTTP functions

async Task DoGet()
{
    try
    {
        
        var client = new HttpClient();

        var response = await client.GetAsync("http://192.168.1.45:8080/doget");

        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        // Above three lines can be replaced with new helper method below
        // string responseBody = await client.GetStringAsync(uri);

        Console.WriteLine(responseBody);
    }

    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

async Task DoPost()
{
    string content = File.ReadAllText(@"input.json");
    var data = new StringContent(content, Encoding.UTF8, "application/json");

    data.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    data.Headers.ContentLength = content.Length;

    // Console.WriteLine(data.ReadAsStringAsync().Result);
    // return;

    try
    {

        var client = new HttpClient();
        var response = await client.PostAsync("http://192.168.1.45:8080/dopost", data);

        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        // Above three lines can be replaced with new helper method below
        // string responseBody = await client.GetStringAsync(uri);

        Console.WriteLine(responseBody);
    }

    catch(Exception e)
    {
        //var a = e;
        Console.WriteLine(e.Message);
    }
}
