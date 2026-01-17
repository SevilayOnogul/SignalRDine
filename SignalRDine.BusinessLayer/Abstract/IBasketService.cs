using SignalRDine.DtoLayer.BasketDto;
using SignalRDine.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDine.BusinessLayer.Abstract
{
    public interface IBasketService:IGenericService<Basket>
    {
        List<Basket> TGetBasketByMenuTableNumber(int id);
        List<ResultBasketListWithProducts> TGetBasketListByMenuTableWithProductName(int id);
        void TAddBasketWithProductPrice(CreateBasketDto createBasketDto);


    }
}
