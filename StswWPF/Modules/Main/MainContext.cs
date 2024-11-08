namespace StswWPF;
public class MainContext : StswObservableObject
{
    public StswAsyncCommand RefreshCommand { get; }
    public StswCommand<object?> SaveCommand { get; }

    public MainContext()
    {
        RefreshCommand = new(Refresh);
        SaveCommand = new(Save, SaveCondition);
    }



    private async Task Refresh()
    {
        try
        {
            await Task.Run(() => Docs = SQL.GetDocs().ToStswBindingList());
        }
        catch (Exception ex)
        {
            await StswMessageDialog.Show(ex, $"Method error: {nameof(Refresh)}");
        }
    }

    private void Save(object? parameter)
    {
        try
        {
            if (parameter is DocHeaderModel model)
                SQL.SetDocs([model]);
            else
                SQL.SetDocs(Docs);

            RefreshCommand.Execute();
        }
        catch (Exception ex)
        {
            StswMessageDialog.Show(ex, $"Method error: {nameof(Save)}");
        }
    }
    private bool SaveCondition() => !RefreshCommand.IsBusy && Docs.Any(x => x.ItemState != StswItemState.Unchanged);



    public StswBindingList<DocHeaderModel> Docs
    {
        get => _docs;
        set => SetProperty(ref _docs, value);
    }
    private StswBindingList<DocHeaderModel> _docs = [];
}
