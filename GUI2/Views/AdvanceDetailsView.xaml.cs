using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GUI2.ViewModels;
using Data_Analysis;
namespace GUI2.Views;

public partial class AdvanceDetailsView : UserControl
{
    public AdvanceDetailsView()
    {
        InitializeComponent();
    }

    // private void Selector1_OnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
    // {
    //     var viewmodel = (AdvanceDetailsViewModel)DataContext;
    //     if (Selector1.SelectedIndex != -1)
    //     {
    //         //viewmodel.ChestPain = (selector1.Items[selector1.SelectedIndex] as ListBoxItem).Name;
    //     }
    //     else
    //     {
    //         viewmodel.ChestPain = "";
    //     }
    // }
    //
    // private void Selector2_OnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
    // {
    //     var viewmodel = (AdvanceDetailsViewModel)DataContext;
    //     if (Selector2.SelectedIndex != -1)
    //     {
    //         //viewmodel.Sweat = (selector2.Items[selector2.SelectedIndex] as ListBoxItem).Name;
    //     }
    //     else
    //     {
    //         viewmodel.Sweat = "";
    //     }
    // }
    //
    // private void Selector3_OnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
    // {
    //     var viewmodel = (AdvanceDetailsViewModel)DataContext;
    //     if (Selector3.SelectedIndex != -1)
    //     {
    //         //viewmodel.RadiatingPain = (selector3.Items[selector3.SelectedIndex] as ListBoxItem).Name;
    //     }
    //     else
    //     {
    //         viewmodel.RadiatingPain = "";
    //     }
    // }
    //
    // private void Selector4_OnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
    // {
    //     var viewmodel = (AdvanceDetailsViewModel)DataContext;
    //     if (Selector4.SelectedIndex != -1)
    //     {
    //         //viewmodel.Weakness = (selector4.Items[selector4.SelectedIndex] as ListBoxItem).Name;
    //     }
    //     else
    //     {
    //         viewmodel.Weakness = "";
    //     }
    // }
    //
    // private void Selector5_OnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
    // {
    //     var viewmodel = (AdvanceDetailsViewModel)DataContext; 
    //     if (Selector5.SelectedIndex != -1)
    //     {
    //         //viewmodel.BreathShort = (Selector5.Items[Selector5.SelectedIndex] as ListBoxItem).Name;;
    //     }
    //     else
    //     {
    //         viewmodel.BreathShort = "";
    //     }
    // }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs routedEventArgs)
    {
        var list = new List<string>();
        try
        {
            if (Selector1.SelectedIndex > 0)
            {
                list.Add((Selector1.Items[Selector1.SelectedIndex] as ListBoxItem).Name);
            }
            if (Selector2.SelectedIndex > 0)
            {
                list.Add((Selector2.Items[Selector2.SelectedIndex] as ListBoxItem).Name);
            }
            if (Selector3.SelectedIndex > 0)
            {
                list.Add((Selector3.Items[Selector3.SelectedIndex] as ListBoxItem).Name);
            }
            if (Selector4.SelectedIndex > 0)
            {
                list.Add((Selector4.Items[Selector4.SelectedIndex] as ListBoxItem).Name);
            }
            if (Selector5.SelectedIndex > 0)
            {
                list.Add((Selector5.Items[Selector5.SelectedIndex] as ListBoxItem).Name);
            }
            var l = Selector6.SelectedItems;
            foreach (var item in l)
            {
                var Item = item as ListBoxItem;
                list.Add(Item.Name);
            }
            var dict = new Dictionary<string, string>();
            dict.Add("A","טרשת עורקים, לא דחוף.");
            dict.Add("B","תעוקת חזה יציבה, לא דחוף.");
            dict.Add("C","תעוקת חזה לא יציבה. דחוף! נט\"ן הושבה והרגעה, אספירין (שלילת התוויות נגד).");
            dict.Add("D","אוטם בשריר הלב (התקף לב). דחוף! נט\"ן הושבה והרגעה, אספירין ( שלילת התוויות נגד).");
            dict.Add("E","אוטם שקט דחוף! נט\"ן הושבה והרגעה, אספירין ( שלילת התוויות נגד).");
            dict.Add("F","בצקת ריאות, דחוף! נט\"ן, השכבה.");
            dict.Add("G","הלם לבבי, דחוף! נט\"ן, השכבה.");
            dict.Add("H","אי ספיקת לב ימין, נט\"ן בשיקול דעתך");
            dict.Add("I","דיסקציה של האאורטה, דחוף! נט\"ן.");
            Analysis a = new Analysis();
            a.TryToDiagnose(list);
            var x = a.MakeADecision();
            Result.Text = dict[x.Question];
        }
        catch (Exception exception)
        {
            Result.Text = "חסרים נתונים מספיקים";
        }
        

        

        
    }
}