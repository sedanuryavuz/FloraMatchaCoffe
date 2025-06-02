using Flora.EntityLayer.Entities;

namespace Flora.DataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        int ProductCount();
        int ProductCountByCategoryDrink();
        int ProductCountByCategoryDessert();
        decimal ProductPriceAvg();
        string ProductNameByMaxPrice();
        string ProductNameByMinPrice();
        decimal ProductPriceByCategoryDrink();
    }
}
