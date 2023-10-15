using EmployeesContracts.BusinessLogicsContracts;
using EmployeesContracts.StorageContracts;
using EmployeesDatabaseImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace EmployeesView
{
    internal static class Program
    {
        private static IUnityContainer container = null;
        public static IUnityContainer Container { get { if (container == null) { container = BuildUnityContainer(); } return container; } }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();

            currentContainer.RegisterType<IEmployeeStorage, EmployeeStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPostStorage, PostStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IEmployeeLogic, EmployeeLogic.BusinessLogics.EmployeeLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPostLogic, EmployeeLogic.BusinessLogics.PostLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}