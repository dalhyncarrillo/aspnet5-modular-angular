using System;
using System.Collections.Generic;

namespace AngularPlugin.Models
{
	// HACK because EF7 doesn't support many-to-many mappings yet
    public class RoleModule
    {
		public Guid RoleId { get; set; }
		public Role Role{ get; set; }
		
		public Guid ModuleId { get; set; }
		public Module Module { get; set; }
    }
}
