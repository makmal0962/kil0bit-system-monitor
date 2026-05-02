using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace Kil0bitSystemMonitor.Services
{
    public static class StartupService
    {
        private const string AppName = "Kil0bitSystemMonitor";
        private const string RunKey = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private const string TaskName = "Kil0bit System Monitor";

        public static void SetStartup(bool enable)
        {
            if (enable)
                EnableViaTaskScheduler();
            else
                Disable();
        }

        private static void EnableViaTaskScheduler()
        {
            try
            {
                string appPath = ProcessPath ?? "";
                if (string.IsNullOrEmpty(appPath)) return;

                // Delete stale registry entry if present
                try
                {
                    using var key = Registry.CurrentUser.OpenSubKey(RunKey, true)!;
                    key.DeleteValue(AppName, false);
                }
                catch { }

                // schtasks XML-less creation: elevated, at-logon, no UAC prompt
                string args = $"/create /f /tn \"{TaskName}\" /sc ONLOGON /rl HIGHEST " +
                              $"/tr \"\\\"{appPath}\\\" --startup\" /delay 0000:30";

                using var p = new Process();
                p.StartInfo.FileName = "schtasks.exe";
                p.StartInfo.Arguments = args;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.Start();
                p.WaitForExit(5000);

                // If schtasks failed for any reason, fall back to registry
                if (p.ExitCode != 0) EnableViaRegistry(appPath);
            }
            catch
            {
                EnableViaRegistry(ProcessPath ?? "");
            }
        }

        private static void EnableViaRegistry(string appPath)
        {
            try
            {
                if (string.IsNullOrEmpty(appPath)) return;
                using var key = Registry.CurrentUser.OpenSubKey(RunKey, true)!;
                key.SetValue(AppName, $"\"{appPath}\" --startup");
            }
            catch { }
        }

        private static void Disable()
        {
            // Remove Task Scheduler task
            try
            {
                using var p = new Process();
                p.StartInfo.FileName = "schtasks.exe";
                p.StartInfo.Arguments = $"/delete /f /tn \"{TaskName}\"";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.WaitForExit(5000);
            }
            catch { }

            // Also clean up registry in case old entry exists
            try
            {
                using var key = Registry.CurrentUser.OpenSubKey(RunKey, true)!;
                key.DeleteValue(AppName, false);
            }
            catch { }
        }

        private static string? ProcessPath => Process.GetCurrentProcess().MainModule?.FileName;
    }
}