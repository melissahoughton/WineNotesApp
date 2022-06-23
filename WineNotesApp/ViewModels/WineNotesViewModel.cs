using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WineNotesApp.Models;

namespace WineNotesApp.ViewModels;
public class WineNotesViewModel : INotifyPropertyChanged
{
    private ObservableCollection<WineNote> _wineNotes = new();

    public ObservableCollection<WineNote> WineNotes {
        get => _wineNotes;
        set
        {
            _wineNotes = value;
            OnPropertyChanged(nameof(WineNotes));
        }
    }

    public Command<WineNote> SubmitWineNote { get; set; }

    public WineNotesViewModel()
    {
        SubmitWineNote = new Command<WineNote>(OnSubmitWineNote);
    }

    private void OnSubmitWineNote(WineNote wineNote)
    {
        _wineNotes.Add(wineNote);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
    }
}
