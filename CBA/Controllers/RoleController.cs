using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CBA.Models.Models;
using CBA.Models.ViewModels.RoleViewModels;
using CBA.BusinessLogic;
using AppContext = CBA.Models.Models.AppContext;
using System.Threading.Tasks;

namespace CBA.Controllers
{
    public class RoleController : Controller
    {
        private AppContext db = new AppContext();
        RoleLogic roleLogic = new RoleLogic();

        public async Task<ActionResult> RoleClaims()
        {
            var roles = await db.Roles
                .Include(c => c.RoleClaims)
                .Select(c => new RoleClaimsViewModel
                {
                    Role = c,
                    RoleClaims = c.RoleClaims.Where(x => x.Claim.ID == x.ClaimID)
                }).ToListAsync();

            return View(roles);
        }

        // GET: role/create 
        public ActionResult Create()
        {
            ViewBag.Claims = roleLogic.getAllClaims();
            return View();
        }

        // POST: role/create   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (roleLogic.isRoleNameExists(model.Name))
                    {
                        ModelState.AddModelError("", "Role name must be unique");
                        ViewBag.Claims = roleLogic.getAllClaims();
                        return View(model);
                    }
                    Role role = new Role { Name = model.Name };
                    db.Roles.Add(role);
                    foreach(var claimID in model.ClaimIDs)
                    {
                        db.RoleClaims.Add(new RoleClaim { RoleID = role.ID, ClaimID = claimID });
                    }
                    
                    db.SaveChanges();
                    TempData["CreateRoleSuccess"] = "Role Created Successfuly!";

                    return RedirectToAction("RoleClaims");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.ToString());
                    ViewBag.Claims = roleLogic.getAllClaims();
                    return View(model);
                }
            }
            ViewBag.Claims = roleLogic.getAllClaims();
            ModelState.AddModelError("", "Please enter valid data");
            return View(model);
        }

        // GET: role/edit/2
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();

            }
            ViewBag.Claims = roleLogic.getAllClaims();

            var roles = await db.Roles
                .Include(c => c.RoleClaims)
                .Where(x => x.ID == id)
                .Select(c => new EditRoleViewModel
                {
                    RoleId = c.ID,
                    Name = c.Name,
                    Role = c,
                    RoleClaims = c.RoleClaims.Where(x => x.Claim.ID == x.ClaimID)
                })
                .FirstOrDefaultAsync();

            return View(roles);
        }

        // POST: role/edit/2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    /*if (model.ClaimIDs.Count() == 0)
                    {
                        ModelState.AddModelError("", "Please enter valid data");
                        //return RedirectToAction("Edit", new { id = model.RoleId });
                        return View(model);
                    }*/
                    Role role = db.Roles.Find(model.RoleId);
                    // if role name has changed
                    if (!model.Name.ToLower().Equals(role.Name.ToLower()))
                    {
                        // Check if the new name exists
                        if (roleLogic.isRoleNameExists(model.Name))
                        {
                            ModelState.AddModelError("", "Role name must be unique");
                            return View(model);
                        }
                    }
                    role.Name = model.Name;
                    db.Entry(role).State = EntityState.Modified;
                    /*db.SaveChanges();*/

                    // Remove all claims for role
                    db.RoleClaims.RemoveRange(role.RoleClaims);

                    // Save the new claims for the role
                    foreach (var claimID in model.ClaimIDs)
                    {
                        db.RoleClaims.Add(new RoleClaim { RoleID = role.ID, ClaimID = claimID });
                    }
                    db.SaveChanges();

                    TempData["EditRoleSuccess"] = "Role Edited Successfuly!";
                    return RedirectToAction("RoleClaims");
                }
                catch (Exception e)
                {
                    ViewBag.Claims = roleLogic.getAllClaims();
                    ModelState.AddModelError("", e.ToString());
                    //return View(model);
                    TempData["EditError"] = "Something is broken";
                    return RedirectToAction("Edit", new { id = model.RoleId });
                }
            }
            ViewBag.Claims = roleLogic.getAllClaims();
            ModelState.AddModelError("", "Please enter valid data");
            /*return View(model);*/

            TempData["EditError"] = "Something is broken";
            return RedirectToAction("Edit", new { id = model.RoleId });
        }

        // GET: role/delete/2
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            
            return View(role);
        }

        // POST: role/delete/2
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Role role = db.Roles.Find(id);
            db.Roles.Remove(role);
            db.SaveChanges();

            TempData["DeleteRoleSuccess"] = "Role Deleted Successfuly!";
            return RedirectToAction("RoleClaims");
        }

        // GET: role/togglestatus/2
        public ActionResult ToggleStatus(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            if (role.Status == Status.Active)
            {
                role.Status = Status.Inactive;
                TempData["DeactivateRoleSuccess"] = "Role Deactivated Successfuly!";
            }
            else
            {
                role.Status = Status.Active;
                TempData["ActivateRoleSuccess"] = "Role Activated Successfuly!";
            }
            db.Entry(role).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("RoleClaims");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}