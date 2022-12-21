using Org.BouncyCastle.Asn1.Crmf;
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
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for symptoms.xaml
    /// </summary>
    public partial class symptoms : Window
    {
        public symptoms()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

            string[] nameOfCheckBox = { "כאב מוכר "
                                        ,"כאב לא מוכר - כאב פתאומי גם במנוחה",
                                        "כאב לוחץ בבית החזה לא משתנה במגע / נשימה / שינוי תנוחה" ,
                                         " כאבים דוקרים / קורעים בין השכמות או במרכז בית החזה"};
            if (ChestPain.IsChecked == true)
            {
                ComboBox? ChildOfChestPain = new ComboBox() { MinWidth = 100, Name = "Child" };
                
                ChildOfChestPain.HorizontalAlignment = HorizontalAlignment.Center;
                
                for (int i = 0; i < 4; i++) { ChildOfChestPain.Items.Add($"{nameOfCheckBox[i]}"); }
                options.Children.Add(ChildOfChestPain);
                Grid.SetRow(ChildOfChestPain, 1); 
            }

            if(ChestPain.IsChecked == false)
            {
                
                ComboBox? a1 = this.FindName("Child") as ComboBox;
                options.Children.Remove(a1);

            }
               
                
                

        }
    }
}
