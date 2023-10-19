using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.Core.Services.CalculatePreScoring
{
    public class CheckMayoriaEdad : INegationRule
    {

        public bool Check(Solicitud solicitud)
        {
            int age = getAge(solicitud.cliente.FechaDeNacimiento);

            return age < 18 ;
        }

        private int getAge(DateTime birthDate) {

            DateTime today = DateTime.Today;

            int years = today.Year - birthDate.Year;
            int months = today.Month - birthDate.Month;
            int days = today.Day - birthDate.Day;


            if (days < 0)
                months--;

            if (months < 0)
                years--;


            return years;
        }

    }
}
