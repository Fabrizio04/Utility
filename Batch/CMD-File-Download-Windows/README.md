# CMD-File-Download-Windows
Raccolta di alcuni Script di esempio per il Download diretto di File attraverso CMD su Windows

Strumenti utilizzati:

- [Windows PowerShell](https://docs.microsoft.com/it-it/powershell/scripting/overview)
- [Bitsadmin](https://docs.microsoft.com/it-it/windows-server/administration/windows-commands/bitsadmin)
- [Curl](https://curl.se/)
- [Wget](https://www.gnu.org/software/wget/)

Nota per Windows PowerShell:
È necessario consentire nel sistema l'esecuzione degli script, ad esempio attraverso il comando
```bash
Set-ExecutionPolicy unrestricted
```
Se in fase di Download attraverso PowerShell, viene restituito un errore sul protocollo SSL/TSL, è possibile correggerlo attraverso queste chiavi nel registro:
```bash
reg add HKLM\SOFTWARE\Microsoft\.NETFramework\v4.0.30319 /v SchUseStrongCrypto /t REG_DWORD /d 1 /reg:64
reg add HKLM\SOFTWARE\Microsoft\.NETFramework\v4.0.30319 /v SchUseStrongCrypto /t REG_DWORD /d 1 /reg:32
```
