using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Xml;

namespace Animation_Sequencing_Mockup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        List<Actions> Data { get; set; }



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
            string groupXml = XamlWriter.Save(sequence1);

            StringReader stringReader = new StringReader(groupXml);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            GroupBox groupBox = (GroupBox)XamlReader.Load(xmlReader);
            int count = wrapPanel1.Children.Count;
            groupBox.Header = "Sequence" + count.ToString();
            wrapPanel1.Children.Insert(wrapPanel1.Children.Count - 1, groupBox);

            foreach (var v in wrapPanel2.Children)
            {
                if (v is GroupBox)
                {
                    ((GroupBox)v).Header = "Sequence" + (count + 1).ToString();
                    count++;
                }
            }

            count = wrapPanel1.Children.Count + wrapPanel2.Children.Count - 1;

            foreach (var v in wrapPanel3.Children)
            {
                if (v is GroupBox)
                {
                    ((GroupBox)v).Header = "Sequence" + count.ToString();
                    count++;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string groupXml = XamlWriter.Save(sequence2);

            StringReader stringReader = new StringReader(groupXml);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            GroupBox groupBox = (GroupBox)XamlReader.Load(xmlReader);
            int count = wrapPanel1.Children.Count + wrapPanel2.Children.Count - 1;
            groupBox.Header = "Sequence" + count.ToString();
            wrapPanel2.Children.Insert(wrapPanel2.Children.Count - 1, groupBox);

            count = wrapPanel1.Children.Count + wrapPanel2.Children.Count - 1;

            foreach (var v in wrapPanel3.Children)
            {
                if (v is GroupBox)
                {
                    ((GroupBox)v).Header = "Sequence" + count.ToString();
                    count++;
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string groupXml = XamlWriter.Save(sequence3);

            StringReader stringReader = new StringReader(groupXml);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            GroupBox groupBox = (GroupBox)XamlReader.Load(xmlReader);
            int count = wrapPanel1.Children.Count + wrapPanel2.Children.Count + wrapPanel3.Children.Count - 2;
            groupBox.Header = "Sequence" + count.ToString();
            wrapPanel3.Children.Insert(wrapPanel3.Children.Count - 1, groupBox);
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
                image.Source = logo;
            }
        }

        //public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        //{
        //    TextWriter writer = null;
        //    try
        //    {
        //        var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
        //        writer = new StreamWriter(filePath, append);
        //        writer.Write(contentsToWriteToFile);
        //    }
        //    finally
        //    {
        //        if (writer != null)
        //            writer.Close();
        //    }
        //}
        private void CheckButtonChecked(object sender, RoutedEventArgs e)
        {
            var checkbutton = sender as CheckBox;
            if (checkbutton == null)
                return;
            int intIndex = Convert.ToInt32(checkbutton.Content.ToString());
            MessageBox.Show(intIndex.ToString(CultureInfo.InvariantCulture));
        }



        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                string path = @"C:\Users\Arman\Desktop\data.json";
                string jsonFile = File.ReadAllText(path);

                if (new FileInfo(path).Length != 0)
                {
                    Data = JsonConvert.DeserializeObject<List<Actions>>(jsonFile);
                }

                Actions action = new Actions();
                List<CheckBox> checkedStyle = stylePanel.Children.OfType<CheckBox>().Where(x => x.IsChecked == true).ToList();
                action.Style = new string[checkedStyle.Count];
                int i = 0;
                foreach (var item in checkedStyle)
                {
                    action.Style[i] = item.Content.ToString();
                    i++;
                }


                if (typeListBox.SelectedItem != null)
                {
                    action.Type = ((ListBoxItem)typeListBox.SelectedItem).Content.ToString();
                }


                action.TotalTime = (double)totalTime.Value;

                List<CheckBox> checkedTargetAudience = targetAudiencePanel.Children.OfType<CheckBox>().Where(x => x.IsChecked == true).ToList();
                action.TargetAudience = new string[checkedTargetAudience.Count];

                i = 0;
                foreach (var item in checkedTargetAudience)
                {
                    action.TargetAudience[i] = item.Content.ToString();
                    i++;
                }

                List<CheckBox> checkedPurpose = purposePanel.Children.OfType<CheckBox>().Where(x => x.IsChecked == true).ToList();
                action.Purpose = new string[checkedPurpose.Count];

                i = 0;
                foreach (var item in checkedPurpose)
                {
                    action.Purpose[i] = item.Content.ToString();
                    i++;
                }

                List<CheckBox> checkedVoiceOver = voiceOverPanel.Children.OfType<CheckBox>().Where(x => x.IsChecked == true).ToList();
                action.VoiceOver = new string[checkedVoiceOver.Count];

                i = 0;
                foreach (var item in checkedVoiceOver)
                {
                    action.VoiceOver[i] = item.Content.ToString();
                    i++;
                }
                action.ColorScheme = new Color();

                if (numbersColorSchemeListBox.SelectedItem != null)
                {
                    action.ColorScheme.Numbers = ((ListBoxItem)numbersColorSchemeListBox.SelectedItem).Content.ToString();
                }


                if (yesOrNoColorSchemeListBox.SelectedItem != null)
                {
                    action.ColorScheme.YesOrNo = ((ListBoxItem)yesOrNoColorSchemeListBox.SelectedItem).Content.ToString();
                }


                if (colorsColorSchemeListBox.SelectedItem != null)
                {
                    action.ColorScheme.Colors = ((ListBoxItem)colorsColorSchemeListBox.SelectedItem).Content.ToString();
                }

                List<CheckBox> checkedMusicVFX = musicFVXPanel.Children.OfType<CheckBox>().Where(x => x.IsChecked == true).ToList();
                action.MusicVFX = new string[checkedMusicVFX.Count];

                i = 0;
                foreach (var item in checkedMusicVFX)
                {
                    action.MusicVFX[i] = item.Content.ToString();
                    i++;
                }

                if (globalRatingListBox.SelectedItem != null)
                {
                    var globalRating = ((ListBoxItem)globalRatingListBox.SelectedItem).Content;
                    action.GlobalRating =globalRating.ToString();
                }

                action.Sequence1 = new Introduction();

                action.Sequence1.What = whatTextBoxSequence1.Text;
                List<TextBox> timeTextBox = timeWrapPanelSequence1.Children.OfType<TextBox>().Where(x => x.Text != null).ToList();

                action.Sequence1.Time = new string[timeTextBox.Count];

                i = 0;
                foreach (var item in timeTextBox)
                {
                    action.Sequence1.Time[i] = item.Text;
                    i++;
                }

                action.Sequence1.Style = new List<string>();

                foreach (var s in styleComboboxSequence1.Items)
                {
                    CheckBox checkBox = (s as ComboBoxItem).Content as CheckBox;
                    if ((bool)(checkBox.IsChecked))
                    {
                        action.Sequence1.Style.Add(checkBox.Content.ToString());
                    }
                }





                if (Data == null)
                {
                    Data = new List<Actions> { };
                    action.Id = 0;
                }
                else
                {
                    var id = Data.Max(x => x.Id);
                    action.Id = ++id;
                }

                using (StreamWriter writer = new StreamWriter(path))
                {
                    Data.Add(action);
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(writer, Data);
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }


    }
}


