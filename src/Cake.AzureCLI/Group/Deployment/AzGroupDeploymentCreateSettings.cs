namespace Cake.AzureCLI.Group.Deployment
{
    public class AzGroupDeploymentCreateSettings : AzSettings
    {
        /// <summary>
        /// Name of resource group
        /// </summary>
        public string ResourceGroup { get; set; }
        
        /// <summary>
        /// Incremental (only add resources to resource group) or Complete (remove extra resources from resource group).
        /// </summary>
        public ResourceGroupDeploymentModes? Mode { get; set; }
        
        /// <summary>
        /// The deployment name. Defaults to template file base name.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Do not wait for the long-running operation to finish.
        /// </summary>
        public bool NoWait { get; set; }

        /// <summary>
        /// Raw json or path to json parameters file. 
        /// </summary>
        [ToolArgument("parameters")]
        public string ParametersJson { get; set; }

        [ToolArgument("parameters")]
        public string ParameterOverrides { get; set; }

        /// <summary>
        /// A template file path in the file system.
        /// </summary>
        public string TemplateFile { get; set; }

        /// <summary>
        /// A uri to a remote template file.
        /// </summary>
        public string TemplateUri { get; set; }
    }
}
