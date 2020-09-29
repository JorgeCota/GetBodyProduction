using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ResourcesDateTime
    {
 
        public static string getTurno(DateTime fecha)
        {
            string turno = "";
            if ((fecha.Hour >= 6) && fecha.Hour <= 16)
            {
                if ((fecha.Minute >= 40) && fecha.Hour >= 16)
                    turno = "B";               
                else
                    turno = "A";               
            }
            else if ((fecha.Hour == 16) && (fecha.Minute < 40))
                turno = "A";           
            else if ((fecha.Hour == 16) && (fecha.Minute >= 40))
                turno = "B";           
            else if ((fecha.Hour > 16) && (fecha.Hour <= 23) && (fecha.Minute <= 59))
                turno = "B";
           
            return turno;
        }

        public static DateTime[] GetFirstAndLastDayOfMont(DateTime fecha)
        {
            DateTime[] arr = new DateTime[2];

            arr[0] = Convert.ToDateTime(new DateTime(fecha.Year,fecha.Month,1));
            arr[1] = Convert.ToDateTime(arr[0].AddMonths(1).AddDays(-1));

            return arr;

         }

        public static DateTime[] GetDateIniAdnFinTurno(string turno)
        {
            DateTime[] arrFechas = new DateTime[2];

            string fInicial = DateTime.Now.ToShortDateString();

            if (turno.Contains("A"))
            {
                arrFechas[0] = Convert.ToDateTime(fInicial).AddHours(7);
                arrFechas[1] = Convert.ToDateTime(fInicial).AddHours(16).AddMinutes(39);
            }
            else
            {
                arrFechas[0] = Convert.ToDateTime(fInicial).AddHours(16).AddMinutes(40);
                arrFechas[1] = Convert.ToDateTime(fInicial).AddDays(1).AddHours(1).AddMinutes(35);
            }

            return arrFechas;
        }

        public static DateTime[] GetCurrentAndNextHour(int hora )
        {
            DateTime[] arrFechas = new DateTime[2];
            
            arrFechas[0] = Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddHours(hora);

            if (getTurno(DateTime.Now).Contains("A"))
            {
                if ((hora >= 7) && (hora < 16))
                    arrFechas[1] = Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddHours(hora + 1);
                else
                    arrFechas[1] = Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddHours(hora + 1).AddMinutes(40);
            }
            else
            {
                if ((hora >= 16) && (DateTime.Now.Minute > 40))
                {
                    arrFechas[0] = Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddHours(hora).AddMinutes(40);
                    arrFechas[1] = Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddHours(hora+2);
                }                   
                else
                    arrFechas[1] = Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddHours(hora + 1).AddMinutes(40);
            }
            

            return arrFechas;
        }
    }
}
