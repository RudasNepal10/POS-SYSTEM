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
    public class SaleProductRepo : ISaleProductRepo
    {
        private readonly IBaseRepo<SaleProductATT> _repo;
        public SaleProductRepo(IBaseRepo<SaleProductATT>repo)
        {
            _repo = repo;    
        }
        public void save(SaleProductDTO dto) 
        {
         var mapdata = MapFromDtoToEntity(dto,new SaleProductATT());
         _repo.Insert(mapdata);
        }
        public List<SaleProductATT> List()
        {
            var saleproductList = _repo.GetQueryable().ToList();
            return saleproductList;
        }


        public SaleProductDTO GetSaleProductDataForUpdate(long id) 
        {
             var data=_repo.GetById(id);
            var mapdata = MapFromEntityToDto(new SaleProductDTO(), data);
            return mapdata;
        } 
        public void UpdateSaleProduct(SaleProductDTO dto) 
        {
         var entity = _repo.GetById(dto.Id);
            var mapadata = MapFromDtoToEntity(dto, entity);
            _repo.Update(mapadata);
        }
        SaleProductATT MapFromDtoToEntity(SaleProductDTO dto, SaleProductATT entity) 
        {
         entity.ProductName = dto.ProductName;
         entity.SaleDate = dto.SaleDate;
         entity.TotalAmount = dto.TotalAmount;
         entity.Quantity = dto.Quantity;
         return entity;
        }
        SaleProductDTO MapFromEntityToDto(SaleProductDTO dto, SaleProductATT entity) 
        {
         dto.ProductName = entity.ProductName;
         dto.SaleDate = entity.SaleDate;
         dto.TotalAmount = entity.TotalAmount;
         dto.Quantity = entity.Quantity;
         return dto;
        
        }

    }
}
