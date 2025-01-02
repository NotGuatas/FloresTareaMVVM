namespace FloresTareaMVVM.Views;

public partial class JFAllNotesPage : ContentPage
{
	public JFAllNotesPage()
	{
		InitializeComponent();
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        notesCollection.SelectedItem = null;
    }
}
