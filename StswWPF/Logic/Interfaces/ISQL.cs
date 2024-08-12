namespace StswWPF;

/// <summary>
/// Defines methods for retrieving and saving example models to and from a SQL database.
/// </summary>
public interface ISQL
{
    /// <summary>
    /// Retrieves a collection of example models from the SQL database.
    /// </summary>
    /// <returns>An enumerable collection of <see cref="ExampleModel"/>.</returns>
    IEnumerable<ExampleModel> GetExampleModels();

    /// <summary>
    /// Saves a collection of example models to the SQL database.
    /// </summary>
    /// <param name="models">The collection of example models to save.</param>
    void SaveExampleModels(StswBindingList<ExampleModel> models);
}
