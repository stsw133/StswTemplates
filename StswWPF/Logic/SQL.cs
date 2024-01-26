using System.Data;
using System.Data.SqlClient;

namespace StswWPF;
internal static class SQL
{
    /// <summary>
    /// Example connection string
    /// </summary>
    private static string connString = new StswDatabaseModel()
    {
#if RELEASE
        Server = "",
#else
        Server = "",
#endif
        Database = "",
        Login = "",
        Password = ""
    }.GetConnString();

    /// <summary>
    /// Example method for getting list
    /// </summary>
    /// <returns>Enumerable of example models</returns>
    internal static IEnumerable<ExampleModel> GetExampleModels()
    {
        using (var sqlConn = new SqlConnection(connString))
        {
            sqlConn.Open();

            var query = $@"
                select
                    1 [{nameof(ExampleModel.ID)}],
                    'Example' [{nameof(ExampleModel.Name)}]";
            using (var sqlDA = new SqlDataAdapter(query, sqlConn))
            {
                var dt = new DataTable();
                sqlDA.Fill(dt);
                return dt.MapTo<ExampleModel>();
            }
        }
    }

    /// <summary>
    /// Example method for saving list
    /// </summary>
    /// <returns>Enumerable of example models</returns>
    internal static void SaveExampleModels(StswBindingList<ExampleModel> models)
    {
        using (var sqlConn = new SqlConnection(connString))
        {
            sqlConn.Open();

            using (var sqlTran = sqlConn.BeginTransaction())
            {
                /// INSERT
                var query = $@"
                    insert into dbo.? (Name)
                    values (@Name)";
                foreach (var item in models.GetItemsByState(StswItemState.Added))
                    using (var sqlCmd = new SqlCommand(query, sqlConn, sqlTran))
                    {
                        sqlCmd.Parameters.AddWithValue("@Name", item.Name);
                        sqlCmd.ExecuteNonQuery();
                    }

                /// UPDATE
                query = $@"
                    update dbo.?
                    set Name=@Name
                    where ID=@ID";
                foreach (var item in models.GetItemsByState(StswItemState.Modified))
                    using (var sqlCmd = new SqlCommand(query, sqlConn, sqlTran))
                    {
                        sqlCmd.Parameters.AddWithValue("@ID", item.ID);
                        sqlCmd.Parameters.AddWithValue("@Name", item.Name);
                        sqlCmd.ExecuteNonQuery();
                    }

                /// DELETE
                query = $@"
                    delete from dbo.?
                    where ID=@ID";
                foreach (var item in models.GetItemsByState(StswItemState.Deleted))
                    using (var sqlCmd = new SqlCommand(query, sqlConn, sqlTran))
                    {
                        sqlCmd.Parameters.AddWithValue("@ID", item.ID);
                        sqlCmd.ExecuteNonQuery();
                    }

                sqlTran.Commit();
            }
        }
    }
}
