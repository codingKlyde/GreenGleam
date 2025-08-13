namespace GreenGleam.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<CartService>();


            ConfigureRefit(builder.Services);

            return builder.Build();
        }

        private static void ConfigureRefit(IServiceCollection services)
        {
            const string baseApiUrl = "https://tp0q42bc-7102.asse.devtunnels.ms";

            static void SetHttpclient(HttpClient httpClient) => httpClient.BaseAddress = new Uri(baseApiUrl);

            static RefitSettings GetRefitSettings(IServiceProvider serviceProvider)
            {
                var settings = new RefitSettings();
                settings.AuthorizationHeaderValueGetter = (_, __) => Task.FromResult("TOKEN");
                return settings;
            }

            services.AddRefitClient<IAuthApi>().ConfigureHttpClient(SetHttpclient);
            services.AddRefitClient<IProductApi>().ConfigureHttpClient(SetHttpclient);
            services.AddRefitClient<IOrderApi>(GetRefitSettings).ConfigureHttpClient(SetHttpclient);
            services.AddRefitClient<IUserApi>(GetRefitSettings).ConfigureHttpClient(SetHttpclient);
        }
    }
}