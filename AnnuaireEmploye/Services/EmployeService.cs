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

        public bool IsUnique(string matricule)
        {

            bool isUnique = !employeRepository.GetAnyEmployeByMatricule(matricule);

            return isUnique;

        }
    }
}