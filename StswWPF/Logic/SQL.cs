using System.Data;
using System.Data.SqlClient;

namespace StswWPF;
/// <summary>
/// Defines methods for retrieving and saving example models to and from a SQL database.
/// </summary>
public class SQL : ISQL
{
#if DEBUG
    private readonly string connString = new StswDatabaseModel() { Server = "TEST", Database = "", Login = "", Password = "" }.GetConnString();
#else
    private readonly string connString = new StswDatabaseModel() { Server = "PROD", Database = "", Login = "", Password = "" }.GetConnString();
#endif

    /// <summary>
    /// Retrieves a collection of example models from the SQL database.
    /// </summary>
    /// <returns>An enumerable collection of <see cref="ExampleModel"/>.</returns>
    public IEnumerable<ExampleModel> GetExampleModels()
    {
        using (var sqlConn = new SqlConnection(connString))
        {
            sqlConn.Open();

            var query = $@"
                select
                    1 [{nameof(ExampleModel.ID)}],
                    'Example' [{nameof(ExampleModel.Name)}]
                from dbo.?
                where ?=@Example1";
            using (var sqlDA = new SqlDataAdapter(query, sqlConn))
            {
                sqlDA.SelectCommand.Parameters.AddWithValue("@Example1", string.Empty);
                var dt = new DataTable();
                sqlDA.Fill(dt);
                return dt.MapTo<ExampleModel>();
            }
        }
    }

    /// <summary>
    /// Saves a collection of example models to the SQL database.
    /// </summary>
    /// <param name="models">The collection of example models to save.</param>
    public void SaveExampleModels(StswBindingList<ExampleModel> models)
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
