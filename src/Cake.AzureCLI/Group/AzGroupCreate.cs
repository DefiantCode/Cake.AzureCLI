using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.AzureCLI.Group
{
    public class AzGroupCreate : AzTool<AzGroupCreateSettings, AzToolResult>
    {
        public AzGroupCreate(ICakeContext context) : base(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools)
        {

        }

        protected AzGroupCreate(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Create(AzGroupCreateSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));
            if (settings.Name == null)
                throw new ArgumentNullException(nameof(settings) + "." + nameof(settings.Name));

            var builder = CreateArgumentBuilder(AzCommands.Group.Create, settings);
            ToolArgumentAttribute.PopulateArguments(builder, settings);
            RunCommand(settings, builder);
        }

    }
}
