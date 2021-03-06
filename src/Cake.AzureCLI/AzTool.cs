﻿using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Cake.AzureCLI
{
    public abstract class AzTool<TSettings, TResult> : Tool<TSettings> where TSettings : AzSettings where TResult : AzToolResult, new()
    {
        public TResult ToolResult { get; private set; }

        protected AzTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
            ToolResult = new TResult();
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override string GetToolName()
        {
            return "Azure CLI 2.0";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "az" };
        }

        protected override IEnumerable<FilePath> GetAlternativeToolPaths(TSettings settings)
        {
            return new[] { new FilePath(@"C:\Program Files (x86)\Microsoft SDKs\Azure\CLI2\wbin\az.cmd") };
        }

        /// <summary>
        /// Runs the az cli command using the specified settings and arguments.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="arguments">The arguments.</param>
        protected void RunCommand(TSettings settings, ProcessArgumentBuilder arguments)
        {
            //redirect stdout is output is json or not set
            if ((settings.Output.HasValue && settings.Output.Value == AzOutputFormats.json) || !settings.Output.HasValue)
            {
                Run(settings, arguments, new ProcessSettings { RedirectStandardOutput = true }, p =>
                {
                    p.WaitForExit();

                    foreach (var line in p.GetStandardOutput())
                    {
                        ToolResult.Raw += line;
                    }
                });
            }
            else
                Run(settings, arguments, null, null);
        }

        /// <summary>
        /// Runs the az cli command using the specified settings and arguments.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="processSettings">The processSettings.</param>
        protected void RunCommand(TSettings settings, ProcessArgumentBuilder arguments, ProcessSettings processSettings)
        {
            Run(settings, arguments, processSettings, null);
        }

        /// <summary>
        /// Creates a <see cref="ProcessArgumentBuilder"/> and adds common commandline arguments.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>Instance of <see cref="ProcessArgumentBuilder"/>.</returns>
        protected ProcessArgumentBuilder CreateArgumentBuilder(string commandName, TSettings settings)
        {
            var builder = new ProcessArgumentBuilder();
            builder.Append(commandName);
            return builder;
        }
    }
}
