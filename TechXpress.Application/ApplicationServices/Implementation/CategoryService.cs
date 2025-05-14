using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.DTOs.TechXpress.Web.DTO;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Infrastructure;

namespace TechXpress.Application.ApplicationServices.Implementation
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly AppDbContext _context;

        public CategoryAppService(AppDbContext context)
        {
            _context = context;
        }

        public void AddCategory(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Category_ID = categoryDto.Id,
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                IsSelected = categoryDto.IsSelected
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(CategoryDto categoryDto)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Category_ID == categoryDto.Id);
            if (category != null)
            {
                category.Name = categoryDto.Name;
                category.Description = categoryDto.Description;
                category.IsSelected = categoryDto.IsSelected;

                _context.SaveChanges();
            }
        }

        public void DeleteCategory(string id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Category_ID == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public CategoryDto GetCategoryById(string id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Category_ID == id);
            if (category == null) return null;

            return new CategoryDto
            {
                Id = category.Category_ID,
                Name = category.Name,
                Description = category.Description,
                IsSelected = category.IsSelected
            };
        }


        public List<CategoryDto> GetAllCategories()
        {
            return _context.Categories
                .Select(c => new CategoryDto
                {
                    Id = c.Category_ID, 
                    Name = c.Name,
                    Description = c.Description,
                    IsSelected = c.IsSelected
                }).ToList();
        }


    }
}
