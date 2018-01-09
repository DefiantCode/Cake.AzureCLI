using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.AzureCLI.Group
{
    public class AzGroupCreateSettings : AzSettings
    {
        /// <summary>
        /// Location (azure region)
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Name of the resource group to create
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Space separated tags in 'key[=value]' format. Use "" to clear existing tags.
        /// </summary>
        public string Tags { get; set; }
    }
}
