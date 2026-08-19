# TLC-VLC-RTSP
## Piccolo script in Batch, per lanciare la riproduzione Live (RTSP) di 2 IP camere posizionando le finestre

1. Creare 2 collegamenti (.lnk) per aprire i flussi video con VLC, esempio

```
"C:\Program Files\VideoLAN\VLC\vlc.exe" rtsp://username:password@ip_address:554/path/to_stream/channel
```

2. Scaricare Cmdow https://ritchielawrence.github.io/cmdow/

3. Inserire il file index.bat nella cartella Release

4. Aprire i monitor con vlc e posizionare le finestre nei punti desiderati

5. Attraverso Cmdow, ricavare la posizione delle finestre dei vlc (cmdow /t /p)

6. Inserire le posizioni corrette nel file index.bat

7. Lanciare lo script
