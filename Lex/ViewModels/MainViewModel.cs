using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using Lex_Core.Features;
using System;
using System.Threading.Tasks;

namespace Lex.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IMediator _mediator;

    [ObservableProperty]
    private string _statusMessage = "Click the button to check status...";

    public MainViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [RelayCommand]
    private async Task CheckStatus()
    {
        try
        {
            StatusMessage = "Checking status...";
            var result = await _mediator.Send(new GetSystemStatusQuery());
            StatusMessage = result;
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }
}
