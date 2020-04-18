using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Net35
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            string cfgFile = Directory.GetCurrentDirectory() + "//modlauncher//commandlist.cfg";
            Dictionary<string, Category[]> modCats = new Dictionary<string, Category[]>();
            List<Item> modexecs = new List<Item>();
            bool fileExists = false;
            Category[] baseCat = null;

            if (File.Exists(cfgFile))
            {
                fileExists = true;

                string cnt = File.ReadAllText(cfgFile);

                // ignore comments
                while (cnt.Contains("//"))
                {
                    int start = cnt.IndexOf("//");
                    int index = start + 1;
                    while (index < cnt.Length && cnt[index] != '\n')
                        index++;

                    cnt = cnt.Remove(start, index - start);
                }

                try
                {
                    foreach (var snippet in cnt.Split('}'))
                    {
                        var catList = new List<Category>();
                        var strimmed = snippet.Trim();

                        if (strimmed.Length == 0)
                            continue;

                        // get mod name
                        string modname = strimmed.Remove(strimmed.IndexOf('{')).Trim();

                        if (modname.Contains('<'))
                        {
                            Item item = new Item();

                            item.Description = GetSubString(modname, '<', '>').Trim();
                            modname = strimmed.Remove(modname.IndexOf('<')).Trim();
                            item.Name = modname;

                            modexecs.Add(item);
                        }

                        // get category name
                        while (strimmed.Contains('"'))
                        {
                            Category category_o = new Category();

                            string category = GetSubString(strimmed, '"', '"');
                            strimmed = strimmed.Replace('"' + category + '"', "").Trim();
                            category_o.Name = category.Trim();

                            while (strimmed.Contains('[') && (strimmed.IndexOf('[') < strimmed.IndexOf('"') || !strimmed.Contains('"')))
                            {
                                Item item = new Item();

                                string argument = GetSubString(strimmed, '[', ']');
                                strimmed = strimmed.Replace('[' + argument + ']', "");
                                item.Name = argument.Trim();

                                string description = GetSubString(strimmed, '[', ']');
                                strimmed = strimmed.Replace('[' + description + ']', "");
                                item.Description = description.Trim();

                                category_o.AddItem(item);
                            }

                            catList.Add(category_o);
                        }

                        modCats.Add(modname, catList.ToArray());
                    }
                }
                catch
                {
                    MessageBox.Show("commandlist.cfg is malformed.", "File Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (modCats.ContainsKey("all"))
                baseCat = modCats.FirstOrDefault(p => p.Key == "all").Value;

            foreach (var mod in ModFinder.GetMods)
            {
                missingPanel.Dispose();

                var gameinfo = new GameInfo(mod);
                var categoryList = new List<FlatButton>();

                if (fileExists && modCats.ContainsKey(mod.ModFolder))
                {
                    modexecs.ForEach((item) => {
                        if (item.Name == mod.ModFolder)
                        {
                            mod.Executable = item.Description;
                            return;
                        }
                    });

                    Category[] cats = null;

                    try
                    {
                        cats = modCats.FirstOrDefault(p => p.Key == mod.ModFolder).Value;

                        if (cats == null)
                            continue;

                        foreach (var cat in cats)
                        {
                            List<CBArg> args = new List<CBArg>();
                            var fbtn = new FlatButton();
                            fbtn.Text = cat.Name;

                            foreach (var cv in cat.Items)
                            {
                                var arg = new CBArg();
                                arg.Argument = cv.Name;
                                arg.Text = cv.Description;
                                arg.Dock = DockStyle.Top;
                                args.Add(arg);
                            }

                            args.Reverse();
                            fbtn.Panel.Controls.AddRange(args.ToArray());
                            categoryList.Add(fbtn);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Cannot parse commandlist.cfg", "File Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (baseCat != null)
                {
                    foreach (var cat in baseCat)
                    {
                        List<CBArg> args = new List<CBArg>();
                        var fbtn = new FlatButton();
                        fbtn.Text = cat.Name;

                        foreach (var cv in cat.Items)
                        {
                            bool flag = true;

                            categoryList.ForEach((a) =>
                            {
                                if (a.IArguments.FirstOrDefault(p => p.Name == cv.Name) != null)
                                {
                                    flag = false;
                                    return;
                                }
                            });

                            if (flag)
                            //if (categoryList.FirstOrDefault( p => p.IArguments.) == null)
                            {
                                var arg = new CBArg();
                                arg.Argument = cv.Name;
                                arg.Text = cv.Description;
                                arg.Dock = DockStyle.Top;
                                args.Add(arg);
                            }
                        }

                        if (args.Count > 0)
                        {
                            fbtn.Panel.Controls.AddRange(args.ToArray());
                            categoryList.Add(fbtn);
                        }
                    }
                }

                gameinfo.ArgPanels.Tabs = categoryList.ToArray();
                gameinfo.ContainerControl = argContents;
                gameList.Controls.Add(gameinfo);
            }

            btnClose.Click += (o, ev) => { Application.Exit(); };
            btnMaximize.Click += (o, ev) =>
            {
                this.WindowState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
            };

            gamePanel.Paint += PaintSeparatorBar;

            CF.SetCenter(this);
            CF.ScaleAllControl(this.Controls);
            FD.EnableFormDrag(title);

            rtbSearcher.TextChanged += (o, ev) =>
            {
                if (gameList.Controls.Count > 0)
                {
                    foreach (Control mod in gameList.Controls)
                    {
                        if (mod is GameInfo)
                        {
                            var modInf = mod as GameInfo;
                            modInf.Visible = modInf.ModInfo.Name.ToLower().Contains((o as TextBox).Text.ToLower());
                        }
                    }
                }
            };

            if (gameList.Controls.Count > 0 && gameList.Controls[gameList.Controls.Count - 1] is GameInfo)
                (gameList.Controls[gameList.Controls.Count - 1] as GameInfo).PerformClick();

            CBArg.StatChecked += UpdateCommands;
            GameInfo.StatClick += UpdateCommands;

            btnLaunch_NR.Click += (o, ev) =>
            {
                if (GameInfo.SelectedMod != null)
                    HLTools.LaunchMod(GameInfo.SelectedMod.ModInfo, rtbAddParams.Text);
            };

            base.OnLoad(e);
        }

        private void UpdateCommands(object sender, EventArgs e)
        {
            if (GameInfo.SelectedMod != null)
            {
                var gi = GameInfo.SelectedMod.ArgPanels.Tabs;

                string arg = string.Empty;
                foreach (var tab in gi)
                    arg += tab.Arguments;

                rtbAddParams.Text = MergeDupStrings(GetArgs(arg));
            }
        }

        private string MergeDupStrings(string[] a)
        {
            HashSet<string> c = new HashSet<string>();
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

        private string[] GetArgs(string arg)
        {
            List<string> a = new List<string>();

            for (int i = 0; i < arg.Length; i++)
            {
                string b = string.Empty;
                string c = string.Empty;

                while (i < arg.Length)
                {
                    if (i + 1 < arg.Length && (arg[i + 1] == '-' || arg[i + 1] == '+'))
                        break;

                    b += arg[i++];
                }

                b = b.Trim();

                if (b.Length > 0)
                    a.Add(b);
            }

            return a.ToArray();
        }

        private string SeekUntil(ref int pos, string stream, char qualifier)
        {
            while (pos < stream.Length)
            {
                if (stream[pos] == qualifier)
                    return stream.Remove(pos);

                pos++;
            }

            return null;
        }

        private string GetSubString(string input, char startSeparator, char endSeparator)
        {
            int startIndex = input.IndexOf(startSeparator) + 1;
            int endIndex = -1;

            int current = startIndex;
            while (current < input.Length && input[current] != endSeparator)
                current++;

            if (current < input.Length)
                endIndex = current;

            if (startIndex > 0 && endIndex != -1)
                return input.Substring(startIndex, endIndex - startIndex);

            return string.Empty;
        }

        private void PaintSeparatorBar(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(23, 25, 27), 2f))
                e.Graphics.DrawLine(pen, gamePanel.Width - 2, 0, gamePanel.Width - 2, gamePanel.Height);
        }
    }
}
