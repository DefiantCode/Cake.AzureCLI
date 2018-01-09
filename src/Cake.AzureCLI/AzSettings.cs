using Cake.Core.Tooling;

namespace Cake.AzureCLI
{
    public class AzSettings : ToolSettings
    {
        public bool Debug { get; set; }
        /// <summary>
        /// Increase logging verbosity. Use Debug for full debug logs. 
        /// </summary>
        public bool Verbose { get; set; }
        /// <summary>
        /// JMESPath query string. See http://jmespath.org/ for more information and examples. 
        /// </summary>
        public string Query { get; set; }
        /// <summary>
        /// Output format. Defaults to json string.
        /// </summary>
        public AzOutputFormats? Output { get; set; }

    }

    public enum AzOutputFormats
    {
        json,
        jsonc,
        table,
        tsv
    }
}
