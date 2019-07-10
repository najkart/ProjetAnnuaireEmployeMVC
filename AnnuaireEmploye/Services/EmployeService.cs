using AnnuaireEmploye.DataAccesslayer;
using AnnuaireEmploye.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace AnnuaireEmploye.Services
{
    public class EmployeService
    {

        EmployeRepository employeRepository = new EmployeRepository();

        public bool Exist(string matricule)
        {
            bool exist = false;

            if (employeRepository.GetEmployeByMatricule(matricule) != null)
            { exist = true; }
      

            return exist;

        }
    }
}