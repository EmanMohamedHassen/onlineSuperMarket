using OnlineMaeket.DAL.ViewModels;
using OnlineMarket.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineMarket.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        public dynamic GetProducts()
        {
            return ProductsManager.Instance.GetProducts();

        }
        public dynamic GetProductsById(int ProductId)
        {
            return ProductsManager.Instance.GetProductsById(ProductId);

        }
        public dynamic GetProductsByBrand(string Brand)
        {
            return ProductsManager.Instance.GetProductsByBrand(Brand);

        }
        public dynamic GetProductsByCategory(string category)
        {
            return ProductsManager.Instance.GetProductsByCategory(category);

        }
        public dynamic PostProduct(ProductsVM s)
        {
            return ProductsManager.Instance.PostProduct(s);
        }
        public dynamic PutProducts(ProductsVM s)
        {
            return ProductsManager.Instance.PutProducts(s);
        }
        public dynamic DeleteProduct(int productId)
        {
            return ProductsManager.Instance.DeleteProduct(productId);
        }
    }
}
