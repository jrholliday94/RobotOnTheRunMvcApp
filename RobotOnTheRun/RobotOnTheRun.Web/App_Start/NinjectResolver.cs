﻿using Ninject;
using Ninject.Extensions.ChildKernel;
using RobotOnTheRun.Shared.Orchestrators;
using RobotOnTheRun.Shared.Orchestrators.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace Angular4WebApi.App_Start
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver() : this(new StandardKernel())
        {

        }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            kernel = ninjectKernel;
            if (!scope)
            {
                AddBindings(kernel);
            }
        }

        private void AddBindings(IKernel kernel)
        {
            // singleton and transient bindings go here
        }

        private IKernel AddRequestBindings(IKernel kernel)
        {
            kernel.Bind<IHighScoreOrchestrator>().To<HighScoreOrchestrator>().InSingletonScope();
            kernel.Bind<IPersonOrchestrator>().To<PersonOrchestrator>().InSingletonScope();
            kernel.Bind<IProjectMemberOrchestrator>().To<ProjectMemberOrchestrator>().InSingletonScope();

            return kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectResolver(AddRequestBindings(new ChildKernel(kernel)), true);
        }

        public void Dispose()
        {
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}