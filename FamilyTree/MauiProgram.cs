using FamilyTree.View;
using FamilyTree.ViewModel;
using Microsoft.Extensions.Logging;

namespace FamilyTree
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
            builder.Services.AddSingleton<MainPageView>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<RelationPageViewModel>();
            builder.Services.AddSingleton<RelationPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
