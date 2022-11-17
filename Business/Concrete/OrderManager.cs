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
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        [ValidationAspect(typeof(OrderValidator))]
        public IResult Add(Order order)
        {
            try
            {
                var orderAdd = new Order
                {
                    CustomerId = order.CustomerId,
                    EmployeeId = order.EmployeeId,
                    Freight = order.Freight,
                    SubTotal = order.SubTotal,
                    Discount = order.Discount,
                    Tax = order.Tax,
                    Total = order.Total,
                    IsDelete = false,
                    IsStatus = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                };

                _orderDal.Add(orderAdd);



                return new SuccessResult(Messages.OrderAdded);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IResult Delete(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<Order>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Order>>(_orderDal.GetAll(p => p.IsDelete == false), Messages.OrderListedSuccess);
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<List<Order>>(Ex.Message);
            }
        }

        public IDataResult<List<Order>> GetAllByCustomerId(int customerId)
        {
            try
            {
                return new SuccessDataResult<List<Order>>(_orderDal.GetAll(p => p.CustomerId == customerId && p.IsDelete == false),
                    Messages.OrderListedByCustomer);
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<List<Order>>(Ex.Message);
            }
        }

        public IDataResult<List<Order>> GetAllByEmployeeId(int employeeId)
        {
            try
            {
                return new SuccessDataResult<List<Order>>(_orderDal.GetAll(p => p.EmployeeId == employeeId && p.IsDelete == false),
                    Messages.OrderListedByEmployee);
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<List<Order>>(Ex.Message);
            }
        }

        public IDataResult<List<Order>> GetAllByTotal(decimal min, decimal max)
        {
            try
            {
                return new SuccessDataResult<List<Order>>(_orderDal.GetAll(p => p.Total >= min && p.Total <= max));
            }
            catch (Exception Ex)
            {

                return new ErrorDataResult<List<Order>>(Ex.Message);
            }
        }

        public IDataResult<Order> GetById(int orderId)
        {
            try
            {
                return new SuccessDataResult<Order>(_orderDal.Get(p => p.Id == orderId && p.IsDelete == false));
            }
            catch (Exception Ex)
            {

                return new ErrorDataResult<Order>(Ex.Message);
            }
        }

        public IResult Update(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
