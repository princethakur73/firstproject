using StructureMap.Configuration.DSL;
using System.Web.Mvc;

namespace WebApplication.Infrastructure.ModelMetaData
{
    public class ModelMetadataRegistry : Registry
    {
        public ModelMetadataRegistry()
        {
            For<ModelMetadataProvider>().Use<ExtensibleModelMetaDataProvider>();

            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.AddAllTypesOf<IModelMetaDataFilter>();
            });
        }
    }
}