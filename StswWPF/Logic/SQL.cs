namespace StswWPF;
public static class SQL //: ISQL
{
#if DEBUG
    private readonly static StswDatabaseModel DbMain = new("SERVER_TEST", "DB_TEST", "LOGIN_TEST", "PASSWORD_TEST");
#else
    private readonly static StswDatabaseModel DbMain = new("SERVER_PROD", "DB_PROD", "LOGIN_PROD", "PASSWORD_PROD");
#endif

    public static IEnumerable<DocHeaderModel> GetDocs(int? id = null) => DbMain.Get<DocHeaderModel>($@"
        select
            1 [{nameof(DocHeaderModel.ID)}],
            'Example' [{nameof(DocHeaderModel.Name)}]
        from dbo.?
        {(id != null ? "where ID=@ID" : string.Empty)}", new { id })!;
    
    public static void SetDocs(StswBindingList<DocHeaderModel> models)
    {
        using var sqlConn = DbMain.OpenedConnection();
        using var sqlTran = sqlConn.BeginTransaction();

        DbMain.ExecuteNonQuery($@"
            insert into dbo.? (Name)
            values (@Name)", models.GetItemsByState(StswItemState.Added));

        DbMain.ExecuteNonQuery($@"
            update dbo.?
            set Name=@Name
            where ID=@ID", models.GetItemsByState(StswItemState.Modified));

        DbMain.ExecuteNonQuery($@"
            delete from dbo.?
            where ID=@ID", models.GetItemsByState(StswItemState.Deleted));

        sqlTran.Commit();
    }
}
