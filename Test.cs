﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CWIdeaTest
{
    public partial class Test : Form
    {
        short[,,] cthead;
        short min, max; //min/max value in the 3D volume data set
        int CT_x_axis = 256;
        int CT_y_axis = 256;
        int CT_z_axis = 113;

        Bitmap topImage;
        Bitmap frontImage;
        Bitmap sideImage;


        public Test()
        {
            InitializeComponent();
            ReadData();

            int Top_width = CT_x_axis;
            int Top_height = CT_y_axis;

            int Front_width = CT_x_axis;
            int Front_height = CT_z_axis;

            topSliceTrackbar.Maximum = CT_z_axis - 1;
            frontSliceTrackbar.Maximum = CT_y_axis - 1;
            sideSliceTrackbar.Maximum = CT_x_axis - 1;
            topViewLabel.Text = "Current Slice: " + topSliceTrackbar.Value;
            frontViewLabel.Text = "Current Slice: " + frontSliceTrackbar.Value;
            sideViewLabel.Text = "Current Slice: " + sideSliceTrackbar.Value;
        }
        private void topSliceTrackbar_ValueChanged(object sender, EventArgs e)
        {
            topViewLabel.Text = "Current Slice: " + topSliceTrackbar.Value;
        }

        private void frontSliceTrackbar_ValueChanged(object sender, EventArgs e)
        {
            frontViewLabel.Text = "Current Slice: " + frontSliceTrackbar.Value;
        }

        private void sideSliceTrackbar_ValueChanged(object sender, EventArgs e)
        {
            sideViewLabel.Text = "Current Slice: " + sideSliceTrackbar.Value;
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void topSliceButton_Click(object sender, EventArgs e)
        {
            short sliceValue = (short)topSliceTrackbar.Value;
            topImage = TopDownSlice(sliceValue);
            topView.Image = topImage;
            topView.SizeMode = PictureBoxSizeMode.Zoom;

            Console.WriteLine("Test Pixel " + topImage.GetPixel(CT_x_axis/2,CT_y_axis/2).ToString());
        }

        private void frontSliceButton_Click(object sender, EventArgs e)
        {
            short sliceValue = (short)frontSliceTrackbar.Value;
            frontImage = FrontInSlice(sliceValue);
            frontView.Image = frontImage;
            frontView.SizeMode = PictureBoxSizeMode.Zoom;

            Console.WriteLine("Test Pixel " + frontImage.GetPixel(CT_x_axis / 2, CT_z_axis / 2).ToString());
        }
        private void sideSliceButton_Click(object sender, EventArgs e)
        {
            short sliceValue = (short)sideSliceTrackbar.Value;
            sideImage = SideOnSlice(sliceValue);
            sideView.Image = sideImage;
            sideView.SizeMode = PictureBoxSizeMode.Zoom;

            Console.WriteLine("Test Pixel " + sideImage.GetPixel(CT_x_axis / 2, CT_z_axis / 2).ToString());
        }

        public void ReadData()
        {
            BinaryReader reader = new BinaryReader(File.Open("CThead", FileMode.Open));

            int i, j, k;


            min = short.MaxValue;
            max = short.MinValue;
            short read;
            int b1, b2;

            cthead = new short[CT_z_axis, CT_y_axis, CT_x_axis];

            FileInfo fi = new FileInfo("CThead");

            if (fi.Exists)
            {
                // Get file size  
                long size = fi.Length;
                Console.WriteLine("File Size in Bytes: {0}", size);
                // File ReadOnly ?  
                bool IsReadOnly = fi.IsReadOnly;
                Console.WriteLine("Is ReadOnly: {0}", IsReadOnly);
                // Creation, last access, and last write time   
                DateTime creationTime = fi.CreationTime;
                Console.WriteLine("Creation time: {0}", creationTime);
                DateTime accessTime = fi.LastAccessTime;
                Console.WriteLine("Last access time: {0}", accessTime);
                DateTime updatedTime = fi.LastWriteTime;
                Console.WriteLine("Last write time: {0}", updatedTime);
            }

            for (k=0; k < CT_z_axis; k++)
            {
                for (j=0; j < CT_y_axis; j++)
                {
                    for (i=0; i < CT_x_axis; i++)
                    {
                        b1 = ((int)reader.ReadByte()) & 0xff;
                        b2 = ((int)reader.ReadByte()) & 0xff;
                        read = (short)((b2 << 8) | b1);
                        //read = (short)reader.ReadByte();
                        if (read < min) min = read;
                        if (read > max) max = read;
                        cthead[k, j, i] = read;
                    }
                }
            }
            Console.WriteLine(min + " " + max);
        }

        public Bitmap TopDownSlice(short sliceNumber)
        {
            int w = CT_x_axis;
            int h = CT_y_axis;

            double datum;
            Bitmap returnScanSlice = new Bitmap(w, h);

            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    //at this point (i,j) is a single pixel in the image
                    //here you would need to do something to (i,j) if the image size
                    //does not match the slice size (e.g. during an image resizing operation
                    //If you don't do this, your j,i could be outside the array bounds
                    //In the framework, the image is 256x256 and the data set slices are 256x256
                    //so I don't do anything - this also leaves you something to do for the assignment
                    datum = cthead[sliceNumber, j, i];
                    Color currentCol = getColour(datum, vToolStripMenuItem.Checked, min, max);
                    returnScanSlice.SetPixel(i, j, currentCol);
                }
            }

            return returnScanSlice;
        }

        public Bitmap FrontInSlice(short sliceNumber)
        {
            int w = CT_x_axis;
            int h = CT_z_axis;

            double datum;
            Bitmap returnScanSlice = new Bitmap(w, h);

            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    datum = cthead[j, sliceNumber, i];
                    Color currentCol = getColour(datum, vToolStripMenuItem.Checked, min, max);
                    returnScanSlice.SetPixel(i, j, currentCol);
                }
            }

            return returnScanSlice;
        }

        public Bitmap SideOnSlice(short sliceNumber)
        {
            int w = CT_y_axis;
            int h = CT_z_axis;

            double datum;
            Bitmap returnScanSlice = new Bitmap(w, h);

            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    datum = cthead[j, i, sliceNumber];
                    Color currentCol = getColour(datum, vToolStripMenuItem.Checked, min, max);
                    returnScanSlice.SetPixel(i, j, currentCol);
                }
            }

            return returnScanSlice;
        }

        private void darkModeToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (darkModeToolStripMenuItem.Checked)
            {
                panel1.BackColor = Color.FromArgb(255, 30, 30, 30);
                topViewLabel.ForeColor = Color.White;
                frontViewLabel.ForeColor = Color.White;
                sideViewLabel.ForeColor = Color.White;
            }
            else
            {
                panel1.BackColor = Test.DefaultBackColor;
                topViewLabel.ForeColor = Color.Black;
                frontViewLabel.ForeColor = Color.Black;
                sideViewLabel.ForeColor = Color.Black;
            }
        }

        private static Color getColour(double datum, bool volumeRender, int min, int max)
        {
            if (volumeRender)
            {
                if (datum < -300)
                {
                    return Color.FromArgb(0, 0, 0, 0);
                }
                if (datum >= -300 && datum < 50)
                {
                    return Color.FromArgb((int)(0.12 * 255), 255, (int)0.79 * 255, (int)0.6 * 255);
                }
                if (datum < 300 && datum >= 50)
                {
                    return Color.FromArgb(0, 0, 0, 0);
                }
                if (datum >= 300 && datum <= 4096)
                {
                    return Color.FromArgb((int)0.8 * 255, 255, 255, 255);
                }
                else
                {
                    return Color.FromArgb(0, 0, 0, 0);
                }
            }
            else
            {
                int col = (int)(((float)(datum - min) / ((float)(max - min))) * 255);
                return Color.FromArgb(255, col, col, col);
            }
        }
    }
}
