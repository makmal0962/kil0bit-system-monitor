# kil0bit System Monitor — User Guide

> A quick-start guide for using the hardware telemetry overlay.

---

## 📦 Installation

1. Download the latest **`.msi`** installer or the portable **`.exe`** from [Releases](https://github.com/kil0bit-kb/kil0bit-system-monitor/releases).
2. Run the installer (MSI) — it installs per-user with no admin required.
3. Launch **kil0bit System Monitor** from the Start Menu or by running the `.exe` directly.

---

## 🖥️ The Overlay

When enabled, a slim pill-shaped overlay appears directly on your **Windows taskbar** showing live hardware stats:

| Metric | Description |
|--------|-------------|
| **CPU** | Total CPU usage percentage |
| **RAM** | System RAM usage percentage |
| **UP / DN** | Network upload and download speed |
| **GPU** | GPU usage percentage |
| **GPU Temp** | GPU temperature in °C |

### Moving the Overlay
- Click and **drag** the overlay to reposition it along the taskbar.
- Enable **Lock Overlay Position** in Settings (or via right-click menu) to prevent accidental movement.

### Right-Click Menu
Right-clicking the overlay gives you quick access to:
- **Settings** — Open the settings window
- **Task Manager** — Launch Windows Task Manager
- **Lock Position** — Toggle drag lock
- **About** — View app info and links
- **Exit** — Quit the application

---

## ⚙️ Settings Window

Open Settings by clicking the system tray icon or right-clicking the overlay.

### GENERAL
| Option | Description |
|--------|-------------|
| Show Hardware Overlay on Taskbar | Toggle the overlay on/off |
| Lock Overlay Position | Prevent the overlay from being dragged |
| Launch on Windows Startup | Auto-start with Windows via registry |

### MONITOR CONTENT
Toggle which metrics are visible on the overlay:
- CPU Usage, RAM Usage, GPU Usage
- Upload Speed, Download Speed, GPU Temperature

### HARDWARE CONFIG
- **Network Adapter** — Select which adapter to monitor for upload/download speeds
- **Display Style** — Choose between **Standard**, **Compact**, or **Icon** display modes

### THEME & DESIGN
- **Accent Color** — Choose the color of the text/icons on the overlay
- **Backdrop Color** — Choose the overlay background color (includes a transparent option)
- **Backdrop Opacity** — Drag to adjust how opaque the background pill is (0–100%)
- **Font Family** — Pick the font used in the overlay

---

## 🔔 System Tray

The app lives in the **system tray** (bottom-right of your taskbar) when the Settings window is closed.

- **Left-click** the tray icon → opens Settings
- **Right-click** → shows the quick menu (same options as overlay right-click)

To completely quit the app, click **Exit** in the tray menu or use the red **Quit Application** button in Settings.

> ⚠️ Closing the Settings window with **X** or clicking **Save & Close** does **not** quit the app — it continues running in the tray to keep your overlay active.

---

## 💾 Saving Settings

- Click **Save & Close Settings** — saves all changes and hides the Settings window to tray.
- Settings are automatically saved to your AppData folder and restored on the next launch.

---

## ❓ FAQ

**Q: The overlay isn't showing up on the taskbar.**  
A: Make sure "Show Hardware Overlay on Taskbar" is toggled **ON** in the GENERAL section of Settings.

**Q: The GPU usage shows 0% or is missing.**  
A: GPU monitoring requires an **NVIDIA GPU**. AMD/Intel GPU usage is not yet supported.

**Q: My network speed is not showing correctly.**  
A: Go to Settings → HARDWARE CONFIG and select the correct **Network Adapter** from the dropdown.

**Q: How do I uninstall?**  
A: Use **Settings → Apps** in Windows and search for "kil0bit System Monitor", then click Uninstall.

---

## 🌐 Links

| | |
|---|---|
| 📺 YouTube | [@kilObit](https://www.youtube.com/@kilObit) |
| ✍️ Blog | [kil0bit.blogspot.com](https://kil0bit.blogspot.com/) |
| 🐙 GitHub | [kil0bit-kb](https://github.com/kil0bit-kb) |
| ❤️ Support | [Patreon](https://www.patreon.com/cw/KB_kilObit) |

---

*Built with ❤️ by KB - kil0bit*
