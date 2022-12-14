using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IDataResult<List<Order>> GetAllByCustomerId(int customerId);
        IDataResult<List<Order>> GetAllByEmployeeId(int employeeId);
        IDataResult<List<Order>> GetAllByTotal(decimal min, decimal max);
        IDataResult<Order> GetById(int orderId);
        IResult Add(OrderDto orderDto);
        IResult Update(Order order);
        IResult Delete(int orderId);
    }
}
