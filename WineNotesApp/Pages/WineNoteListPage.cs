using CommunityToolkit.Maui.Markup;
using WineNotesApp.ViewModels;

namespace WineNotesApp.Pages;

public class WineNoteListPage : ContentPage
{
    public WineNoteCollectionViewModel WineNoteCollectionViewModel { get; set; }

    public WineNoteListPage()
    {
        BindingContext = WineNoteCollectionViewModel = new WineNoteCollectionViewModel();
        Content = new ScrollView
        {
            Content = new VerticalStackLayout
            {
                Children =
                {
                    new Image { Source = "jjw_black.svg", WidthRequest = 300, HorizontalOptions = LayoutOptions.Center },
                    new Label { Text = "Wine Notes", FontSize = 18, HorizontalOptions = LayoutOptions.Center },
                    new Button { Text = "New", HorizontalOptions = LayoutOptions.Start }.Bind(Button.CommandProperty, nameof(WineNoteCollectionViewModel.NewCommand)),
                    new VerticalStackLayout
                    {
                        Children =
                        {
                            new Entry 
                            { 
                                Placeholder = "Enter wine id"
                            }
                            .Bind(Entry.TextProperty, nameof(WineNoteCollectionViewModel.WineNoteEdit.WineId)),
                            new DatePicker {}
                            .Bind(DatePicker.DateProperty, nameof(WineNoteCollectionViewModel.WineNoteEdit.Date)),
                            new Editor 
                            {
                                Placeholder = "Enter your notes here",
                                HeightRequest = 150
                            }
                            .Bind(Editor.TextProperty, nameof(WineNoteCollectionViewModel.WineNoteEdit.Notes)),
                            new Grid 
							{
								ColumnDefinitions = 
								{
									new ColumnDefinition { Width = GridLength.Star },
									new ColumnDefinition { Width = GridLength.Star },
                                    new ColumnDefinition { Width = GridLength.Star }
                                },
								Children =
								{
									new Button { Text = "Submit" }
									.Bind(Button.CommandProperty, nameof(WineNoteCollectionViewModel.SubmitCommand))
									.Column(0),
									new Button { Text = "Cancel" }
									.Bind(Button.CommandProperty, nameof(WineNoteCollectionViewModel.CancelCommand))
									.Column(2)
								}
							}
						}
					}
					.Bind(IsVisibleProperty, nameof(WineNoteCollectionViewModel.IsEditing)),
					new ListView
					{
						ItemTemplate = new DataTemplate(() =>
						{
							return new TextCell
							{
								Text = "{Binding WineId}"
							};
						})
					}
					.Bind(ListView.ItemsSourceProperty, nameof(WineNoteCollectionViewModel.WineNotes))
				},
				Spacing = 25,
				VerticalOptions = LayoutOptions.Center
			}
			.Padding(30, 0)
		};
    }
}