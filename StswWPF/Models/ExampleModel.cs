namespace StswWPF;
/// <summary>
/// If you need model that have info about item state for SQL saving data from DataGrid then use:
/// <see cref="StswObservableObject"/> and <see cref="IStswCollectionItem"/>, otherwise you do not need them
/// </summary>
public class ExampleModel : StswObservableObject, IExample, IStswCollectionItem
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public Example1? Example1 { get; set; }
    public Example2? Example2 { get; set; }

    #region IStswCollectionItem
    public StswItemState ItemState
    {
        get => _itemState;
        set => SetProperty(ref _itemState, value);
    }
    private StswItemState _itemState;

    public bool? ShowDetails
    {
        get => _showDetails;
        set => SetProperty(ref _showDetails, value);
    }
    private bool? _showDetails;
    #endregion
}
