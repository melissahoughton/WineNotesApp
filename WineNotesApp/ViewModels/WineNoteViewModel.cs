using System.Runtime.CompilerServices;

namespace WineNotesApp.ViewModels;

public class WineNoteViewModel : BaseViewModel {
    private string _wineId;
    private string _notes;
    private DateTime _date = DateTime.Now;

    public string WineId {
        get => _wineId;
        set { SetProperty(ref _wineId, value); }
    }

    public string Notes {
        get => _notes;
        set { SetProperty(ref _notes, value); }
    }

    public DateTime Date
    {
        get => _date;
        set { SetProperty(ref _date, value); }
    }

    private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
    {
        if (Object.Equals(storage, value))
            return false;

        storage = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
