using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;



namespace testGtay
{
    public partial class Form1 : Form
    {
        Image<Gray, Byte> imgBi;
        

        public Form1()
        {
            InitializeComponent();

        }

    

     

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(@"E:\OCR\TestOCR\car\");
            FileInfo[] Files = d.GetFiles("*.jpg"); 
            foreach (FileInfo file in Files)
            {
            
                    byte[] byteArray = new byte[0];
                    using (MemoryStream stream = new MemoryStream())
                    {
                        Image<Bgr, Byte> img1 = new Image<Bgr, Byte>(file.FullName);
                        Image<Gray, Byte> grayImage = img1.Convert<Gray, Byte>();
                        imgBi = new Image<Gray, byte>(grayImage.Width, grayImage.Height, new Gray(0));

                        CvInvoke.Threshold(grayImage, imgBi, 150,255,Emgu.CV.CvEnum.ThresholdType.Binary);

                         imgBi.ToBitmap().Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        stream.Close();

                        byteArray = stream.ToArray();
                    }

                    FileStream fs = new FileStream(@"E:\OCR\TestOCR\CAR2\" + file.Name, FileMode.Create);

                    fs.Write(byteArray, 0, byteArray.Length);
                    fs.Close(); 

                    // print picture in gray scale
                    //picturebox2.image = imgoutput.bitmap;
                    //using (memorystream stream = new memorystream()
                
                
                

            }
        }
    }
}
