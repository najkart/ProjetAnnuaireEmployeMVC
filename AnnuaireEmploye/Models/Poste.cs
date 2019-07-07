using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AnnuaireEmploye.Models
{
    public class Poste
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPoste { get; set; }
        public string NomPoste { get; set; }

        public virtual ICollection<Employe> Employes { get; set; }
    }
}