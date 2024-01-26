namespace StswWPF;
/// <summary>
/// If you need model that have info about item state for SQL saving data from DataGrid then use:
/// <see cref="StswObservableObject"/> and <see cref="IStswCollectionItem"/>, otherwise you do not need them
/// </summary>
public class ExampleModel : StswObservableObject, IStswCollectionItem
{
    public int ID { get; set; }
    public string? Name { get; set; }

    /// IStswCollectionItem properties:
    private string? _itemMessage;
    public string? ItemMessage
    {
        get => _itemMessage;
        set => SetProperty(ref _itemMessage, value);
    }

    private StswItemState _itemState;
    public StswItemState ItemState
    {
        get => _itemState;
        set => SetProperty(ref _itemState, value);
    }

    private bool? _showDetails;
    public bool? ShowDetails
    {
        get => _showDetails;
        set => SetProperty(ref _showDetails, value);
    }
}
