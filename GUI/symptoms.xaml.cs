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
        string[] nameOfCheckBoxSbEN = { "without pain", "quick breathing", "None" };
        string[] nameOfCheckBoxCpEN = { "A familiar pain", "Unrecognized sudden pain", "Pressing pain in the chest", "stabbing pains between the shoulder blades", "None" };
        string[] nameOfCheckBoxWEN = { "general weakness", "extreme weakness"};
        string[] nameOfCheckBoxSEN = { "Normal Sweating", "Cold Sweating"};
        string[] nameOfCheckBoxPEN = { "Fast palpitations", "Fast palpitations and week" };



        /// <summary>
        /// ChestPain symptoms.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChestPain_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (ChestPain.IsChecked == true)
            {
                ComboBox? childCP = this.FindName("ChildChestPain") as ComboBox;
                childCP.SelectionChanged += ChildOfChestPain_SelectionChanged;
                childCP.Visibility = Visibility.Visible;
            }
        }


        /// <summary>
        /// ShortnessOfBreath symptom.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ShortnessOfBreath_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (ShortnessOfBreath.IsChecked == true)
            {
                ComboBox? childSB = this.FindName("ChildShortnessOfBreath") as ComboBox;
                childSB.Visibility = Visibility.Visible;
                childSB.SelectionChanged += ChildShortnessOfBreath_SelectionChanged;
            }
        }
        /// <summary>
        /// Weakness symptom.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Weakness_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Weakness.IsChecked == true)
            {
                ComboBox? childW = this.FindName("ChildWeakness") as ComboBox;
                childW.Visibility = Visibility.Visible;
                childW.SelectionChanged += ChildWeakness_SelectionChanged;
            }
        }

        /// <summary>
        /// Sweating symptom.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sweating_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Sweating.IsChecked == true)
            {
                ComboBox? childS = this.FindName("ChildSweating") as ComboBox;
                childS.Visibility = Visibility.Visible;
                childS.SelectionChanged += ChildSweating_SelectionChanged;
            }
        }



        private void Paleness_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // None, just: True / False.
            if (Paleness.IsChecked == true)
            {
                symptomsList.Add("Paleness");
            }

        }

        private void NauseaAndVomiting_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // None, just: True / False.
            if (NauseaAndVomiting.IsChecked == true)
            {
                symptomsList.Add("Nausea and Vomiting");
            }
        }

        private void Palpitations_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Palpitations.IsChecked == true)
            {
                ComboBox? childP = this.FindName("ChildPalpitations") as ComboBox;
                childP.Visibility = Visibility.Visible;
                childP.SelectionChanged += ChildPalpitations_SelectionChanged;
            }

        }


        // ------------------------------------------->> Child CombobBox<<---------------------------------------------------

        private void ChildOfChestPain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox? temp = this.FindName("ChildChestPain") as ComboBox;
            int insexCohise = temp.SelectedIndex;
            symptomsList.Add(nameOfCheckBoxCpEN[insexCohise]);
        }

        private void ChildShortnessOfBreath_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox? temp = this.FindName("ChildShortnessOfBreath") as ComboBox;
            int insexCohise = temp.SelectedIndex;
            symptomsList.Add(nameOfCheckBoxSbEN[insexCohise]);
        }

        private void ChildWeakness_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox? temp = this.FindName("ChildWeakness") as ComboBox;
            int insexCohise = temp.SelectedIndex;
            symptomsList.Add(nameOfCheckBoxWEN[insexCohise]);
        }

        private void ChildSweating_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox? temp = this.FindName("ChildSweating") as ComboBox;
            int insexCohise = temp.SelectedIndex;
            MessageBox.Show(insexCohise.ToString());
            symptomsList.Add(nameOfCheckBoxSEN[insexCohise]);
        }

        private void ChildPalpitations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox? temp = this.FindName("ChildPalpitations") as ComboBox;
            int insexCohise = temp.SelectedIndex;
            symptomsList.Add(nameOfCheckBoxPEN[insexCohise]);
        }


        // ------------------------------------------->> Cancel Choise <<---------------------------------------------------
        private void cancelChoise_ChestPain(object sender, RoutedEventArgs e)
        {

            ComboBox? temp = this.FindName("ChildChestPain") as ComboBox;
            temp.Visibility = Visibility.Hidden;
            int insexCohise = temp.SelectedIndex;
            symptomsList.Remove(nameOfCheckBoxCpEN[insexCohise]);

        }

        private void cancelChoise_ShortnessOfBreath(object sender, RoutedEventArgs e)
        {
            ComboBox? temp = this.FindName("ChildShortnessOfBreath") as ComboBox;
            temp.Visibility = Visibility.Hidden;
            int insexCohise = temp.SelectedIndex;
            symptomsList.Remove(nameOfCheckBoxSbEN[insexCohise]);
        }

        private void cancelChoise_Weakness(object sender, RoutedEventArgs e)
        {
            ComboBox? temp = this.FindName("ChildWeakness") as ComboBox;
            temp.Visibility = Visibility.Hidden;
            int insexCohise = temp.SelectedIndex;
            symptomsList.Remove(nameOfCheckBoxWEN[insexCohise]);
        }

        private void cancelChoise_Sweating(object sender, RoutedEventArgs e)
        {
            ComboBox? temp = this.FindName("ChildSweating") as ComboBox;
            temp.Visibility = Visibility.Hidden;
            int insexCohise = temp.SelectedIndex;
            symptomsList.Remove(nameOfCheckBoxSEN[insexCohise]);
        }

        private void cancelChoise_Paleness(object sender, RoutedEventArgs e)
        {
            symptomsList.Remove("Paleness");
        }

        private void cancelChoise_NauseaAndVomiting(object sender, RoutedEventArgs e)
        {
            symptomsList.Remove("Nausea and Vomiting");
        }

        private void cancelChoise_Palpitations(object sender, RoutedEventArgs e)
        {
            ComboBox? temp = this.FindName("ChildPalpitations") as ComboBox;
            temp.Visibility = Visibility.Hidden;
            int insexCohise = temp.SelectedIndex;
            symptomsList.Remove(nameOfCheckBoxPEN[insexCohise]);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in symptomsList)
            {
                MessageBox.Show(item.ToString());
            }
        }
    }
}
