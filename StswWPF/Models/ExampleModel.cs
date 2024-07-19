namespace StswWPF;
/// <summary>
/// Represents an example model with various properties and implements state management for SQL saving from a DataGrid.
/// </summary>
/// <remarks>
/// If you need a model that has information about item state for SQL saving data from DataGrid, then use:
/// <see cref="StswObservableObject"/> and <see cref="IStswCollectionItem"/>, otherwise you do not need them.
/// </remarks>
public class ExampleModel : StswObservableObject, IExample, IStswCollectionItem
{
    /// <summary>
    /// Gets or sets the ID of the example.
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Gets or sets the name of the example.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the first example detail.
    /// </summary>
    public Example1? Example1 { get; set; }

    /// <summary>
    /// Gets or sets the second example detail.
    /// </summary>
    public Example2? Example2 { get; set; }



    /// <summary>
    /// Gets or sets the state of the item.
    /// </summary>
    public StswItemState ItemState
    {
        get => _itemState;
        set => SetProperty(ref _itemState, value);
    }
    private StswItemState _itemState;

    /// <summary>
    /// Gets or sets a value indicating whether to show details.
    /// </summary>
    public bool? ShowDetails
    {
        get => _showDetails;
        set => SetProperty(ref _showDetails, value);
    }
    private bool? _showDetails;
}
