using WineNotesApp.ViewModels;

namespace WineNotesApp;

public partial class WineNoteEntryPage : ContentPage
{
    public WineNoteEntryPage()
    {
        InitializeComponent();

        BindingContext = new WineNoteCollectionViewModel();
    }
}
