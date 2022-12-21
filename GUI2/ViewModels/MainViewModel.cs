using GUI2.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI2.ViewModels;

internal class MainViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    public ViewModelBase? CurrentViewModel => _navigationStore.CurrentViewModel;
    public MainViewModel(NavigationStore navigationStore)
    {
        this._navigationStore = navigationStore;
        this._navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}
