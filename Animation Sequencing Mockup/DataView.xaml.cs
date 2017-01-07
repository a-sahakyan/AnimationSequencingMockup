using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Animation_Sequencing_Mockup
{
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class DataView : Window, INotifyPropertyChanged
    {
        public List<Data> Data { get; set; }
        public DataView()
        {
            InitializeComponent();
            dataView.DataContext = this;

            string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string directory = home + @"\AnimationSequencingData";
            string file = directory + @"\data.json";
            string content = "";
            try
            {
                StreamReader reader = new StreamReader(file);
                content = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            Data = JsonConvert.DeserializeObject<List<Data>>(content);
            RaisePropertyChangedEvent("Data");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
