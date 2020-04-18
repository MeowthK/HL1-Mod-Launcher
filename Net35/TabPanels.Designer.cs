namespace Net35
{
    partial class TabPanels
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.content = new System.Windows.Forms.Panel();
            this.flpTabs = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // content
            // 
            this.content.AutoScroll = true;
            this.content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(82)))));
            this.content.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(0, 49);
            this.content.Name = "content";
            this.content.Padding = new System.Windows.Forms.Padding(15);
            this.content.Size = new System.Drawing.Size(775, 436);
            this.content.TabIndex = 1;
            // 
            // flpTabs
            // 
            this.flpTabs.AutoScroll = true;
            this.flpTabs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.flpTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpTabs.Location = new System.Drawing.Point(0, 0);
            this.flpTabs.Name = "flpTabs";
            this.flpTabs.Size = new System.Drawing.Size(775, 49);
            this.flpTabs.TabIndex = 0;
            // 
            // TabPanels
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.content);
            this.Controls.Add(this.flpTabs);
            this.DoubleBuffered = true;
            this.Name = "TabPanels";
            this.Size = new System.Drawing.Size(775, 485);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel content;
        private System.Windows.Forms.Panel flpTabs;
    }
}
