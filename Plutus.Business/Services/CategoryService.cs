using AutoMapper;
using Plutus.Business.Services.Contracts;
using Plutus.Infrastructure.Shared;
using Plutus.Model.Client;
using Plutus.Model.Entities;
using Plutus.Repository.Contracts;
using System;
using System.Collections.Generic;

namespace Plutus.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #region Public Methods

        public XHRResponse<List<_Category>> ReadAllByType(int typeId)
        {
            XHRResponse<List<_Category>> result = new XHRResponse<List<_Category>>();

            try
            {
                List<Category> categories = _categoryRepository.GetAll(x => x.TypeId == typeId);
                result.Data = Mapper.Map<List<_Category>>(categories);
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.Message = "Unable to get categories.";
                result.Succeeded = false;
            }

            return result;
        }

        #endregion
    }
}
