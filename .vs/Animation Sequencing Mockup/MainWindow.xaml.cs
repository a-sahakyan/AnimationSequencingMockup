using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public string ImageSource { get; set; }
        public string Keywords { get; set; }
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
        public double TotalTime { get; set; }
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
            isEdit = false;
            editData = null;
        }

        private bool isEdit = false;
        private Data editData = null;
        public MainWindow(Data data)
        {
            InitializeComponent();
            isEdit = true;
            show_data.Visibility = Visibility.Hidden;
            editData = data;
            if (data != null)
            {
                title.Text = data.Title;
                link.Text = data.Link;
                
                // style
                var elements = style.Children;
                foreach (var e in elements)
                {
                    CheckBox c = e as CheckBox;
                    if (data.Style.Contains(c.Content.ToString()))
                    {
                        c.IsChecked = true;
                    }
                }

                // type
                ListBox typeListBox = type as ListBox;
                foreach (ListBoxItem item in typeListBox.Items)
                {
                    if (item.Content.ToString() == data.Type)
                    {
                        typeListBox.SelectedItem = item;
                    }
                }

                // total time
                try
                {
                    total_time.Value = data.TotalTime;
                }
                catch(Exception ex)
                { }

                // target audience
                elements = target_audience.Children;
                foreach (var e in elements)
                {
                    CheckBox c = e as CheckBox;
                    if (data.TargetAudience.Contains(c.Content.ToString()))
                    {
                        c.IsChecked = true;
                    }
                }

                // purpose
                elements = purpose.Children;
                foreach (var e in elements)
                {
                    CheckBox c = e as CheckBox;
                    if (data.Purpose.Contains(c.Content.ToString()))
                    {
                        c.IsChecked = true;
                    }
                }

                // voice over
                elements = voiceover.Children;
                foreach (var e in elements)
                {
                    CheckBox c = e as CheckBox;
                    if (data.VoiceOver.Contains(c.Content.ToString()))
                    {
                        c.IsChecked = true;
                    }
                }

                // music vfx
                elements = music_vfx.Children;
                foreach (var e in elements)
                {
                    CheckBox c = e as CheckBox;
                    if (data.MusicVFX.Contains(c.Content.ToString()))
                    {
                        c.IsChecked = true;
                    }
                }

                // global rating
                ListBox grListBox = global_rating as ListBox;
                foreach (ListBoxItem item in grListBox.Items)
                {
                    if (item.Content.ToString() == data.GlobalRating)
                    {
                        grListBox.SelectedItem = item;
                    }
                }

                // color scheme
                ListBox csc = color_scheme_color as ListBox;
                ListBox csn = color_scheme_number as ListBox;
                ListBox csy = color_scheme_yesno as ListBox;

                foreach(ListBoxItem item in csc.Items)
                {
                    if (item.Content.ToString() == data.ColorScheme.Color)
                    {
                        csc.SelectedItem = item;
                    }
                }
                foreach (ListBoxItem item in csn.Items)
                {
                    if (item.Content.ToString() == data.ColorScheme.Number)
                    {
                        csn.SelectedItem = item;
                    }
                }
                foreach (ListBoxItem item in csy.Items)
                {
                    if (item.Content.ToString() == data.ColorScheme.YesNo)
                    {
                        csy.SelectedItem = item;
                    }
                }

                // Sequences
                foreach (var g in data.Groups)
                {
                    ParentGroup p = new ParentGroup();
                    p.group.Header = g.Name;
                    rootWrapPanel.Children.Add(p);
                    foreach(var s in g.Sequences)
                    {
                        Sequence sequence = new Sequence();
                        sequence.what.Text = s.What;
                        sequence.from.Text = s.TimeSec.From;
                        sequence.to.Text = s.TimeSec.To;
                        sequence.duration.Text = s.TimeSec.Duration;

                        ComboBox style = sequence.style;
                        foreach (var item in style.Items)
                        {
                            CheckBox checkBox = (item as ComboBoxItem).Content as CheckBox;
                            if (s.Style.Contains(checkBox.Content.ToString()))
                            {
                                checkBox.IsChecked = true;
                            }
                        }

                        // voice list
                        ListBox voiceOverListBox = sequence.voiceList as ListBox;
                        foreach (ListBoxItem item in voiceOverListBox.Items)
                        {
                            if (item.Content.ToString() == s.VoiceMusic.Type)
                            {
                                voiceOverListBox.SelectedItem = item;
                            }
                        }

                        sequence.voiceDropDown.Value = (int?)s.VoiceMusic.Level;
                        sequence.energy.Value = (int?)s.Energy;
                        //sequence.rtb2.SetValue()

                        sequence.rtb2.Document.Blocks.Clear();
                        sequence.rtb2.Document.Blocks.Add(new Paragraph(new Run(s.Description)));

                        try
                        {
                            BitmapImage logo = new BitmapImage();
                            logo.BeginInit();
                            string home = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                            string directory = home + @"\AnimationSequencingData\Images\";
                            logo.UriSource = new Uri(directory + s.ImageSource);
                            logo.EndInit();
                            sequence.image.Source = logo;
                            sequence.ImageSource = s.ImageSource;
                        }
                        catch(Exception ex)
                        {

                        }

                        sequence.keywords.Text = s.Keywords;
                        p.rootWrapPanel.Children.Add(sequence);
                    }
                }
            }
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
            foreach(var e in elements)
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
            string home = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
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
            catch(Exception ex)
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
            data.TotalTime = (double)total_time.Value;
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
                data.ColorScheme.Color = (colorSchemeColor.SelectedItem as ListBoxItem).Content.ToString();
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
                    foreach(var item in style.Items)
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

                    sequenceInstance.Keywords = s.keywords.Text;
                    sequenceInstance.ImageSource = s.ImageSource;
                }
            }
            if (d == null)
            {
                d = new List<Data> { };
            }

            if (isEdit)
            {
                data.Id = editData.Id;
                //Data dd = null;
                //foreach(var d1 in d)
                //{
                //    if (dd.Id == editData.Id)
                //    {

                //    }
                //}
                var d1 = d.FirstOrDefault(x => x.Id == editData.Id);
                int index = d.IndexOf(d1);
                d[index] = data;
                //d1 = data;
            }
            else
            {
                d.Add(data);
            }
            string output = JsonConvert.SerializeObject(d);
            StreamWriter writer = new StreamWriter(file);
            writer.Write(output);
            writer.Close();
            if (isEdit)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Your data has been successfully saved.");
            }
        }

        private void Show_Data(object sender, RoutedEventArgs e)
        {
            DataView data = new DataView();
            data.ShowDialog();
        }
    }
}
