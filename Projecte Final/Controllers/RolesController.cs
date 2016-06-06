using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Projecte_Final.Models;

namespace Projecte_Final.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Root")]
        public ActionResult ManageUserRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            // prepopulat roles for the view dropdown
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>

            new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;
            return View();
        }


        [Authorize(Roles = "Root")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {

            ApplicationDbContext context = new ApplicationDbContext();
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (user != null)
            {
                if (RoleName == "")
                {
                    ViewBag.TypeMessage = "warning";
                    ViewBag.ResultMessage = "Por favor selecciona un rol";
                }
                else
                {
                    UserManager.AddToRole(user.Id, RoleName);
                    ViewBag.TypeMessage = "success";
                    ViewBag.ResultMessage = "Rol asignado correctamente!";
                }
            }
            else
            {
                ViewBag.TypeMessage = "danger";
                ViewBag.ResultMessage = "El usuario introducido no existe";
            }

            // prepopulat roles for the view dropdown
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            return View("ManageUserRoles");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                if (user != null)
                {
                    ViewBag.RolesForThisUser = UserManager.GetRoles(user.Id);
                }
                else
                {
                    ViewBag.TypeMessage = "danger";
                    ViewBag.ResultMessage = "El usuario introducido no existe";
                }

                // prepopulat roles for the view dropdown
                var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = list;
            }

            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (user != null)
            {
                if(RoleName=="")
                {
                    ViewBag.TypeMessage = "warning";
                    ViewBag.ResultMessage = "Por favor selecciona un rol";
                }
                else
                {
                    if (UserManager.IsInRole(user.Id, RoleName))
                    {
                        UserManager.RemoveFromRole(user.Id, RoleName);
                        ViewBag.TypeMessage = "success";
                        ViewBag.ResultMessage = "Rol eliminado del usuario correctamente!";
                    }
                    else
                    {
                        ViewBag.TypeMessage = "danger";
                        ViewBag.ResultMessage = "Este usuario no pertenece al rol seleccionado";
                    }
                }
            }
            else
            {
                ViewBag.TypeMessage = "danger";
                ViewBag.ResultMessage = "El usuario introducido no existe";
            }
            
            // prepopulat roles for the view dropdown
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            return View("ManageUserRoles");
        }
    }
}