﻿using AnnuaireEmploye.DataAccesslayer;
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


        public IList<Employe> GetEmployeByCritere(String matricule,string NomComplet, int IdPoste , int IdDepartement)
        {

            return db.Employe.Where(emp => emp.Matricule.Contains(matricule) && emp.NomComplet.Contains(NomComplet)
            && emp.IdPoste == IdPoste && emp.IdDepartement == IdDepartement).ToList();
        }

    }
}