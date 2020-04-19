using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Net35
{
    class ModFinder
    {
        public static HLMOD[] GetMods
        {
            get
            {
                // get mod directories
                var directories = System.IO.Directory.GetDirectories(Directory.GetCurrentDirectory());
                var mods = new List<HLMOD>();
                string[] gch = { "gameinfo.txt", "liblist.gam" };
                string[] efl = { "maps", "models", "sound" };
                Dictionary<string, string> modmap = new Dictionary<string, string>()
                {
                    // GoldSrc Mods
                    { "cstrike", "Counter-Strike" },
                    { "valve", "Half-Life" },
                    { "tfc", "Team Fortress Classic" },
                    { "ricochet", "Ricochet" },
                    { "czero", "Condition Zero" },
                    { "bshift", "Blue Shift" },
                    { "dmc", "Deathmatch Classic" },
                    { "op4classic", "Opposing Force" },

                    // Source Mods
                    { "hl1", "Half-Life Source" },
                    { "hl2", "Half-Life 2" },
                    { "tf2", "Team Fortress 2" },
                    { "portal", "Portal" }
                };

                for (int i = 0; i < directories.Length; i++)
                {
                    int gchi = -1;
                    string dir = string.Empty;

                    for (int j = 0; j < gch.Length; j++)
                        if (File.Exists(directories[i] + "\\" + gch[j]))
                            gchi = j;

                    if (gchi == -1)
                    {
                        string[] dirs = Directory.GetDirectories(directories[i]);

                        for (int j = 0; j < dirs.Length; j++)
                            dirs[j] = Path.GetFileName(dirs[j]);

                        bool flag = false;

                        foreach (var ef in efl)
                        {
                            if (!dirs.Contains(ef))
                            {
                                flag = true;
                                break;
                            }
                        }

                        if (flag)
                            continue;
                    }
                    else
                        dir = directories[i] + "\\" + gch[gchi];

                    //game info
                    string modname = Path.GetFileName(directories[i]);
                    string name = modname;
                    string version = "Unknown";
                    System.Drawing.Image icon = null;

                    if (dir != string.Empty)
                    {
                        var lines = File.ReadAllLines(dir);

                        foreach (var line in lines)
                        {
                            if (name == modname && line.Contains("game"))
                                name = GetToken(line, '\"');

                            if (version == "Unknown" && line.Contains("version"))
                                version = GetToken(line, '\"');
                        }
                    }
                    else
                    {
                        foreach (var mm in modmap)
                        {
                            if (mm.Key == modname)
                            {
                                name = mm.Value;
                                break;
                            }
                        }
                    }

                    //get icon file (if there's any)
                    if (File.Exists(directories[i] + "\\game.ico"))
                        icon = System.Drawing.Image.FromFile(directories[i] + "\\game.ico");
                    else if (File.Exists(directories[i] + "\\" + modname + ".ico"))
                        icon = System.Drawing.Image.FromFile(directories[i] + "\\" + modname + ".ico");
                    else if (File.Exists(directories[i] + "\\resource//game.ico"))
                        icon = System.Drawing.Image.FromFile((directories[i] + "\\resource\\game.ico"));
                    else
                    {
                        foreach (string file in Directory.GetFiles(directories[i]))
                        {
                            if (file.EndsWith(".ico"))
                            {
                                icon = System.Drawing.Image.FromFile(file);
                                break;
                            }
                        }
                    }

                    var mod = new HLMOD(name, modname, version, string.Empty, icon);
                    mods.Add(mod);
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
