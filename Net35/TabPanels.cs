using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Net35
{
    public partial class TabPanels : UserControl
    {
        private FlatButton[] tabs_ = null;
        public FlatButton[] Tabs { get { return tabs_; }
            set
            {
                tabs_ = value;

                if (tabs_ != null)
                {
                    flpTabs.Controls.Clear();
                    content.Controls.Clear();

                    foreach (var tab in tabs_)
                    {
                        flpTabs.Controls.Add(tab);
                        content.Controls.Add(tab.Panel);
                    }
                }
            }
        }

        public TabPanels()
        {
            InitializeComponent();
        }
    }
}
