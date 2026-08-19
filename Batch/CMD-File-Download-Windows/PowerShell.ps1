$url="https://www.7-zip.org/a/7z1900-x64.exe"
$file=([Environment]::GetFolderPath("Desktop")+"\7z1900-x64.exe")

$mysize=1447178
$username="myusername"
$password="mypassword"

$proxy="http://localhost"
$porta="8080"

$webClient=new-object System.Net.WebClient;

# Basic Auth
# $webClient.Credentials=new-object System.Net.NetworkCredential($username, $password);

# Proxy Auth
# $WebProxy=New-Object System.Net.WebProxy(($proxy+":"+$porta),$true);
# $Credentials=New-Object Net.NetworkCredential($username, $password);
# $Credentials=$Credentials.GetCredential($proxy,$porta, 'KERBEROS');
# $WebProxy.Credentials=$Credentials;
# $webClient.Proxy=$WebProxy;

$webClient.DownloadFile($url, $file);

timeout /t 2

ECHO ""

If (Test-Path -Path $file ) {
	$size=(Get-Item $file).length
	
	if ( $mysize -eq $size ){
		ECHO "Download completato"
	} else {
		ECHO "Errore"
	}
}

pause
exit