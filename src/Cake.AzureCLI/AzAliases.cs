using Cake.AzureCLI.Group;
using Cake.AzureCLI.Login;
using Cake.AzureCLI.Group.Deployment;
using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.AzureCLI
{
    [CakeNamespaceImport("Cake.AzureCLI")]
    public static class AzAliases
    {
        [CakeMethodAlias]
        [CakeAliasCategory("Azure")]
        public static void AzLogin(this ICakeContext context, string username, string password)
        {
            var az = new AzLogin(context);
            az.Login(new AzLoginSettings { Username = username, Password = password });
        }

        [CakeMethodAlias]
        [CakeAliasCategory("Azure")]
        public static void AzGroupCreate(this ICakeContext context, string name, string location)
        {
            var az = new AzGroupCreate(context);
            az.Create(new AzGroupCreateSettings { Name = name, Location = location });
        }

        [CakeMethodAlias]
        [CakeAliasCategory("Azure")]
        public static bool AzGroupExists(this ICakeContext context, string name)
        {
            var az = new AzGroupExists(context);
            return az.Exists(new AzGroupExistsSettings { Name = name });
        }

        [CakeMethodAlias]
        [CakeAliasCategory("Azure")]
        public static void AzGroupDelete(this ICakeContext context, string name, bool noWait = false, bool confirmYes = true)
        {
            var az = new AzGroupDelete(context);
            az.Delete(new AzGroupDeleteSettings { Name = name, NoWait = noWait, Yes = confirmYes});
        }

        [CakeMethodAlias]
        [CakeAliasCategory("Azure")]
        public static void AzGroupDeploymentCreate(this ICakeContext context, string name, string templateFileOrUri, string parameters, bool validateOnly = false)
        {
            var az = new AzGroupDeploymentCreate(context);
            var settings = new AzGroupDeploymentCreateSettings { ResourceGroup = name, Parameters = parameters };
            if (Uri.TryCreate(templateFileOrUri, UriKind.Absolute, out Uri result))
                settings.TemplateUri = result.AbsoluteUri;
            else
                settings.TemplateFile = templateFileOrUri;

            if (validateOnly)
                az.Validate(settings);
            else
                az.Create(settings);
        }

    }
}
