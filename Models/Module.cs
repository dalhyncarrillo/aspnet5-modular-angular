using System;
using System.Collections.Generic;

namespace AngularPlugin.Models
{
    public class Module
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
		
		public IList<RoleModule> RoleModules { get; set; }
    }
}
