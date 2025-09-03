namespace GreenGleam.App
{
    public partial class App : Application
    {
        private readonly AppState _appState;
        private readonly LocalDataContext _localDataContext;
        private readonly CartService _cartService;

        public App(AppState appState, LocalDataContext localDataContext ,CartService cartService)
        {
            InitializeComponent();
            _appState = appState;
            _localDataContext = localDataContext;
            _cartService = cartService;
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await _localDataContext.InitializeDatabaseAsync();
            await _cartService.InitializeCartAsync();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage(_appState)) { Title = "GreenGleam.App" };
        }
    }
}