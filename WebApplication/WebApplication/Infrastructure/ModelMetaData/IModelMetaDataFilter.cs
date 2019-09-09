using System;
using System.Collections.Generic;

namespace WebApplication.Infrastructure.ModelMetaData
{
    public interface IModelMetaDataFilter
    {
        void TransformMetaData(System.Web.Mvc.ModelMetadata metadata,
            IEnumerable<Attribute> attributes);
    }
}
