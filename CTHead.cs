using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CWCTHead
{
    public partial class CTHead : Form
    {
        enum View {
            Side,
            Front,
            Top
        }


        short[,,] cthead;
        public short min, max; //min/max value in the 3D volume data set
        int CT_x_axis;
        int CT_y_axis;
        int CT_z_axis;

        public int skin_opacity; //stores the skin weighting for volume rendering

        Bitmap topImage;
        Bitmap frontImage;
        Bitmap sideImage;

        //Creates a new CTHead object
        public CTHead(String filename, int x, int y, int z)
        {
            CT_x_axis = x;
            CT_y_axis = y;
            CT_z_axis = z;

            InitializeComponent();
            ReadData(filename);

            topSliceTrackbar.Maximum = CT_z_axis - 1;
            frontSliceTrackbar.Maximum = CT_y_axis - 1;
            sideSliceTrackbar.Maximum = CT_x_axis - 1;
            topViewLabel.Text = "Current Slice: " + topSliceTrackbar.Value;
            frontViewLabel.Text = "Current Slice: " + frontSliceTrackbar.Value;
            sideViewLabel.Text = "Current Slice: " + sideSliceTrackbar.Value;

            skinOpacityLabel.Text = "Skin Opacity: " + skinOpacityTrackbar.Value + "%\n(Requires Re-Render)";
            skin_opacity = (skinOpacityTrackbar.Value * 255) / 100;
            renderModeBox.Text = "Default";

            if (renderModeBox.Text == "Volume")
            {
                skinOpacityTrackbar.Visible = true;
                skinOpacityLabel.Visible = true;
            }
            else
            {
                skinOpacityTrackbar.Visible = false;
                skinOpacityLabel.Visible = false;
            }
        }

        //Updates top image and trackbar value label
        private void topSliceTrackbar_ValueChanged(object sender, EventArgs e)
        {
            updateTopView();
            topViewLabel.Text = "Current Slice: " + topSliceTrackbar.Value;
        }

        //Updates front image and trackbar value label
        private void frontSliceTrackbar_ValueChanged(object sender, EventArgs e)
        {
            updateFrontView();
            frontViewLabel.Text = "Current Slice: " + frontSliceTrackbar.Value;
        }

        //Updates side image and trackbar value label
        private void sideSliceTrackbar_ValueChanged(object sender, EventArgs e)
        {
            updateSideView();

            sideViewLabel.Text = "Current Slice: " + sideSliceTrackbar.Value;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        //Updates top image
        private void topSliceButton_Click(object sender, EventArgs e)
        {
            updateTopView();
        }

        //Updates front image
        private void frontSliceButton_Click(object sender, EventArgs e)
        {
            updateFrontView();
        }

        //Updates side image
        private void sideSliceButton_Click(object sender, EventArgs e)
        {
            updateSideView();
        }

        //Renders top image based on current render settings
        private void updateTopView()
        {
            short sliceValue = (short) topSliceTrackbar.Value;

            string renderMode = renderModeBox.Text;
            switch (renderMode)
            {
                case "Default":
                    topImage = Slice(sliceValue, CT_x_axis, CT_y_axis, View.Top);
                    break;
                case "Depth":
                    topImage = Depth(sliceValue, CT_x_axis, CT_y_axis, CT_z_axis, View.Top);
                    break;
                case "Volume":
                    topImage = Volume(sliceValue, CT_x_axis, CT_y_axis, CT_z_axis, View.Top);
                    break;
                default:
                    topImage = Slice(sliceValue, CT_x_axis, CT_y_axis, View.Top);
                    break;

            }
            topView.Image = topImage;
            topView.SizeMode = PictureBoxSizeMode.Zoom;
        }

        //Renders front image based on current render settings
        private void updateFrontView()
        {
            short sliceValue = (short)frontSliceTrackbar.Value;

            string renderMode = renderModeBox.Text;
            switch (renderMode)
            {
                case "Default":
                    frontImage = Slice(sliceValue, CT_x_axis, CT_z_axis, View.Front);
                    break;
                case "Depth":
                    frontImage = Depth(sliceValue, CT_x_axis, CT_z_axis, CT_y_axis, View.Front);
                    break;
                case "Volume":
                    frontImage = Volume(sliceValue, CT_x_axis, CT_z_axis, CT_y_axis, View.Front);
                    break;
                case "Gradient":
                    frontImage = Gradient(sliceValue, CT_x_axis, CT_z_axis, CT_y_axis, View.Front);
                    break;
                default:
                    frontImage = Slice(sliceValue, CT_x_axis, CT_z_axis, View.Front);
                    break;

            }

            frontView.Image = frontImage;
            frontView.SizeMode = PictureBoxSizeMode.Zoom;
        }

        //Renders side image based on current render settings
        private void updateSideView()
        {
            short sliceValue = (short) sideSliceTrackbar.Value;
            string renderMode = renderModeBox.Text;
            switch (renderMode)
            {
                case "Default":
                    sideImage = Slice(sliceValue, CT_y_axis, CT_z_axis, View.Side);
                    break;
                case "Depth":
                    sideImage = Depth(sliceValue, CT_y_axis, CT_z_axis, CT_x_axis, View.Side);
                    break;
                case "Volume":
                    sideImage = Volume(sliceValue, CT_y_axis, CT_z_axis, CT_x_axis, View.Side);
                    break;
                default:
                    sideImage = Slice(sliceValue, CT_y_axis, CT_z_axis, View.Side);
                    break;

            }
            sideView.Image = sideImage;
            sideView.SizeMode = PictureBoxSizeMode.Zoom;
        }

        //Reads data from a CT data file
        private void ReadData(String filename)
        {
            BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open));

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
                        //Reads voxel data and reverses endianness
                        b1 = ((int)reader.ReadByte()) & 0xff;
                        b2 = ((int)reader.ReadByte()) & 0xff;
                        read = (short)((b2 << 8) | b1);
                        if (read < min) min = read;
                        if (read > max) max = read;
                        cthead[k, j, i] = read;
                    }
                }
            }
            Console.WriteLine("Minimum CT Value: " + min + ", Maximum CT Value: " + max);
        }

        private Bitmap Slice(short sliceNumber, int width, int height, View view)
        {
            double datum;
            Bitmap returnScanSlice = new Bitmap(width, height);

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    switch (view)
                    {
                        case View.Top:
                            datum = cthead[sliceNumber, j, i];
                            break;
                        case View.Side:
                            datum = cthead[j, i, sliceNumber];
                            break;
                        case View.Front:
                            datum = cthead[j, sliceNumber, i];
                            break;
                        default:
                            datum = cthead[0, 0, 0];
                            break;
                    }
                    Color currentCol = getColour(datum, false);
                    returnScanSlice.SetPixel(i, j, currentCol);
                }
            }

            return returnScanSlice;
        }

        private Bitmap Depth(short sliceNumber, int width, int height, int depth, View view)
        {
            Bitmap returnScanVolume = new Bitmap(width, height);

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    Color pixelColour = Color.FromArgb(255, 0, 0, 0);
                    int firstIntersectDepth = depth;
                    for (int k = sliceNumber; k < depth; k++)
                    {
                        double voxelVal;
                        switch (view)
                        {
                            case View.Top:
                                voxelVal = cthead[k, j, i];
                                break;
                            case View.Side:
                                voxelVal = cthead[j, i, k];
                                break;
                            case View.Front:
                                voxelVal = cthead[j, k, i];
                                break;
                            default:
                                voxelVal = cthead[0, 0, 0];
                                break;
                        }
                        if (voxelVal > 400)
                        {
                            if (k < firstIntersectDepth)
                            {
                                float multiplier = (float)k / depth;
                                int brightness = 255 - (int)(255 * multiplier);
                                pixelColour = Color.FromArgb(255, brightness, brightness, brightness);
                                firstIntersectDepth = k;
                            }
                        }
                    }
                    returnScanVolume.SetPixel(i, j, pixelColour);
                }
            }
            return returnScanVolume;
        }

        private Bitmap Volume(short sliceNumber, int width, int height, int depth, View view)
        {
            Bitmap returnScanVolume = new Bitmap(width, height);

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    double transparency = 1.0;
                    double voxelVal;
                    Color pixelColour = Color.FromArgb(0, 0, 0, 0);
                    double lighting = 1.0;
                    for (int k = sliceNumber; k < depth; k++)
                    {
                        if (transparency > 0)
                        {
                            switch (view)
                            {
                                case View.Top:
                                    voxelVal = cthead[k, j, i];
                                    break;
                                case View.Side:
                                    voxelVal = cthead[j, i, k];
                                    break;
                                case View.Front:
                                    voxelVal = cthead[j, k, i];
                                    break;
                                default:
                                    voxelVal = cthead[0, 0, 0];
                                    break;
                            }
                            Color voxelColour = getColour(voxelVal, true);
                            int newR = Math.Min(255, (int)(pixelColour.R + ((transparency * voxelColour.A * lighting * voxelColour.R) / 255)));
                            int newG = Math.Min(255, (int)(pixelColour.G + ((transparency * voxelColour.A * lighting * voxelColour.G) / 255)));
                            int newB = Math.Min(255, (int)(pixelColour.B + ((transparency * voxelColour.A * lighting * voxelColour.B) / 255)));

                            double transparencyOffset = (double)voxelColour.A / 255;
                            transparency = transparency * (1.0f - transparencyOffset);

                            pixelColour = Color.FromArgb(255, newR, newG, newB);
                        }
                    }
                    returnScanVolume.SetPixel(i, j, pixelColour);
                }
            }
            return returnScanVolume;
        }

        private Bitmap Gradient(short sliceNumber, int width, int height, int depth, View view)
        {
            Bitmap returnScanVolume = new Bitmap(width, height);

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    Color pixelColour = Color.FromArgb(255, 0, 0, 0);
                    int firstIntersectDepth = depth;
                    for (int k = sliceNumber; k < depth; k++)
                    {
                        double voxelVal;
                        switch (view)
                        {
                            case View.Top:
                                voxelVal = cthead[k, j, i];
                                break;
                            case View.Side:
                                voxelVal = cthead[j, i, k];
                                break;
                            case View.Front:
                                voxelVal = cthead[j, k, i];
                                break;
                            default:
                                voxelVal = cthead[0, 0, 0];
                                break;
                        }
                        if (voxelVal > 400)
                        {
                            if (k < firstIntersectDepth)
                            {
                                float multiplier = (float)k / depth;
                                int brightness = 255 - (int)(255 * multiplier);
                                pixelColour = Color.FromArgb(255, brightness, brightness, brightness);
                                firstIntersectDepth = k;
                            }
                        }
                    }
                    returnScanVolume.SetPixel(i, j, pixelColour);
                }
            }
            return returnScanVolume;
        }

        private void darkModeToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (darkModeToolStripMenuItem.Checked)
            {
                panel1.BackColor = Color.FromArgb(255, 30, 30, 30);
                topViewLabel.ForeColor = Color.White;
                frontViewLabel.ForeColor = Color.White;
                sideViewLabel.ForeColor = Color.White;

                skinOpacityLabel.ForeColor = Color.White;
            }
            else
            {
                panel1.BackColor = CTHead.DefaultBackColor;
                topViewLabel.ForeColor = Color.Black;
                frontViewLabel.ForeColor = Color.Black;
                sideViewLabel.ForeColor = Color.Black;

                skinOpacityLabel.ForeColor = Color.Black;
            }
        }

        private void skinOpacityTrackbar_ValueChanged(object sender, EventArgs e)
        {
            skin_opacity = (int) (skinOpacityTrackbar.Value * 255) / 100;
            skinOpacityLabel.Text = "Skin Opacity: " + skinOpacityTrackbar.Value + "%\n(Requires Re-Render)";
        }

        private void renderModeBox_DropDownClosed(object sender, EventArgs e)
        {
            string renderMode = renderModeBox.Text;
            switch (renderMode)
            {
                case "Default":
                    skinOpacityTrackbar.Visible = false;
                    skinOpacityLabel.Visible = false;
                    break;
                case "Depth":
                    skinOpacityTrackbar.Visible = false;
                    skinOpacityLabel.Visible = false;
                    break;
                case "Volume":
                    skinOpacityTrackbar.Visible = true;
                    skinOpacityLabel.Visible = true;
                    break;
                default:
                    skinOpacityTrackbar.Visible = false;
                    skinOpacityLabel.Visible = false;
                    break;

            }
        }

        private Color getColour(double datum, bool volumeRender)
        {
            if (volumeRender)
            {
                if (datum < -300)
                {
                    return Color.FromArgb(0, 0, 0, 0);
                }
                if (datum >= -300 && datum < 50)
                {
                    return Color.FromArgb(skin_opacity, 255, 201, 153);
                }
                if (datum < 300 && datum >= 50)
                {
                    return Color.FromArgb(0, 0, 0, 0);
                }
                if (datum >= 300 && datum <= 4096)
                {
                    return Color.FromArgb((int)(1.0 * 255), 255, 255, 255);
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
