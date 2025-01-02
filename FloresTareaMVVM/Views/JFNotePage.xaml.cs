namespace FloresTareaMVVM.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class JFNotePage : ContentPage
{
    public string ItemId
    {
        set { LoadNote(value); }
    }

    public JFNotePage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    private void LoadNote(string fileName)
    {
        Models.JFNote noteModel = new Models.JFNote();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.JFNote note)
            File.WriteAllText(note.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.JFNote note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }
}