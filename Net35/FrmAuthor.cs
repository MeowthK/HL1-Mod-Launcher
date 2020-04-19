using System;
using System.Windows.Forms;

namespace HLModLauncher
{
    public partial class FrmAuthor : Form
    {
        private static FrmAuthor frmAuth = new FrmAuthor();

        public FrmAuthor()
        {
            InitializeComponent();
        }

        static FrmAuthor()
        {
            frmAuth.Deactivate += (o, e) =>
            {
                frmAuth.Hide();
            };

            frmAuth.MouseDown += (o, e) =>
            {
                frmAuth.Hide();
            };

            frmAuth.authLink.LinkClicked += (o, e) =>
            {
                try
                {
                    System.Diagnostics.Process.Start(frmAuth.authLink.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to open link. Reason: " + ex.Message);
                }
            };
        }

        public static void ShowForm()
        {
            frmAuth.Show();
        }
    }
}
