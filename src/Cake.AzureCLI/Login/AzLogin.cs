using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.AzureCLI.Login
{
    public class AzLogin : AzTool<AzLoginSettings>
    {
        public AzLogin(ICakeContext context) : this(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools)
        {

        }

        protected AzLogin(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Login(AzLoginSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));
            if (settings.Username == null)
                throw new ArgumentNullException(nameof(settings) + "." + nameof(settings.Username));
            if (settings.Password == null)
                throw new ArgumentNullException(nameof(settings) + "." + nameof(settings.Password));

            var builder = CreateArgumentBuilder(AzCommands.Login, settings);
            ToolArgumentAttribute.PopulateArguments(builder, settings);
            RunCommand(settings, builder);
        }
    }
}
