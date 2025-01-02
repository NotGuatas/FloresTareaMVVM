namespace FloresTareaMVVM.Views;

public partial class JFAboutPage : ContentPage
{
	public JFAboutPage()
	{
		InitializeComponent();
    }

    private async void LearnMore_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is Models.JFAbout about)
            {
                // Navigate to the specified URL in the system browser.
                await Launcher.Default.OpenAsync(about.MoreInfoUrl);
            }
         }
}