using System.Text.RegularExpressions;
/// <summary>
/// Default formatter that will format a pascal-case name. Arguments fromat as my-arg-name and environment varfiables as MY_ARG_NAME
/// </summary>
public class VariableNameFormatter : IVariableNameFormatter
{
    public string FormatArgument(string prefix, string propertyName)
    {
        return prefix.ToLower() + "-" + Regex.Replace(propertyName, "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", "-$1").ToLower();
    }

    public string FormatEnvironmentVariable(string prefix, string propertyName)
    {
        return prefix.ToUpper() + "_" + Regex.Replace(propertyName, "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", "_$1").ToUpper();
    }
}