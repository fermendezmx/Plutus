using Microsoft.EntityFrameworkCore;
using Plutus.Context;
using Plutus.Model.Entities;
using Plutus.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Plutus.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryContext _context;

        public CategoryRepository()
        {
            _context = new CategoryContext();
        }

        #region Contract

        public List<Category> GetAll(Expression<Func<Category, bool>> filter)
        {
            return _context.Categories
                .Where(filter)
                .ToList();
        }

        #endregion

        #region Base

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.CategoryId == id);
        }

        public void Insert(Category data)
        {
            _context.Entry(data).State = EntityState.Added;
        }

        public void Update(Category data)
        {
            _context.Entry(data).State = EntityState.Modified;
        }

        public void Delete(Category data)
        {
            _context.Entry(data).State = EntityState.Deleted;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        #endregion
    }
}
