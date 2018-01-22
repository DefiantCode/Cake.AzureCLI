public interface IVariableNameFormatter
{
    string FormatArgument(string prefix, string propertyName);
    string FormatEnvironmentVariable(string prefix, string propertyName);
}