# Text2DragAndDrop (Text → Drag & Drop Datei)

Kleine Windows-Tray-App, die **Text aus der Zwischenablage** in eine **temporäre Datei** schreibt, damit man den Inhalt per **Drag & Drop als Datei** in andere Programme ziehen kann (z. B. Explorer, Outlook, Ticket-Tools, Web-Uploader etc.).

## Was macht die App?

- Läuft als **Tray-Icon** im Infobereich.
- Menüpunkt **„Text to Clippyfile“** öffnet einen Dialog.
- Der Dialog:
  - nimmt den aktuellen **Clipboard-Text**
  - schreibt ihn als Datei nach `%TEMP%\<Dateiname>`
  - startet einen **Drag & Drop**-Vorgang (FileDrop)
  - löscht die Datei **automatisch nach ~10 Sekunden**

## Screens / UI

- Tray-Menü:
  - `Text to Clippyfile`
  - `Exit`
- Dialog:
  - Textfeld für Dateiname
  - Textfeld für Clipboard-Inhalt (vorbelegt)
  - Drag-Icon (PictureBox) zum Ziehen der Datei

## Voraussetzungen

- Windows
- .NET (WinForms).  
  > Je nach Projektdatei/Target: klassisch **.NET Framework** oder **.NET (Windows Desktop)**.

## Build

Falls du eine `.sln/.csproj` hast:

```bash
dotnet build
