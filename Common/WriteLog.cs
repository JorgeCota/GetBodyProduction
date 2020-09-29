using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class WriteLog
    {
        public static void WriteLogInformation(string funcion, DateTime fecha)
        {
            if (funcion == "Total")
            {
                TimeSpan tm = DateTime.Now - fecha;
                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("log.txt")
                .CreateLogger();
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", tm.Minutes, tm.Seconds, tm.Milliseconds);
                Log.Information($"Funcion=> {funcion} , TM ejecucion => {elapsedTime}");
                Log.CloseAndFlush();
            }
            else if (ConfigurationManager.AppSettings["serilogall"].ToString().ToUpper() == "Y")
            {
                TimeSpan tm = DateTime.Now - fecha;
                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("log.txt")
                .CreateLogger();
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", tm.Minutes, tm.Seconds, tm.Milliseconds);
                Log.Information($"Funcion => {funcion} , TM ejecucion => {elapsedTime}");
                Log.CloseAndFlush();
            }



        }

        public static void WriteLogException(string funcion, Exception e, DateTime fecha)
        {
            TimeSpan tm = DateTime.Now - fecha;
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("log.txt")
            .CreateLogger();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", tm.Minutes, tm.Seconds, tm.Milliseconds);
            Log.Fatal($"Error => {funcion}, TM ejecucion => {elapsedTime} Ecepcion => {e.Message}");
            Log.CloseAndFlush();
        }
    }
}
