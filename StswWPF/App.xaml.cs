global using StswExpress;
using System.Windows;

namespace StswWPF;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : StswApp
{
    public IServiceProvider? ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        /// example for global command
        // var commandBinding = new RoutedUICommand("Help", "Help", typeof(StswWindow), new InputGestureCollection() { new KeyGesture(Key.F1) });
        // CommandManager.RegisterClassCommandBinding(typeof(StswWindow), new CommandBinding(commandBinding, (s, e) => OpenHelp()));

        /// example for removing language from config:
        StswTranslator.AvailableLanguages = ["pl"];
        StswSettings.Default.Language = "pl";

        /// example for removing theme from config:
        // StswResources.AvailableThemes.Remove(StswTheme.Auto);
        // StswResources.AvailableThemes.Remove(StswTheme.Pink);
        // StswSettings.Default.Theme = (int)StswTheme.Dark;

        /// Dependency Injection implementation
        // var serviceCollection = new ServiceCollection();
        // ConfigureServices(serviceCollection);
        // Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        // ServiceProvider = serviceCollection.BuildServiceProvider();
        // MainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        // MainWindow.Show();
    }

    /// Dependency Injection implementation
    // private void ConfigureServices(ServiceCollection serviceCollection)
    // {
    //     /// Views
    //     serviceCollection.AddSingleton<MainWindow>();
    // 
    //     /// Contexts
    //     serviceCollection.AddSingleton<MainContext>();
    // 
    //     /// Services
    //     serviceCollection.AddSingleton<ISQL, SQL>();
    // 
    //     /// Stores
    //     serviceCollection.AddSingleton<ExampleStore>();
    // }
    
    /// add this event if you want log unhandled exceptions
    // private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) => StswLog.Write(StswInfoType.Error, e.Exception.ToString());

    // private void OpenHelp() => StswFn.OpenFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\tutorial.pdf"));
}
