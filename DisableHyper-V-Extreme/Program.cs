using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

class Program
{
    static void Main()
    {
        Console.Title = "Disable Hyper-V Extreme | axiverse";

        Header();

        try
        {
            string tempPath = Path.Combine(Path.GetTempPath(), "DGTool.ps1");
            string resourceName = "DisableHyper_V_Extreme.DG_Readiness_Tool_v3.6.ps1";

            Step("[1/3] Extracting DG Readiness Tool...");
            ExtractResource(resourceName, tempPath);
            Success("Script extracted");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Select option:");
            Console.ResetColor();

            Console.WriteLine("[1] Disable VBS / Hyper-V (Recommended for Panel)");
            Console.WriteLine("[2] Enable VBS / Hyper-V (Not Recommended for Panel)");
            Console.WriteLine("[3] Exit");
            Console.Write("\n> ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Step("[2/3] Disabling VBS...");
                RunCommand("powershell.exe",
                    $"-ExecutionPolicy Bypass -File \"{tempPath}\" -Disable");
                Success("VBS Disabled");
            }
            else if (choice == "2")
            {
                Step("[2/3] Enabling VBS...");
                RunCommand("powershell.exe",
                    $"-ExecutionPolicy Bypass -File \"{tempPath}\" -Enable");
                Success("VBS Enabled");
            }
            else
            {
                Info("Exit selected.");
                return;
            }

            Step("[3/3] Finalizing...");
            Success("Operation completed");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[✔] All tasks completed successfully!");
            Console.ResetColor();

            Console.WriteLine("\n[!] Please restart your PC to apply changes.");
        }
        catch (Exception ex)
        {
            Error(ex.Message);
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void Header()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║   Disable Hyper-V Extreme Tool       ║");
        Console.WriteLine("║            by axiverse               ║");
        Console.WriteLine("╚══════════════════════════════════════╝\n");

        Console.ResetColor();
    }

    static void Step(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("[*] " + message);
        Console.ResetColor();
    }

    static void Success(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[+] " + message);
        Console.ResetColor();
    }

    static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("[X] Error: " + message);
        Console.ResetColor();
    }

    static void Info(string message)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("[i] " + message);
        Console.ResetColor();
    }

    static void RunCommand(string file, string args)
    {
        Process p = new Process();
        p.StartInfo.FileName = file;
        p.StartInfo.Arguments = args;
        p.StartInfo.Verb = "runas"; 
        p.StartInfo.UseShellExecute = true;
        p.Start();
        p.WaitForExit();
    }

    static void ExtractResource(string resourceName, string outputPath)
    {
        var assembly = Assembly.GetExecutingAssembly();

        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        {
            if (stream == null)
                throw new Exception("Resource tidak ditemukan: " + resourceName);

            using (FileStream file = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(file);
            }
        }
    }
}