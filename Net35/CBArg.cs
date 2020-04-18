using System;
using System.Windows.Forms;
using System.Drawing;

namespace Net35
{
    public class CBArg : CheckBox
    {
        public string Argument { get; set; }

        public CBArg()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CBArg
            // 
            this.ForeColor = System.Drawing.SystemColors.Info;
            this.Padding = new System.Windows.Forms.Padding(100, 0, 0, 0);
            this.ResumeLayout(false);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            using (var brush = new SolidBrush(Color.FromArgb(39, 176, 244)))
            {
                using (var sf = new StringFormat())
                {
                    var font = new Font(this.Font.FontFamily, 8.25f, FontStyle.Bold);

                    sf.LineAlignment = StringAlignment.Center;
                    float stringWidth = pevent.Graphics.MeasureString(Argument, font).Width;
                    string truncStr = Argument;

                    if (stringWidth > this.Padding.Left)
                    {
                        float w = 0;
                        int index = 0;
                        truncStr = string.Empty;

                        while (index < Argument.Length && w < stringWidth)
                        {
                            truncStr += Argument[index++];
                            w += this.Font.Size * 1.4f;
                        }

                        truncStr += "…";
                    }

                    pevent.Graphics.DrawString(truncStr, font, brush, new RectangleF(0, 0, this.Padding.Left, this.Height), sf);
                }
            }
        }
    }
}
