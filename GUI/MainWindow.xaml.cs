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

namespace GUI;

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
        if(CityName_Box.Text == "")
            MessageBox.Show("חסר עיר מגורים", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);
        else if (StreetName_Box.Text == "")
            MessageBox.Show("חסר שם רחוב", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);
        else if (HouseNumber_Box.Text == "")
            MessageBox.Show("חסר מספר בית", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);
        else if (Age_Box.Text == "")
            MessageBox.Show("חסר גיל", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);
        else
        {
            MessageBox.Show($" הוזמן אמבולנס לכתובת {StreetName_Box.Text} : {HouseNumber_Box.Text} - {CityName_Box.Text}", "שליחה", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            new symptoms().Show();
            this.Close();
        }
        
    }

    private void closeWindow_Click(object sender, RoutedEventArgs e)
    {
        this.Close();   
    }
}