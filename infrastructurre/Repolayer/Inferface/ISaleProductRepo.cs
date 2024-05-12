using infrastructurre.DTO;
using infrastructurre.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.Repolayer.Inferface
{
    public interface ISaleProductRepo
    {
        void save(SaleProductDTO dto);
        List<SaleProductATT> List();

        SaleProductDTO GetSaleProductDataForUpdate(long id);
        void UpdateSaleProduct(SaleProductDTO dto);
        List<PaymentMethodATT> PaymentMethodList();
    }
}
