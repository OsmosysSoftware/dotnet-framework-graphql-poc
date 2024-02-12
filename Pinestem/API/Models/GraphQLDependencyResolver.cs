using GraphQL;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class GraphQLDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public GraphQLDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }


        #region IDependencyResolver implementation 

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            return _kernel.Get(type);
        }

        #endregion
    }
}
