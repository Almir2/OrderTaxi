using System.Web.Mvc;
using System.Web.Routing;

namespace ETOS.WebUI
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			// Игнорируемые маршруты.
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("Account/Login");
			routes.IgnoreRoute("Admin/Contractors/Index");
			routes.IgnoreRoute("Admin/Contractors");
			routes.IgnoreRoute("Brand/");
			routes.Ignore("Brand/Index");

			// Маршрут для страницы авторизации.
			routes.MapRoute(
				name: "LoginFormRoute",
				url: "Login",
				defaults: new { controller = "Account", action = "Login" }
				);

			// Маршрут для страницы со списком подрядчиков.
			routes.MapRoute(
				name: "ContractorsListRoute",
				url: "Contractors",
				defaults: new { controller = "Contractor", action = "Index" }
				);

			// Маршрут для страницы со списком марок автомобилей.
			routes.MapRoute(
				name: "BrandsListRoute",
				url: "Brands",
				defaults: new { controller = "Brand", action = "Index" }
			);

			// Стандартный шаблон.
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Request", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
