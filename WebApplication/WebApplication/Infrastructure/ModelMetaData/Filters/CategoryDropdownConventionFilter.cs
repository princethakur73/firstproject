using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication.Infrastructure.ModelMetaData.Filters
{
    public class CategoryDropdownConventionFilter : IModelMetaDataFilter
    {
        public void TransformMetaData(ModelMetadata metadata, IEnumerable<Attribute> attributes)
        {
            if (!string.IsNullOrEmpty(metadata.PropertyName)
                && metadata.PropertyName.Contains("CategoryId")
                && string.IsNullOrEmpty(metadata.DataTypeName)
                )
            {

                metadata.DataTypeName = "CategoryId";
                metadata.DisplayName = "Category";
            }
        }
    }
}