using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GUI2.Stores;
using GUI2.ViewModels;

namespace GUI2;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly NavigationStore _navigationStore;
    private LogsViewModel _logsViewModel;
    public App()
    {
        _navigationStore = new NavigationStore();
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        _navigationStore.CurrentViewModel = new BasicInfoViewModel(_navigationStore);
        _navigationStore.SecondViewModel = new AdvanceDetailsViewModel(_navigationStore);
        MainWindow = new MainWindow(_navigationStore, _logsViewModel) 
        { 
            DataContext = new MainViewModel(_navigationStore) 
        };
        MainWindow.Show();
        base.OnStartup(e);
    }
}
