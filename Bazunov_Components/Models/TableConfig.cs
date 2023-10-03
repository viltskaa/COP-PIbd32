namespace Bazunov_Components.Models;

public class TableConfig : DocumentConfig
{
    public List<string[,]>? Data { get; init; }

    public void CheckFields()
    {
        if (Data == null || Data.Count == 0 || Data.All(x => x.Length == 0))
            throw new ArgumentNullException("Data is null");
    }
}