using System.Windows.Controls;
using System.Windows.Input;
using GUI2.Commands;
using GUI2.Services;
using GUI2.Stores;

namespace GUI2.ViewModels;

public class BasicInfoViewModel : ViewModelBase
{
    private string? _name = null;
    private string? _street;
    private string? _houseNumber;
    private string? _city = null;
    private string? _age;
    private string? _phone;
    private string? _gender;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(_name));
        }
        
    }
    public string Street
    {
        get => _street;
        set
        {
            _street = value;
            OnPropertyChanged(nameof(_street));
        }
        
    }
    public string HouseNumber
    {
        get => _houseNumber;
        set
        {
            _houseNumber = value;
            OnPropertyChanged(nameof(_houseNumber));
        }
        
    }
    public string City
    {
        get => _city;
        set
        {
            _city = value;
            OnPropertyChanged(nameof(_city));
        }
        
    }
    public string Age
    {
        get => _age;
        set
        {
            _age = value;
            OnPropertyChanged(nameof(_age));
        }
        
    }
    public string Phone
    {
        get => _phone;
        set
        {
            _phone = value;
            OnPropertyChanged(nameof(_phone));
        }
        
    }
    public string Gender
    {
        get => _gender;
        set
        {
            _gender = value;
            OnPropertyChanged(nameof(_gender));
        }
        
    }

    public ICommand GoToAdvanceDetailsCommand
    {
        get;
    }
    public BasicInfoViewModel(NavigationStore navigationStore)
    {
        GoToAdvanceDetailsCommand = new GoToAdvanceDetailsCommand(this, new NavigationService(navigationStore, () =>new AdvanceDetailsViewModel(navigationStore)));
    }
}