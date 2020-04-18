using System;
using System.Diagnostics;

namespace Net35
{
    public static class HLTools
    {
        public static bool CheckExecutableExists(string execFile)
        {
            return System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "//" + execFile);
        }

        public static void LaunchMod(HLMOD mod, string arguments)
        {
            bool executableExists = CheckExecutableExists(mod.Executable);
            var filename = "hl.exe";
            var proc_arg = string.Empty;

            if (mod.Executable == string.Empty)
            {
                if (!CheckExecutableExists("hl.exe"))
                {
                    System.Windows.Forms.MessageBox.Show("hl.exe was not found, cannot launch the game.", "Executable Not Found", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return;
                }

                proc_arg = " -game " + mod.ModFolder;
            }
            else if (!CheckExecutableExists(mod.Executable))
            {
                System.Windows.Forms.MessageBox.Show(mod.Executable + " was not found and hl.exe is non-existent, cannot launch the game.", "Executable Not Found", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }
            else
                filename = mod.Executable;

            proc_arg += " " + arguments;

            using (var process = new Process())
            {
                process.StartInfo.WorkingDirectory = System.IO.Directory.GetCurrentDirectory();
                process.StartInfo.FileName = filename;
                process.StartInfo.Arguments = proc_arg;
                process.Start();
            }
        }
    }
}
