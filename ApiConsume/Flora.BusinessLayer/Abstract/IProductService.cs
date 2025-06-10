using Flora.EntityLayer.Entities;

namespace Flora.BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        int TProductCount();
        int TProductCountByCategoryDrink();
        int TProductCountByCategoryDessert();
        decimal TProductPriceAvg();
        string TProductNameByMaxPrice();
        string TProductNameByMinPrice();
        decimal TProductPriceByCategoryDrink();
        List<Product> TGetTop4DrinkProducts();
    }
}
