using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(CategoryDto categoryDto)
        {
            try
            {
                var categoryAdd = new Category
                {
                    CategoryName = categoryDto.CategoryName,
                    Description = categoryDto.Description,
                    IsDelete = false,
                    IsStatus = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                };

                _categoryDal.Add(categoryAdd);

                return new SuccessResult(Messages.CategoryAdded);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IResult Delete(int categoryId)
        {
            try
            {
                var postData = _categoryDal.GetAll();
                var deleteData = postData.Find(p => p.Id == categoryId);
                deleteData.IsDelete = true;

                _categoryDal.Update(deleteData);
                return new SuccessResult(Messages.CategoryDeleted);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IDataResult<List<Category>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(p => p.IsDelete == false), Messages.CategoryListedSuccess);
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<List<Category>>(Ex.Message);
            }
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            try
            {
                return new SuccessDataResult<Category>(_categoryDal.Get(p => p.Id == categoryId && p.IsDelete == false));
            }
            catch (Exception Ex)
            {

                return new ErrorDataResult<Category>(Ex.Message);
            }
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(Category category)
        {
            try
            {
                var postData = _categoryDal.GetAll();
                var updateData = postData.Find(p => p.Id == category.Id);

                updateData.CategoryName = category.CategoryName;
                updateData.Description = category.Description;
                updateData.IsStatus = category.IsStatus;
                updateData.UpdatedAt = DateTime.Now;
                updateData.UpdatedBy = 1;

                _categoryDal.Update(updateData);
                return new SuccessResult(Messages.CategoryUpdated);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }
    }
}