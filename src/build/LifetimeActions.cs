using Cake.Common;
using Cake.Common.Build;
using Cake.Common.IO;
using Cake.Common.Tools.DotNetCore;
using Cake.Core;
using DefiantCode.Cake.Frosting;
using DefiantCode.Cake.Frosting.Utilities;

class LifetimeActions : ILifetimeActions
{
    public void BeforeSetup(DotNetCoreContext ctx)
    {
        if (ctx.HasArgument("assemblyVersion"))
        {
            var av = ctx.Argument<string>("assemblyVersion");
            if (ctx.HasEnvironmentVariable("Git_Branch") && !ctx.EnvironmentVariable("Git_Branch").Contains("master")) //TODO: move this to Core lib
                av = av + "-CI";

            var pv = ctx.Argument("packageVersion", av);
            ctx.DisableGitVersion = true;
            ctx.BuildVersion = new BuildVersion(av, pv);
            var buildSystem = ctx.BuildSystem();
            if (buildSystem.IsRunningOnTeamCity)
                buildSystem.TeamCity.SetBuildNumber(av);
        }

    }

    public void AfterSetup(DotNetCoreContext ctx)
    {
    }

    public void BeforeTeardown(DotNetCoreContext context, ITeardownContext info)
    {
    }

    public void AfterTeardown(DotNetCoreContext context, ITeardownContext info)
    {
    }
}
