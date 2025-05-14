using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Application.DTOs.TechXpress.Web.DTO;

namespace TechXpress.Application.ApplicationServices.Contract
{
    public interface ICategoryAppService
    {
        void AddCategory(CategoryDto categoryDto);
        void UpdateCategory(CategoryDto categoryDto);
        void DeleteCategory(string id);
        CategoryDto GetCategoryById(string id);
        List<CategoryDto> GetAllCategories();
    }
}
