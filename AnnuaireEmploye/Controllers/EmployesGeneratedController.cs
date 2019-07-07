using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnnuaireEmploye.DataAccesslayer;
using AnnuaireEmploye.Models;
using AnnuaireEmploye.Services;

namespace AnnuaireEmploye.Controllers
{
    public class EmployesGeneratedController : Controller
    {
        private AnnuaireEmployeContext db = new AnnuaireEmployeContext();

        // GET: EmployesGenerated
        public ActionResult Index()
        {
            var employeRepository = new EmployeRepository();
            var employes = employeRepository.GetEmployes();
            return View(employes);
        }

        // GET: EmployesGenerated/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {

            }
            var employeRepository= new EmployeRepository();
            Employe employe = employeRepository.GetEmployeById(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // GET: EmployesGenerated/Create
        public ActionResult Create()
        {
            ViewBag.IdDepartement = new SelectList(db.Departement, "IdDepartement", "NomDepartement");
            ViewBag.IdPoste = new SelectList(db.Poste, "IdPoste", "NomPoste");
            return View();
        }

        // POST: EmployesGenerated/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmploye,Matricule,NomComplet,DateEmbauche,IdPoste,IdDepartement,Actif,Ville,Email,Telephone")] Employe employe)
        {
            
            if (ModelState.IsValid)
            {
               
                var employeService = new EmployeService();
                if (employeService.IsUnique(employe.Matricule))
                {
                    var employeRepository = new EmployeRepository();
                    employeRepository.AddEmploye(employe);

                    return RedirectToAction("Index");

                }
                else
                {
                    ModelState.AddModelError("Matricule", "Ce matricule existe déjà");
                }
             
            }

            ViewBag.IdDepartement = new SelectList(db.Departement, "IdDepartement", "NomDepartement", employe.IdDepartement);
            ViewBag.IdPoste = new SelectList(db.Poste, "IdPoste", "NomPoste", employe.IdPoste);
            return View(employe);
        }

        // GET: EmployesGenerated/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeRepository = new EmployeRepository();
            Employe employe = employeRepository.GetEmployeById(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDepartement = new SelectList(db.Departement, "IdDepartement", "NomDepartement", employe.IdDepartement);
            ViewBag.IdPoste = new SelectList(db.Poste, "IdPoste", "NomPoste", employe.IdPoste);
            return View(employe);
        }

        // POST: EmployesGenerated/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmploye,Matricule,NomComplet,DateEmbauche,IdPoste,IdDepartement,Actif,Ville,Email,Telephone")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                var employeRepository = new EmployeRepository();
                employeRepository.UpdateEmploye(employe);
                return RedirectToAction("Index");
            }
            ViewBag.IdDepartement = new SelectList(db.Departement, "IdDepartement", "NomDepartement", employe.IdDepartement);
            ViewBag.IdPoste = new SelectList(db.Poste, "IdPoste", "NomPoste", employe.IdPoste);
            return View(employe);
        }

        // GET: EmployesGenerated/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeRepository = new EmployeRepository();
            Employe employe = employeRepository.GetEmployeById(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: EmployesGenerated/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var employeRepository = new EmployeRepository();
            Employe employe = employeRepository.GetEmployeById(id);
            employeRepository.RemoveEmploye(employe);
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
