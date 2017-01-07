using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Animation_Sequencing_Mockup
{
    public class TimeSec
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Duration { get; set; }
    }
    public class VoiceMusic
    {
        public string Type { get; set; }
        public double Level { get; set; }
    }
    public class SequenceInstance
    {
        public int Id { get; set; }
        public SequenceInstance()
        {
            TimeSec = new TimeSec();
            VoiceMusic = new VoiceMusic();
            Style = new List<string> { };
        }
        public string What { get; set; }
        public TimeSec TimeSec { get; set; }
        public List<string> Style { get; set; }
        public VoiceMusic VoiceMusic { get; set; }
        public double Energy { get; set; }
        public string Description { get; set; }
    }
    public class GroupInstance
    {
        public GroupInstance()
        {
            Sequences = new List<SequenceInstance> { };
        }
        public string Name { get; set; }
        public List<SequenceInstance> Sequences { get; set; }
    }
    public class ColorScheme
    {
        public string Number { get; set; }
        public string YesNo { get; set; }
        public string Color { get; set; }
    }
    public class MyList
    {
        public MyList()
        {
            List = new List<string> { };
        }

        public List<string> List { get; set; }
    }
    public class Data
    {
        public Data()
        {
            ColorScheme = new ColorScheme();
            Groups = new List<GroupInstance> { };
            Style = new List<string> { };
            TargetAudience = new List<string> { };
            Purpose = new List<string> { };
            VoiceOver = new List<string> { };
            MusicVFX = new List<string> { };
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public List<string> Style { get; set; }
        public string Type { get; set; }
        public uint TotalTime { get; set; }
        public List<string> TargetAudience { get; set; }
        public List<string> Purpose { get; set; }
        public List<string> VoiceOver { get; set; }
        public List<string> MusicVFX { get; set; }
        public string GlobalRating { get; set; }
        public ColorScheme ColorScheme { get; set; }
        public List<GroupInstance> Groups { get; set; }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text == "Title")
                (sender as TextBox).Text = "";
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0)
            {
                (sender as TextBox).Text = "Title";
            }
        }

        private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text == "Link")
                (sender as TextBox).Text = "";
        }

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0)
            {
                (sender as TextBox).Text = "Link";
            }
        }

        private object CloneObject(object o)
        {
            Type t = o.GetType();
            PropertyInfo[] properties = t.GetProperties();


            Object p = t.InvokeMember("", System.Reflection.
                BindingFlags.CreateInstance, null, o, null);


            foreach (PropertyInfo pi in properties)
            {
                if (pi.CanWrite)
                {
                    pi.SetValue(p, pi.GetValue(o, null), null);
                }
            }
            return p;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string groupXml = XamlWriter.Save(sequence1);

            //StringReader stringReader = new StringReader(groupXml);
            //XmlReader xmlReader = XmlReader.Create(stringReader);
            //GroupBox groupBox = (GroupBox)XamlReader.Load(xmlReader);
            //int count = wrapPanel1.Children.Count;
            //groupBox.Header = "Sequence" + count.ToString();
            //wrapPanel1.Children.Insert(wrapPanel1.Children.Count - 1, groupBox);

            //foreach(var v in wrapPanel2.Children)
            //{
            //    if (v is GroupBox)
            //    {
            //        ((GroupBox)v).Header = "Sequence" + (count + 1).ToString();
            //        count++;
            //    }
            //}

            //count = wrapPanel1.Children.Count + wrapPanel2.Children.Count - 1;

            //foreach (var v in wrapPanel3.Children)
            //{
            //    if (v is GroupBox)
            //    {
            //        ((GroupBox)v).Header = "Sequence" + count.ToString();
            //        count++;
            //    }
            //}
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //string groupXml = XamlWriter.Save(sequence2);

            //StringReader stringReader = new StringReader(groupXml);
            //XmlReader xmlReader = XmlReader.Create(stringReader);
            //GroupBox groupBox = (GroupBox)XamlReader.Load(xmlReader);
            //int count = wrapPanel1.Children.Count + wrapPanel2.Children.Count - 1;
            //groupBox.Header = "Sequence" + count.ToString();
            //wrapPanel2.Children.Insert(wrapPanel2.Children.Count - 1, groupBox);

            //count = wrapPanel1.Children.Count + wrapPanel2.Children.Count - 1;

            //foreach (var v in wrapPanel3.Children)
            //{
            //    if (v is GroupBox)
            //    {
            //        ((GroupBox)v).Header = "Sequence" + count.ToString();
            //        count++;
            //    }
            //}
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //string groupXml = XamlWriter.Save(sequence3);

            //StringReader stringReader = new StringReader(groupXml);
            //XmlReader xmlReader = XmlReader.Create(stringReader);
            //GroupBox groupBox = (GroupBox)XamlReader.Load(xmlReader);
            //int count = wrapPanel1.Children.Count + wrapPanel2.Children.Count + wrapPanel3.Children.Count - 2;
            //groupBox.Header = "Sequence" + count.ToString();
            //wrapPanel3.Children.Insert(wrapPanel3.Children.Count - 1, groupBox);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;

                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(filename);
                logo.EndInit();
                //image.Source = logo;
            }
        }

        private void Add_Group(object sender, RoutedEventArgs e)
        {
            ParentGroup p = new ParentGroup();
            rootWrapPanel.Children.Add(p);
        }

        private List<string> GetCheckedValues(UIElementCollection elements)
        {
            List<string> list = new List<string> { };
            foreach (var e in elements)
            {
                CheckBox c = e as CheckBox;
                if ((bool)c.IsChecked)
                {
                    list.Add(c.Content.ToString());
                }
            }
            return list;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string directory = home + @"\AnimationSequencingData";
            string file = directory + @"\data.json";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
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
            List<Data> d = JsonConvert.DeserializeObject<List<Data>>(content);
            Data data = new Data();
            if (d != null)
            {
                data.Id = d[d.Count - 1].Id + 1;
            }
            else
            {
                data.Id = 1;
            }
            data.Title = title.Text;
            data.Link = link.Text;
            data.Style = GetCheckedValues(style.Children);
            ListBox typeListBox = type as ListBox;
            if (typeListBox.SelectedItem != null)
            {
                data.Type = (typeListBox.SelectedItem as ListBoxItem).Content.ToString();
            }
            data.TotalTime = (uint)total_time.Value;
            ListBox globalRating = global_rating as ListBox;
            if (globalRating.SelectedItem != null)
            {
                data.GlobalRating = (globalRating.SelectedItem as ListBoxItem).Content.ToString();
            }
            data.TargetAudience = GetCheckedValues(target_audience.Children);
            data.Purpose = GetCheckedValues(purpose.Children);
            data.VoiceOver = GetCheckedValues(voiceover.Children);
            data.MusicVFX = GetCheckedValues(music_vfx.Children);

            ListBox colorSchemeNumber = color_scheme_number as ListBox;
            if (colorSchemeNumber.SelectedItem != null)
            {
                data.ColorScheme.Number = (colorSchemeNumber.SelectedItem as ListBoxItem).Content.ToString();
            }
            ListBox colorSchemeYesNo = color_scheme_yesno as ListBox;
            if (colorSchemeYesNo.SelectedItem != null)
            {
                data.ColorScheme.YesNo = (colorSchemeYesNo.SelectedItem as ListBoxItem).Content.ToString();
            }
            ListBox colorSchemeColor = color_scheme_color as ListBox;
            if (colorSchemeColor.SelectedItem != null)
            {
                foreach (var item in colorSchemeColor.SelectedItems)
                {
                    data.ColorScheme.Color += (item as ListBoxItem).Content.ToString() + "\n";
                }
            }

            List<GroupInstance> groups = new List<GroupInstance> { };
            data.Groups = groups;

            var child = rootWrapPanel.Children;
            for (int i = 1; i < child.Count; i++)
            {
                var parentGroups = child[i] as ParentGroup;
                GroupInstance group = new GroupInstance();
                groups.Add(group);
                group.Name = parentGroups.group.Header.ToString();
                var seq = parentGroups.rootWrapPanel.Children;
                for (int j = 1; j < seq.Count; j++)
                {
                    Sequence s = seq[j] as Sequence;
                    SequenceInstance sequenceInstance = new SequenceInstance();
                    group.Sequences.Add(sequenceInstance);
                    sequenceInstance.Id = j;
                    // 1
                    string what = s.what.Text;
                    sequenceInstance.What = what;
                    // 2
                    string from = s.from.Text;
                    sequenceInstance.TimeSec.From = from;
                    // 3
                    string to = s.to.Text;
                    sequenceInstance.TimeSec.To = to;
                    // 4
                    string duration = s.duration.Text;
                    sequenceInstance.TimeSec.Duration = duration;

                    ComboBox style = s.style;
                    // 5
                    List<string> styles = new List<string> { };
                    foreach (var item in style.Items)
                    {
                        CheckBox c = (item as ComboBoxItem).Content as CheckBox;
                        if ((bool)c.IsChecked)
                        {
                            styles.Add(c.Content.ToString());
                        }
                    }
                    sequenceInstance.Style = styles;

                    ListBox l = s.voiceList;
                    if (l.SelectedItem != null)
                    {
                        // 6
                        string voiceListSelected = (l.SelectedValue as ListBoxItem).Content.ToString();
                        sequenceInstance.VoiceMusic.Type = voiceListSelected;
                    }

                    var dropDown = s.voiceDropDown;
                    // 7
                    double dropDownValue = (double)dropDown.Value;
                    sequenceInstance.VoiceMusic.Level = dropDownValue;

                    double energy = (double)s.energy.Value;
                    sequenceInstance.Energy = energy;

                    TextRange textRange = new TextRange(s.rtb2.Document.ContentStart, s.rtb2.Document.ContentEnd);
                    // 9
                    string description = textRange.Text;
                    sequenceInstance.Description = description;
                }
            }
            if (d == null)
            {
                d = new List<Data> { };
            }
            d.Add(data);
            string output = JsonConvert.SerializeObject(d);
            StreamWriter writer = new StreamWriter(file);
            writer.Write(output);
            writer.Close();
            MessageBox.Show("Your data has been successfully saved.");
        }

        private void Show_Data(object sender, RoutedEventArgs e)
        {
            DataView data = new DataView();
            data.ShowDialog();
        }



        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string directory = home + @"\AnimationSequencingData";
            string file = directory + @"\data.json";
            string content = "";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            try
            {
                StreamReader reader = new StreamReader(file);
                content = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            List<Data> d = JsonConvert.DeserializeObject<List<Data>>(content);
            int count = 1;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".json";
            string jsonFile = "";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string fileName = dlg.FileName;

                StreamReader sr = new StreamReader(fileName);
                jsonFile = sr.ReadToEnd();
                sr.Close();
                List<Data> data = JsonConvert.DeserializeObject<List<Data>>(jsonFile);
                if (data != null && d!=null)
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        data[i].Id = d[d.Count - 1].Id + count++;
                    }
                }
                else
                {
                    Data newData = new Data();
                    d = new List<Data>();
                    d.Add(newData);
                    d[0].Id = 1;
                    d.Remove(newData);
                }




                if (data != null)
                {
                    foreach (var item in data)
                    {

                        d.Add(item);
                    }
                    string output = JsonConvert.SerializeObject(d);

                    StreamWriter writer = new StreamWriter(file);
                    writer.Write(output);
                    writer.Close();
                    MessageBox.Show("Your data has been successfully added.");

                }
                else
                {
                    MessageBox.Show("there is no data");
                }
            }
        }
    }
}
