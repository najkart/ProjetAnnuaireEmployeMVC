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
        public List<Employe> GetEmployes()
        {

            var employes = db.Employe.Include(e => e.Departement).Include(e => e.Poste);
            return (employes.ToList());
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

        public Employe GetEmployeByMatricule(String matricule)
        {

            return db.Employe.FirstOrDefault(e => e.Matricule == matricule);
        }


        public List<Employe> GetEmployeByCritere(String matricule,string nomComplet, int idPoste , int idDepartement, DateTime dateEmbauche , bool actif)
        {

            return db.Employe.Where(emp => emp.Matricule.ToUpper().Contains(matricule.ToUpper())
            || emp.NomComplet.ToUpper().Contains(nomComplet.ToUpper())
            || emp.IdPoste ==idPoste || emp.IdDepartement == idDepartement
            || emp.DateEmbauche == dateEmbauche || emp.Actif==actif).ToList();
        }

    }
}