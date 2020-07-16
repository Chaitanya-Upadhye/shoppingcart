using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartDAL;
using ShoppingCartBE;

namespace ShoppingCartBAL
{
    public class ProductsBAL
    {
       ProductsDAL _productDAL=new ProductsDAL();


        public List<ProductsBE> GetAllProducts()
        {
            try
            {
                return _productDAL.GetAllProducts();
            }
            catch (Exception)
            {
                
                throw;
            }

        }
        //public void InsertOrder()
        //{
        //    try
        //    {
        //        _productDAL.InsertOrder();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}



          public List<ProductsBE> SearchProducts(string productName,decimal productPrice,int productRating)
        {

            try
            {

                return _productDAL.SearchProducts(productName,productPrice,productRating);
            }
            catch (Exception)
            {
                
                throw;
            }

        }


         public List<string> GetProductName(string productName)
          {

              try
              {
                  return _productDAL.GetProductName(productName);
              }
              catch (Exception)
              {
                  
                  throw;
              }
          }






        public ProductsBE GetProduct(int productId)
        {
            try
            {
                return _productDAL.GetProduct(productId);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ResponseBE InsertToCart(ProductsBE product)
        {
            try
            {
                return _productDAL.InsertToCart(product);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ProductsBE> GetCartDetails(int customerId)
        {
            try
            {
                return _productDAL.GetCartDetails(customerId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ProductsBE TotalCartAmount(int customerId)
        {
            try
            {
                return _productDAL.TotalCartAmount(customerId);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
