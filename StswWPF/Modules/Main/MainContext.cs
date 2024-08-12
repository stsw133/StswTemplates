namespace StswWPF;

/// <summary>
/// Represents the context for examples, containing commands and properties related to examples.
/// </summary>
public class MainContext : StswObservableObject
{
    public StswAsyncCommand Example1Command { get; }
    public StswCommand<object?> Example2Command { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainContext"/> class.
    /// </summary>
    public MainContext()
    {
        Example1Command = new(Example1, Example1Condition);
        Example2Command = new(Example2, Example2Condition);
    }

    #region Commands & methods
    /// <summary>
    /// Example method 1 for synchronous command.
    /// </summary>
    /// <param name="value">Example value.</param>
    private async Task Example1()
    {
        try
        {
            // Perform some action here
            await Task.Run(() => ExampleProperty1 = SQL.GetExampleModels().ToStswBindingList());
        }
        catch (Exception ex)
        {
            await StswMessageDialog.Show(ex, $"Method error: {nameof(Example1)}");
        }
    }
    private bool Example1Condition() => !Example2Command.IsBusy;

    /// <summary>
    /// Example method 2 for asynchronous command.
    /// </summary>
    /// <param name="value">Example value.</param>
    private void Example2(object? value)
    {
        try
        {
            // Perform some action here
            SQL.SaveExampleModels(ExampleProperty1);
            Example1Command.Execute(null);
        }
        catch (Exception ex)
        {
            StswMessageDialog.Show(ex, $"Method error: {nameof(Example2)}");
        }
    }
    private bool Example2Condition() => !Example1Command.IsBusy && ExampleProperty1.Any(x => x.ItemState != StswItemState.Unchanged);
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
