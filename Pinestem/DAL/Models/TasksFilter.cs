using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TasksFilter 
    {
        public string TaskID { get; set; }
        public string TaskName { get; set; }
        public List<long> UserStoryID { get; set; }
        public int ComapanyID { get; set; }
        public List<long> ProjectID { get; set; }
        public List<string> ProjectCode { get; set; }
        public List<string> UserStoryShortCode { get; set; }
        public List<long> TaskCategoryID { get; set; }
        public IList<short> TaskStatusID { get; set; }
        public List<long> SprintID { get; set; }
        public List<long> AssignedTo { get; set; }
        public bool ExcludeInformTo { get; set; }
        public IList<short> BillingStatusID { get; set; }
    }
}
