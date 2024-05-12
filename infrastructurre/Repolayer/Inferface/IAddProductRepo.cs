using infrastructurre.DTO;
using infrastructurre.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.Repolayer.Inferface
{
    public interface IAddProductRepo
    {
        void save(AddProductDTO dTO);
        List<AddProductATT> List();
        void DeleteAddproduct(long id);
        AddProductDTO GetAddproductDataForUpdate(long id);  
        void UpdateAddproduct(AddProductDTO dTO);   

    }
}
