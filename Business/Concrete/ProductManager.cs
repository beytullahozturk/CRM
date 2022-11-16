using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            try
            {
                var productAdd = new Product
                {
                    ProductName = product.ProductName,
                    CategoryId = product.CategoryId,
                    SupplierId = product.SupplierId,
                    UnitPrice = product.UnitPrice,
                    UnitInStock = product.UnitInStock,
                    IsDelete = false,
                    IsStatus = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                };

                _productDal.Add(productAdd);

                return new SuccessResult(Messages.ProductAdded);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }

        }

        public IResult Delete(int id)
        {
            try
            {
                var postData = _productDal.GetAll();
                var deleteData = postData.Find(p => p.Id == id);
                deleteData.IsDelete = true;

                _productDal.Update(deleteData);
                return new SuccessResult(Messages.ProductDeleted);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }

        }

        public IDataResult<List<Product>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.IsDelete==false), Messages.ProductListedSuccess);
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<List<Product>>(Ex.Message);
            }
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id && p.IsDelete==false));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId && p.IsDelete==false));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IResult Update(Product product)
        {
            try
            {
                var postData = _productDal.GetAll();
                var updateData = postData.Find(p => p.Id == product.Id);
                updateData.ProductName = product.ProductName;
                updateData.CategoryId = product.CategoryId;
                updateData.SupplierId = product.SupplierId;
                updateData.UnitPrice = product.UnitPrice;
                updateData.UnitInStock = product.UnitInStock;
                updateData.IsStatus = product.IsStatus;
                updateData.UpdatedAt = DateTime.Now;
                updateData.UpdatedBy = 1;

                _productDal.Update(updateData);
                return new SuccessResult(Messages.ProductUpdated);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }

        }
    }
}
