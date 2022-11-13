using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var item in productManager.GetByUnitPrice(200,1200))
            {
                Console.WriteLine($"{item.ProductName} - {item.UnitPrice}");
            }
        }
    }
}
