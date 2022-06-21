using WineNotesApp.ViewModels;

namespace WineNotesApp;

public partial class MainPage : ContentPage
{
    private string _wineId = string.Empty;
    private string _notes = string.Empty;

    public MainPage()
    {
        InitializeComponent();

        BindingContext = new WineNotesViewModel();
    }

    // Raised on each text event
    private void OnWineIdChanged(object sender, TextChangedEventArgs e)
    {
        _wineId = WineIdEntry.Text;
    }

    // Raised on return or tab key
    private void OnWineIdEntryCompleted(object sender, EventArgs e)
    {
        _wineId = ((Entry)sender).Text;
    }

    private void OnNotesChanged(object sender, EventArgs e)
    {
        _notes = NotesEditor.Text;
    }

    private void OnNotesEditorCompleted(object sender, EventArgs e)
    {
        _notes = ((Editor)sender).Text;
    }
}

