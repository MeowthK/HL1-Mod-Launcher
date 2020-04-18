using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Net35
{
    public partial class GameInfo : Button
    {
        public static event EventHandler StatClick;

        protected virtual void OnStatClick(EventArgs e)
        {
            EventHandler handler = StatClick;

            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private static GameInfo lastClickedControl = null;

        private HLMOD modInfo = null;
        private TabPanels argPanels = null;

        public static GameInfo SelectedMod { get { return lastClickedControl; } }
        public HLMOD ModInfo { get { return modInfo; } }
        public TabPanels ArgPanels { get { return argPanels; } }
        public Control ContainerControl { get; set; }
        
        private void Initialize()
        {
            InitializeComponent();
            argPanels = new TabPanels();
            argPanels.Dock = DockStyle.Fill;

            Click += (o, e) =>
            {
                if (argPanels.Tabs.Length > 0)
                    argPanels.Tabs.ElementAt(argPanels.Tabs.Length - 1).PerformClick();

                if (lastClickedControl != null)
                {
                    lastClickedControl.BackColor = Color.Transparent;

                    if (ContainerControl != null)
                        ContainerControl.Controls.Remove(lastClickedControl.ArgPanels);
                }

                this.BackColor = this.FlatAppearance.MouseOverBackColor;

                if (ContainerControl != null)
                    ContainerControl.Controls.Add(this.ArgPanels);

                lastClickedControl = this;

                OnStatClick(EventArgs.Empty);
            };
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            if ((ModInfo != null) && (ModInfo.Icon != null))
                pevent.Graphics.DrawImage(ModInfo.Icon, 5, 5, this.Height - 10, this.Height - 10);
        }

        private void AssignValues()
        {
            if (ModInfo != null)
            {
                this.Text = ModInfo.Name;

                if (ModInfo.Version != "Unknown")
                    this.Text += " " + ModInfo.Version;
            }
        }

        public GameInfo(HLMOD ModInfo)
        {
            this.modInfo = ModInfo;
            Initialize();

            AssignValues();
        }

        public GameInfo()
        {
            Initialize();
        }
    }
}
