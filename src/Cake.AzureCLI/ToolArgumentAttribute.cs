using Cake.Core;
using Cake.Core.IO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Cake.AzureCLI
{
    public class ToolArgumentAttribute : Attribute
    {
        public string ArgumentName { get; }
        public bool Ignore { get; set; }

        public ToolArgumentAttribute()
        {
        }

        public ToolArgumentAttribute(bool ignore)
        {
            Ignore = ignore;
        }

        public ToolArgumentAttribute(string argumentName)
        {
            ArgumentName = argumentName;
        }
        
        public static void PopulateArguments<TSettings>(ProcessArgumentBuilder builder, TSettings settings, bool autoFormat = false)
        {
            foreach (var pinfo in typeof(TSettings).GetTypeInfo().GetProperties())
            {
                string argumentName = null;

                var toolArgument = pinfo.GetCustomAttribute<ToolArgumentAttribute>(true);
                if ((toolArgument == null && !autoFormat) || (toolArgument != null && toolArgument.Ignore))
                    continue;
                
                argumentName = toolArgument?.ArgumentName;

                //if no argument name is supplied, format the property name into the probable argument name
                if(string.IsNullOrEmpty(argumentName))
                    argumentName = FormatArgumentName(pinfo.Name);

                var pvalue = pinfo.GetValue(settings);

                if (pinfo.PropertyType == typeof(bool))
                { 
                    if((bool)pvalue) //only write the switch if the bool property is true
                        builder.Append("--{0}", argumentName);

                    continue;
                }
                else if (pvalue != null)
                    builder.Append("--{0} {1}", argumentName, pvalue);
            }
        }

        private static string FormatArgumentName(string propertyName)
        {
            return Regex.Replace(propertyName, "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", "-$1").ToLower();
        }

    }
}
