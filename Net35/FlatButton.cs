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
                this.Width = (int)((float) this.Text.Length * this.Font.Size);
            };
        }
    }
}
