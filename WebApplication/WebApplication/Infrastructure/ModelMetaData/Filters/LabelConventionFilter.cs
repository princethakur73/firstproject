using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace WebApplication.Infrastructure.ModelMetaData.Filters
{
    public class LabelConventionFilter : IModelMetaDataFilter
    {
        public void TransformMetaData(ModelMetadata metadata, IEnumerable<Attribute> attributes)
        {
            if (!string.IsNullOrEmpty(metadata.PropertyName) &&
                string.IsNullOrEmpty(metadata.DisplayName))
            {
                metadata.DisplayName = GetStringWithSpaces(metadata.PropertyName);
            }
        }

        private string GetStringWithSpaces(string propertyName)
        {
            return Regex.Replace(
                propertyName,
                "(?<!^)" +
               "(" +
               "  [A-Z][a-z] |" +
               "  (?<=[a-z])[A-Z] |" +
               "  (?<![A-Z])[A-Z]$" +
               ")",
               " $1",
                RegexOptions.IgnorePatternWhitespace);
        }
    }
}