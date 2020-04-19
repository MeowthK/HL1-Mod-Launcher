using System;
using System.Diagnostics;

namespace Net35
{
    public static class HLTools
    {
        public static bool CheckExecutableExists(string execFile)
        {
            return System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\" + execFile);
        }

        public static void LaunchMod(HLMOD mod, string arguments)
        {
            bool executableExists = CheckExecutableExists(mod.Executable);
            var filename = "hl.exe";
            var proc_arg = string.Empty;

            if (CheckExecutableExists(mod.Executable))
                filename = mod.Executable;
            else if (CheckExecutableExists("hl.exe"))
            {
                filename = "hl.exe";
                proc_arg = " -game " + mod.ModFolder;
            }
            else if (CheckExecutableExists("hl2.exe")) // test source compat
            {
                filename = "hl2.exe";
                proc_arg = " -game " + mod.ModFolder;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("hl.exe was not found, cannot launch the game.", "Executable Not Found", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            proc_arg += " " + arguments;

            using (var process = new Process())
            {
                process.StartInfo.WorkingDirectory = System.IO.Directory.GetCurrentDirectory();
                process.StartInfo.FileName = filename;
                process.StartInfo.Arguments = proc_arg;
                process.Start();
            }
        }

        public static string MergeDupStrings(string[] a)
        {
            var c = new System.Collections.Generic.HashSet<string>();
            string c_s = string.Empty;

            if (a != null)
            {
                foreach (var a_s in a)
                    c.Add(a_s);
            }

            foreach (var c_ss in c)
                c_s += c_ss + " ";

            return c_s;
        }

        public static string[] GetCFGContents(string modname)
        {
            string cfgRoot = System.IO.Directory.GetCurrentDirectory() + "\\modlauncher\\" + modname + ".cfg";
            string[] retval = null;

            if (System.IO.File.Exists(cfgRoot))
                return System.IO.File.ReadAllLines(cfgRoot);

            return retval;
        }
    }
}
