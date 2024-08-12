namespace StswWPF;

/// <summary>
/// Defines methods for retrieving and saving example models to and from a SQL database.
/// </summary>
public static class SQL //: ISQL
{
#if DEBUG
    private readonly static StswDatabaseModel DbMain = new() { Server = "TEST", Database = "", Login = "", Password = "" };
#else
    private readonly static StswDatabaseModel DbMain = new() { Server = "PROD", Database = "", Login = "", Password = "" };
#endif

    /// <summary>
    /// Retrieves a collection of example models from the SQL database.
    /// </summary>
    /// <returns>An enumerable collection of <see cref="ExampleModel"/>.</returns>
    public static IEnumerable<ExampleModel> GetExampleModels() => DbMain.Get<ExampleModel>($@"
        select
            1 [{nameof(ExampleModel.ID)}],
            'Example' [{nameof(ExampleModel.Name)}]
        from dbo.?
        where ?=@Example1", new { Example1 = string.Empty });

    /// <summary>
    /// Saves a collection of example models to the SQL database.
    /// </summary>
    /// <param name="models">The collection of example models to save.</param>
    public static void SaveExampleModels(StswBindingList<ExampleModel> models)
    {
        using var sqlTran = DbMain.BeginTransaction();

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
