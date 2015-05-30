using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace AngularPlugin.Migrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateSequence(
                name: "DefaultSequence",
                type: "bigint",
                startWith: 1L,
                incrementBy: 10);
            migration.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column(type: "uniqueidentifier", nullable: false),
                    Name = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });
            migration.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column(type: "uniqueidentifier", nullable: false),
                    Name = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });
            migration.CreateTable(
                name: "RoleModule",
                columns: table => new
                {
                    ModuleId = table.Column(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModule", x => new { x.ModuleId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RoleModule_Module_ModuleId",
                        columns: x => x.ModuleId,
                        referencedTable: "Module",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleModule_Role_RoleId",
                        columns: x => x.RoleId,
                        referencedTable: "Role",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "User",
                columns: table => new
                {
                    Email = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "uniqueidentifier", nullable: false),
                    Name = table.Column(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        columns: x => x.RoleId,
                        referencedTable: "Role",
                        referencedColumn: "Id");
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropSequence("DefaultSequence");
            migration.DropTable("Module");
            migration.DropTable("Role");
            migration.DropTable("RoleModule");
            migration.DropTable("User");
        }
    }
}
