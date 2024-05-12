using infrastructurre.DTO;
using infrastructurre.Entities;
using infrastructurre.Repolayer.Inferface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.Repolayer.Implementation
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly IBaseRepo<CategoryATT> _repo;

        public CategoryRepo(IBaseRepo<CategoryATT> repo)
        {
            _repo = repo;
        }
        public void save(CategoryDTO dTO)
        {
            var mapdata = MapFromDtoToEntity(dTO, new CategoryATT());
            _repo.Insert(mapdata);
        }
        public List<CategoryATT> List()
        {
            var CategoryList = _repo.GetQueryable().ToList();
            return CategoryList;
        }
        public void DeleteCategory(long id)
        {
            var data = _repo.GetById(id);
            _repo.Delete(data);

        }
        public CategoryDTO GetCategoryDataForUpdate(long id)
        {
            var data = _repo.GetById(id);
            var mapdata = MapFromEntityToDto(new CategoryDTO(), data);
            return mapdata;
        }
        public void UpdateCategory(CategoryDTO dto)
        {
            var entity = _repo.GetById(dto.Id);
            var mapadata = MapFromDtoToEntity(dto, entity);
            _repo.Update(mapadata);
        }
        CategoryATT MapFromDtoToEntity(CategoryDTO dto, CategoryATT entity)
        {
            entity.Categoryname = dto.Categoryname;
            return entity;

        }
        CategoryDTO MapFromEntityToDto(CategoryDTO dto, CategoryATT entity)
        {
           
            dto.Categoryname = entity.Categoryname;
            return dto;

        }

    }
}
