using System.Web;
using System.Web.Optimization;

namespace ETOS.WebUI.App_Start
{
	public class BundleConfig
	{
		// Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
					"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					"~/Scripts/bootstrap.js",
					"~/Scripts/respond.js",
					"~/Scripts/moment-with-locales.min.js",
					"~/Scripts/bootstrap-datetimepicker.min.js"
					));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					"~/Content/bootstrap.css",
					"~/Content/bootstrap-datetimepicker.css",
					"~/Content/site.css"
					));

			bundles.Add(new StyleBundle("~/Content/css/pagedList").Include(
					"~/Content/PagedList.css"));

			bundles.Add(new ScriptBundle("~/bundles/geolocation").Include(
					"~/Scripts/geolocationAPI.js"
					));
		}
	}
}