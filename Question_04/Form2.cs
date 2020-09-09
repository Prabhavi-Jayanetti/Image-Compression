using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_04
{
    public partial class Form2 : Form
    {
        preprocessing p = new preprocessing();
        OpenFileDialog ofd = new OpenFileDialog();

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.LoadOriginalImage(ofd.FileName);
            pictureBox1.ImageLocation = "InputImageSave.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p.SaveBitPlaneImages();

            pictureBox2.ImageLocation = "bitSliceImage1.png";
            pictureBox3.ImageLocation = "bitSliceImage2.png";
            pictureBox4.ImageLocation = "bitSliceImage3.png";
            pictureBox5.ImageLocation = "bitSliceImage4.png";
            pictureBox6.ImageLocation = "bitSliceImage5.png";
            pictureBox7.ImageLocation = "bitSliceImage6.png";
            pictureBox8.ImageLocation = "bitSliceImage7.png";
            pictureBox9.ImageLocation = "bitSliceImage8.png";

            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
