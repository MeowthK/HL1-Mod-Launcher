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
            //if (!HLTools.CheckHLExists())
            //{
            //    DialogResult result;

            //    while ((result = MessageBox.Show("hl.exe was not found!", "Warning", MessageBoxButtons.AbortRetryIgnore)) == System.Windows.Forms.DialogResult.Retry)
            //    {
            //        if (HLTools.CheckHLExists())
            //            break;
            //    }

            //    if (result == System.Windows.Forms.DialogResult.Abort)
            //        Application.Exit();
            //}

            string cfgFile = Directory.GetCurrentDirectory() + "//modlauncher//commandlist.cfg";
            Dictionary<string, Category[]> modCats = new Dictionary<string, Category[]>();
            bool fileExists = false;
            Category[] baseCat = null;

            if (File.Exists(cfgFile))
            {
                fileExists = true;

                string cnt = File.ReadAllText(cfgFile);

                foreach (var snippet in cnt.Split('}'))
                {
                    var catList = new List<Category>();
                    var strimmed = snippet.Trim();

                    if (strimmed.Length == 0)
                        continue;

                    // get mod name
                    string modname = strimmed.Remove(strimmed.IndexOf('{')).Trim();

                    // get category name
                    while (strimmed.Contains('"'))
                    {
                        Category category_o = new Category();

                        int endIndex = strimmed.IndexOf('"') + 1;
                        while (strimmed[endIndex] != '"')
                            endIndex++;

                        string category = GetSubString(strimmed, '"', '"');
                        strimmed = strimmed.Replace('"' + category + '"', "");
                        category_o.Name = category.Trim();

                        while (strimmed.Contains('[') && strimmed.IndexOf('[') < endIndex)
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
                        MessageBox.Show(modname + ": " + category_o.ToString());
                    }

                    modCats.Add(modname, catList.ToArray());
                }
            }

            if (modCats.ContainsKey("all"))
                baseCat = modCats.FirstOrDefault(p => p.Key == "all").Value;

            foreach (var mod in ModFinder.GetMods)
            {
                var gameinfo = new GameInfo(mod);
                var categoryList = new List<FlatButton>();

                if (fileExists && modCats.ContainsKey(mod.ModFolder))
                {
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
                        MessageBox.Show("Cannot parse commandlist.cfg");
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
                            if (categoryList.FirstOrDefault( p => p.AllArguments.Contains(cv.Name)) == null)
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

            btnLaunch_NR.Click += (o, ev) =>
            {
                if (GameInfo.SelectedMod != null)
                {
                    var gi = GameInfo.SelectedMod.ArgPanels.Tabs;

                    string arg = string.Empty;
                    foreach (var tab in gi)
                        arg += tab.Arguments;

                    HLTools.LaunchMod(GameInfo.SelectedMod.ModInfo, arg);
                }
            };

            base.OnLoad(e);
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
