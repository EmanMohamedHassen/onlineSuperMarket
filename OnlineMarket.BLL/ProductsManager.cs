using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMaeket.DAL;
using OnlineMaeket.DAL.ViewModels;

namespace OnlineMarket.BLL
{
    public class ProductsManager
    {
        private static ProductsManager instance;
        public static ProductsManager Instance { get { return instance; } }
        static ProductsManager()
        {
            instance = new ProductsManager();
        }
        private OnlineMarketEntities1 db = new OnlineMarketEntities1();

        public dynamic GetProducts()
        {
            try
            {
                List<ProductsVM> product = db.Products.Select(s => new ProductsVM
                {
                    Product_id = s.Product_id,
                    Product_name = s.Product_name,
                    Product_price = s.Product_price,
                    product_quantity = s.product_quantity,
                    Product_Brand = s.Product_Brand,
                    Product_image = s.Product_image,
                    Description = s.Description,
                    category = s.category


                }).ToList();
                if (product == null)
                {
                    return new
                    {
                        Id = 0
                    };
                }
                return product;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public dynamic GetProductsById(int ProductId)
        {
            try
            {
                List<ProductsVM> product = db.Products.Where(e => e.Product_id == ProductId).Select(s => new ProductsVM
                {
                    Product_id = s.Product_id,
                    Product_name = s.Product_name,
                    Product_price = s.Product_price,
                    product_quantity = s.product_quantity,
                    Product_Brand = s.Product_Brand,
                    Product_image = s.Product_image,
                    Description = s.Description,
                    category = s.category


                }).ToList();
                if (product == null)
                {
                    return new
                    {
                        Id = 0
                    };
                }
                return product;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public dynamic GetProductsByBrand(string Brand)
        {
            try
            {
                List<ProductsVM> product = db.Products.Where(e => e.Product_Brand == Brand).Select(s => new ProductsVM
                {
                    Product_id = s.Product_id,
                    Product_name = s.Product_name,
                    Product_price = s.Product_price,
                    product_quantity = s.product_quantity,
                    Product_Brand = s.Product_Brand,
                    Product_image = s.Product_image,
                    Description = s.Description,
                    category = s.category


                }).ToList();
                if (product == null)
                {
                    return new
                    {
                        Id = 0
                    };
                }
                return product;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public dynamic GetProductsByCategory(string category)
        {
            try
            {
                List<ProductsVM> product = db.Products.Where(e => e.category == category).Select(s => new ProductsVM
                {
                    Product_id = s.Product_id,
                    Product_name = s.Product_name,
                    Product_price = s.Product_price,
                    product_quantity = s.product_quantity,
                    Product_Brand = s.Product_Brand,
                    Product_image = s.Product_image,
                    Description = s.Description,
                    category = s.category


                }).ToList();
                if (product == null)
                {
                    return new
                    {
                        Id = 0
                    };
                }
                return product;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public dynamic PostProduct(ProductsVM s)
        {
            var product = db.Products.Add(new Product
            {

                Product_name = s.Product_name,
                Product_price = s.Product_price,
                product_quantity = s.product_quantity,
                Product_image = s.Product_image,
                Product_Brand = s.Product_Brand,
                category = s.category,
                Description = s.Description
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                productId = product.Product_id
            };
        }
        public dynamic PutProducts(ProductsVM s)
        {
            var product = db.Products.Find(s.Product_id);

            product.Product_id= s.Product_id;
            product.Product_name = s.Product_name;
            product.Product_price = s.Product_price;
            product.product_quantity = s.product_quantity;
            product.Product_image = s.Product_image;
            product.Product_Brand = s.Product_Brand;
            product.category = s.category;
            product.Description = s.Description;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        public dynamic DeleteProduct(int productId)
        {
            var product = db.Products.Where(s => s.Product_id == productId).FirstOrDefault();
            db.Products.Remove(product);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
    }
}
