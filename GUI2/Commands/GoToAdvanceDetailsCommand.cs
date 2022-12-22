using System.ComponentModel;
using GUI2.Services;
using GUI2.ViewModels;

namespace GUI2.Commands;

public class GoToAdvanceDetailsCommand:BaseCommand
{
    private readonly BasicInfoViewModel _model;
    private readonly NavigationService _navigationService;
    public GoToAdvanceDetailsCommand(BasicInfoViewModel model, NavigationService navigationService)
    {
        _model = model;
        _navigationService = navigationService;
        _model.PropertyChanged += ModelOnPropertyChanged;
    
    }

    private void ModelOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        OnCanExecutedChanged();
    }

    public override bool CanExecute(object? parameter)
    {
        if (!string.IsNullOrEmpty(_model.City) &&
            !string.IsNullOrEmpty(_model.Age) && !string.IsNullOrEmpty(_model.Street) &&
            !string.IsNullOrEmpty(_model.HouseNumber) && !string.IsNullOrEmpty(_model.Gender))
        {
            return true;
        }

        return false;
    }
    public override void Execute(object? parameter)
    {
        
    }
}