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

            var searchVM = new SearchViewModel();

            var employeRepository = new EmployeRepository();
            searchVM.Employes = employeRepository.GetEmployes();
            ViewBag.Departements = new SelectList(db.Departement, "IdDepartement", "NomDepartement");
            ViewBag.IdPoste = new SelectList(db.Poste, "IdPoste", "NomPoste");



            searchVM.Actif = true;


            return View(searchVM);
        }

        [HttpPost]
        public ActionResult Index(SearchViewModel searchVM)
        {
            var employeRepository = new EmployeRepository();
            // var employe = employeRepository.GetEmployeByMatricule(searchVM.SearchMatricule);

            var employes = employeRepository.GetEmployes();

            searchVM.NomComplet = searchVM.NomComplet == null ? "" : searchVM.NomComplet;
            searchVM.Matricule = searchVM.Matricule == null ? "" : searchVM.Matricule;


            searchVM.Employes = employes.Where(x => x.Matricule.ToUpper().Contains(searchVM.Matricule.ToUpper()) && x.NomComplet.ToUpper().Contains(searchVM.NomComplet.ToUpper())).ToList();
            ViewBag.IdDepartement = new SelectList(db.Departement, "IdDepartement", "NomDepartement");
            ViewBag.IdPoste = new SelectList(db.Poste, "IdPoste", "NomPoste");

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
            return View(searchVM);
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


        public ActionResult Recherche()
        {

            var RechercheVM = new RechercheViewModel();

            var employeRepository = new EmployeRepository();
            RechercheVM.Employes = employeRepository.GetEmployes();
            RechercheVM.Departements = new SelectList(db.Departement, "IdDepartement", "NomDepartement");
            RechercheVM.Postes = new SelectList(db.Poste, "IdPoste", "NomPoste");

            return View(RechercheVM);
        }

        [HttpPost]
        public ActionResult Recherche(RechercheViewModel RechercheVM)
        {
            var employeRepository = new EmployeRepository();
            RechercheVM.NomComplet = RechercheVM.NomComplet??"";
            RechercheVM.Matricule = RechercheVM.Matricule ?? "";

            RechercheVM.Employes = employeRepository.GetEmployeByCritere(RechercheVM.Matricule, RechercheVM.NomComplet, RechercheVM.IdPoste, RechercheVM.IdDepartement);

            RechercheVM.Departements = new SelectList(db.Departement, "IdDepartement", "NomDepartement");
            RechercheVM.Postes = new SelectList(db.Poste, "IdPoste", "NomPoste");


            return View(RechercheVM);
        }


    }
}
