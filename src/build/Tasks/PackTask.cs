using Cake.Frosting;
using DefiantCode.Cake.Frosting;
using DefiantCode.Cake.Frosting.Tasks;

namespace Build.Tasks
{
    [TaskName("Pack")]
    [Dependency(typeof(DotNetCorePack))]
    public sealed class PackTask : FrostingTask<DotNetCoreContext>
    {
    }
}
