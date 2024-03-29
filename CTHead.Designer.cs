﻿
namespace CWCTHead
{
    partial class CTHead
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CTHead));
            this.topSliceTrackbar = new System.Windows.Forms.TrackBar();
            this.frontSliceTrackbar = new System.Windows.Forms.TrackBar();
            this.sideSliceTrackbar = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderModeBox = new System.Windows.Forms.ToolStripComboBox();
            this.topSliceButton = new System.Windows.Forms.Button();
            this.topView = new System.Windows.Forms.PictureBox();
            this.frontView = new System.Windows.Forms.PictureBox();
            this.sideView = new System.Windows.Forms.PictureBox();
            this.frontSliceButton = new System.Windows.Forms.Button();
            this.sideSliceButton = new System.Windows.Forms.Button();
            this.topViewLabel = new System.Windows.Forms.Label();
            this.frontViewLabel = new System.Windows.Forms.Label();
            this.sideViewLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.skinOpacityLabel = new System.Windows.Forms.Label();
            this.skinOpacityTrackbar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.topSliceTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontSliceTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideSliceTrackbar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinOpacityTrackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // topSliceTrackbar
            // 
            this.topSliceTrackbar.Location = new System.Drawing.Point(42, 511);
            this.topSliceTrackbar.Name = "topSliceTrackbar";
            this.topSliceTrackbar.Size = new System.Drawing.Size(104, 45);
            this.topSliceTrackbar.TabIndex = 0;
            this.topSliceTrackbar.ValueChanged += new System.EventHandler(this.TopSliceTrackbar_ValueChanged);
            // 
            // frontSliceTrackbar
            // 
            this.frontSliceTrackbar.Location = new System.Drawing.Point(521, 516);
            this.frontSliceTrackbar.Name = "frontSliceTrackbar";
            this.frontSliceTrackbar.Size = new System.Drawing.Size(104, 45);
            this.frontSliceTrackbar.TabIndex = 1;
            this.frontSliceTrackbar.ValueChanged += new System.EventHandler(this.FrontSliceTrackbar_ValueChanged);
            // 
            // sideSliceTrackbar
            // 
            this.sideSliceTrackbar.Location = new System.Drawing.Point(1009, 511);
            this.sideSliceTrackbar.Name = "sideSliceTrackbar";
            this.sideSliceTrackbar.Size = new System.Drawing.Size(104, 45);
            this.sideSliceTrackbar.TabIndex = 2;
            this.sideSliceTrackbar.ValueChanged += new System.EventHandler(this.SideSliceTrackbar_ValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1555, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darkModeToolStripMenuItem,
            this.renderModeMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // darkModeToolStripMenuItem
            // 
            this.darkModeToolStripMenuItem.CheckOnClick = true;
            this.darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            this.darkModeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.darkModeToolStripMenuItem.Text = "Dark Mode";
            this.darkModeToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.DarkModeToolStripMenuItem_CheckStateChanged);
            // 
            // renderModeMenuItem
            // 
            this.renderModeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renderModeBox});
            this.renderModeMenuItem.Name = "renderModeMenuItem";
            this.renderModeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.renderModeMenuItem.Text = "Render Mode:";
            // 
            // renderModeBox
            // 
            this.renderModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.renderModeBox.Items.AddRange(new object[] {
            "Default",
            "Depth",
            "Volume"});
            this.renderModeBox.Name = "renderModeBox";
            this.renderModeBox.Size = new System.Drawing.Size(121, 23);
            this.renderModeBox.DropDownClosed += new System.EventHandler(this.RenderModeBox_DropDownClosed);
            // 
            // topSliceButton
            // 
            this.topSliceButton.Location = new System.Drawing.Point(257, 511);
            this.topSliceButton.Name = "topSliceButton";
            this.topSliceButton.Size = new System.Drawing.Size(75, 23);
            this.topSliceButton.TabIndex = 4;
            this.topSliceButton.Text = "Slice";
            this.topSliceButton.UseVisualStyleBackColor = true;
            this.topSliceButton.Click += new System.EventHandler(this.TopSliceButton_Click);
            // 
            // topView
            // 
            this.topView.Image = ((System.Drawing.Image)(resources.GetObject("topView.Image")));
            this.topView.Location = new System.Drawing.Point(42, 50);
            this.topView.Name = "topView";
            this.topView.Size = new System.Drawing.Size(427, 396);
            this.topView.TabIndex = 5;
            this.topView.TabStop = false;
            // 
            // frontView
            // 
            this.frontView.Image = ((System.Drawing.Image)(resources.GetObject("frontView.Image")));
            this.frontView.Location = new System.Drawing.Point(521, 50);
            this.frontView.Name = "frontView";
            this.frontView.Size = new System.Drawing.Size(427, 396);
            this.frontView.TabIndex = 6;
            this.frontView.TabStop = false;
            // 
            // sideView
            // 
            this.sideView.Image = ((System.Drawing.Image)(resources.GetObject("sideView.Image")));
            this.sideView.Location = new System.Drawing.Point(1009, 50);
            this.sideView.Name = "sideView";
            this.sideView.Size = new System.Drawing.Size(427, 396);
            this.sideView.TabIndex = 7;
            this.sideView.TabStop = false;
            // 
            // frontSliceButton
            // 
            this.frontSliceButton.Location = new System.Drawing.Point(736, 516);
            this.frontSliceButton.Name = "frontSliceButton";
            this.frontSliceButton.Size = new System.Drawing.Size(75, 23);
            this.frontSliceButton.TabIndex = 8;
            this.frontSliceButton.Text = "Slice";
            this.frontSliceButton.UseVisualStyleBackColor = true;
            this.frontSliceButton.Click += new System.EventHandler(this.FrontSliceButton_Click);
            // 
            // sideSliceButton
            // 
            this.sideSliceButton.Location = new System.Drawing.Point(1224, 511);
            this.sideSliceButton.Name = "sideSliceButton";
            this.sideSliceButton.Size = new System.Drawing.Size(75, 23);
            this.sideSliceButton.TabIndex = 9;
            this.sideSliceButton.Text = "Slice";
            this.sideSliceButton.UseVisualStyleBackColor = true;
            this.sideSliceButton.Click += new System.EventHandler(this.SideSliceButton_Click);
            // 
            // topViewLabel
            // 
            this.topViewLabel.AutoSize = true;
            this.topViewLabel.Location = new System.Drawing.Point(152, 516);
            this.topViewLabel.Name = "topViewLabel";
            this.topViewLabel.Size = new System.Drawing.Size(81, 13);
            this.topViewLabel.TabIndex = 11;
            this.topViewLabel.Text = "Current Slice: {}";
            // 
            // frontViewLabel
            // 
            this.frontViewLabel.AutoSize = true;
            this.frontViewLabel.Location = new System.Drawing.Point(631, 521);
            this.frontViewLabel.Name = "frontViewLabel";
            this.frontViewLabel.Size = new System.Drawing.Size(81, 13);
            this.frontViewLabel.TabIndex = 12;
            this.frontViewLabel.Text = "Current Slice: {}";
            // 
            // sideViewLabel
            // 
            this.sideViewLabel.AutoSize = true;
            this.sideViewLabel.Location = new System.Drawing.Point(1119, 516);
            this.sideViewLabel.Name = "sideViewLabel";
            this.sideViewLabel.Size = new System.Drawing.Size(81, 13);
            this.sideViewLabel.TabIndex = 13;
            this.sideViewLabel.Text = "Current Slice: {}";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.skinOpacityLabel);
            this.panel1.Controls.Add(this.skinOpacityTrackbar);
            this.panel1.Controls.Add(this.sideSliceButton);
            this.panel1.Controls.Add(this.sideViewLabel);
            this.panel1.Controls.Add(this.topView);
            this.panel1.Controls.Add(this.frontViewLabel);
            this.panel1.Controls.Add(this.sideSliceTrackbar);
            this.panel1.Controls.Add(this.frontSliceButton);
            this.panel1.Controls.Add(this.frontView);
            this.panel1.Controls.Add(this.topViewLabel);
            this.panel1.Controls.Add(this.sideView);
            this.panel1.Controls.Add(this.topSliceButton);
            this.panel1.Controls.Add(this.frontSliceTrackbar);
            this.panel1.Controls.Add(this.topSliceTrackbar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1555, 751);
            this.panel1.TabIndex = 14;
            // 
            // skinOpacityLabel
            // 
            this.skinOpacityLabel.AutoSize = true;
            this.skinOpacityLabel.Location = new System.Drawing.Point(226, 614);
            this.skinOpacityLabel.Name = "skinOpacityLabel";
            this.skinOpacityLabel.Size = new System.Drawing.Size(81, 13);
            this.skinOpacityLabel.TabIndex = 15;
            this.skinOpacityLabel.Text = "Skin Opacity: {}";
            this.skinOpacityLabel.Visible = false;
            // 
            // skinOpacityTrackbar
            // 
            this.skinOpacityTrackbar.Location = new System.Drawing.Point(29, 614);
            this.skinOpacityTrackbar.Maximum = 100;
            this.skinOpacityTrackbar.Name = "skinOpacityTrackbar";
            this.skinOpacityTrackbar.Size = new System.Drawing.Size(191, 45);
            this.skinOpacityTrackbar.TabIndex = 14;
            this.skinOpacityTrackbar.Value = 12;
            this.skinOpacityTrackbar.Visible = false;
            this.skinOpacityTrackbar.ValueChanged += new System.EventHandler(this.SkinOpacityTrackbar_ValueChanged);
            // 
            // CTHead
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1555, 751);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CTHead";
            this.Text = "CT Head Reader";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.topSliceTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontSliceTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideSliceTrackbar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinOpacityTrackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar topSliceTrackbar;
        private System.Windows.Forms.TrackBar frontSliceTrackbar;
        private System.Windows.Forms.TrackBar sideSliceTrackbar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button topSliceButton;
        private System.Windows.Forms.PictureBox topView;
        private System.Windows.Forms.PictureBox frontView;
        private System.Windows.Forms.PictureBox sideView;
        private System.Windows.Forms.Button frontSliceButton;
        private System.Windows.Forms.Button sideSliceButton;
        private System.Windows.Forms.Label topViewLabel;
        private System.Windows.Forms.Label frontViewLabel;
        private System.Windows.Forms.Label sideViewLabel;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkModeToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label skinOpacityLabel;
        private System.Windows.Forms.TrackBar skinOpacityTrackbar;
        private System.Windows.Forms.ToolStripMenuItem renderModeMenuItem;
        private System.Windows.Forms.ToolStripComboBox renderModeBox;
    }
}

