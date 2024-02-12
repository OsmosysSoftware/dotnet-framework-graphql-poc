using DAL.Models;
using GraphQL.Types;

namespace API.Types.InputType
{
    public class TaskInputType : InputObjectGraphType<TaskDetails>
    {
        public TaskInputType()
        {
            Name = "Input";
            Field(x => x.TaskID);
            Field(x => x.TaskName);
            Field(x => x.ProjectCode);
            Field(x => x.ProjectName);
            Field(x => x.AssignedTo);
            Field(x => x.AssignedBy);
            Field(x => x.StatusType);
            Field(x => x.ExpectedHours);
            Field(x => x.BillableHours);
        }
    }
}