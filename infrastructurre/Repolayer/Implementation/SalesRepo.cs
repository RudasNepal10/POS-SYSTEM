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
    public class SalesRepo :ISalesRepo
    {
        private readonly IBaseRepo<SalesATT> _repo;
        public SalesRepo(IBaseRepo<SalesATT> repo)
        {
            _repo = repo; 
        }
        public void save(SalesDTO dTO) 
        {
         var mapdata=MapFromDtoToEntity(dTO, new SalesATT());
         _repo.Insert(mapdata);
        
        }
        public List<SalesATT> List() 
        {
         var SalesList = _repo.GetQueryable().ToList();
         return SalesList;
        }
        public SalesDTO GetsalesDataForUpdate(long id)
        {
            var data = _repo.GetById(id);
            var mapdata = MapFromEntityToDto(new SalesDTO(), data);
            return mapdata;
        }
        public void UpdateSales(SalesDTO dto)
        {
            var entity = _repo.GetById(dto.Id);
            var mapadata = MapFromDtoToEntity(dto, entity);
            _repo.Update(mapadata);
        }
        SalesATT MapFromDtoToEntity(SalesDTO dto, SalesATT entity)
        {
         entity.quantity = dto.quantity;
         entity.Product = dto.Product;
         return entity;
        }
        SalesDTO MapFromEntityToDto(SalesDTO dto, SalesATT entity)
        {
         dto.quantity = entity.quantity;
         dto.Product = entity.Product;
         return dto;
        }

    }
}
