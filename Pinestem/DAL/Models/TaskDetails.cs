using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DAL.Models
{
    public class TaskDetails 
    {
        public long TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime TaskDueDate { get; set; }
        public DateTime TaskStartDate { get; set; }
        public string AssignedTo { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedOn { get; set; }
        public long TaskProjectID { get; set; }
        public int TaskPriorityID { get; set; }
        public byte? TaskDifficultyID { get; set; }
        public string PriorityType { get; set; }
        public string StatusType { get; set; }
        public long ExpectedHours { get; set; }
        public long BillableHours { get; set; }
        public long NonBillableHours { get; set; }
        public string TotalHours { get; set; }
        public string TaskStatusID { get; set; }
        public string StatusColor { get; set; }
        public int? OwnerID { get; set; }
        public string OwnerName { get; set; }
        public string InformTo { get; set; }
        public string Notes { get; set; }
        public string MDDescription { get; set; }
        public string AssociatedTasks { get; set; }
        public long AssignedToEmpID { get; set; }
        public long EmpID { get; set; }
        public string SprintName { get; set; }
        public bool? NonBillableTask { get; set; }
        public string CustomerCompanyName { get; set; }
        public string AttachedFiles { get; set; }
        public short? RoleID { get; set; }
        public short GetUpdates { get; set; }
        public int CompanyID { get; set; }
        public short TaskCategoryID { get; set; }
        public string AssignedBy { get; set; }
        public string OldAttachments { get; set; }
    }
}
