using System.Windows;
using System.Windows.Controls;
using GUI2.ViewModels;

namespace GUI2.Views;

public partial class BasicInfoView : UserControl
{
    public BasicInfoView()
    {
        InitializeComponent();
    }

    private void RadioButtonGroupChoiceChip_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var viewmodel = (BasicInfoViewModel)DataContext;
        if (RadioButtonGroupChoiceChip.SelectedIndex != -1)
        {
            viewmodel.Gender =
                (RadioButtonGroupChoiceChip.Items[RadioButtonGroupChoiceChip.SelectedIndex] as ListBoxItem).Content
                .ToString();
        }
        else
        {
            viewmodel.Gender = "";
        }
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var b = sender as Button;
        b.Content = "כונן הוזעק";
    }
}