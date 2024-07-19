namespace StswWPF;
/// <summary>
/// Represents the context for examples, containing commands and properties related to examples.
/// </summary>
public class ExampleContext : StswObservableObject
{
    /// <summary>
    /// Gets or sets the command for example 1.
    /// </summary>
    public StswCommand<object?> Example1Command { get; set; }

    /// <summary>
    /// Gets or sets the asynchronous command for example 2.
    /// </summary>
    public StswAsyncCommand<object?> Example2Command { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExampleContext"/> class.
    /// </summary>
    public ExampleContext()
    {
        Example1Command = new(Example1, Example1Condition);
        Example2Command = new(Example2, Example2Condition);
    }

    #region Commands & methods
    /// <summary>
    /// Example method 1 for synchronous command.
    /// </summary>
    /// <param name="value">Example value.</param>
    private void Example1(object? value)
    {
        try
        {
            // Perform some action here
        }
        catch (Exception ex)
        {
            StswMessageDialog.Show(ex, $"Method error: {nameof(Example2)}");
        }
    }
    private bool Example1Condition() => true;

    /// <summary>
    /// Example method 2 for asynchronous command.
    /// </summary>
    /// <param name="value">Example value.</param>
    private async Task Example2(object? value)
    {
        try
        {
            // do something here
            await Task.Run(() => Thread.Sleep(10));
        }
        catch (Exception ex)
        {
            await StswMessageDialog.Show(ex, $"Method error: {nameof(Example2)}");
        }
    }
    private bool Example2Condition() => true;
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets example property 1.
    /// </summary>
    public StswBindingList<ExampleModel> ExampleProperty1
    {
        get => _exampleProperty1;
        set => SetProperty(ref _exampleProperty1, value);
    }
    private StswBindingList<ExampleModel> _exampleProperty1 = [];

    /// <summary>
    /// Gets or sets example property 2.
    /// </summary>
    public object? ExampleProperty2
    {
        get => _exampleProperty2;
        set => SetProperty(ref _exampleProperty2, value);
    }
    private object? _exampleProperty2;
    #endregion
}
