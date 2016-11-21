using System;
using System.Collections.Generic;
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
    /// Interaction logic for ParentGroup.xaml
    /// </summary>
    public partial class ParentGroup : UserControl
    {
        public ParentGroup()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Sequence s = new Sequence();
            rootWrapPanel.Children.Add(s);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditDialog edit = new EditDialog(group.Header.ToString());
            if (edit.ShowDialog() == true)
            {
                group.Header = edit.Answer;
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            int count = rootWrapPanel.Children.Count;
            if (count > 1)
            {
                rootWrapPanel.Children.RemoveAt(count - 1);
            }
            else
            {
                var parent = userControl.Parent as WrapPanel;
                parent.Children.Remove(this);
            }
        }
    }
}
