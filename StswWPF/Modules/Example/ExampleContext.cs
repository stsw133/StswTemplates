namespace StswWPF;
public class ExampleContext : StswObservableObject
{
    /// <summary>
    /// Example command
    /// </summary>
    public StswCommand<object?> Example1Command { get; set; }
    public StswAsyncCommand<object?> Example2Command { get; set; }

    public ExampleContext()
    {
        Example1Command = new(Example1, Example1Condition);
        Example2Command = new(Example2, Example2Condition);
    }

    #region Commands & methods
    /// <summary>
    /// Example method 1 for sync command
    /// </summary>
    /// <param name="value">Example value</param>
    private void Example1(object? value)
    {
        try
        {
            // do something here
            ;
        }
        catch (Exception ex)
        {
            StswMessageDialog.Show(ex, $"Błąd metody {nameof(Example2)}");
        }
    }
    private bool Example1Condition() => true;

    /// <summary>
    /// Example method 2 for async command
    /// </summary>
    /// <param name="value">Example value</param>
    private async Task Example2(object? value)
    {
        try
        {
            // do something here
            await Task.Run(() => Thread.Sleep(10));
        }
        catch (Exception ex)
        {
            await StswMessageDialog.Show(ex, $"Błąd metody {nameof(Example2)}");
        }
    }
    private bool Example2Condition() => true;
    #endregion

    #region Properties
    /// <summary>
    /// Example property 1
    /// </summary>
    public StswBindingList<ExampleModel> ExampleProperty1
    {
        get => _exampleProperty1;
        set => SetProperty(ref _exampleProperty1, value);
    }
    private StswBindingList<ExampleModel> _exampleProperty1 = [];

    /// <summary>
    /// Example property 2
    /// </summary>
    public object? ExampleProperty2
    {
        get => _exampleProperty2;
        set => SetProperty(ref _exampleProperty2, value);
    }
    private object? _exampleProperty2;
    #endregion
}
