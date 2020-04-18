namespace Net35
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gamePanel = new System.Windows.Forms.Panel();
            this.gameList = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.launch_NR = new System.Windows.Forms.Panel();
            this.btnLaunch_NR = new System.Windows.Forms.Button();
            this.argContents = new System.Windows.Forms.Panel();
            this.rtbSearcher = new Net35.RoundTextbox();
            this.gamePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.launch_NR.SuspendLayout();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.gamePanel.Controls.Add(this.gameList);
            this.gamePanel.Controls.Add(this.panel1);
            this.gamePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.gamePanel.Location = new System.Drawing.Point(0, 49);
            this.gamePanel.Margin = new System.Windows.Forms.Padding(4);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.gamePanel.Size = new System.Drawing.Size(360, 651);
            this.gamePanel.TabIndex = 0;
            // 
            // gameList
            // 
            this.gameList.AutoScroll = true;
            this.gameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameList.Location = new System.Drawing.Point(0, 52);
            this.gameList.Name = "gameList";
            this.gameList.Size = new System.Drawing.Size(358, 599);
            this.gameList.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtbSearcher);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(358, 52);
            this.panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(30)))), ((int)(((byte)(22)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnClose.Location = new System.Drawing.Point(946, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 49);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "✕\t";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.pnlTopBar.Controls.Add(this.title);
            this.pnlTopBar.Controls.Add(this.btnMaximize);
            this.pnlTopBar.Controls.Add(this.btnClose);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1000, 49);
            this.pnlTopBar.TabIndex = 2;
            // 
            // title
            // 
            this.title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.title.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Name = "title";
            this.title.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.title.Size = new System.Drawing.Size(892, 49);
            this.title.TabIndex = 3;
            this.title.Text = "Half-Life Mod Launcher";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnMaximize
            // 
            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(30)))), ((int)(((byte)(22)))));
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximize.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnMaximize.Location = new System.Drawing.Point(892, 0);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(4);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(54, 49);
            this.btnMaximize.TabIndex = 2;
            this.btnMaximize.Text = "▣";
            this.btnMaximize.UseVisualStyleBackColor = true;
            // 
            // launch_NR
            // 
            this.launch_NR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(72)))));
            this.launch_NR.Controls.Add(this.btnLaunch_NR);
            this.launch_NR.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.launch_NR.Location = new System.Drawing.Point(360, 631);
            this.launch_NR.Name = "launch_NR";
            this.launch_NR.Padding = new System.Windows.Forms.Padding(15);
            this.launch_NR.Size = new System.Drawing.Size(640, 69);
            this.launch_NR.TabIndex = 3;
            // 
            // btnLaunch_NR
            // 
            this.btnLaunch_NR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(116)))), ((int)(((byte)(218)))));
            this.btnLaunch_NR.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLaunch_NR.FlatAppearance.BorderSize = 0;
            this.btnLaunch_NR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(106)))), ((int)(((byte)(208)))));
            this.btnLaunch_NR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaunch_NR.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch_NR.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLaunch_NR.Image = ((System.Drawing.Image)(resources.GetObject("btnLaunch_NR.Image")));
            this.btnLaunch_NR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLaunch_NR.Location = new System.Drawing.Point(465, 15);
            this.btnLaunch_NR.Name = "btnLaunch_NR";
            this.btnLaunch_NR.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnLaunch_NR.Size = new System.Drawing.Size(160, 39);
            this.btnLaunch_NR.TabIndex = 0;
            this.btnLaunch_NR.Text = "LAUNCH";
            this.btnLaunch_NR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLaunch_NR.UseVisualStyleBackColor = false;
            // 
            // argContents
            // 
            this.argContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.argContents.Location = new System.Drawing.Point(360, 49);
            this.argContents.Name = "argContents";
            this.argContents.Size = new System.Drawing.Size(640, 582);
            this.argContents.TabIndex = 4;
            // 
            // rtbSearcher
            // 
            this.rtbSearcher.BackColor = System.Drawing.Color.Transparent;
            this.rtbSearcher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSearcher.Location = new System.Drawing.Point(10, 10);
            this.rtbSearcher.Margin = new System.Windows.Forms.Padding(4);
            this.rtbSearcher.Name = "rtbSearcher";
            this.rtbSearcher.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rtbSearcher.Size = new System.Drawing.Size(338, 33);
            this.rtbSearcher.T_Color = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(27)))));
            this.rtbSearcher.T_FColor = System.Drawing.SystemColors.Info;
            this.rtbSearcher.T_Image = ((System.Drawing.Image)(resources.GetObject("rtbSearcher.T_Image")));
            this.rtbSearcher.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(82)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.argContents);
            this.Controls.Add(this.launch_NR);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.pnlTopBar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.gamePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.launch_NR.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Button btnMaximize;
        private RoundTextbox rtbSearcher;
        private System.Windows.Forms.Panel gameList;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel launch_NR;
        private System.Windows.Forms.Button btnLaunch_NR;
        private System.Windows.Forms.Panel argContents;
    }
}

