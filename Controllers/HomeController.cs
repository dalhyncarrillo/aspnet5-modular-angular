using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AngularPlugin.Models;

namespace PluginArchitecture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        
        public HomeController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public async Task<IActionResult> Index(string email)
        {
            var roleId =  await _ctx.Users.Where(y => y.Email == email).Select(x => x.RoleId).SingleAsync();
            var moduleIds = await _ctx.RoleModules.Where(x => x.RoleId == roleId).Select(rm => rm.ModuleId).ToListAsync();
            var modules = await _ctx.Modules.Where(x => moduleIds.Contains(x.Id)).ToListAsync();
            
            // This should work but EF7 is clearly not ready for primetime
//             var modules = await _ctx.Users.Where(x => x.Email == email)
//                 .SelectMany(x => x.Role.RoleModules)
//                 .Select(x => x.Module)
//                 .ToListAsync();

            
            ViewBag.Email = email;
            ViewBag.Modules = modules;
            return View();
        }
    }
}