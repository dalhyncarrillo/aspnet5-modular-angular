using System;
using System.Collections.Generic;

namespace AngularPlugin.Models
{
    public class Role
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
		
		public IList<User> Users { get; set; }
		
		public IList<RoleModule> RoleModules { get; set; }
    }
}
