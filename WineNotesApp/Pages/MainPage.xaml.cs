using WineNotesApp.Models;
using WineNotesApp.ViewModels;

namespace WineNotesApp;

public partial class MainPage : ContentPage
{
    public WineNote wineNote = new();

    public MainPage()
    {
        InitializeComponent();

        BindingContext = new WineNotesViewModel();
    }

    // Raised on each text event
    private void OnWineIdChanged(object sender, TextChangedEventArgs e)
    {
        wineNote.WineId = WineIdEntry.Text;
    }

    // Raised on return or tab key
    private void OnWineIdEntryCompleted(object sender, EventArgs e)
    {
        wineNote.WineId = ((Entry)sender).Text;
    }

    private void OnNotesChanged(object sender, EventArgs e)
    {
        wineNote.Notes = NotesEditor.Text;
    }

    private void OnNotesEditorCompleted(object sender, EventArgs e)
    {
        wineNote.Notes = ((Editor)sender).Text;
    }
}

