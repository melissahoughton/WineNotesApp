using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WineNotesApp.ViewModels;

public class WineNoteCollectionViewModel : BaseViewModel
{
    private WineNoteViewModel wineNoteEdit;
    private bool isEditing = false;

    public WineNoteCollectionViewModel()
    {
        NewCommand = new Command(
            execute: () =>
            {
                WineNoteEdit = new WineNoteViewModel();
                WineNoteEdit.PropertyChanged += OnWineNoteEditPropertyChanged;
                IsEditing = true;
                RefreshCanExecutes();
            },
            canExecute: () =>
            {
                return !IsEditing;
            });

        SubmitCommand = new Command(
            execute: () =>
            {
                WineNoteEdit.PropertyChanged -= OnWineNoteEditPropertyChanged;
                WineNotes.Add(WineNoteEdit);
                WineNoteEdit = null;
                IsEditing = false;
                RefreshCanExecutes();
            },
            canExecute: () =>
            {
                return WineNoteEdit is not null && WineNoteEdit.WineId is not null && WineNoteEdit.Notes is not null;
            });

        CancelCommand = new Command(
            execute: () =>
            {
                WineNoteEdit.PropertyChanged -= OnWineNoteEditPropertyChanged;
                WineNoteEdit = null;
                IsEditing = false;
                RefreshCanExecutes();
            },
            canExecute: () =>
            {
                return IsEditing;
            }); 
    }

    void OnWineNoteEditPropertyChanged(object sender, PropertyChangedEventArgs args)
    {
        (SubmitCommand as Command).ChangeCanExecute();
    }

    void RefreshCanExecutes()
    {
        (NewCommand as Command).ChangeCanExecute();
        (SubmitCommand as Command).ChangeCanExecute();
        (CancelCommand as Command).ChangeCanExecute();
    }

    public bool IsEditing
    {
        private set { SetProperty(ref isEditing, value); }
        get { return isEditing; }
    }

    public WineNoteViewModel WineNoteEdit
    {
        set { SetProperty(ref wineNoteEdit, value); }
        get { return wineNoteEdit; }
    }

    public ICommand NewCommand { private set; get; }

    public ICommand SubmitCommand { private set; get; }

    public ICommand CancelCommand { private set; get; }

    public IList<WineNoteViewModel> WineNotes { get; } = new ObservableCollection<WineNoteViewModel>();

    bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
    {
        if (Object.Equals(storage, value))
            return false;

        storage = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}

