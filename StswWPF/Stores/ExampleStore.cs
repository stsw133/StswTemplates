namespace StswWPF;

/// <summary>
/// Represents a store for managing a collection of examples.
/// </summary>
public class ExampleStore
{
    /// <summary>
    /// Occurs when the collection of examples changes.
    /// </summary>
    public event EventHandler<ExamplesChangedArgs>? ExamplesChanged;

    private readonly List<ExampleModel> _examples = [];

    protected bool _refreshDefered;

    /// <summary>
    /// Gets the collection of examples.
    /// </summary>
    public IEnumerable<ExampleModel> Examples => _examples;

    /// <summary>
    /// Adds a new example to the collection and triggers the ExamplesChanged event.
    /// </summary>
    /// <param name="example">The example to add.</param>
    public void AddExample(ExampleModel example)
    {
        _examples.Add(example);
        OnExamplesChanged();
    }

    /// <summary>
    /// Removes an example from the collection and triggers the ExamplesChanged event.
    /// </summary>
    /// <param name="example">The example to remove.</param>
    public void RemoveExample(ExampleModel example)
    {
        _examples.Remove(example);
        OnExamplesChanged();
    }

    /// <summary>
    /// Adds a range of examples to the collection and triggers the ExamplesChanged event.
    /// </summary>
    /// <param name="examples">The examples to add.</param>
    public void AddExampleRange(List<ExampleModel> example)
    {
        _examples.AddRange(example);
        OnExamplesChanged();
    }

    /// <summary>
    /// Clears all examples from the collection and triggers the ExamplesChanged event.
    /// </summary>
    public void ClearExamples()
    {
        _examples.Clear();
        OnExamplesChanged();
    }

    /// <summary>
    /// Raises the ExamplesChanged event if refresh is not deferred.
    /// </summary>
    private void OnExamplesChanged()
    {
        if (!_refreshDefered)
            ExamplesChanged?.Invoke(this, new ExamplesChangedArgs(Examples));
    }

    /// <summary>
    /// Defers the triggering of the ExamplesChanged event until the returned IDisposable is disposed.
    /// </summary>
    /// <returns>An IDisposable that will enable the triggering of the ExamplesChanged event when disposed.</returns>
    public IDisposable DeferRefresh()
    {
        _refreshDefered = true;
        return new StswRefreshBlocker(() =>
        {
            _refreshDefered = false;
            OnExamplesChanged();
        });
    }
}

/// <summary>
/// Provides data for the ExamplesChanged event.
/// </summary>
/// <param name="newExamples">The new examples that have been added.</param>
public class ExamplesChangedArgs(IEnumerable<ExampleModel> newExamples) : EventArgs
{
    /// <summary>
    /// Gets the new examples that have been added.
    /// </summary>
    public IEnumerable<ExampleModel> NewExamples { get; private set; } = newExamples;
}
