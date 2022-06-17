using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVolvo.Domain.Entities;
using TesteVolvo.Domain.Interfaces;
using TesteVolvo.Infra.Data.Context;

namespace TesteVolvo.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDBContext _categoryContext;

        public CategoryRepository(ApplicationDBContext context)
        {
            _categoryContext = context;
        }

        public Task<Category> Create(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetById(int? id)
        {
            return await _categoryContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        public Task<Category> Remove(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
