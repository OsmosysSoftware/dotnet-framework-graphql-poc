using GraphQL.Types;
using DAL.Models;

namespace API.Types
{
    public class TaskFilter : ObjectGraphType<TasksFilter>
    {
        public TaskFilter()
        {
            Field(f => f.TaskID, nullable: true);
            Field(f => f.TaskName, nullable: true);
            Field<ListGraphType<IntGraphType>>("userStoryID");
            Field<IntGraphType>("companyID");
            Field<ListGraphType<IntGraphType>>("projectID");
            Field<ListGraphType<StringGraphType>>("projectCode");
            Field<ListGraphType<StringGraphType>>("userStoryShortCode");
            Field<ListGraphType<IntGraphType>>("taskCategoryID");
            Field<ListGraphType<ShortGraphType>>("taskStatusID");
            Field<ListGraphType<IntGraphType>>("sprintID");
            Field<ListGraphType<IntGraphType>>("assignedTo");
            Field<BooleanGraphType>("excludeInformTo");
            Field<ListGraphType<ShortGraphType>>("billingStatusID");
        }
    }
}