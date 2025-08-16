namespace GreenGleam.App
{
    public partial class App : Application
    {
        private readonly AppState _appState;

        public App(AppState appState)
        {
            InitializeComponent();
            _appState = appState;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage(_appState)) { Title = "GreenGleam.App" };
        }
    }
}