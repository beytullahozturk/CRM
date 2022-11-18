using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Business.Abstract
{
    public interface ITaskService
    {
        IDataResult<List<Task>> GetAll();
        IDataResult<List<Task>> GetAllByEmployee(int employeeId);
        IDataResult<Task> GetById(int taskId);
        IResult Add(Task task);
        IResult Update(Task task);
        IResult Delete(int taskId);
    }
}
