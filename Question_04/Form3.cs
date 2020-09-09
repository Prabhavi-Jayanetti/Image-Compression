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
    public partial class Form3 : Form
    {
        preprocessing p = new preprocessing();
        OpenFileDialog ofd = new OpenFileDialog();

        public Form3()
        {
            InitializeComponent();
        }
        //load bitton
        private void button1_Click(object sender, EventArgs e)
        {
            p.LoadOriginalImage(ofd.FileName);
            pictureBox1.ImageLocation = "InputImageSave.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //bitplane image
        private void button2_Click(object sender, EventArgs e)
        {
            p.SaveBitPlaneImages();
            pictureBox2.ImageLocation = "bitSliceImage5.png";
            pictureBox3.ImageLocation = "bitSliceImage6.png";
            pictureBox5.ImageLocation = "bitSliceImage7.png";

            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //nearly orginal image
        private void button3_Click(object sender, EventArgs e)
        {
            p.NearlyOriginalImage();
            pictureBox6.ImageLocation = "Output.png";
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
