using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ISupplierService
    {
        IDataResult<List<Supplier>> GetAll();
        IDataResult<Supplier> GetById(int supplierId);
        IResult Add(Supplier supplier);
        IResult Update(Supplier supplier);
        IResult Delete(int supplierId);
    }
}
