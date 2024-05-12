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
    public class CustomerRepo : ICustomerRepo
    {
        private readonly IBaseRepo<CustomerATT> _repo;
        public CustomerRepo(IBaseRepo<CustomerATT> repo)
        {
            _repo = repo;
        }
        public void Save(CustomerDTO dTO)
        {
            var mapdata = MapFromDtoToEntity(dTO, new CustomerATT());
            _repo.Insert(mapdata);
        }
        public List<CustomerATT> List()
        {
            var CustomerList = _repo.GetQueryable().ToList();
            return CustomerList;
        }
        public void DeleteCustomer(long id)
        {
            var data = _repo.GetById(id);
            _repo.Delete(data);

        }
        public CustomerDTO GetCustomerDataForUpdate(long id)
        {
            var data = _repo.GetById(id);
            var mapdata = MapFromEntityToDto(new CustomerDTO(), data);
            return mapdata;
        }
        public void UpdateCustomer(CustomerDTO dto)
        {
            var entity = _repo.GetById(dto.Id);
            var mapadata = MapFromDtoToEntity(dto, entity);
            _repo.Update(mapadata);
        }
        CustomerATT MapFromDtoToEntity(CustomerDTO dto, CustomerATT entity)
        {
          
            entity.CustomerName = dto.CustomerName;
            entity.CustomerEmail = dto.CustomerEmail;
            entity.CustomerPhone = dto.CustomerPhone;
            entity.Address = dto.Address;
            return entity;

        }
        CustomerDTO MapFromEntityToDto(CustomerDTO dto, CustomerATT entity)
        {
            
            dto.CustomerName = entity.CustomerName;
            dto.CustomerEmail = entity.CustomerEmail;
            dto.CustomerPhone = entity.CustomerPhone;
            dto.Address = entity.Address;
            return dto;

        }
    }
}
