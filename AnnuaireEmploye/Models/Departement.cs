using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AnnuaireEmploye.Models
{
    public class Departement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDepartement { get; set; }
        public string NomDepartement { get; set; }
        public virtual ICollection<Employe> Employes { get; set; }
    }
}