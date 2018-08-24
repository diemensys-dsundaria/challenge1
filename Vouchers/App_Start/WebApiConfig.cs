using System.Web.Http;

namespace Dominos.OLO.Vouchers
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            UnityWebApiActivator.Start();
            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
