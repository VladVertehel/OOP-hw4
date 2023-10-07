using Microsoft.Extensions.Logging;

namespace Task5
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

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }

    public class Good
    {
        public double Price { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }

    public class Products : Good
    {
        public string Expiration { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
    }

    public class Books : Good
    {
        public int Pages { get; set; }
        public string Publishing { get; set; }
        public string Author { get; set; }
    }

}