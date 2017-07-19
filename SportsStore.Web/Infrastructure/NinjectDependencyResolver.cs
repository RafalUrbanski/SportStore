using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using Ninject;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.Domain.Repositories;

namespace SportsStore.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        #region Fields

        private IKernel kernel;

        #endregion

        #region Constructors

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        #endregion

        #region Public Methods

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        #endregion

        #region Non-public Methods

        private void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<DatabaseProductRepository>();
        }

        #endregion
    }
}