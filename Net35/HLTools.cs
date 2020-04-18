using System;
using System.Diagnostics;

namespace Net35
{
    public static class HLTools
    {
        public static bool CheckHLExists()
        {
            return System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "//hl.exe");
        }

        public static void LaunchMod(HLMOD mod, string arguments)
        {
            if (CheckHLExists())
            {
                using (var process = new Process())
                {
                    process.StartInfo.WorkingDirectory = System.IO.Directory.GetCurrentDirectory();
                    process.StartInfo.FileName = "hl.exe";
                    process.StartInfo.Arguments = " -game " + mod.ModFolder + " " + arguments;
                    process.Start();
                }
            }
        }
    }
}
