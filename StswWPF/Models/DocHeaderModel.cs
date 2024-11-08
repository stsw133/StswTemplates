namespace StswWPF;
public class DocHeaderModel : StswObservableObject, IHeader, IStswCollectionItem
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public DocType? Type { get; set; }
    public DocStatus? Status { get; set; }
    public IEnumerable<DocPositionModel>? Positions { get; set; }



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
}
