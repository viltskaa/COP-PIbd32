using Bazunov_Components.Models;

namespace Bazunov_Components.Helpers
{
    public interface ICreator
    {
        void CreateHeader(string header);
        void SaveDoc(string filepath);
        void CreateBarChart(ChartConfig config);
    }
}
