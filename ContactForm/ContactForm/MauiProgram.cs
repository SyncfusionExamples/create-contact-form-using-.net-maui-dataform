using Syncfusion.Maui.Core.Hosting;

namespace ContactForm;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.ConfigureSyncfusionCore();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				//// Register custom font label 
                fonts.AddFont("InputLayoutIcons.ttf", "InputLayoutIcons");
            });

		return builder.Build();
	}
}
