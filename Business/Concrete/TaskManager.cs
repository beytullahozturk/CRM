using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TaskManager : ITaskService
    {
        ITaskDal _taskDal;

        public TaskManager(ITaskDal taskDal)
        {
            _taskDal = taskDal;
        }

        [ValidationAspect(typeof(TaskValidator))]
        public IResult Add(TaskDto taskDto)
        {
            try
            {
                var taskAdd = new Task
                {
                    EmployeeId = taskDto.EmployeeId,
                    Title = taskDto.Title,
                    Description = taskDto.Description,
                    IsDelete = false,
                    IsStatus = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                };

                _taskDal.Add(taskAdd);

                return new SuccessResult(Messages.TaskAdded);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IResult Delete(int taskId)
        {
            try
            {
                var postData = _taskDal.GetAll();
                var deleteData = postData.Find(p => p.Id == taskId);
                deleteData.IsDelete = true;

                _taskDal.Update(deleteData);
                return new SuccessResult(Messages.TaskDeleted);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IDataResult<List<Task>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Task>>(_taskDal.GetAll(p => p.IsDelete == false), Messages.TaskListedSuccess);
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<List<Task>>(Ex.Message);
            }
        }

        public IDataResult<List<Task>> GetAllByEmployee(int employeeId)
        {
            try
            {
                return new SuccessDataResult<List<Task>>(_taskDal.GetAll(p => p.EmployeeId == employeeId && p.IsDelete == false), Messages.TaskListedByEmployee);
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<List<Task>>(Ex.Message);
            }
        }

        public IDataResult<Task> GetById(int taskId)
        {
            try
            {
                return new SuccessDataResult<Task>(_taskDal.Get(p => p.Id == taskId && p.IsDelete == false));
            }
            catch (Exception Ex)
            {

                return new ErrorDataResult<Task>(Ex.Message);
            }
        }

        public IResult Update(Task task)
        {
            try
            {
                var postData = _taskDal.GetAll();
                var updateData = postData.Find(p => p.Id == task.Id);

                updateData.EmployeeId = task.EmployeeId;
                updateData.Title = task.Title;
                updateData.Description = task.Description;
                updateData.IsStatus = true;
                updateData.UpdatedAt = DateTime.Now;
                updateData.UpdatedBy = 1;

                _taskDal.Update(updateData);
                return new SuccessResult(Messages.TaskUpdated);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }
    }
}
