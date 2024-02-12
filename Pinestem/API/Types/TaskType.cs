using GraphQL.Types;
using DAL.Models;

namespace API.Types
{
    public class TaskType : ObjectGraphType<TaskDetails>
    {
        public TaskType()
        {
            Field(x => x.TaskID);
            Field(x => x.TaskName);
            Field(x => x.OwnerID, type: typeof(IdGraphType));
            Field(x => x.TaskDueDate);
            Field(x => x.AssignedTo);
            Field(x => x.AssignedBy);
            Field(x => x.TaskProjectID);
            Field(x => x.StatusType);
            Field(x => x.ExpectedHours);
            Field(x => x.BillableHours);
            Field(x => x.TaskPriorityID);
        }
    }
}