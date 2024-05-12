using infrastructurre.DTO;
using infrastructurre.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.Repolayer.Inferface
{
    public interface ICategoryRepo
    {
        void save(CategoryDTO dto);
        List<CategoryATT> List();
        void DeleteCategory(long id);
        CategoryDTO GetCategoryDataForUpdate(long id);
        void UpdateCategory(CategoryDTO dto);

    }
}
