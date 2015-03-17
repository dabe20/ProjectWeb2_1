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
    public class ProductosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Productos/
        public async Task<ActionResult> Index()
        {
            return View(await db.ProductosModels.ToListAsync());
        }

        // GET: /ProductDetails-5
        [Route("ProductDetails-{id}")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosModels productosmodels = await db.ProductosModels.FindAsync(id);
            if (productosmodels == null)
            {
                return HttpNotFound();
            }
            return View(productosmodels);
        }

        // GET: /Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Nombre,Descripcion,Foto,Estado,FechaRegistro")] ProductosModels productosmodels)
        {
            if (ModelState.IsValid)
            {
                db.ProductosModels.Add(productosmodels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(productosmodels);
        }

        // GET: /Productos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosModels productosmodels = await db.ProductosModels.FindAsync(id);
            if (productosmodels == null)
            {
                return HttpNotFound();
            }
            return View(productosmodels);
        }

        // POST: /Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Nombre,Descripcion,Foto,Estado,FechaRegistro")] ProductosModels productosmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productosmodels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productosmodels);
        }

        // GET: /Productos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosModels productosmodels = await db.ProductosModels.FindAsync(id);
            if (productosmodels == null)
            {
                return HttpNotFound();
            }
            return View(productosmodels);
        }

        // POST: /Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProductosModels productosmodels = await db.ProductosModels.FindAsync(id);
            db.ProductosModels.Remove(productosmodels);
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
