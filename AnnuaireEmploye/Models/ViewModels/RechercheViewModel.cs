using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnnuaireEmploye.Models.ViewModels
{
    public class RechercheViewModel
    {
        public RechercheViewModel()
        {
            Employes = new List<Employe>();
        }

        public string Matricule { get; set; }
        public string NomComplet { get; set; }
        public DateTime DateEmbaucheDebut { get; set; }
        public DateTime DateEmbaucheFin { get; set; }
        public int IdPoste { get; set; }
        public SelectList Postes { get; set; }
        public int IdDepartement { get; set; }
        public SelectList Departements { get; set; }
        public IList<Employe> Employes { get; set; }
        public Employe Employe { get; set; }
    }
}