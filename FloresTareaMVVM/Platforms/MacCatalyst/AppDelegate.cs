using Foundation;

namespace FloresTareaMVVM
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => JFMauiProgram.CreateMauiApp();
    }
}
