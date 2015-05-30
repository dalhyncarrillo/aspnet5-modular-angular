using System;
using System.Collections.Generic;
using System.Linq;

namespace AngularPlugin.Models
{
    public class DatabaseInitializer
    {
        private ApplicationDbContext _ctx;

        public DatabaseInitializer(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public void Initialize()
        {
          if(_ctx.Users.Any())
          {
            return;
          }
          
          var module1 = _ctx.Modules.Add(new Module{
              Id = Guid.NewGuid(),
              Name = "module1"
          });
          var module2 = _ctx.Modules.Add(new Module{
              Id = Guid.NewGuid(),
              Name = "module2"
          });
          var module3 = _ctx.Modules.Add(new Module{
              Id = Guid.NewGuid(),
              Name = "module3"
          });
          var module4 = _ctx.Modules.Add(new Module{
              Id = Guid.NewGuid(),
              Name = "module4",
          });
          
          var adminRole = _ctx.Roles.Add(new Role
          {
              Id = Guid.NewGuid(),
              Name = "admin"
          });
          
          var userRole = _ctx.Roles.Add(new Role
          {
              Id = Guid.NewGuid(),
              Name = "user"
          });
          
          _ctx.RoleModules.Add(new RoleModule
          {
              Role = adminRole.Entity,
              Module = module1.Entity
          });
          
          _ctx.RoleModules.Add(new RoleModule
          {
              Role = adminRole.Entity,
              Module = module2.Entity
          });
          
          _ctx.RoleModules.Add(new RoleModule
          {
              Role = adminRole.Entity,
              Module = module3.Entity
          });
          
          _ctx.RoleModules.Add(new RoleModule
          {
              Role = adminRole.Entity,
              Module = module4.Entity
          });
          
          _ctx.RoleModules.Add(new RoleModule
          {
              Role = userRole.Entity,
              Module = module1.Entity
          });
          
          _ctx.RoleModules.Add(new RoleModule
          {
              Role = userRole.Entity,
              Module = module2.Entity
          });
          
          var user1 = _ctx.Users.Add(new User{
              Id = Guid.NewGuid(),
              Name = "Test User1",
              Email = "testuser1@test.com",
              Role = adminRole.Entity
          });
          
          var user2 = _ctx.Users.Add(new User{
              Id = Guid.NewGuid(),
              Name = "Test User2",
              Email = "testuser2@test.com",
              Role = userRole.Entity
          });
          
          _ctx.SaveChanges();
        }
    }
}