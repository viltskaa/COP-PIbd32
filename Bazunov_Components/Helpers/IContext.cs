using Bazunov_Components.Models;

namespace Bazunov_Components.Helpers
{
    public interface IContext : ICreator
    {
        void CreateTable(string[,] data);
        void CreateTableWithHeader();
        void CreateMultiHeader<T>(TableWithHeaderConfig<T> config);
        void LoadDataToTableWithMultiHeader(string[,] data, int rowHeight);
    }
}
