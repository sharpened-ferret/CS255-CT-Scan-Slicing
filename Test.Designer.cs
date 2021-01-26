
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Test));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.topSliceTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontSliceTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideSliceTrackbar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideView)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // topSliceTrackbar
            // 
            this.topSliceTrackbar.Location = new System.Drawing.Point(263, 985);
            this.topSliceTrackbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.topSliceTrackbar.Name = "topSliceTrackbar";
            this.topSliceTrackbar.Size = new System.Drawing.Size(329, 136);
            this.topSliceTrackbar.TabIndex = 0;
            // 
            // frontSliceTrackbar
            // 
            this.frontSliceTrackbar.Location = new System.Drawing.Point(1694, 868);
            this.frontSliceTrackbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.frontSliceTrackbar.Name = "frontSliceTrackbar";
            this.frontSliceTrackbar.Size = new System.Drawing.Size(329, 136);
            this.frontSliceTrackbar.TabIndex = 1;
            // 
            // sideSliceTrackbar
            // 
            this.sideSliceTrackbar.Location = new System.Drawing.Point(2239, 868);
            this.sideSliceTrackbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.sideSliceTrackbar.Name = "sideSliceTrackbar";
            this.sideSliceTrackbar.Size = new System.Drawing.Size(329, 136);
            this.sideSliceTrackbar.TabIndex = 2;
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
            this.menuStrip1.Size = new System.Drawing.Size(3116, 64);
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
            this.topSliceButton.Location = new System.Drawing.Point(304, 1204);
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
            this.frontView.Location = new System.Drawing.Point(1612, 330);
            this.frontView.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.frontView.Name = "frontView";
            this.frontView.Size = new System.Drawing.Size(576, 458);
            this.frontView.TabIndex = 6;
            this.frontView.TabStop = false;
            // 
            // sideView
            // 
            this.sideView.Image = ((System.Drawing.Image)(resources.GetObject("sideView.Image")));
            this.sideView.Location = new System.Drawing.Point(2239, 330);
            this.sideView.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.sideView.Name = "sideView";
            this.sideView.Size = new System.Drawing.Size(576, 458);
            this.sideView.TabIndex = 7;
            this.sideView.TabStop = false;
            // 
            // Test
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3116, 1597);
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

        private System.Windows.Forms.ImageList imageList1;
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
    }
}

