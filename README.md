# 🚀 Disable Hyper-V Extreme

> Powerful tool to **enable / disable VBS & Hyper-V** easily on Windows
> ⚡ Built with C# | 💻 CLI UI | 🔒 Admin-level control

---

## ✨ Features

* 🔄 Toggle **Virtualization-Based Security (VBS)**
* ⚙️ Enable / Disable **Hyper-V**
* 📦 Embedded **DG Readiness Tool (Microsoft)**
* 🧠 Clean & minimal CLI interface
* 🛡️ Requires Administrator privileges
* ⚡ Fast & lightweight (single EXE)

---

## 📸 Preview

```
╔══════════════════════════════════════╗
║   Disable Hyper-V Extreme Tool       ║
║            by axiverse               ║
╚══════════════════════════════════════╝

[1] Disable VBS / Hyper-V
[2] Enable VBS / Hyper-V
[3] Exit
```

---

## 🛠️ Usage

1. Run the program as **Administrator**
2. Choose an option:

   * `1` → Disable VBS / Hyper-V
   * `2` → Enable VBS / Hyper-V
3. Restart your PC after execution

---

## ⚠️ Important Notes

* 🔁 **Restart is required** after changes
* 🧪 Disabling VBS may improve compatibility with:

  * VMware
  * VirtualBox
* 🔒 Enabling VBS increases system security

---

## 📦 Build

### Requirements

* .NET 8 SDK

### Build command:

```
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
```

---

## 📁 Project Structure

```
/DisableHyper-V-Extreme
 ├── Program.cs
 ├── DG_Readiness_Tool_v3.6.ps1 (embedded)
 ├── app.manifest
 └── README.md
```

---

## 🧠 How it works

* Uses Microsoft **DG Readiness Tool**
* Executes PowerShell internally
* Applies system-level changes:

  * Device Guard
  * Credential Guard
  * Hypervisor settings

---

## ⚖️ Disclaimer

This tool modifies system-level security settings.

> Use at your own risk.
> Make sure you understand what VBS / Hyper-V does before using.

---

## 👨‍💻 Author

**axiverse**

---

## ⭐ Support

If you find this useful:

* ⭐ Star the repo
* 🍴 Fork it
* 💬 Share feedback

---
