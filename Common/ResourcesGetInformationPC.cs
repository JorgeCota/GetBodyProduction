using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public static class ResourcesGetInformationPC
    {
        public static string GetMacAdrs()
        {
            var macAddr = (
                from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString()
                 ).FirstOrDefault();

            return macAddr;

        }

        public static int[] GetSizeScreen()
        {
            int[] size = new int[2];

            size[0] = Screen.PrimaryScreen.Bounds.Width; //Obtiene el alto de la pantalla principal en pixeles.
            size[1] = Screen.PrimaryScreen.Bounds.Height; //Obtiene el ancho de la pantalla principal en pixeles.

            return size;
        }

        public static List<string> GetInfoPC()
        {

            List<string> lstValues = new List<string>();

            lstValues.Add(Environment.MachineName);
            lstValues.Add(Environment.UserName);
            lstValues.Add(Environment.UserDomainName);

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    lstValues.Add(ip.ToString());
                }
            }

            lstValues.Add(GetMacAdrs());

            return lstValues;

        }

    }
}
