using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramowanieWizualne_17_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();



            of.Filter = "Image Files (*.bmp)|*.BMP";

            if (of.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = of.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            Bitmap flippedBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            Graphics gfx = Graphics.FromImage(flippedBitmap);
            gfx.Clear(Color.White);
            gfx.ScaleTransform(-1, 1);
            gfx.TranslateTransform(-bitmap.Width, 0);
            gfx.DrawImage(bitmap, new Point(0, 0));
            pictureBox1.Image = flippedBitmap;
            gfx.Dispose();
            bitmap.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            Bitmap rotatedBitmap = new Bitmap(bitmap.Height, bitmap.Width);
            Graphics gfx = Graphics.FromImage(rotatedBitmap);
            gfx.Clear(Color.White);
            gfx.TranslateTransform((float)bitmap.Height / 2, (float)bitmap.Width / 2);
            gfx.RotateTransform(90);
            gfx.TranslateTransform(-(float)bitmap.Width / 2, -(float)bitmap.Height / 2);
            gfx.DrawImage(bitmap, new Point(0, 0));
            pictureBox1.Image = rotatedBitmap;
            gfx.Dispose();
            bitmap.Dispose();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            Bitmap flippedBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            Graphics gfx = Graphics.FromImage(flippedBitmap);
            gfx.Clear(Color.White);
            gfx.ScaleTransform(1, -1);
            gfx.TranslateTransform(0, -bitmap.Height);
            gfx.DrawImage(bitmap, new Point(0, 0));
            pictureBox1.Image = flippedBitmap;
            gfx.Dispose();
            bitmap.Dispose();
        }

            private void button2_Click(object sender, EventArgs e)
            {

                if (pictureBox1.Image == null)
                {
                    return;
                }


                Bitmap bitmap = new Bitmap(pictureBox1.Image);


                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        Color pixelColor = bitmap.GetPixel(x, y);


                        if (pixelColor.R >= 0 && pixelColor.R <= 100 &&
                            pixelColor.G >= 100 && pixelColor.G <= 255 &&
                            pixelColor.B >= 0 && pixelColor.B <= 100)
                        {

                        }
                        else
                        {
                            bitmap.SetPixel(x, y, Color.FromArgb(0, pixelColor));
                        }
                    }
                }

                pictureBox1.Image = bitmap;
            }

            private void button3_Click(object sender, EventArgs e)
            {
                if (pictureBox1.Image == null)
                {
                    return;
                }


                Bitmap bitmap = new Bitmap(pictureBox1.Image);


                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        Color pixelColor = bitmap.GetPixel(x, y);

                        int newR = 255 - pixelColor.R;
                        int newG = 255 - pixelColor.G;
                        int newB = 255 - pixelColor.B;

                        bitmap.SetPixel(x, y, Color.FromArgb(pixelColor.A, newR, newG, newB));
                    }
                }

                pictureBox1.Image = bitmap;

            }
        }
    }

