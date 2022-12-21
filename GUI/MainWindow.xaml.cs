using Org.BouncyCastle.Asn1.Cmp;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            setSex_ComboBox();
        }

        private void Sex_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        public void setSex_ComboBox()
        {
            string[] choises = { "זכר", "נקבה" };
            for (int i = 0; i < 2; i++) { Sex_Box.Items.Add($"{choises[i]}"); }

        }

        private void EndOfDetails_Click(object sender, RoutedEventArgs e)
        {
            /*
            if(CityName_Box.Text == "" || StreetName_Box.Text == "" || HousNumber_Box.Text == "")
            {
                MessageBox.Show("חסר פרטים חייונים", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else
            {
                new symptoms().Show();
                this.Close();
            }
            */
            new symptoms().Show();
            this.Close();

        }
    }
}