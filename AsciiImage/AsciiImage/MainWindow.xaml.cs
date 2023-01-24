using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using Microsoft.Win32;
using System.IO;

namespace AsciiImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        BitmapImage? img;
        
        public MainWindow()
        {
           
            InitializeComponent();

            
        }

        private void file_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.png,*.jpeg,*.jpg)|*.jpeg;*.png";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if(ofd.ShowDialog() == true)
            {


                img = new BitmapImage(new Uri(ofd.FileName));
                if ((img.Width <= 800) && (img.Height <= 400))
                {

                }
                else
                {
                    MessageBox.Show("Obrázek je příliš velký");
                }
                

                
            }
           

            
        }

        public Bitmap convert(BitmapImage bpmI)
        {
            using(MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder ENC = new BmpBitmapEncoder();
                ENC.Frames.Add(BitmapFrame.Create(bpmI));
                ENC.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);
                return new Bitmap(bitmap);

            }
        }

        private void run_Click(object sender, RoutedEventArgs e)
        {
            char[,] symbols = new char[img.PixelHeight, img.PixelWidth];

            Bitmap BmpImage = convert(img);
            
           for (int i = 0; i < BmpImage.Width; i++)
            {
                for (int j = 0; j < BmpImage.Height; j++)
                {
                    System.Drawing.Color pixel = BmpImage.GetPixel(i, j);

                    

                    //BMPImage width or height arent in pixel, fix that

                }
            }
            content.Text = Convert.ToString(BmpImage.Width);
            content.Text = content.Text + " " + Convert.ToString(BmpImage.Height);



        }
    }
}
