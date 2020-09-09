using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Question_04
{
    class preprocessing
    {

        IplImage srcImage, grayImage;

        //Load orginal Image
        public void LoadOriginalImage(string fname)
        {
            srcImage = Cv.LoadImage("InputImage.png", LoadMode.Color);
            Cv.SaveImage("InputImageSave.png", srcImage);
        }

        //Load gray scale image
        public void LoadGrayScaleImage()
        {
            grayImage = Cv.CreateImage(srcImage.Size, BitDepth.U8, 1);
            Cv.CvtColor(srcImage, grayImage, ColorConversion.RgbToGray);
            Cv.SaveImage("grayImage.png", grayImage);
        }

        private static int GetBit(byte b, int bitIndex)
        {
            return (b >> bitIndex) & 0x01;
        }

        public Bitmap GetBitPlaneRed(Bitmap bitmap, int bitPlaneIndex)
        {
            Bitmap newBit = new Bitmap(bitmap.Width, bitmap.Height);

            for (int a = 0; a < bitmap.Width; a++)
            {
                for (int b = 0; b < bitmap.Height; b++)
                {
                    Color Color1 = bitmap.GetPixel(a, b);

                    int bit = GetBit(Color1.B, bitPlaneIndex);

                    //Color code for the bitplane images
                    Color Color2 = Color.FromArgb(153 * bit, 50 * bit, 204 * bit);

                    newBit.SetPixel(a, b, Color2);
                }
            }
            return newBit;
        }

        //Save bitplane images
        public void SaveBitPlaneImages()
        {
            LoadGrayScaleImage();


            Bitmap bitmap = new Bitmap("grayImage.png");
            ImageFormat imageformat = bitmap.RawFormat;

            //for loop for save the 8 bitplane images

            for (int a = 1; a <= 8; a++)
            {

                Bitmap newBitmapImage = GetBitPlaneRed(bitmap, a);
                newBitmapImage.Save("bitSliceImage" + a + ".png", imageformat);
            }

        }

        // create an array for the store bitplance
        public int[] GetBinaryVal(int pixel)
        {

            int number = pixel;
            int[] binaryArray = new int[8];
            int Count = 0;
            while (number != 1)
            {
                int mod = number % 2;
                number /= 2;
                if (Count < 8)
                    binaryArray[Count++] = mod;
                if (number == 1)
                    binaryArray[Count] = number;

            }
            if (binaryArray.Length != 8)
            {
                int noOfelements = 8 - binaryArray.Length;
                for (int x = 0; x < noOfelements; x++)
                {
                    binaryArray[x] = 0;
                }
            }

            return binaryArray;
        }

        ////// PART B/////

        public void NearlyOriginalImage()
        {
            Bitmap bitmapImage4 = new Bitmap("bitSliceImage5.png");
            Bitmap bitmapImage5 = new Bitmap("bitSliceImage6.png");
            Bitmap bitmapImage6 = new Bitmap("bitSliceImage7.png");
            ImageFormat[] imageFormat = { bitmapImage4.RawFormat, bitmapImage5.RawFormat, bitmapImage6.RawFormat };
            Bitmap[] bitmapArray = { bitmapImage4, bitmapImage5, bitmapImage6 };
            int[] indexArray = { 4, 5, 6 };

            Bitmap NewBitmap = getBitplane(bitmapArray);
            NewBitmap.Save("Output.png", imageFormat[0]);
        }

        public Bitmap getBitplane(Bitmap[] bitmapArray)
        {
            Bitmap NewBitmap = new Bitmap(bitmapArray[0].Width, bitmapArray[0].Height);

            for (int c = 0; c < NewBitmap.Width; c++)
            {
                for (int d = 0; d < NewBitmap.Height; d++)
                {
                    int Color1 = bitmapArray[0].GetPixel(c, d).ToArgb();
                    int Color2 = bitmapArray[1].GetPixel(c, d).ToArgb();
                    int Color3 = bitmapArray[2].GetPixel(c, d).ToArgb();

                    //int bit = GetBit(currColor.B, index);

                    Color newColor = Color.FromArgb(Color1 + Color2 + Color3);

                    // Color newColor = Color.Gray;
                    NewBitmap.SetPixel(c, d, newColor);
                }
            }
            return NewBitmap;
        }
    }
}