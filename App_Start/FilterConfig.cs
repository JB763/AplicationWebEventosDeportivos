using System.Web;
using System.Web.Mvc;

namespace AplicationWeb_CRUD_EventosDeportivos
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
