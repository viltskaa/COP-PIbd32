namespace Bazunov_Components.Models;

public class ChartConfig : DocumentConfig
{
    public string ChartTitle { get; init; } = string.Empty;
    public Location LegendLocation { get; init; }
    public Dictionary<string, List<(int Date, double Value)>>? Data { get; init; }

    public void CheckFields()
    {
        if (Data == null || Data.Count == 0)
            throw new ArgumentNullException("Data count is null");
    }
}