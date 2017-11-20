using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _4Healthy_.Contexts;
using _4Healthy_.Models;

namespace _4Healthy_.Controllers
{
    public class AlimentosController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Alimentos
        public ActionResult Index()
        {
            var alimento = db.Alimento.Include(a => a.Categoria);
            return View(alimento.ToList());
        }

        // GET: Alimentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alimento alimento = db.Alimento.Find(id);
            if (alimento == null)
            {
                return HttpNotFound();
            }
            return View(alimento);
        }

        // GET: Alimentos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaId", "Nome");
            return View();
        }

        // POST: Alimentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlimentoId,Descricao,CategoriaId,Calorias,Carboidratos,Proteinas,Gorduras")] Alimento alimento)
        {
            if (ModelState.IsValid)
            {
                db.Alimento.Add(alimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaId", "Nome", alimento.CategoriaId);
            return View(alimento);
        }

        // GET: Alimentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alimento alimento = db.Alimento.Find(id);
            if (alimento == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaId", "Nome", alimento.CategoriaId);
            return View(alimento);
        }

        // POST: Alimentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlimentoId,Descricao,CategoriaId,Calorias,Carboidratos,Proteinas,Gorduras")] Alimento alimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaId", "Nome", alimento.CategoriaId);
            return View(alimento);
        }

        // GET: Alimentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alimento alimento = db.Alimento.Find(id);
            if (alimento == null)
            {
                return HttpNotFound();
            }
            return View(alimento);
        }

        // POST: Alimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alimento alimento = db.Alimento.Find(id);
            db.Alimento.Remove(alimento);
            db.SaveChanges();
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
