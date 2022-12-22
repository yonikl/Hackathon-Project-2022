using System.Collections.Generic;
using GUI2.Stores;

namespace GUI2.ViewModels;

public class AdvanceDetailsViewModel:ViewModelBase
{
    private NavigationStore _navigationStore;
    public AdvanceDetailsViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
    }

    private string? _chestPain;
    private string? _sweat;
    private string? _radiatingPain;
    private string? _weakness;
    private string? _breathShort;
    private List<string> _general;

    public string ChestPain
    {
        get => _chestPain;
        set
        {
            _chestPain = value;
            OnPropertyChanged(nameof(_chestPain));
        }
    }

    public string Sweat
    {
        get => _sweat;
        set
        {
            _sweat = value;
            OnPropertyChanged(nameof(_sweat));
        }
    }
    public string RadiatingPain
    {
        get => _radiatingPain;
        set
        {
            _radiatingPain = value;
            OnPropertyChanged(nameof(_radiatingPain));
        }
    }
    public string Weakness
    {
        get => _weakness;
        set
        {
            _weakness = value;
            OnPropertyChanged(nameof(_weakness));
        }
    }
    public string BreathShort
    {
        get => _breathShort;
        set
        {
            _breathShort = value;
            OnPropertyChanged(nameof(_breathShort));
        }
    }

}