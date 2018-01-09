using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.AzureCLI.Aks
{
    public class AzAksCreateSettings : AzAksSettings
    {
        public string AdminUsername { get; set; }
        public string DnsNamePrefix { get; set; }
        public string ClientSecret { get; set; }
        public string GenerateSshKeys { get; set; }
        public string KubernetesVersion { get; set; }
        /// <summary>
        /// Do not wait for the long-running operation to finish.
        /// </summary>
        public bool NoWait { get; set; }
        public int NodeCount { get; set; }
        public int NodeOsdiskSize { get; set; }
        public string NodeVmSize { get; set; }
        public string ServicePrincipal { get; set; }
        public string SshKeyValue { get; set; }
        public string Tags { get; set; }
    }
}
