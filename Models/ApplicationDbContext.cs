using Microsoft.Data.Entity;

namespace AngularPlugin.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Module> Modules { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RoleModule> RoleModules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Startup.Configuration.Get("Data:DefaultConnection:ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<RoleModule>().Key(x => new{x.ModuleId, x.RoleId});
            builder.Entity<Role>().Key(x => x.Id);
            builder.Entity<Module>().Key(x => x.Id);
            builder.Entity<User>().Key(x => x.Id);
                
            builder.Entity<Role>()
                .Collection(r => r.RoleModules)
                .InverseReference(rm => rm.Role)
                .ForeignKey(rm => rm.RoleId);
                
            builder.Entity<Module>()
                .Collection(r => r.RoleModules)
                .InverseReference(rm => rm.Module)
                .ForeignKey(rm => rm.ModuleId);
                
            builder.Entity<Role>()
                .Collection(r => r.Users)
                .InverseReference(u => u.Role)
                .ForeignKey(u => u.RoleId);
        }
    }
}
