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
            //For any other formats
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = of.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                Bitmap bitmap = new Bitmap(pictureBox1.Image);
                Bitmap rotatedBitmap = new Bitmap(bitmap.Height, bitmap.Width); // Tworzenie nowego obrazka o obróconych wymiarach
                Graphics gfx = Graphics.FromImage(rotatedBitmap);
                gfx.Clear(Color.White); // Wyczyść nowy obrazek tłem w kolorze białym
                gfx.TranslateTransform((float)bitmap.Height / 2, (float)bitmap.Width / 2);
                gfx.RotateTransform(90);
                gfx.TranslateTransform(-(float)bitmap.Width / 2, -(float)bitmap.Height / 2);
                gfx.DrawImage(bitmap, new Point(0, 0));
                pictureBox1.Image = rotatedBitmap;
                gfx.Dispose();
                bitmap.Dispose();
            

        }
    }
}
