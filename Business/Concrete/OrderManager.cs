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
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        IOrderDetailDal _orderDetailDal;

        public OrderManager(IOrderDal orderDal, IOrderDetailDal orderDetailDal)
        {
            _orderDal = orderDal;
            _orderDetailDal = orderDetailDal;
        }

        [ValidationAspect(typeof(OrderValidator))]
        public IResult Add(OrderDto orderDto)
        {
            try
            {
                var orderAdd = new Order
                {
                    CustomerId = orderDto.CustomerId,
                    EmployeeId = orderDto.EmployeeId,
                    Freight = orderDto.Freight,
                    SubTotal = orderDto.SubTotal,
                    Discount = orderDto.Discount,
                    Tax = orderDto.Tax,
                    Total = orderDto.Total,
                    IsDelete = false,
                    IsStatus = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                };

                _orderDal.Add(orderAdd);


                foreach (var item in orderDto.OrderDetailDto)
                {
                    var orderDetailAdd = new OrderDetail
                    {
                        ProductId = item.ProductId,
                        OrderId = item.OrderId,
                        UnitPrice = item.UnitPrice,
                        Quantity = item.Quantity,
                        Amount = item.Amount,
                        IsDelete = false,
                        IsStatus = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        CreatedBy = 1,
                        UpdatedBy = 1
                    };

                    _orderDetailDal.Add(orderDetailAdd);
                }

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
