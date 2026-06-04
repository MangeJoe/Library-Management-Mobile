using Microsoft.Extensions.Logging;
using OnlineLibrary.ViewModels;
using OnlineLibrary.Views;

namespace OnlineLibrary
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            /* f your ViewModel has a parameterless constructor and does not require complex services, 
             * you can instantiate it directly inside your XAML layout file*/

            builder.Services.AddSingleton<HttpClient>();

            /* f your ViewModel has a parameterless constructor and does not require complex services, 
           * you can instantiate it directly inside your XAML layout file*/
       
         builder.Services.AddTransient<RegisterViewModel>();
         //  builder.Services.AddTransient<RegisterPage>();

            //  builder.Services.AddTransient<LoginPage>();
            //    builder.Services.AddTransient<LoginViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
