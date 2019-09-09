using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication.Infrastructure.ModelMetaData.Filters
{
    public class TextAreaByNameFilter : IModelMetaDataFilter
    {
        private static readonly HashSet<string> TextAreaFieldNames = new HashSet<string>
        {
            "body",
            "comments"

        };

        public void TransformMetaData(ModelMetadata metadata, IEnumerable<Attribute> attributes)
        {
            if (!string.IsNullOrEmpty(metadata.PropertyName) &&
                string.IsNullOrEmpty(metadata.DataTypeName) &&
                TextAreaFieldNames.Contains(metadata.PropertyName.ToLower()))
            {
                metadata.DataTypeName = "MultilineText";
            }
        }
    }
}