using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Intercambealo.Models;

namespace Intercambealo.Controllers
{
    public class UsuariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Usuarios/
        public async Task<ActionResult> Index()
        {
            return View(await db.UsuariosModels.ToListAsync());
        }

        // GET: /Usuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosModels usuariosmodels = await db.UsuariosModels.FindAsync(id);
            if (usuariosmodels == null)
            {
                return HttpNotFound();
            }
            return View(usuariosmodels);
        }

        // GET: /Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Nombre,Correo,Contraseña,ConfirContraseña,Telefono,Edad")] UsuariosModels usuariosmodels)
        {
            if (ModelState.IsValid)
            {
                db.UsuariosModels.Add(usuariosmodels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(usuariosmodels);
        }

        // GET: /Usuarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosModels usuariosmodels = await db.UsuariosModels.FindAsync(id);
            if (usuariosmodels == null)
            {
                return HttpNotFound();
            }
            return View(usuariosmodels);
        }

        // POST: /Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Nombre,Correo,Contraseña,ConfirContraseña,Telefono,Edad")] UsuariosModels usuariosmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuariosmodels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(usuariosmodels);
        }

        // GET: /Usuarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosModels usuariosmodels = await db.UsuariosModels.FindAsync(id);
            if (usuariosmodels == null)
            {
                return HttpNotFound();
            }
            return View(usuariosmodels);
        }

        // POST: /Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UsuariosModels usuariosmodels = await db.UsuariosModels.FindAsync(id);
            db.UsuariosModels.Remove(usuariosmodels);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
