using EnterpriseBusinessLogic.BusinessLogics;
using EnterpriseContracts.BusinessLogicContracts;
using EnterpriseContracts.StorageContracts;
using EnterpriseDataBaseImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace Bazunov_application
{
    internal static class Program
    {
        private static IUnityContainer container = null;
        public static IUnityContainer Container { get { container ??= BuildUnityContainer(); return container; } }

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
            currentContainer.RegisterType<ISubdivisionStorage, SubdivisionStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IEmployeeLogic, EmployeeLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISubdivisionLogic, SubdivisionLogic>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<EmployerForm>();
            currentContainer.RegisterType<Directory>();

            return currentContainer;
        }
    }
}