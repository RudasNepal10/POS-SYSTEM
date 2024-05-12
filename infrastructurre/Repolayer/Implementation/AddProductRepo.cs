using infrastructurre.DTO;
using infrastructurre.Entities;
using infrastructurre.Repolayer.Inferface;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SG.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.Repolayer.Implementation
{
    public class AddProductRepo : IAddProductRepo
    {
        private readonly IBaseRepo<AddProductATT> _repo;
        private readonly IFileHelper _fileHelper;
        public AddProductRepo(IBaseRepo<AddProductATT> repo, IFileHelper fileHelper)
        {
            _repo = repo;
            _fileHelper = fileHelper;
        }
        public void save(AddProductDTO dto)
        {
            var mapdata = MapFormDtoToEntity(dto, new AddProductATT());
            _repo.Insert(mapdata);
        }
        public List<AddProductATT> List()
        {
            var AddproductList = _repo.GetQueryable().ToList();
            return AddproductList;

        }
        public void DeleteAddproduct(long id)
        {
            var data = _repo.GetById(id);
            _repo.Delete(data);
        }
        public AddProductDTO GetAddproductDataForUpdate(long id)
        {
            var data = _repo.GetById(id);
            var mapdata = MapFormEntityToDTO(new AddProductDTO(), data);
            return mapdata;
        }

        public void UpdateAddproduct(AddProductDTO dto)
        {
            var entity = _repo.GetById(dto.Id);
            var mapdata = MapFormDtoToEntity(dto, entity);
            _repo.Update(mapdata);
        }
        AddProductATT MapFormDtoToEntity(AddProductDTO dto, AddProductATT entity)
        {
            entity.Productname = dto.Productname;
            if (dto.ImageFile != null)
            {
                entity.ImageFile = _fileHelper.saveImageAndGetFileName(dto.ImageFile, "Product").Result;
            }
            entity.Quantity = dto.Quantity;
            entity.Price = dto.Price;
            entity.Description = dto.Description;
            entity.category_id = dto.category_id;
            return entity;

        }

        AddProductDTO MapFormEntityToDTO(AddProductDTO dTO, AddProductATT entity)
        {
            dTO.Productname = entity.Productname;
            dTO.Quantity = entity.Quantity;
            dTO.Price = entity.Price;
            dTO.Description = entity.Description;
            dTO.category_id = entity.category_id;
            dTO.FileName = entity.ImageFile;
            return dTO;

        }


    }
}
