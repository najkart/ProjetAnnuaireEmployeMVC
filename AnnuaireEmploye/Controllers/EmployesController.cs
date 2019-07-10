using AnnuaireEmploye.DataAccesslayer;
using AnnuaireEmploye.Models;
using AnnuaireEmploye.Models.ViewModels;
using AnnuaireEmploye.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AnnuaireEmploye.Controllers
{
    public class EmployesController : Controller
    {
        private AnnuaireEmployeContext db = new AnnuaireEmployeContext();

        // GET: EmployesGenerated
        public ActionResult Index()
        {

            var vm = new CreateViewModel();

            var employeRepository = new EmployeRepository();
            var employes = employeRepository.GetEmployes();
            ViewBag.IdDepartement = new SelectList(db.Departement, "IdDepartement", "NomDepartement");
            ViewBag.IdPoste = new SelectList(db.Poste, "IdPoste", "NomPoste");

            vm.Employes = employes;

            vm.Actif = true;


            return View(vm);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Matricule,Name,IdPoste,IdDepartement,date,Actif")]SearchViewModel searchVM)
        {
            var employeRepository = new EmployeRepository();
            // var employe = employeRepository.GetEmployeByMatricule(searchVM.SearchMatricule);

            var employees = employeRepository.GetEmployes();

            searchVM.Name = searchVM.Name == null ? "" : searchVM.Name;
            searchVM.Matricule = searchVM.Matricule == null ? "" : searchVM.Matricule;


            var employeesfilter = employees.Where(x => x.Matricule.ToUpper().Contains(searchVM.Matricule.ToUpper()) && x.NomComplet.ToUpper().Contains(searchVM.Name.ToUpper())).ToList();


            // List<Employe> employes = new List<Employe>();
            // if (!String.IsNullOrEmpty(SearchMatricule)) {
            //     if (employe!=null) {
            //         employes.Add(employe);
            //     }
            //      //exeception employe null non gérée
            // }
            //else
            // {
            //     employes= employeRepository.GetEmployes();
            // }
            return View(employeesfilter);
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
            var employeRepository = new EmployeRepository();
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
                if (!employeService.Exist(employe.Matricule))
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
