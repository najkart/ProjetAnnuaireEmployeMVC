using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnnuaireEmploye.Models
{
    public class SearchViewModel
    {
        public String Matricule { get; set; }
        public String Name { get; set; }
        public String IdPoste { get; set; }
        public String IdDepartement { get; set; }
    
        public DateTime Date { get; set; }
        public bool Actif { get; set; }
    }
}