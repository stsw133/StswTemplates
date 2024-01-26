 namespace StswWPF;
public class ExampleContext : StswObservableObject
{
    /// <summary>
    /// Example command
    /// </summary>
    public StswCommand<object?> Example1Command { get; set; }

    public ExampleContext()
    {
        Example1Command = new(Example1, Example1Condition);
    }

    #region Commands & methods
    /// <summary>
    /// Example method for command
    /// </summary>
    /// <param name="value">Example value</param>
    private void Example1(object? value)
    {
        // do something here
    }
    private bool Example1Condition() => true;
    #endregion

    #region Properties
    /// <summary>
    /// Example property
    /// </summary>
    public object? Example2
    {
        get => _example2;
        set => SetProperty(ref _example2, value);
    }
    private object? _example2;
    #endregion
}
