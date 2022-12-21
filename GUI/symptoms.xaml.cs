using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        List<string> symptomsList = new List<string>(); 
        private void ChestPain_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string[] nameOfCheckBox = { "כאב מוכר"
                                        ,"כאב לא מוכר - כאב פתאומי גם במנוחה",
                                        "כאב לוחץ בבית החזה לא משתנה במגע / נשימה / שינוי תנוחה" ,
                                         " כאבים דוקרים / קורעים בין השכמות או במרכז בית החזה"};
            if (ChestPain.IsChecked == true)
            {
                ComboBox? ChildOfChestPain = new ComboBox() { MinWidth = 100};
                this.RegisterName("ChildChestPain", ChildOfChestPain);
                ChildOfChestPain.HorizontalAlignment = HorizontalAlignment.Center;
                for (int i = 0; i < 4; i++) { ChildOfChestPain.Items.Add($"{nameOfCheckBox[i]}"); }
                options.Children.Add(ChildOfChestPain);
                Grid.SetRow(ChildOfChestPain, 1);
                ChildOfChestPain.SelectionChanged += ChildOfChestPain_SelectionChanged;
            }
        }

        private void ChildOfChestPain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] nameOfCheckBoxEN = { "A familiar pain", "Unrecognized sudden pain", "Pressing pain in the chest", "stabbing pains between the shoulder blades" };
            ComboBox? a = this.FindName("ChildChestPain") as ComboBox;
            int insexCohise = a.SelectedIndex;
            MessageBox.Show(insexCohise.ToString());
            symptomsList.Add(nameOfCheckBoxEN[insexCohise]);
        }

        private void canselChoise_ChestPain(object sender, RoutedEventArgs e)
        {

            ComboBox? a1 = this.FindName("ChildChestPain") as ComboBox;
            options.Children.Remove(a1);

        }



        private void ShortnessOfBreath_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string[] nameOfCheckBox = {  "ללא כאב"
                                        ,"נשימה מהירה",
                                         "רגיל" };

            if (ShortnessOfBreath.IsChecked == true)
            {
                ComboBox? ShortnessOfBreath = new ComboBox() { MinWidth = 100};
                this.RegisterName("ChildShortnessOfBreath", ShortnessOfBreath);
                ShortnessOfBreath.HorizontalAlignment = HorizontalAlignment.Center;

                for (int i = 0; i < 3; i++) { ShortnessOfBreath.Items.Add($"{nameOfCheckBox[i]}"); }
                options.Children.Add(ShortnessOfBreath);
                Grid.SetRow(ShortnessOfBreath, 2);
            }
        }



        private void Weakness_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string[] nameOfCheckBox = {"חולשה", "חולשה קיצונית"};

            if (Weakness.IsChecked == true)
            {
                ComboBox? Weakness = new ComboBox() { MinWidth = 100};
                this.RegisterName("ChildWeakness", Weakness);
                Weakness.HorizontalAlignment = HorizontalAlignment.Center;

                for (int i = 0; i < 2; i++) { Weakness.Items.Add($"{nameOfCheckBox[i]}"); }
                options.Children.Add(Weakness);
                Grid.SetRow(Weakness, 3);
            }
        }



        private void Sweating_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string[] nameOfCheckBox = { "הזעה פשוטה"
                                        ,"זיעה קרה",
                                         "רגיל" };

            if (Sweating.IsChecked == true)
            {
                ComboBox? Sweating = new ComboBox() { MinWidth = 100};
                this.RegisterName("ChildSweating", Sweating);
                Sweating.HorizontalAlignment = HorizontalAlignment.Center;

                for (int i = 0; i < 3; i++) { Sweating.Items.Add($"{nameOfCheckBox[i]}"); }
                options.Children.Add(Sweating);
                Grid.SetRow(Sweating, 4);
            }
        }



        private void Paleness_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // None, just: True / False.
        }

        private void NauseaAndVomiting_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // None, just: True / False.
        }

        private void Palpitations_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string[] nameOfCheckBox = { "דופק מהיר", "דןפק מהיר וחלש" };



            if (Palpitations.IsChecked == true)
            {
                ComboBox? Palpitations = new ComboBox() { MinWidth = 100};
                this.RegisterName("ChildPalpitations",Palpitations);
                Palpitations.HorizontalAlignment = HorizontalAlignment.Center;

                for (int i = 0; i < 2; i++) { Palpitations.Items.Add($"{nameOfCheckBox[i]}"); }
                options.Children.Add(Palpitations);
                Grid.SetRow(Palpitations, 7);
            }

        }
    }
}
