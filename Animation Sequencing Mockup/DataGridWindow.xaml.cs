using Newtonsoft.Json;
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
using System.Windows.Shapes;

namespace Animation_Sequencing_Mockup
{
    /// <summary>
    /// Interaction logic for DataGridWindow.xaml
    /// </summary>
    public partial class DataGridWindow : Window
    {
        
        public DataGridWindow()
        {
            InitializeComponent();
            string path = @"c:/Users/Arman/Desktop/data.json";
            string jsonFile = File.ReadAllText(path);
            if (new FileInfo(path).Length != 0)
            {

                List<Data> d = JsonConvert.DeserializeObject<List<Data>>(jsonFile);
                string[] result = new string[d.Count];

                List<string> str = new List<string>()
                {
                    "a",
                    "b",
                };

                dataGrid.ItemsSource = d;
                List<Data> g = new List<Data>();
                

            }

            //using (StreamWriter writer = new StreamWriter(path))
            //{
            //    //Data.Add(action);
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(writer,jsonFile);
            //}
        }

      
    }
}
