var isExpired = false;

void CheckStatus(Object? stateInfo)
{
    isExpired = true;
}

var stateTimer = new Timer(CheckStatus, null, 10000, 0);

while(true)
{
    Console.WriteLine(isExpired);
    Thread.Sleep(1000);
}
