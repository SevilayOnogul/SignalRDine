using SignalRDine.BusinessLayer.Abstract;
using SignalRDine.DataAccessLayer.Abstract;
using SignalRDine.DtoLayer.BasketDto;
using SignalRDine.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDine.BusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;
        private readonly IProductDal _productDal;

        public BasketManager(IBasketDal basketDal, IProductDal productDal)
        {
            _basketDal = basketDal;
            _productDal = productDal;
        }

        public void TAdd(Basket entity)
        {
           _basketDal.Add(entity);
        }

        public void TAddBasketWithProductPrice(CreateBasketDto createBasketDto)
        {
            var product = _productDal.GetByID(createBasketDto.ProductID);

            // 2. Yeni sepet nesnesi oluşturup ekliyoruz
            _basketDal.Add(new Basket
            {
                ProductID = createBasketDto.ProductID,
                MenuTableID = createBasketDto.MenuTableID,
                Count = 1,
                Price = product.Price,
                TotalPrice = product.Price // Adet 1 olduğu için fiyatla aynı
            });
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public List<Basket> TGetBasketByMenuTableNumber(int id)
        {
            return(_basketDal.GetBasketByMenuTableNumber(id));
        }

        public List<ResultBasketListWithProducts> TGetBasketListByMenuTableWithProductName(int id)
        {
            return(_basketDal.GetBasketListByMenuTableWithProductName(id));
        }

        public Basket TGetByID(int id)
        {
            return _basketDal.GetByID(id);
        }

        public List<Basket> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}
