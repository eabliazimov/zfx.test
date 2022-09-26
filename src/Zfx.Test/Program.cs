using Autofac;
using Serilog;
using System;
using System.Threading.Tasks;
using Zfx.Test.Application;
using Zfx.Test.Runner;

namespace Zfx.Test
{
    internal static class Program
    {
        private static async Task<int> Main(string[] args)
        {
            Log.Logger =
                    new LoggerConfiguration()
                    .WriteTo
                    .File("log-.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();

            try
            {
                var container = Bootstrap();
                var zfxRunner = container.Resolve<ZfxIORunner>();
                await zfxRunner.RunAsync();

                return (int) ExitCodes.NoErrors;
            }
            catch(Exception ex)
            {
                Log.Logger.Error(ex, "Application crushed with Unexpected Error");
                Console.WriteLine("Application crushed with Unexpected Error. Check Logs for more details.");
                return (int) ExitCodes.Error;
            }
        }

        private static IContainer Bootstrap()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterInstance(Log.Logger);
            containerBuilder.RegisterType<ZfxIORunner>();
            containerBuilder.RegisterType<ZFxConsole>().As<IZfxConsole>();
            containerBuilder.BootstrapApplication();

            return containerBuilder.Build();
        }
    }
}