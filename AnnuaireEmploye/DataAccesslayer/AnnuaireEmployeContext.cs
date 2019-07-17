using AnnuaireEmploye.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnnuaireEmploye.DataAccesslayer
{
    public class AnnuaireEmployeContext : DbContext
    {
   
        public DbSet<Employe> Employe { get; set; }
        public DbSet<Poste> Poste { get; set; }
        public DbSet<Departement> Departement { get; set; }

 
        public AnnuaireEmployeContext(): base("AnnuaireEmployeContext") // the name of the connection string is passed to the constructor 
        {


        }
    }
}