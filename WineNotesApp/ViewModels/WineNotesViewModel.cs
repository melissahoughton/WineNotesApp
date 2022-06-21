using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WineNotesApp.Models;

namespace WineNotesApp.ViewModels;
public class WineNotesViewModel : INotifyPropertyChanged
{
    private List<WineNote> _wineNotes;

    public List<WineNote> WineNotes {
        get => _wineNotes;
        set
        {
            _wineNotes = value;
            OnPropertyChanged(nameof(WineNotes));
        }
    }

    public Command SubmitWineNote { get; set; }

    public WineNotesViewModel()
    {
        SubmitWineNote = new Command<WineNote>(OnSubmitWineNote);
    }

    private void OnSubmitWineNote(WineNote wineNote)
    {
        WineNotes.Add(wineNote);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
    }
}
