# Network-Printer-Silent-Install
## Piccolo script in CMD, per installare una stampante di rete su Windows in modo semplice e veloce.

### Configurazione Variabili

Indirizzo ip / Host di una condivisione smb

```bash
shareIP=192.168.1.10
```

Percorso di una cartella condivisa

```bash
sharePath=\\server\condivisione
```

Lettera per la creazione unità

```bash
shareLetter=A-Z
```

Nome utente connessione smb

```bash
shareUsername=dominio\utente
```

Password connessione smb

```bash
sharePassword=myPassword
```

Verifica ping unità remota

```bash
sharePingCheck=true|false
```

Percorso del file dell'informazione di installazione del driver all'interno della share

```bash
infPath=path\to\my\driver\folder\oemsetup.inf
```

Nome del driver da installare contenuto nell'informazione di installazione

```bash
driverName=DRIVER NAME
```

Indirizzo ip / Host stampante

```bash
ipAddress=192.168.1.11
```

Nome della porta virtuale della stampante
(In caso questa porta sia esistente, verrà mostrato un avviso di errore)

```bash
portName=192.168.1.11_TCP_IP
```

Nome della stampante Windows
(In caso questo nome sia esistente, verrà mostrato un avviso di errore)

```bash
printName=Nome stampante
```

Architettura del driver da installare

```bash
architecture=x86|x64
```

### Procedura

Scaricare lo script, quindi impostare i parametri nelle variabili correttamente per le stampanti di rete da installare.<br>
Eseguire lo script con un doppio click, oppure richiamandolo.<br>
Per l'installazione del driver nel sistema, sono necessari i privilegi di amministratore.

È possibile inoltre dopo l'aggiunta della nuova stampante, impostarla subito come predefinita.<br>
Per farlo, specificare il parametro /d come di seguito:

```bash
Network-Printer-Silent-Install.bat /d
```
