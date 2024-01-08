
using Hospitall.Models;
using Hospitall.Repositories;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Utitilities
{
    public class Dbinitializer : IDbInitializer
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public Dbinitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();


                }

            }

            catch (Exception)
            {


                throw;

            }
            if (!_roleManager.RoleExistsAsync(WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult())
            {


                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Doctor)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Patient)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "mohan",
                    Email = "mohanhettihewa@gmail.com"


                }, "#Madush93").GetAwaiter().GetResult();
                var AppUser = _context.ApplicationUsers.FirstOrDefault(x => x.Email == "mohanhettihewa@gmail.com");
                if (AppUser != null)
                {

                    _userManager.AddToRoleAsync(AppUser, WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult();

                }
            }

        }
    }

}
