using System.ComponentModel;
using System.Runtime.CompilerServices;
using CorrectionPenduMVVM.Models;
using CorrectionPenduMVVM.Services;

namespace CorrectionPenduMVVM.ViewModels;

public class LePenduViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private GenerateurMotService _generateurMotService;

    private Pendu _pendu;

    public LePenduViewModel(GenerateurMotService generateurMotService)
    {
        _generateurMotService = generateurMotService;
        _pendu = new Pendu(_generateurMotService);
    }

    public string Masque
    {
        get => _pendu.Masque;
    }

    public int NombreEssai
    {
        get => _pendu.NbEssaisRestants;
    }
    
    public char Lettre { get; set; }
    public string Message { get; set; }

    public void TesterLettre()
    {
        Message = _pendu.TestChar(Lettre);
        if (_pendu.TestWin())
        {
            Message = "Bravo";
        }

        Lettre = '\0';
        _pendu.GenererMasque();
        NotifyAllPropertiesChanged();
    }

    public void NotifyAllPropertiesChanged()
    {
        OnPropertyChanged(nameof(Message));
        // OnPropertyChanged(nameof(Masque));
        // OnPropertyChanged(nameof(NombreEssai));
        // OnPropertyChanged(nameof(Lettre));
    }
    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public void TestElement(int i)
    {
        Console.WriteLine(i);
    }
}