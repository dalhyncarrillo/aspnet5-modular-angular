using System;

namespace AngularPlugin.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Guid RoleId{ get; set; }
        public Role Role { get; set; }
    }
}
