using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication.Infrastructure.ModelMetaData.Filters
{
    public class CountryDropdownConventionFilter : IModelMetaDataFilter
    {
        public void TransformMetaData(ModelMetadata metadata, IEnumerable<Attribute> attributes)
        {
            if (!string.IsNullOrEmpty(metadata.PropertyName)
                 && metadata.PropertyName.Contains("CountryId")
                 && string.IsNullOrEmpty(metadata.DataTypeName))
            {
                metadata.DataTypeName = "CountryId";
            }
        }
    }
}