# Combat Arms Decrypt and Encrypt TXT Files

A Windows Forms application for encrypting and decrypting text files using the TwoFish algorithm. Developed by Olívio Rodrigues.

## Table of Contents
- [Features](#features)
- [Requirements](#requirements)
- [Installation Guide](#installation-guide)
- [How to Run](#how-to-run)
- [Usage](#usage)
- [Troubleshooting](#troubleshooting)

## Features

- ✅ Encrypt and decrypt TXT files using TwoFish algorithm
- ✅ Batch decryption of multiple files
- ✅ User-friendly graphical interface
- ✅ Progress bar for operations
- ✅ View decrypted content before saving
- ✅ Detailed operation logs

## Requirements

- Windows 10 or Windows 11
- .NET 6.0 Runtime (the application will guide you to install it)
- At least 100MB of free disk space

## Installation Guide

### Step 1: Check if .NET is installed

1. Press `Windows + R` on your keyboard
2. Type `cmd` and press Enter
3. In the black window that opens, type:
   ```
   dotnet --version
   ```
4. Press Enter

**If you see a version number** (like 6.0.0 or higher), skip to [How to Run](#how-to-run).

**If you see an error message**, continue with Step 2.

### Step 2: Download and Install .NET 6.0

1. Open your web browser
2. Go to: https://dotnet.microsoft.com/download/dotnet/6.0
3. Look for ".NET Desktop Runtime 6.0" section
4. Click on "x64" under Windows (for 64-bit systems)
5. Save the file (it will be named something like `windowsdesktop-runtime-6.0.xx-win-x64.exe`)
6. Double-click the downloaded file
7. Click "Install" and wait for completion
8. Click "Close" when finished

### Step 3: Verify Installation

1. Close and reopen Command Prompt (Windows + R, type `cmd`, Enter)
2. Type `dotnet --version` and press Enter
3. You should now see the version number

## How to Run

### Option 1: Using the Pre-built Executable (Easiest)

1. Navigate to the folder: `TwoFishCrypto\bin\Release\net6.0-windows\win-x64\`
2. Double-click on `TwoFishCrypto.exe`
3. The application will start!

### Option 2: Building from Source Code

1. **Install Visual Studio Community 2022** (Free)
   - Download from: https://visualstudio.microsoft.com/downloads/
   - During installation, check "Desktop development with .NET"
   - Wait for installation (this may take 20-30 minutes)

2. **Open the Project**
   - Start Visual Studio 2022
   - Click "Open a project or solution"
   - Navigate to the TwoFishCrypto folder
   - Select `TwoFishCrypto.csproj` and click "Open"

3. **Build and Run**
   - Press `F5` on your keyboard, or
   - Click the green "Start" button at the top
   - The application will build and start automatically

### Option 3: Using Command Line

1. Open Command Prompt as Administrator
2. Navigate to the project folder:
   ```
   cd C:\path\to\TwoFishCrypto
   ```
3. Build the project:
   ```
   dotnet build -c Release
   ```
4. Run the application:
   ```
   dotnet run
   ```

## Usage

### Main Window

1. **Select a File**: Click "Browse" and choose a .txt file
2. **Enter Encryption Key**: 
   - Use the default key or enter your own
   - Key must be exactly 64 hexadecimal characters
3. **Enter IV (Optional)**:
   - Use the default IV or enter your own
   - IV must be exactly 32 hexadecimal characters
4. **Choose Operation**:
   - Click "Encrypt" to encrypt the file
   - Click "Decrypt" to decrypt the file

### Batch Decryption

1. Click "Batch Decrypt" button
2. Select source folder containing encrypted files
3. Select destination folder for decrypted files
4. Click "Start Decryption"

### Important Notes

- Only .txt files are supported
- Keep your encryption key safe - you'll need it to decrypt files
- Encrypted files are saved with "_encrypted" suffix
- Original files are not modified

## Troubleshooting

### "The application cannot start"
- Make sure .NET 6.0 Desktop Runtime is installed
- Try running as Administrator (right-click → Run as administrator)

### "dotnet is not recognized as a command"
- .NET is not installed or not in system PATH
- Restart your computer after installing .NET
- Use the pre-built executable instead

### "Access denied" errors
- Make sure you have write permissions in the folder
- Try running the application as Administrator
- Check if the file is not being used by another program

### Building errors in Visual Studio
- Make sure you have ".NET desktop development" workload installed
- Try cleaning the solution: Build → Clean Solution
- Then rebuild: Build → Rebuild Solution

## Default Encryption Values

- **Key**: `620C724A2FF22C975B5A2B9C21430820227B3D2800193AAA4CF3128803AC3ABD`
- **IV**: `56B83E3F68B60F0F29357BED335E5642`

⚠️ **Security Warning**: For real-world use, always generate your own unique keys!

## Support

If you encounter any issues:
1. Check the Troubleshooting section above
2. Make sure you're using Windows 10 or 11
3. Verify .NET 6.0 is properly installed
4. Try running as Administrator

---
Developed by Olívio Rodrigues