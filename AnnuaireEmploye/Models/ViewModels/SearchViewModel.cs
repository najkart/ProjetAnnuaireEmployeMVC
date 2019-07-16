using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        public IEnumerable<Employe> Employes { get; set; }
        public IEnumerable<Poste> Postes { get; set; }
        public IEnumerable<Departement> Departements { get; set; }

    }
}