using System;
using System.Web.Mvc;

using Owin;

using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

using ETOS.Core.Services.Abstract;

namespace ETOS.WebUI
{
	/// <summary>
	/// Реализует инициализацию и настройку Identity.
	/// </summary>
	public class IdentityConfig
	{
		public void Configuration(IAppBuilder appBuilder)
		{
			appBuilder.CreatePerOwinContext(() => DependencyResolver.Current.GetService<IApplicationUserService>());

			appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/Login")
			});
		}
	}
}