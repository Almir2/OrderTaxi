using System;
using System.Collections.Generic;
using System.Web.Mvc;

using Ninject;

using ETOS.Core.Services;
using ETOS.Core.Services.Abstract;

namespace ETOS.WebUI.Utils
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();

            addBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void addBindings()
        {
            _kernel.Bind<IAccountService>().To<AccountService>();
        }

    }
}