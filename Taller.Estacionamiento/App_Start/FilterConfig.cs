using System.Web;
using System.Web.Mvc;

namespace Taller.Estacionamiento
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}