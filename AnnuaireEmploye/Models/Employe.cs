using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AnnuaireEmploye.Models
{
    public class Employe
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmploye { get; set; }
        [Required]
        public string Matricule { get; set; }
        [Required]
        public string NomComplet { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateEmbauche { get; set; }
        [ForeignKey("Poste")]
        public int IdPoste { get; set; }
        [ForeignKey("Departement")]
        public int IdDepartement { get; set; }
        public bool Actif { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string Telephone { get; set; }

        [Display(Name ="Villlllle")]
        public string Ville { get; set; }

        public virtual Departement Departement { get; set; }
        public virtual Poste Poste { get; set; }
    }
}