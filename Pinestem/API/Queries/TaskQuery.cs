using API.Types;
using DAL.GraphQL.Interface;
using GraphQL.Types;


namespace API.Queries
{
    public class TaskQuery : ObjectGraphType
    {
        public TaskQuery(ITaskRepository taskRepository)
        {
            Field<ListGraphType<TaskType>>(
                "properties",
                resolve: context => taskRepository.GetAll());

            Field<TaskType>(
                "property",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => taskRepository.GetById(context.GetArgument<int>("id")));
        }
    }
}