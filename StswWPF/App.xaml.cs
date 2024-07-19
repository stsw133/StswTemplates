global using StswExpress;
using System.Windows;

namespace StswWPF;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : StswApp
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        /// set this if you need encrypting/decrypting/hashing
        //StswSecurity.Key = "myOwnStswHashKey"; /// needs 16 characters

        /// example for importing encrypted databases from app directory
        //StswDatabases.ImportList();
        //StswDatabases.Current = StswDatabases.List.FirstOrDefault() ?? new();

        /// example for global command
        //var commandBinding = new RoutedUICommand("Help", "Help", typeof(StswWindow), new InputGestureCollection() { new KeyGesture(Key.F1) });
        //CommandManager.RegisterClassCommandBinding(typeof(StswWindow), new CommandBinding(commandBinding, (s, e) => OpenHelp()));

        /// example for removing language from config:
        StswTranslator.AvailableLanguages = ["pl"];
        StswSettings.Default.Language = "pl";
        /// example for removing theme from config:
        //StswResources.AvailableThemes.Remove(StswTheme.Auto);
        //StswResources.AvailableThemes.Remove(StswTheme.Pink);
        //StswSettings.Default.Theme = (int)StswTheme.Dark;
    }

    /// add this event if you want log unhandled exceptions
    //private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) => StswLog.Write(StswInfoType.Error, e.Exception.ToString());

    //private void OpenHelp() => StswFn.OpenFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\tutorial.pdf"));
}
