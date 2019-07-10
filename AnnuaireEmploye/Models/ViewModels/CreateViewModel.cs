using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnnuaireEmploye.Models.ViewModels
{
    public class CreateViewModel
    {

        public List<Employe> Employes { get; set; }
     

        public Employe BindingLabel{ get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime date { get; set; }

        public bool Actif { get; set; }
    }
}
