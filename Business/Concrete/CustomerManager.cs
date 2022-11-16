using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            try
            {
                var customerAdd = new Customer
                {
                    CustomerCompany = customer.CustomerCompany,
                    CustomerName = customer.CustomerName,
                    Address = customer.Address,
                    City = customer.City,
                    Phone = customer.Phone,
                    Email = customer.Email,
                    IsDelete = false,
                    IsStatus = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                };

                _customerDal.Add(customerAdd);

                return new SuccessResult(Messages.CustomerAdded);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IResult Delete(int customerId)
        {
            try
            {
                var postData = _customerDal.GetAll();
                var deleteData = postData.Find(p => p.Id == customerId);
                deleteData.IsDelete = true;

                _customerDal.Update(deleteData);
                return new SuccessResult(Messages.CustomerDeleted);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(p => p.IsDelete == false), Messages.CustomerListedSuccess);
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<List<Customer>>(Ex.Message);
            }
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            try
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(p => p.Id == customerId && p.IsDelete == false));
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<Customer>(Ex.Message);
            }
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            try
            {
                var postData = _customerDal.GetAll();
                var updateData = postData.Find(p => p.Id == customer.Id);

                updateData.CustomerCompany = customer.CustomerCompany;
                updateData.CustomerName = customer.CustomerName;
                updateData.Address = customer.Address;
                updateData.City = customer.City;
                updateData.Phone = customer.Phone;
                updateData.Email = customer.Email;
                updateData.IsStatus = true;
                updateData.UpdatedAt = DateTime.Now;
                updateData.UpdatedBy = 1;

                _customerDal.Update(updateData);
                return new SuccessResult(Messages.CustomerUpdated);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }
    }
}
