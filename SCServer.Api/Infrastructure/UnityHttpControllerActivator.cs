using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Microsoft.Practices.Unity;

namespace SCServer.Api.Infrastructure
{
    public class UnityHttpControllerActivator : IHttpControllerActivator
    {
        private IUnityContainer _container;

        public UnityHttpControllerActivator(IUnityContainer container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            IUnityContainer childContainer = _container.CreateChildContainer();
            var controller = (IHttpController)childContainer.Resolve(controllerType);
            request.RegisterForDispose(new ReleaseResource(() => childContainer.Dispose()));

            return controller;
        }
    }
}
