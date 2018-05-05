using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MECANICAPP.BackEnd.Models;
using MECANICAPP.Domain;

namespace MECANICAPP.BackEnd.Controllers
{
    public class HistoriasController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Historias
        public async Task<ActionResult> Index()
        {
            var historias = db.Historias.Include(h => h.Item);
            return View(await historias.ToListAsync());
        }

        // GET: Historias/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historia historia = await db.Historias.FindAsync(id);
            if (historia == null)
            {
                return HttpNotFound();
            }
            return View(historia);
        }

        // GET: Historias/Create
        public ActionResult Create()
        {
            ViewBag.ItemsId = new SelectList(db.Items, "ItemsId", "Codigo");
            return View();
        }

        // POST: Historias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Historias,ItemsId,FechaIntervecion,Valor,Repuestos")] Historia historia)
        {
            if (ModelState.IsValid)
            {
                db.Historias.Add(historia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ItemsId = new SelectList(db.Items, "ItemsId", "Codigo", historia.ItemsId);
            return View(historia);
        }

        // GET: Historias/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historia historia = await db.Historias.FindAsync(id);
            if (historia == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemsId = new SelectList(db.Items, "ItemsId", "Codigo", historia.ItemsId);
            return View(historia);
        }

        // POST: Historias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Historias,ItemsId,FechaIntervecion,Valor,Repuestos")] Historia historia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ItemsId = new SelectList(db.Items, "ItemsId", "Codigo", historia.ItemsId);
            return View(historia);
        }

        // GET: Historias/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historia historia = await db.Historias.FindAsync(id);
            if (historia == null)
            {
                return HttpNotFound();
            }
            return View(historia);
        }

        // POST: Historias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Historia historia = await db.Historias.FindAsync(id);
            db.Historias.Remove(historia);
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
