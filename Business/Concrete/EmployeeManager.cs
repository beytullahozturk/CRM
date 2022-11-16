using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult Add(Employee employee)
        {
            try
            {
                var employeeAdd = new Employee
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Department = employee.Department,
                    BirthDate = employee.BirthDate,
                    Address = employee.Address,
                    City = employee.City,
                    Phone = employee.Phone,
                    Email = employee.Email,
                    IsDelete = false,
                    IsStatus = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                };

                _employeeDal.Add(employeeAdd);

                return new SuccessResult(Messages.EmployeeAdded);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IResult Delete(int employeeId)
        {
            try
            {
                var postData = _employeeDal.GetAll();
                var deleteData = postData.Find(p => p.Id == employeeId);
                deleteData.IsDelete = true;

                _employeeDal.Update(deleteData);
                return new SuccessResult(Messages.EmployeeDeleted);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IDataResult<List<Employee>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(p => p.IsDelete == false), Messages.EmployeeListedSuccess);
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<List<Employee>>(Ex.Message);
            }
        }

        public IDataResult<Employee> GetById(int employeeId)
        {
            try
            {
                return new SuccessDataResult<Employee>(_employeeDal.Get(p => p.Id == employeeId && p.IsDelete == false));
            }
            catch (Exception Ex)
            {

                return new ErrorDataResult<Employee>(Ex.Message);
            }
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult Update(Employee employee)
        {
            try
            {
                var postData = _employeeDal.GetAll();
                var updateData = postData.Find(p => p.Id == employee.Id);

                updateData.FirstName = employee.FirstName;
                updateData.LastName = employee.LastName;
                updateData.Department = employee.Department;
                updateData.BirthDate = employee.BirthDate;
                updateData.Address = employee.Address;
                updateData.City = employee.City;
                updateData.Phone = employee.Phone;
                updateData.Email = employee.Email;
                updateData.IsStatus = true;
                updateData.UpdatedAt = DateTime.Now;
                updateData.UpdatedBy = 1;

                _employeeDal.Update(updateData);
                return new SuccessResult(Messages.EmployeeUpdated);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }
    }
}
