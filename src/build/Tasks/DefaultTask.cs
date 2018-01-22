using Cake.Frosting;
using DefiantCode.Cake.Frosting;

namespace Build.Tasks
{
    [TaskName("Default")]
    [Dependency(typeof(PackTask))]
    public sealed class DefaultTask : FrostingTask<DotNetCoreContext>
    {
    }
}
