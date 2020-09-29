using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Conectividad
    {
        public static bool RevisarConexion(string _host, int _timeout)
        {
            bool statusPing = false;
            Ping pingSender = new Ping();
            PingReply reply = null;
            try
            {
                int timeout = _timeout;
                reply = pingSender.Send(_host, timeout);

                if (reply.Status == IPStatus.Success)
                {
                    statusPing = true;
                }
            }
            catch
            {
                statusPing = false;
                //$"Problemas de conexion con host => {_host} ".Error();
            }
            return statusPing;
        }
    }
}
