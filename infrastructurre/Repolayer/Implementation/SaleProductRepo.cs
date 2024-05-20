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
        private readonly IBaseRepo<SalesProduct> _sprepo;
        private readonly IBaseRepo<PaymentMethodATT> _paymentrepo;

        public SaleProductRepo(IBaseRepo<SaleProductATT>repo, IBaseRepo<PaymentMethodATT> paymentrepo, IBaseRepo<SalesProduct> sprepo)
        {
            _repo = repo;
            _paymentrepo = paymentrepo;
            _sprepo = sprepo;   
        }

        private void savesalesproduct(SaleProductDTO dTO, long id) 
        {
         List<SalesProduct> entitylist=new List<SalesProduct>();
         foreach(var item in dTO.SalesProduct)
            {
                entitylist.Add(new SalesProduct
                {
                    product_id = item.product_id,
                    quantity = item.quantity,
                    sales_id = id,
                    total_prod_amount = item.total_prod_amount,
                }) ;
            }
            _sprepo.InsertRange(entitylist);
        }
        public void save(SaleProductDTO dto) 
        {
         var mapdata = MapFromDtoToEntity(dto,new SaleProductATT());
         _repo.Insert(mapdata);
         savesalesproduct(dto,mapdata.Id);
        }
        public List<SaleProductATT> List()
        {
            var saleproductList = _repo.GetQueryable().ToList();
            return saleproductList;
        }


        public List<PaymentMethodATT> PaymentMethodList()
        {
            var paymentMethodList = _paymentrepo.GetQueryable().ToList();
            return paymentMethodList;
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
            entity.customer_Id = dto.customer_Id;
            entity.payment_method_id= dto.payment_method_id;
            entity.paid_amount= dto.paid_amount;
            return entity;
        }
        SaleProductDTO MapFromEntityToDto(SaleProductDTO dto, SaleProductATT entity) 
        {
            dto.customer_Id = entity.customer_Id;
            dto.payment_method_id = entity.payment_method_id;
            return dto;
        
        }

    }
}
