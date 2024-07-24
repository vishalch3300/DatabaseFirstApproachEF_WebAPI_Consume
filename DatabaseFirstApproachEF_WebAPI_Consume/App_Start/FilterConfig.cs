using System.Web;
using System.Web.Mvc;

namespace DatabaseFirstApproachEF_WebAPI_Consume
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
