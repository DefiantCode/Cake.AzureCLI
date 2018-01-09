using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.AzureCLI.Aks
{
    public class AzAksSettings : AzSettings
    {
        public string ResourceGroup { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
