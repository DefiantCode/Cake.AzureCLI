using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.AzureCLI.Aks
{
    public class AzAksCreate : AzTool<AzAksCreateSettings>
    {
        public AzAksCreate(ICakeContext context) : this(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools)
        {

        }

        protected AzAksCreate(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Create(AzAksCreateSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));
            if (string.IsNullOrEmpty(settings.Name))
                throw new ArgumentNullException(nameof(settings) + "." + nameof(settings.Name));
            if (string.IsNullOrEmpty(settings.ResourceGroup))
                throw new ArgumentNullException(nameof(settings) + "." + nameof(settings.ResourceGroup));

            var builder = CreateArgumentBuilder(AzCommands.Aks.Create, settings);
            ToolArgumentAttribute.PopulateArguments(builder, settings);
            RunCommand(settings, builder);
        }
    }
}
