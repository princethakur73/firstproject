using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace WebApplication.Infrastructure.ModelMetaData
{
    public class ExtensibleModelMetaDataProvider : DataAnnotationsModelMetadataProvider
    {
        private readonly IModelMetaDataFilter[] _metadataFilters;

        public ExtensibleModelMetaDataProvider(IModelMetaDataFilter[] metadataFilters)
        {
            _metadataFilters = metadataFilters;
        }

        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {

            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            _metadataFilters.ForEach(m =>
                    m.TransformMetaData(metadata, attributes));

            return metadata;
        }
    }
}