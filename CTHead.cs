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
using System.Windows.Media.Media3D;

namespace CWCTHead
{
    public partial class CTHead : Form
    {
        //Enumerates values for possible view directions
        private enum View {
            Side,
            Front,
            Top
        }


        short[,,] cthead;

        private short min, max; //store the min and max CT values in the data set

        //Store the directional sizes of the data set
        private int CT_x_axis;
        private int CT_y_axis;
        private int CT_z_axis;

        private int skin_opacity; //stores the skin weighting for volume rendering

        private Bitmap topImage;
        private Bitmap frontImage;
        private Bitmap sideImage;




        /*
         * ---Core Methods---
        */ 
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

            for (k = 0; k < CT_z_axis; k++)
            {
                for (j = 0; j < CT_y_axis; j++)
                {
                    for (i = 0; i < CT_x_axis; i++)
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

        //Calculates colour values based on the transfer functions
        private Color GetColour(double datum, bool volumeRender)
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

        //Calculates a single-layer slice through the data set
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
                    Color currentCol = GetColour(datum, false);
                    returnScanSlice.SetPixel(i, j, currentCol);
                }
            }

            return returnScanSlice;
        }

        //Calculates a depth view through the data set
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

        //Calculates a volume view through the data set
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
                            Color voxelColour = GetColour(voxelVal, true);
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


        /*
         * ---Update Helpers---
        */
        //Renders top image based on current render settings
        private void UpdateTopView()
        {
            short sliceValue = (short)topSliceTrackbar.Value;

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
        private void UpdateFrontView()
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
                default:
                    frontImage = Slice(sliceValue, CT_x_axis, CT_z_axis, View.Front);
                    break;

            }

            frontView.Image = frontImage;
            frontView.SizeMode = PictureBoxSizeMode.Zoom;
        }

        //Renders side image based on current render settings
        private void UpdateSideView()
        {
            short sliceValue = (short)sideSliceTrackbar.Value;
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


        /* 
         * ---Button Handlers---
        */
        //Updates top image
        private void TopSliceButton_Click(object sender, EventArgs e)
        {
            UpdateTopView();
        }

        //Updates front image
        private void FrontSliceButton_Click(object sender, EventArgs e)
        {
            UpdateFrontView();
        }

        //Updates side image
        private void SideSliceButton_Click(object sender, EventArgs e)
        {
            UpdateSideView();
        }


        /*
         * ---Trackbar Handlers---
        */ 
        //Controls the slice position in the front viewport
        private void FrontSliceTrackbar_ValueChanged(object sender, EventArgs e)
        {
            UpdateFrontView();
            frontViewLabel.Text = "Current Slice: " + frontSliceTrackbar.Value;
        }

        //Controls the slice position in the side viewport
        private void SideSliceTrackbar_ValueChanged(object sender, EventArgs e)
        {
            UpdateSideView();

            sideViewLabel.Text = "Current Slice: " + sideSliceTrackbar.Value;
        }

        //Controls the slice position in the top viewport
        private void TopSliceTrackbar_ValueChanged(object sender, EventArgs e)
        {
            UpdateTopView();
            topViewLabel.Text = "Current Slice: " + topSliceTrackbar.Value;
        }

        //Controls the skin opacity (only visible in volume render mode)
        private void SkinOpacityTrackbar_ValueChanged(object sender, EventArgs e)
        {
            skin_opacity = (int)(skinOpacityTrackbar.Value * 255) / 100;
            skinOpacityLabel.Text = "Skin Opacity: " + skinOpacityTrackbar.Value + "%\n(Requires Re-Render)";
        }



        //Updates UI elements when dark mode is toggled
        private void DarkModeToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
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


        //Updates the UI elements when a new render mode is selected
        private void RenderModeBox_DropDownClosed(object sender, EventArgs e)
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
    }
}
