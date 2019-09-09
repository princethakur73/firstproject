using StructureMap;
using System.Web;

namespace WebApplication.Infrastructure
{
    public static class ContainerPerRequestExtensions
    {
        public static IContainer GetContainer(this HttpContextBase context)
        {
            return (IContainer)HttpContext.Current.Items["_Container"]
                ?? ObjectFactory.Container;
        }
    }
}