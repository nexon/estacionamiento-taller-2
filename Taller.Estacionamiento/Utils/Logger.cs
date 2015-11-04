using System;
using System.Globalization;
using System.Web;

namespace Taller.Estacionamiento.Utils
{
    public class Logger
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("Estacionamiento");

        public static void Info(string nombreMetodo, string parametros)
        {
            logger.Info(string.Format("Method: {0},  Info: ({1})", nombreMetodo, parametros ?? string.Empty));
        }

        public static void EntradaMetodo(string nombreMetodo, string parametros)
        {
            logger.Info(string.Format("Starting Method: {0},  Parameters: ({1})", nombreMetodo, parametros ?? string.Empty));
        }

        public static void SalidaMetodo(string nombreMetodo, string parametros)
        {
            logger.Info(string.Format("End Method: {0},  Parameters: ({1})", nombreMetodo, parametros ?? string.Empty));
        }

        public static void Excepcion(Exception ex)
        {
            logger.Fatal(ex);
        }
    }
}