using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.AzureCLI.Group.Deployment
{
    public class AzGroupDeploymentCreate : AzTool<AzGroupDeploymentCreateSettings>
    {
        public AzGroupDeploymentCreate(ICakeContext context) : base(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools)
        {

        }

        protected AzGroupDeploymentCreate(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Create(AzGroupDeploymentCreateSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));
            if (string.IsNullOrWhiteSpace(settings.ResourceGroup))
                throw new ArgumentNullException(nameof(settings) + "." + nameof(settings.ResourceGroup));

            var builder = CreateArgumentBuilder(AzCommands.Group.Deployment.Create, settings);
            ToolArgumentAttribute.PopulateArguments(builder, settings);
            RunCommand(settings, builder);
        }

        public void Validate(AzGroupDeploymentCreateSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));
            if (string.IsNullOrWhiteSpace(settings.ResourceGroup))
                throw new ArgumentNullException(nameof(settings) + "." + nameof(settings.ResourceGroup));

            var builder = CreateArgumentBuilder(AzCommands.Group.Deployment.Validate, settings);
            ToolArgumentAttribute.PopulateArguments(builder, settings);
            RunCommand(settings, builder);
        }

    }
}
