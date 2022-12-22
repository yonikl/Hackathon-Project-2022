using GUI2.Stores;
using GUI2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI2.Services;

public class NavigationService
{
    private readonly NavigationStore _navigationStore;
    private readonly Func<ViewModelBase> _createViewModel;
    public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
    {
        this._navigationStore = navigationStore;
        this._createViewModel = createViewModel;
    }

    public void Navigate()
    {
        _navigationStore.CurrentViewModel = _createViewModel();
    }
}
