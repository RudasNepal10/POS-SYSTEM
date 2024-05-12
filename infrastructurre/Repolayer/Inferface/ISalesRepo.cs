using infrastructurre.DTO;
using infrastructurre.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.Repolayer.Inferface
{
     public interface ISalesRepo
     {
      void save(SalesDTO dto);
      List<SalesATT> List();
      SalesDTO GetsalesDataForUpdate(long id);
      void UpdateSales(SalesDTO dto);   

     }
}
