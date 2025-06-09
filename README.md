# Command Runner

A Windows utility to repeatedly execute a specified command-line command at a set time interval.

![Screenshot](screenshot.png)

## Features
- System tray icon with Start, Stop, Settings, and Exit options
- Settings window for command, interval, and log display
- Hidden command execution with output/error logging
- State persistence for command and interval

## Folder Structure
- `UI/` — All user interface code (forms, tray icon)
- `Core/` — Core logic (command execution)
- `Properties/` — Application settings

## Build & Run

1. **Open in Visual Studio 2022+**
   - Open `CommandRunner.sln` (if present) or the `command-runner` folder as a project.
2. **Build**
   - Press `Ctrl+Shift+B` or use the Build menu.
3. **Run**
   - Press `F5` (with debugger) or `Ctrl+F5` (without debugger).

## Usage
- Right-click the tray icon for Start, Stop, Settings, Exit.
- Left-click the tray icon to open Settings.
- Enter your command and interval, then Start.
- Logs are shown in the main window and can be cleared.

---

**Requirements:**
- .NET 8.0+ ([Download](https://dotnet.microsoft.com/download))

## Contributing
Pull requests are welcome! For major changes, please open an issue first to discuss what you would like to change.

## License
![License](LICENSE)

## Author

[rennnenen on GitHub](https://github.com/rennnenen) 
