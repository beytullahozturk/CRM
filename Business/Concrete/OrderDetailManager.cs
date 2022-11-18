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
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;
        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        [ValidationAspect(typeof(OrderDetailValidator))]
        public IResult Add(OrderDetail orderDetail)
        {
            try
            {
                var orderDetailAdd = new OrderDetail
                {
                    ProductId = orderDetail.ProductId,
                    OrderId = orderDetail.OrderId,
                    UnitPrice = orderDetail.UnitPrice,
                    Quantity = orderDetail.Quantity,
                    Amount = orderDetail.Amount,
                    IsDelete = false,
                    IsStatus = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                };

                _orderDetailDal.Add(orderDetailAdd);

                return new SuccessResult(Messages.OrderDetailAdded);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IResult Delete(int orderDetailId)
        {
            try
            {
                var postData = _orderDetailDal.GetAll();
                var deleteData = postData.Find(p => p.Id == orderDetailId);
                deleteData.IsDelete = true;

                _orderDetailDal.Update(deleteData);
                return new SuccessResult(Messages.OrderDetailDeleted);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IDataResult<List<OrderDetail>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<OrderDetail>>(_orderDetailDal.GetAll(p => p.IsDelete == false), Messages.OrderDetailListedSuccess);
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<List<OrderDetail>>(Ex.Message);
            }
        }

        public IDataResult<List<OrderDetail>> GetAllByOrderId(int orderId)
        {
            try
            {
                return new SuccessDataResult<List<OrderDetail>>(_orderDetailDal.GetAll(p => p.OrderId == orderId && p.IsDelete == false), Messages.OrderDetailListedSuccess);
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<List<OrderDetail>>(Ex.Message);
            }
        }

        public IDataResult<OrderDetail> GetById(int orderDetailId)
        {
            try
            {
                return new SuccessDataResult<OrderDetail>(_orderDetailDal.Get(p => p.Id == orderDetailId && p.IsDelete == false));
            }
            catch (Exception Ex)
            {

                return new ErrorDataResult<OrderDetail>(Ex.Message);
            }
        }

        public IResult Update(OrderDetail orderDetail)
        {
            try
            {
                var postData = _orderDetailDal.GetAll();
                var updateData = postData.Find(p => p.Id == orderDetail.Id);

                updateData.ProductId = orderDetail.ProductId;
                updateData.OrderId = orderDetail.OrderId;
                updateData.UnitPrice = orderDetail.UnitPrice;
                updateData.Quantity = orderDetail.Quantity;
                updateData.Amount = orderDetail.Amount;
                updateData.IsStatus = orderDetail.IsStatus;
                updateData.UpdatedAt = DateTime.Now;
                updateData.UpdatedBy = 1;

                _orderDetailDal.Update(updateData);
                return new SuccessResult(Messages.OrderDetailUpdated);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }
    }
}
