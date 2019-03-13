using System.Web.Mvc;

namespace SSO.Api
{
    ///<Summary>
    ///</Summary>
    public class FilterConfig
    {
        ///<Summary>
        ///</Summary>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
