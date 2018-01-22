using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System.Linq;

namespace Cake.AzureCLI.Group
{
    public class AzGroupExists : AzTool<AzGroupExistsSettings, AzToolResult>
    {
        public AzGroupExists(ICakeContext context) : base(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools)
        {

        }

        protected AzGroupExists(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
        }

        public bool Exists(AzGroupExistsSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));
            if (settings.Name == null)
                throw new ArgumentNullException(nameof(settings) + "." + nameof(settings.Name));

            var builder = CreateArgumentBuilder(AzCommands.Group.Exists, settings);
            ToolArgumentAttribute.PopulateArguments(builder, settings);
            
            var p = RunProcess(settings, builder, new ProcessSettings { RedirectStandardOutput = true });
            var log = p.GetStandardOutput();
            var resultString = log.SingleOrDefault();
            if (resultString == null)
                throw new CakeException("az group exists: No output logged");

            if (!bool.TryParse(resultString, out bool result))
                throw new CakeException("az group exists: Unable to parse log output: " + resultString);

            return result;
        }

    }
}
