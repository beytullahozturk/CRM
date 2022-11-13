using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        public List<Order> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
