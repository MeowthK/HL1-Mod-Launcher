using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Net35
{
    public partial class FlatButton : Button
    {
        private static FlatButton lastClicked = null;

        private Panel panel = null;
        public Panel Panel { get { return panel; } set { panel = value; } }

        public string Arguments
        {
            get
            {
                if (panel == null)
                    return string.Empty;

                string argument = string.Empty;

                foreach (Control arg in panel.Controls)
                {
                    if (arg is CBArg)
                    {
                        var cb = arg as CBArg;

                        if (cb.Checked)
                            argument += cb.Argument + " ";
                    }
                }

                return argument;
            }
        }

        public Item[] IArguments
        {
            get
            {
                if (panel == null)
                    return null;

                List<Item> item = new List<Item>();

                foreach (Control arg in panel.Controls)
                {
                    if (arg is CBArg)
                    {
                        var cb = arg as CBArg;

                        Item i = new Item();
                        i.Name = cb.Argument;
                        i.Description = cb.Text;

                        item.Add(i);
                    }
                }

                return item.ToArray();
            }
        }

        public string AllArguments
        {
            get
            {
                if (panel == null)
                    return string.Empty;

                string argument = string.Empty;

                foreach (Control arg in panel.Controls)
                    if (arg is CBArg)
                        argument += (arg as CBArg).Argument + " ";

                return argument;
            }
        }

        public FlatButton()
        {
            InitializeComponent();
            panel = new Panel();
            panel.AutoScroll = true;
            panel.Dock = DockStyle.Fill;
            panel.Hide();

            Click += (o, e) =>
            {
                if (lastClicked != null)
                {
                    lastClicked.Panel.Hide();
                    lastClicked.BackColor = Color.Transparent;
                }

                panel.Show();
                this.BackColor = this.FlatAppearance.MouseOverBackColor;
                lastClicked = this;
            };

            TextChanged += (o, e) =>
            {
                using (Graphics g = this.CreateGraphics())
                {
                    SizeF stringSize = g.MeasureString(this.Text, this.Font);
                    this.Width = (int) stringSize.Width + 25;
                }

                //this.Width = (int)((float) this.Text.Length * this.Font.Size);
            };
        }
    }
}
