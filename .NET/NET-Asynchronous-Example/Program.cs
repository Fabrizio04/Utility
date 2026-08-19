Console.WriteLine("Test 1");

var taskLog = LogTest(); // -> Continue to Test 3
//await LogTest(); // -> Await end of method, doesn't continue

Console.WriteLine("Wait 5s...");
Thread.Sleep(5000);
Console.WriteLine("Test 3");

var a = await taskLog; // -> The bool
Console.WriteLine(a);


async Task<bool> LogTest()
{
    // Ex. waiting a Fetch from web site
    await Task.Delay(3000);
    Console.WriteLine("Test 2");
    return true;
}
