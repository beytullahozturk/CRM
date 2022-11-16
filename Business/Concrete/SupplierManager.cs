using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SupplierManager : ISupplierService
    {
        ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        [ValidationAspect(typeof(SupplierValidator))]
        public IResult Add(Supplier supplier)
        {
            try
            {
                var supplierrAdd = new Supplier
                {
                    SupplierCompany = supplier.SupplierCompany,
                    SupplierName = supplier.SupplierName,
                    Address = supplier.Address,
                    City = supplier.City,
                    Phone = supplier.Phone,
                    Email = supplier.Email,
                    IsDelete = false,
                    IsStatus = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                };

                _supplierDal.Add(supplierrAdd);

                return new SuccessResult(Messages.SupplierAdded);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IResult Delete(int supplierId)
        {
            try
            {
                var postData = _supplierDal.GetAll();
                var deleteData = postData.Find(p => p.Id == supplierId);
                deleteData.IsDelete = true;

                _supplierDal.Update(deleteData);
                return new SuccessResult(Messages.SupplierDeleted);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IDataResult<List<Supplier>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Supplier>>(_supplierDal.GetAll(p => p.IsDelete == false), Messages.SupplierListedSuccess);
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<List<Supplier>>(Ex.Message);
            }
        }

        public IDataResult<Supplier> GetById(int supplierId)
        {
            try
            {
                return new SuccessDataResult<Supplier>(_supplierDal.Get(p => p.Id == supplierId && p.IsDelete == false));
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<Supplier>(Ex.Message);
            }
        }

        [ValidationAspect(typeof(SupplierValidator))]
        public IResult Update(Supplier supplier)
        {
            try
            {
                var postData = _supplierDal.GetAll();
                var updateData = postData.Find(p => p.Id == supplier.Id);


                updateData.SupplierCompany = supplier.SupplierCompany;
                updateData.SupplierName = supplier.SupplierName;
                updateData.Address = supplier.Address;
                updateData.City = supplier.City;
                updateData.Phone = supplier.Phone;
                updateData.Email = supplier.Email;
                updateData.IsStatus = true;
                updateData.UpdatedAt = DateTime.Now;
                updateData.UpdatedBy = 1;

                _supplierDal.Update(updateData);
                return new SuccessResult(Messages.SupplierUpdated);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }
    }
}
