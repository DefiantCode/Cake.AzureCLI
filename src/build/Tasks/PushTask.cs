using Cake.Frosting;
using DefiantCode.Cake.Frosting;
using DefiantCode.Cake.Frosting.Tasks;

namespace Build.Tasks
{
    [TaskName("Push")]
    [Dependency(typeof(NugetPush))]
    public sealed class PushTask : FrostingTask<DotNetCoreContext>
    {
    }
}
