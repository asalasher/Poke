using PK.Domain.Services;
using Poke.Logging;
using Poke.Repository;
using System.Web.Http;
using Unity;
using Unity.Microsoft.Logging;
using Unity.WebApi;

namespace Poke.DistributedSystems
{
    public static class UnityConfig
    {
        //private static readonly string _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "SerilogPoke.log");

        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.AddExtension(new LoggingExtension());

            //Microsoft.Extensions.Logging.ILogger logger = new SerilogLoggerProvider(new LoggerConfiguration()
            //    .MinimumLevel.Verbose()
            //    .WriteTo.File(_logFilePath)
            //    .CreateLogger()) // hasta aquí podría ir en un proyecto aparte en metodo estatico
            //    .CreateLogger("SerilogPoke"); // nombre custom
            //container.RegisterInstance(logger);

            Microsoft.Extensions.Logging.ILogger logger = SerilogConfiguration.ConfigureLog()
                .CreateLogger("SerilogPoke"); // nombre custom
            container.RegisterInstance(logger);

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IMoveServices, MoveServices>();
            container.RegisterType<ITypesRepository, TypesRepository>();
            container.RegisterType<IMovesRepository, MovesRepository>();

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}