using GUI2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI2.Stores;

public class NavigationStore
{
    private ViewModelBase? _currentViewModel;
    private ViewModelBase? _secondViewModel;
    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    public ViewModelBase? SecondViewModel
    {
        get => _secondViewModel;
        set
        {
            _secondViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    public event Action? CurrentViewModelChanged;
    private void OnCurrentViewModelChanged() 
    {
        CurrentViewModelChanged?.Invoke();
    }
}
