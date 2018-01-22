using Cake.Frosting;
using DefiantCode.Cake.Frosting;

namespace Build.Tasks
{
    [TaskName("CI")]
    [Dependency(typeof(PushTask))]
    public sealed class CITask : FrostingTask<DotNetCoreContext>
    {

    }
}
