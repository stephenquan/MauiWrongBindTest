using Microsoft.Extensions.Logging;

namespace MauiWrongBindTest;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
        //builder.Logging.AddProvider(new MauiToWinUiBindingDiagnosticsProvider());
#endif

        builder.Services.AddTransient<MainPage>();

        Routing.RegisterRoute(nameof(SecondPage), typeof(SecondPage));

        return builder.Build();
    }
}
