using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnnuaireEmploye.Models.ViewModels
{
    public class SearchViewModel
    {
        public string Matricule { get; set; }
       
        public string NomComplet { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateEmbauche { get; set; }
      
        public int IdPoste { get; set; }

        public int IdDepartement { get; set; }
        public bool Actif { get; set; }

       
        public string Email { get; set; }

     
        public string Telephone { get; set; }

        public string Ville { get; set; }
        public Employe Employe { get; set; }
        public List<Employe> Employes { get; set; }
        public SelectList Postes { get; set; }
        public SelectList Departements { get; set; }


        public SearchViewModel()
        {
            Employes = new List<Employe>();
        }

    }
}