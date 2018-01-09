using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.AzureCLI.Group
{
    public class AzGroupExistsSettings : AzSettings
    {
        /// <summary>
        /// Name of the resource group to delete
        /// </summary>
        public string Name { get; set; }

    }
}
