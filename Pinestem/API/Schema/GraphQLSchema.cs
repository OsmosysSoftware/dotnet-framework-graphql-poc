using API.Queries;
using GraphQL;

namespace API.Schema
{
    public class GraphQLSchema : GraphQL.Types.Schema
    {
        public GraphQLSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TaskQuery>();
        }
    }
}