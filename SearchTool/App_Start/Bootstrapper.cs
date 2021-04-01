using Autofac;
using Autofac.Integration.Mvc;
using System.Linq;
using System.Reflection;
using SearchTool.Service.Services;
using System.Web.Mvc;

namespace SearchTool.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutoFacContainer();            
        }

        private static void SetAutoFacContainer()
        {
            var builder = new ContainerBuilder();
            {
                //Controllers
                builder.RegisterControllers(Assembly.GetExecutingAssembly());

                //Services
                builder.RegisterAssemblyTypes(typeof(FileService).Assembly)
                    .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces().InstancePerRequest();
                builder.RegisterAssemblyTypes(typeof(SearchService).Assembly)
                    .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces().InstancePerRequest();

                builder.RegisterFilterProvider();
                IContainer container = builder.Build();
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            };
        }
    }
}