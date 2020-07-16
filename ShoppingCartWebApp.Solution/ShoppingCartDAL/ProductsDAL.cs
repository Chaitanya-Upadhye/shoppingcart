using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartBE;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace ShoppingCartDAL
{
   public class ProductsDAL:BaseDAL
    {
       public    List<int> _populateAlterDdl = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

       public List<ProductsBE> GetAllProducts()
       {
           List<ProductsBE> Products = new List<ProductsBE>();
           using (_Connection=new SqlConnection(_ConnectionString) )
           {
               try
               {
                   _Connection.Open();
                   string query = "USP_PRODUCTDETAILS";
                   SqlCommand cmd = new SqlCommand(query,_Connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   SqlDataReader reader = cmd.ExecuteReader();
                   while (reader.Read())
                   {
                       ProductsBE product = new ProductsBE();
                       product.ProductId = Convert.ToInt32(reader["ProductId"]);
                       product.ProductName = Convert.ToString(reader["ProductName"]);
                       product.UnitsInStock = Convert.ToInt32(reader["UnitsInStock"]);
                       product.CategoryName = Convert.ToString(reader["CategoryName"]);
                       product.ProductPrice = Convert.ToDecimal(reader["ProductPrice"]);
                       product.ProductRating = Convert.ToInt32(reader["ProductRating"]);
                       Products.Add(product);
        
                   }

               }
               catch (Exception)
               {
                   
                   throw;
               }
               return Products;
               
           }

         

       }


        



         public ProductsBE TotalCartAmount(int customerId)
        {
            using (_Connection=new SqlConnection(_ConnectionString))
            {
                ProductsBE product = new ProductsBE();


                try
                {
                    _Connection.Open();
                    string query = "USP_GETTOTALPRICE";
                    SqlCommand cmd = new SqlCommand(query, _Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    product.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                    product.TotalCartAmount = Convert.ToDecimal(reader["totalcartamount"]);


                }
                catch (Exception)
                {

                    throw;
                }
                return product;
            }



        }



        public List<ProductsBE> GetCartDetails(int customerId)
        {

            using (_Connection=new SqlConnection(_ConnectionString))
            {
                List<ProductsBE> products = new List<ProductsBE>();
                try
                {
                    _Connection.Open();
                    string query = "USP_GETCARTDETAILS";
                    SqlCommand cmd = new SqlCommand(query, _Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductsBE product = new ProductsBE();
                        product.ProductId =Convert.ToInt32(reader["ProductId"]);
                        product.ProductName = Convert.ToString(reader["ProductName"]);
                        product.Quantity = Convert.ToInt32(reader["Quantity"]);
                        product.TotalPrice = Convert.ToInt32(reader["totalprice"]);
                        product.AlterQuantity = _populateAlterDdl;
                        products.Add(product);

                    }

                }
                catch (Exception)
                {

                    throw;
                }
                return products;
            }



        }



        public ResponseBE InsertToCart(ProductsBE product)
        {
            using (_Connection=new SqlConnection(_ConnectionString))
            {
                ResponseBE response = new ResponseBE();
                try
                {
                    _Connection.Open();
                    string query = "USP_INSERTTOCART";
                    SqlCommand cmd = new SqlCommand(query, _Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerId", product.CustomerId);
                    cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                    cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                    response.Status = cmd.ExecuteNonQuery();
                    response.IsSuccess = (response.Status > 0 ? true : false);


                }
                catch (Exception)
                {

                    throw;
                }
                return response;
            }



        }




       public ProductsBE GetProduct(int productId)
       {
           ProductsBE product = new ProductsBE();
           using (_Connection = new SqlConnection(_ConnectionString))
           {
               try
               {
                   _Connection.Open();
                   string query = "USP_GETPRODUCT";
                   SqlCommand cmd = new SqlCommand(query, _Connection);
                   cmd.Parameters.AddWithValue("@ProductId", productId);

                   cmd.CommandType = CommandType.StoredProcedure;
                   SqlDataReader reader = cmd.ExecuteReader();
                   while (reader.Read())
                   {
                      
                      // product.ProductId = Convert.ToInt32(reader["ProductId"]);
                       product.ProductName = Convert.ToString(reader["ProductName"]);
                       product.UnitsInStock = Convert.ToInt32(reader["UnitsInStock"]);
                      // product.CategoryName = Convert.ToString(reader["CategoryName"]);
                       product.ProductPrice = Convert.ToDecimal(reader["ProductPrice"]);
                       //Products.Add(product);

                   }

               }
               catch (Exception)
               {

                   throw;
               }
               return product;

           }

       }



       public List<ProductsBE> SearchProducts(string productName,decimal productPrice,int productRating)
       {
           using (_Connection=new SqlConnection(_ConnectionString))
           {
               List<ProductsBE> Products = new List<ProductsBE>();
               try
               {
                   _Connection.Open();
                   SqlCommand cmd = new SqlCommand();
                   cmd.Connection = _Connection;
                   StringBuilder query = new StringBuilder("select PRODUCTS.ProductId,ProductName,ProductRating,ProductPrice,UnitsInStock,CategoryName from PRODUCTS,CATEGORY,PRODUCT_PRICES where CATEGORY.Categoryid=PRODUCTS.CategoryId and PRODUCTS.ProductId=PRODUCT_PRICES.ProductId");
                   StringBuilder andClauses = new StringBuilder("");

                   if(productName!=null)
                   {
                       andClauses.Append(" AND ProductName=@ProductName");
                       cmd.Parameters.AddWithValue("@ProductName", productName);
                   }
                   if(productPrice!=0)
                   {
                       andClauses.Append(" AND ProductPrice>@PRoductPrice");
                       cmd.Parameters.AddWithValue("@ProductPrice", productPrice);

                   }
                   if(productRating!=0)
                   {
                       andClauses.Append(" AND ProductRating=@ProductRating");
                       cmd.Parameters.AddWithValue("@ProductRating",productRating);
                   }
                   query.Append(andClauses);
                   cmd.CommandText = query.ToString();
                   cmd.CommandType = CommandType.Text;
                   SqlDataReader reader = cmd.ExecuteReader();

                   while(reader.Read())
                   {
                       ProductsBE product = new ProductsBE();
                       product.ProductId = Convert.ToInt32(reader["ProductId"]);
                       product.ProductName = Convert.ToString(reader["ProductName"]);
                       product.UnitsInStock = Convert.ToInt32(reader["UnitsInStock"]);
                       product.CategoryName = Convert.ToString(reader["CategoryName"]);
                       product.ProductPrice = Convert.ToDecimal(reader["ProductPrice"]);
                       product.ProductRating = Convert.ToInt32(reader["ProductRating"]);
                       Products.Add(product);

                   }


               }
               catch (Exception)
               {
                   
                   throw;
               }
               return Products;
               
           }
       }

       public List<string> GetProductName(string productName)
       {
           using (_Connection=new SqlConnection(_ConnectionString))
           {
               List<string> resultProductNames = new List<string>();
               try
               {
                   _Connection.Open();
                   SqlCommand cmd = new SqlCommand();
                   cmd.Connection = _Connection;
                   cmd.CommandText = "select Top 10 ProductName from PRODUCTS where ProductName LIKE ''+@SearchProductName+'%'";
                   cmd.CommandType = CommandType.Text;
                   cmd.Parameters.AddWithValue("@SearchProductName", productName);
                   SqlDataReader dataReader = cmd.ExecuteReader();
                   while (dataReader.Read())
                   {
                       resultProductNames.Add(Convert.ToString( dataReader["ProductName"]));
                   }  

               }
               catch (Exception)
               {

                   throw;
               }
               return resultProductNames;
           }


       }




    }
}
