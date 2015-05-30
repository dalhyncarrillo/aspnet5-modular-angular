using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using AngularPlugin.Models;

namespace AngularPlugin.Migrations
{
    [ContextType(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Sequence");
                
                builder.Entity("AngularPlugin.Models.Module", b =>
                    {
                        b.Property<Guid>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("Name")
                            .Annotation("OriginalValueIndex", 1);
                        b.Key("Id");
                    });
                
                builder.Entity("AngularPlugin.Models.Role", b =>
                    {
                        b.Property<Guid>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("Name")
                            .Annotation("OriginalValueIndex", 1);
                        b.Key("Id");
                    });
                
                builder.Entity("AngularPlugin.Models.RoleModule", b =>
                    {
                        b.Property<Guid>("ModuleId")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<Guid>("RoleId")
                            .Annotation("OriginalValueIndex", 1);
                        b.Key("ModuleId", "RoleId");
                    });
                
                builder.Entity("AngularPlugin.Models.User", b =>
                    {
                        b.Property<string>("Email")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<Guid>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("Name")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<Guid>("RoleId")
                            .Annotation("OriginalValueIndex", 3);
                        b.Key("Id");
                    });
                
                builder.Entity("AngularPlugin.Models.RoleModule", b =>
                    {
                        b.ForeignKey("AngularPlugin.Models.Module", "ModuleId");
                        b.ForeignKey("AngularPlugin.Models.Role", "RoleId");
                    });
                
                builder.Entity("AngularPlugin.Models.User", b =>
                    {
                        b.ForeignKey("AngularPlugin.Models.Role", "RoleId");
                    });
                
                return builder.Model;
            }
        }
    }
}
