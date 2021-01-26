
namespace CWIdeaTest
{
    partial class Test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Test));
            this.topSliceTrackbar = new System.Windows.Forms.TrackBar();
            this.frontSliceTrackbar = new System.Windows.Forms.TrackBar();
            this.sideSliceTrackbar = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topSliceButton = new System.Windows.Forms.Button();
            this.topView = new System.Windows.Forms.PictureBox();
            this.frontView = new System.Windows.Forms.PictureBox();
            this.sideView = new System.Windows.Forms.PictureBox();
            this.frontSliceButton = new System.Windows.Forms.Button();
            this.sideSliceButton = new System.Windows.Forms.Button();
            this.topViewLabel = new System.Windows.Forms.Label();
            this.frontViewLabel = new System.Windows.Forms.Label();
            this.sideViewLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.topSliceTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontSliceTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideSliceTrackbar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideView)).BeginInit();
            this.SuspendLayout();
            // 
            // topSliceTrackbar
            // 
            this.topSliceTrackbar.Location = new System.Drawing.Point(92, 985);
            this.topSliceTrackbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.topSliceTrackbar.Name = "topSliceTrackbar";
            this.topSliceTrackbar.Size = new System.Drawing.Size(329, 136);
            this.topSliceTrackbar.TabIndex = 0;
            this.topSliceTrackbar.ValueChanged += new System.EventHandler(this.topSliceTrackbar_ValueChanged);
            // 
            // frontSliceTrackbar
            // 
            this.frontSliceTrackbar.Location = new System.Drawing.Point(1156, 985);
            this.frontSliceTrackbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.frontSliceTrackbar.Name = "frontSliceTrackbar";
            this.frontSliceTrackbar.Size = new System.Drawing.Size(329, 136);
            this.frontSliceTrackbar.TabIndex = 1;
            this.frontSliceTrackbar.ValueChanged += new System.EventHandler(this.frontSliceTrackbar_ValueChanged);
            // 
            // sideSliceTrackbar
            // 
            this.sideSliceTrackbar.Location = new System.Drawing.Point(2233, 985);
            this.sideSliceTrackbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.sideSliceTrackbar.Name = "sideSliceTrackbar";
            this.sideSliceTrackbar.Size = new System.Drawing.Size(329, 136);
            this.sideSliceTrackbar.TabIndex = 2;
            this.sideSliceTrackbar.ValueChanged += new System.EventHandler(this.sideSliceTrackbar_ValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(19, 6, 0, 6);
            this.menuStrip1.Size = new System.Drawing.Size(3572, 64);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(103, 52);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(305, 66);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // topSliceButton
            // 
            this.topSliceButton.Location = new System.Drawing.Point(773, 985);
            this.topSliceButton.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.topSliceButton.Name = "topSliceButton";
            this.topSliceButton.Size = new System.Drawing.Size(238, 65);
            this.topSliceButton.TabIndex = 4;
            this.topSliceButton.Text = "Slice";
            this.topSliceButton.UseVisualStyleBackColor = true;
            this.topSliceButton.Click += new System.EventHandler(this.topSliceButton_Click);
            // 
            // topView
            // 
            this.topView.Image = ((System.Drawing.Image)(resources.GetObject("topView.Image")));
            this.topView.Location = new System.Drawing.Point(92, 157);
            this.topView.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.topView.Name = "topView";
            this.topView.Size = new System.Drawing.Size(918, 774);
            this.topView.TabIndex = 5;
            this.topView.TabStop = false;
            // 
            // frontView
            // 
            this.frontView.Image = ((System.Drawing.Image)(resources.GetObject("frontView.Image")));
            this.frontView.Location = new System.Drawing.Point(1156, 157);
            this.frontView.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.frontView.Name = "frontView";
            this.frontView.Size = new System.Drawing.Size(918, 774);
            this.frontView.TabIndex = 6;
            this.frontView.TabStop = false;
            // 
            // sideView
            // 
            this.sideView.Image = ((System.Drawing.Image)(resources.GetObject("sideView.Image")));
            this.sideView.Location = new System.Drawing.Point(2233, 157);
            this.sideView.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.sideView.Name = "sideView";
            this.sideView.Size = new System.Drawing.Size(918, 774);
            this.sideView.TabIndex = 7;
            this.sideView.TabStop = false;
            // 
            // frontSliceButton
            // 
            this.frontSliceButton.Location = new System.Drawing.Point(1837, 985);
            this.frontSliceButton.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.frontSliceButton.Name = "frontSliceButton";
            this.frontSliceButton.Size = new System.Drawing.Size(238, 65);
            this.frontSliceButton.TabIndex = 8;
            this.frontSliceButton.Text = "Slice";
            this.frontSliceButton.UseVisualStyleBackColor = true;
            this.frontSliceButton.Click += new System.EventHandler(this.frontSliceButton_Click);
            // 
            // sideSliceButton
            // 
            this.sideSliceButton.Location = new System.Drawing.Point(2913, 985);
            this.sideSliceButton.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.sideSliceButton.Name = "sideSliceButton";
            this.sideSliceButton.Size = new System.Drawing.Size(238, 65);
            this.sideSliceButton.TabIndex = 9;
            this.sideSliceButton.Text = "Slice";
            this.sideSliceButton.UseVisualStyleBackColor = true;
            this.sideSliceButton.Click += new System.EventHandler(this.sideSliceButton_Click);
            // 
            // topViewLabel
            // 
            this.topViewLabel.AutoSize = true;
            this.topViewLabel.Location = new System.Drawing.Point(440, 999);
            this.topViewLabel.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.topViewLabel.Name = "topViewLabel";
            this.topViewLabel.Size = new System.Drawing.Size(241, 37);
            this.topViewLabel.TabIndex = 11;
            this.topViewLabel.Text = "Current Slice: {}";
            // 
            // frontViewLabel
            // 
            this.frontViewLabel.AutoSize = true;
            this.frontViewLabel.Location = new System.Drawing.Point(1504, 999);
            this.frontViewLabel.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.frontViewLabel.Name = "frontViewLabel";
            this.frontViewLabel.Size = new System.Drawing.Size(241, 37);
            this.frontViewLabel.TabIndex = 12;
            this.frontViewLabel.Text = "Current Slice: {}";
            // 
            // sideViewLabel
            // 
            this.sideViewLabel.AutoSize = true;
            this.sideViewLabel.Location = new System.Drawing.Point(2581, 999);
            this.sideViewLabel.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.sideViewLabel.Name = "sideViewLabel";
            this.sideViewLabel.Size = new System.Drawing.Size(241, 37);
            this.sideViewLabel.TabIndex = 13;
            this.sideViewLabel.Text = "Current Slice: {}";
            // 
            // Test
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3572, 1511);
            this.Controls.Add(this.sideViewLabel);
            this.Controls.Add(this.frontViewLabel);
            this.Controls.Add(this.topViewLabel);
            this.Controls.Add(this.sideSliceButton);
            this.Controls.Add(this.frontSliceButton);
            this.Controls.Add(this.sideView);
            this.Controls.Add(this.frontView);
            this.Controls.Add(this.topView);
            this.Controls.Add(this.topSliceButton);
            this.Controls.Add(this.sideSliceTrackbar);
            this.Controls.Add(this.frontSliceTrackbar);
            this.Controls.Add(this.topSliceTrackbar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "Test";
            this.Text = "Test";
            ((System.ComponentModel.ISupportInitialize)(this.topSliceTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontSliceTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideSliceTrackbar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar topSliceTrackbar;
        private System.Windows.Forms.TrackBar frontSliceTrackbar;
        private System.Windows.Forms.TrackBar sideSliceTrackbar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Button topSliceButton;
        private System.Windows.Forms.PictureBox topView;
        private System.Windows.Forms.PictureBox frontView;
        private System.Windows.Forms.PictureBox sideView;
        private System.Windows.Forms.Button frontSliceButton;
        private System.Windows.Forms.Button sideSliceButton;
        private System.Windows.Forms.Label topViewLabel;
        private System.Windows.Forms.Label frontViewLabel;
        private System.Windows.Forms.Label sideViewLabel;
    }
}

