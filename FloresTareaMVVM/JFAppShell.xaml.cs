namespace FloresTareaMVVM
{
    public partial class JFAppShell : Shell
    {
        public JFAppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.JFNotePage), typeof(Views.JFNotePage));

        }
    }
}
