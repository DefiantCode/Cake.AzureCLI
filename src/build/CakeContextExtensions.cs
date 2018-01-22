using Cake.Common;
using Cake.Core;

public static class CakeContextExtensions
{
    private static object _lock = new object();
    private static IVariableNameFormatter _variableNameFormatter = new VariableNameFormatter();

    public static void RegisterVariableNameFormatter(IVariableNameFormatter variableNameFormatter)
    {
        lock (_lock)
            _variableNameFormatter = variableNameFormatter;
    }

    public static string ArgOrEnv(this ICakeContext context, string prefix, string propertyName, string defaultValue = null)
    {
        var envName = _variableNameFormatter.FormatEnvironmentVariable(prefix, propertyName);
        var argName = _variableNameFormatter.FormatArgument(prefix, propertyName);
        if (context.HasEnvironmentVariable(envName))
            return context.EnvironmentVariable(envName);
        if(context.HasArgument(argName))
            return context.Argument<string>(argName);

        if (defaultValue == null)
            throw new CakeException($"Could not find environment variable {envName} or argument {argName}");

        return defaultValue;
    }
}
