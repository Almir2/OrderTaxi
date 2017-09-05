using System;
using System.Web.Http;
using System.Web.Mvc;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

using ETOS.Core.Services;
using ETOS.Core.Services.Abstract;
using ETOS.DAL.EF;
using ETOS.DAL.Interfaces;
using ETOS.DAL.Repositories;


namespace ETOS.WebUI
{
	/// <summary>
	/// Класс, реализующий загрузчик контейнера Unity.
	/// </summary>
	public static class UnityBootstrapper
	{
		/// <summary>
		/// Метод, реализующий инициализацию контейнера Unity.
		/// </summary>
		public static IUnityContainer Initialize()
		{
			var container = BuildUnityContainer();

			// Назначение приложению созданного контейнера в качестве внедрителя зависимостей.
			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
			GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

			return container;
		}

		/// <summary>
		/// Метод, реализующий регистрацию типов для контейнера Unity.
		/// Для каждого IInterface, Unity будет создавать сопоставленный ему Type.
		/// </summary>
		/// <param name="container">Контейнер, для которого осуществляется регистрация типов.</param>
		public static void RegisterTypes(IUnityContainer container)
		{
			container.RegisterType<ILocationRepository, LocationRepository>();
			container.RegisterType<ILocationService, LocationService>();

			container.RegisterType<IEmployeeRepository, EmployeeRepository>();
			container.RegisterType<IEmployeeService, EmployeeService>();

			container.RegisterType<ILogRepository, LogRepository>();
			container.RegisterType<ILogService, LogService>();

			container.RegisterType<IBrandRepository, BrandRepository>();
			container.RegisterType<IBrandService, BrandService>();

			container.RegisterType<IModelRepository, ModelRepository>();
			container.RegisterType<IModelService, ModelService>();

			container.RegisterType<IContractorRepository, ContractorRepository>();
			container.RegisterType<IContractorService, ContractorService>();

			container.RegisterType<IRequestServiceHelper, RequestServiceHelper>();
			container.RegisterType<IRequestService, RequestService>();
			container.RegisterType<IRequestRepository, RequestRepository>();
			container.RegisterType<IDataWarehouseContext, EFDataWarehouseContext>();

			container.RegisterType<IUnitOfWork, IdentityUnitOfWork>();
			container.RegisterType<IApplicationUserService, ApplicationUserService>();
		}

		/// <summary>
		/// Метод, реализующий построение контейнера Unity.
		/// </summary>
		private static IUnityContainer BuildUnityContainer()
		{
			var container = new UnityContainer();

			RegisterTypes(container);

			return container;
		}


	}
}