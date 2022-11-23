using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ISupplierService
    {
        IDataResult<List<Supplier>> GetAll();
        IDataResult<Supplier> GetById(int supplierId);
        IResult Add(SupplierDto supplierDto);
        IResult Update(Supplier supplier);
        IResult Delete(int supplierId);
    }
}
