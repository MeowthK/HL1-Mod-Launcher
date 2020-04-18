using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net35
{
    class ModFinder
    {
        public static HLMOD[] GetMods
        {
            get
            {
                // get mod directories
                var directories = System.IO.Directory.GetDirectories(System.IO.Directory.GetCurrentDirectory());
                var mods = new List<HLMOD>();
                
                for (int i = 0; i < directories.Length; i++)
                {
                    if (System.IO.File.Exists(directories[i] + "//liblist.gam"))
                    {
                        //game info
                        string modname = System.IO.Path.GetFileName(directories[i]);
                        string name = modname;
                        string version = "Unknown";
                        System.Drawing.Image icon = null;

                        var lines = System.IO.File.ReadAllLines(directories[i] + "//liblist.gam");

                        foreach (var line in lines)
                        {
                            if (name == modname && line.Contains("game"))
                                name = GetToken(line, '\"');

                            if (version == "Unknown" && line.Contains("version"))
                                version = GetToken(line, '\"');
                        }

                        //get icon file (if there's any)
                        if (System.IO.File.Exists(directories[i] + "//game.ico"))
                            icon = System.Drawing.Image.FromFile(directories[i] + "//game.ico");
                        else if (System.IO.File.Exists(directories[i] + "//" + modname + ".ico"))
                            icon = System.Drawing.Image.FromFile(directories[i] + "//" + modname + ".ico");

                        var mod = new HLMOD(name, modname, version, icon);
                        mods.Add(mod);
                    }
                }

                return mods.ToArray();
            }
        }

        public static string GetToken(string line, char encloser)
        {
            int startIndex = line.IndexOf(encloser) + 1;
            int endIndex = line.LastIndexOf(encloser);

            if (startIndex == 0 || endIndex == -1)
                return string.Empty;

            return line.Substring(startIndex, endIndex - startIndex);
        }
    }
}
