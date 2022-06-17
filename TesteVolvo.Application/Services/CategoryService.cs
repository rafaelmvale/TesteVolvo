using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVolvo.Application.DTOs;
using TesteVolvo.Application.Interfaces;
using TesteVolvo.Domain.Interfaces;

namespace TesteVolvo.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public Task Add(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDTO> GetByID(int? id)
        {
            var categoryEntity = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public Task Remove(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
