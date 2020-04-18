using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System;

namespace Net35
{
    public partial class RoundTextbox : UserControl
    {
        public new event EventHandler TextChanged;
        public new string Text { get { return input.Text; } set { input.Text = value; } }

        protected new virtual void OnTextChanged(EventArgs e)
        {
            EventHandler handler = TextChanged;

            if (handler != null)
                handler(input, EventArgs.Empty);
        }

        public Image T_Image { get { return pbImg.Image; } set { pbImg.Image = value; } }
        public Color T_Color { get { return input.BackColor; } set { input.BackColor = value; pbImg.BackColor = value; } }
        public Color T_FColor { get { return input.ForeColor; } set { input.ForeColor = value; } }

        public RoundTextbox()
        {
            InitializeComponent();
            input.TextChanged += (o, e) => { OnTextChanged(EventArgs.Empty); };
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            input.Width = this.Width - (this.Padding.Left + this.Padding.Right);
            this.Height = input.Bottom + this.Padding.Bottom;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            using (var gp = new GraphicsPath())
            {
                gp.AddArc(1, 1, 5, 5, 180, 90);
                gp.AddArc(this.Width - 7, 1, 5, 5, 270, 90);
                gp.AddArc(this.Width - 7, this.Height - 7, 5, 5, 0, 90);
                gp.AddArc(1, this.Height - 7, 5, 5, 90, 90);
                gp.CloseFigure();

                if (input != null)
                    using (var brush = new SolidBrush(input.BackColor))
                        e.Graphics.FillPath(brush, gp);
                else
                    e.Graphics.FillPath(Brushes.Black, gp);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString() == "Back, Control")
                return true;

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
