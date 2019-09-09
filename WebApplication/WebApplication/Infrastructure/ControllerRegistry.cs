using StructureMap.Configuration.DSL;

namespace WebApplication.Infrastructure
{
    public class ControllerRegistry : Registry
    {
        public ControllerRegistry()
        {
            Scan(scan =>
            {
                scan.WithDefaultConventions();
                scan.With(new ControllerConvention());
            });
        }
    }
}