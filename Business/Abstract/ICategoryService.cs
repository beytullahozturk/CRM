using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int categoryId);
        IResult Add(CategoryDto categoryDto);
        IResult Update(Category category);
        IResult Delete(int categoryId);
    }
}
