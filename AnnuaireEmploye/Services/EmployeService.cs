using AnnuaireEmploye.DataAccesslayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace AnnuaireEmploye.Services
{
    public class EmployeService
    {
        
      

        public bool IsUnique(string matricule)
        {
             AnnuaireEmployeContext db = new AnnuaireEmployeContext();
            bool isUnique = true;
            if (db.Employe.Any(e => e.Matricule == matricule))
                {
                isUnique = false;
            }

            return isUnique;

        }
    }
}