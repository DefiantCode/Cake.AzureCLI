using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.AzureCLI.Group
{
    public class AzGroupDeleteSettings : AzSettings
    {
        /// <summary>
        /// Name of the resource group to delete
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Do not wait for the long-running operation to finish
        /// </summary>
        public bool NoWait { get; set; }
        /// <summary>
        /// Do not prompt for comnfirmation
        /// </summary>
        public bool Yes { get; set; }
    }
}
