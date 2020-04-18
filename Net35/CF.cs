using System.Windows.Forms;
using System.Drawing;
using System;

namespace Net35
{
    public static class CF
    {
        private static Size displaySize = new Size();

        public static void SetCenter(Form form)
        {
            displaySize = Screen.GetWorkingArea(form).Size;

            PointF pf = GetScaledSize(form.Width, form.Height);
            form.Width = (int) pf.X;
            form.Height = (int) pf.Y;

            Point deskLocation = form.DesktopLocation;
            deskLocation.X = displaySize.Width / 2 - form.Width / 2;
            deskLocation.Y = displaySize.Height / 2 - form.Height / 2;
            form.DesktopLocation = deskLocation;

            float fontSize = form.Font.Size;
            fontSize = form.Font.Size - displaySize.Width / 1366;

            Font f = new Font(form.Font.FontFamily, fontSize);
            form.Font = f;
        }

        public static void ScaleAllControl(Control.ControlCollection root)
        {
            foreach (Control ctl in root)
            {
                if (!ctl.Name.Contains("_NR"))
                    ScaleControl(ctl);

                if (ctl.HasChildren)
                    ScaleAllControl(ctl.Controls);
            }
        }

        public static void ScaleControl(Control control)
        {
            PointF pf = GetScaledSize(control.Left, control.Top);
            control.Left = (int) pf.X;
            control.Top = (int) pf.Y;

            pf = GetScaledSize(control.Width, control.Height);
            control.Width = (int) pf.X;
            control.Height = (int) pf.Y;

            float emSize = control.Font.Size;
            Font f = new Font(control.Font.FontFamily, emSize, control.Font.Style);
            control.Font = f;

            //pf = GetScaledSize(control.Padding.Left, control.Padding.Top);
            //Padding p = new Padding();
            //p.Left = (int) pf.X;
            //p.Top = (int) pf.Y;

            //pf = GetScaledSize(control.Padding.Right, control.Padding.Bottom);
            //p.Right = (int) pf.X;
            //p.Bottom = (int) pf.Y;

            //control.Padding = p;
        }

        private static PointF GetScaledSize(double f1, double f2)
        {
            PointF p = new PointF();
            p.X = (int) Math.Floor((double) f1 - displaySize.Width / 1366);
            p.Y = (int) Math.Floor((double) f2 - displaySize.Height / 768);

            return p;
        }
    }
}
