using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GraphQL.Interface
{
    public interface ITaskRepository
    {
        IEnumerable<TaskDetails> GetAll();
        TaskDetails GetById(int id);
    }
}
