namespace StswWPF;
public interface ISQL
{
    IEnumerable<DocHeaderModel> GetDocs();

    void SetDocs(StswBindingList<DocHeaderModel> models);
}
