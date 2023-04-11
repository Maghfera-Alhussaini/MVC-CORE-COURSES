using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CORE.Models;
using MVC_CORE.Models.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CORE.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly MYDbContext db;

        public RolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, MYDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
          
            var users = await _userManager.Users.Select(user => new AdminViewModel
            {
                Id = user.Id,
                Name = user.firstName + " " + user.lastName,
                Email=user.Email,
                PhoneNumber=user.PhoneNumber,
                Roles= _userManager.GetRolesAsync(user).Result

            }).ToListAsync();
           
            return View(users);
        }

        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            
                return NotFound();
            
            var roles = await _roleManager.Roles.ToListAsync();
            var viewModel = new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.firstName+" "+user.lastName,
                Roles = roles.Select(role => new RoleViewModel
                {
                    RoleId=role.Id,
                    RoleName= role.Name,
                    IsSelected= _userManager.IsInRoleAsync(user, role.Name).Result

                }).ToList()
            };
            return View(viewModel);
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound();
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach(var role in model.Roles)
            {
                if(userRoles.Any(r => r == role.RoleName) && !role.IsSelected)
                {
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
                if (!userRoles.Any(r => r == role.RoleName) && role.IsSelected)
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }
            }
            return RedirectToAction("Index");

        }
      






        public IActionResult AvailableSections()
        {
            ViewBag.model = db.sections.ToList();
            return View();
        }
        public async Task<IActionResult> manageSections([Bind("Name")] Section section)
        {
            
             db.sections.Add(section);
             await db.SaveChangesAsync();
            
            return RedirectToAction("AvailableSections");
        }

        public IActionResult AvailableTopics()
        {
            ViewBag.model = db.sections.ToList();
            ViewBag.model2 = db.topics.ToList();
            return View();
        }
        public IActionResult ManageTopics(string topic, int sId)
        {
            if (ModelState.IsValid)
            {
                db.topics.Add(new Topic()
                {
                    Name = topic,
                    SectionId = sId
                });
                db.SaveChanges();
            }
            return RedirectToAction("AvailableTopics");
        }

    }
}
