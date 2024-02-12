[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(API.App_Start.GraphQLConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(API.App_Start.GraphQLConfig), "Stop")]

namespace API.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using Ninject.Web.WebApi;
    using GraphQL;
    using GraphQL.Types;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using DAL.GraphQL.Interface;
    using API.Queries;
    using API.Types;
    using API.Schema;
    using API.Types.InputType;
    using DAL.GraphQL;
    using API.Models;

    public static class GraphQLConfig
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);


                // VERY IMPORTANT: ONLY FOR WEBAPI PROJECTS.
                // This following line is needed if we want to use ninject to construct the api controllers.
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);


                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ITaskRepository>().To<TaskRepository>();
            kernel.Bind<IDocumentExecuter>().To<DocumentExecuter>();
            kernel.Bind<TaskQuery>().ToSelf();
            kernel.Bind<TaskType>().ToSelf();
            kernel.Bind<TaskInputType>().ToSelf();
            kernel.Bind<ISchema>().To<GraphQLSchema>();

            // Pass the same kernel
            kernel.Bind<GraphQL.IDependencyResolver>().To<GraphQLDependencyResolver>().WithConstructorArgument(kernel);
        }
    }
}