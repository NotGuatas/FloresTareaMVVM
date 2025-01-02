namespace FloresTareaMVVM.Views;

public partial class JFAllNotesPage : ContentPage
{
	public JFAllNotesPage()
	{
		InitializeComponent();

        BindingContext = new Models.JFAllNotes();

    }
    protected override void OnAppearing()
    {
        ((Models.JFAllNotes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(JFNotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.JFNote)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(JFNotePage)}?{nameof(JFNotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }

}