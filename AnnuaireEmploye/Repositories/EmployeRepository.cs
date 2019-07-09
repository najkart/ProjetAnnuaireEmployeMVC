using AnnuaireEmploye.DataAccesslayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace AnnuaireEmploye.Models
{
    public class EmployeRepository
    {
        private AnnuaireEmployeContext db = new AnnuaireEmployeContext();
        public IEnumerable<Employe> GetEmployes()
        {
            var employes = db.Employe.Include(e => e.Departement).Include(e => e.Poste);
            return (employes);
        }

        public Employe GetEmployeById(int? id)
        {
            var employe = db.Employe.Find(id);
            return employe;
        }

        public void AddEmploye(Employe employe)
        {
            db.Employe.Add(employe);
            db.SaveChanges();
        }
        public void UpdateEmploye(Employe employe)
        {
           db.Entry(employe).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveEmploye(Employe employe)
        {
            db.Employe.Remove(employe);
            db.SaveChanges();
        }

        public bool GetAnyEmployeByMatricule(String matricule)
        {

            return db.Employe.Any(e => e.Matricule == matricule);
        }

    }
}