using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{Id=1, CategoryId=1, ProductName="Bilgisayar", UnitPrice=1000, UnitInStock=100},
                new Product{Id=2, CategoryId=1, ProductName="Kamera", UnitPrice=100, UnitInStock=20},
                new Product{Id=3, CategoryId=1, ProductName="Telefon", UnitPrice=1200, UnitInStock=10},
                new Product{Id=4, CategoryId=1, ProductName="Televizyon", UnitPrice=20000, UnitInStock=5}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // Language-Integrated Query (LINQ) / Dile Entegre Edilmiş Sorgu
            // => Lambda
            Product productToDelete = _products.SingleOrDefault(p => p.Id == product.Id);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.Id == product.Id);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.SupplierId = product.SupplierId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
            productToUpdate.IsDeleted = product.IsDeleted;
            productToUpdate.IsStatus = product.IsStatus;
        }
    }
}
