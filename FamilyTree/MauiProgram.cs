using FamilyTree.View;
using UraniumUI;
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
                })
                .UseUraniumUI()  // Ensure UraniumUI is installed and referenced
              .UseUraniumUIMaterial(); // Ensure UraniumUI.Material is installed and referenced
            builder.Services.AddSingleton<MainPageView>();
            builder.Services.AddSingleton<MainPageViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
