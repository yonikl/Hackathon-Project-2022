using GUI2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI2.Commands;

internal class NavigationCommand : BaseCommand
{
    private readonly NavigationService _navigationService;
    public NavigationCommand(NavigationService navigationService)
    {
        this._navigationService = navigationService;
    }

    public override void Execute(object? parameter)
    {
        this._navigationService.Navigate();
    }
}
