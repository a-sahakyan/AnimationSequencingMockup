using System;
using System.Collections.Generic;
using System.IO;
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

namespace Animation_Sequencing_Mockup
{
    /// <summary>
    /// Interaction logic for Sequence.xaml
    /// </summary>
    public partial class Sequence : UserControl
    {
        public string ImageSource = "";
        public Sequence()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            
            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                try
                {
                    string filename = dlg.FileName;
                    string home = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string directory = home + @"\AnimationSequencingData";
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    directory = home + @"\AnimationSequencingData\Images";
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    string imagePath = directory + @"\" + System.IO.Path.GetFileName(filename);
                    if (!File.Exists(imagePath))
                    {
                        File.Copy(filename, imagePath);
                    }
                    BitmapImage logo = new BitmapImage();
                    logo.BeginInit();
                    logo.UriSource = new Uri(imagePath);
                    logo.EndInit();
                    image.Source = logo;
                    ImageSource = System.IO.Path.GetFileName(dlg.FileName);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
