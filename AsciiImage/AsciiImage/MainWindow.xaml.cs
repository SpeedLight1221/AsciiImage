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
                

                image.Source = img;
            }
           

            
        }
        


       
    }
}
