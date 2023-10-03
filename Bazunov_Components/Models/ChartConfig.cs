using DocumentFormat.OpenXml.Spreadsheet;

namespace Bazunov_Components.Models
{
    public class ChartConfig : DocumentConfig
    {
        public string ChartTitle { get; set; }
        public Location LegendLocation { get; set; }
        public Dictionary<string, List<(int Date, double Value)>> Data { get; set; }

        public void CheckFields()
        {
            if (Data == null || Data.Count == 0)
                throw new ArgumentNullException("Data count is null");
        }
    }
}
