using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<List<Employee>> GetAll();
        IDataResult<Employee> GetById(int employeeId);
        IResult Add(EmployeeDto employeeDto);
        IResult Update(Employee employee);
        IResult Delete(int employeeId);
    }
}
