using CorrectionPenduMVVM.ViewModels;
using Microsoft.AspNetCore.Components;

namespace CorrectionPenduMVVM.Views;

public partial class  LePenduView
{
    [Inject]
    public LePenduViewModel ViewModel { get; set; }

    protected override void OnInitialized()
    {
        ViewModel.PropertyChanged += (sender, e) =>
        {
            StateHasChanged();
        };
    }
}