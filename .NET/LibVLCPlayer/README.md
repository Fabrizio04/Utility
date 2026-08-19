# LibVLCPlayer
## Piccolo riproduttore di video (locali e remoti), basato su LibVLCSharp

### Funzioni

- Riproduzione file locale
- Riproduzione remota (es. HTTP(S), RTSP)
- Personalizzazione programma/avvio
- Shortcut
  - [J] Indietro
  - [L] Avanti
  - [Spazio] Play/Pausa
  - [Esc] Esci da full screen
  
### Lista parametri

- Titolo finestra
```cmd
/title="Mio Titolo"
```
- Icona programma
```cmd
/ico="C:\mia\icona\favicon.ico"
```

- File / URI
```cmd
/file="C:\mio\file\video.mp4"
```
```cmd
/file="https://dominio.est/path/video.mp4"
```
- Finestra massimizzata all'avvio
```cmd
/maximized
```
- Schermo intero all'avvio
```cmd
/fullscreen
```  
- Finestra centrata all'avvio
```cmd
/center
```

Esempio:
```cmd
LibVLCPlayer.exe /titolo="Player Fabrizio" /fullscreen /file="https://www.w3schools.com/html/mov_bbb.mp4"
```

### Fonti

- [LibVLCSharp](https://github.com/videolan/libvlcsharp)
- [Codesailer](https://codesailer.com/tutorials/simple_video_player/)
