using SignalRDine.DtoLayer.BasketDto;
using SignalRDine.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDine.DataAccessLayer.Abstract
{
    public interface IBasketDal:IGenericDal<Basket>
    {
        List<Basket> GetBasketByMenuTableNumber(int id);
        List<ResultBasketListWithProducts> GetBasketListByMenuTableWithProductName(int id);
    }
}
