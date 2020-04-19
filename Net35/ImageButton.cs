using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace HLModLauncher
{
    public partial class ImageButton : Button
    {
        public Image BackgroundImageOnMouseUp { get; set; }
        public Image BackgroundImageOnMouseDown { get; set; }

        public ImageButton()
        {
            InitializeComponent();
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            BackgroundImageOnMouseUp = this.BackgroundImage;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            this.BackgroundImage = BackgroundImageOnMouseDown;
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            this.BackgroundImage = BackgroundImageOnMouseUp;
            base.OnMouseUp(mevent);
        }
    }
}
