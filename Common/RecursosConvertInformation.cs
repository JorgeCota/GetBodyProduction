using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class RecursosConvertInformation
    {
        public static string convertTurno(string _turno)
        {
            string turno = string.Empty;
            switch (_turno)
            {
                case "1":
                    turno = "A";
                    break;
                case "2":
                    turno = "B";
                    break;
                default:
                    break;
            }

            return turno;
        }
    }
}
