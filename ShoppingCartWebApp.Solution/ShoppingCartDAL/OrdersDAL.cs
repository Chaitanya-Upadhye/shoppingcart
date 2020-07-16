using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartBE;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace ShoppingCartDAL
{
   public class OrdersDAL:BaseDAL
    {

       public void CreateOrder(int customerId,List<ProductsBE> products)
       {

           OrderBE order = new OrderBE();
           ResponseBE response = new ResponseBE();
           using (TransactionScope transactionScope=new TransactionScope())
           {

               try
               {

                   using (_Connection = new SqlConnection(_ConnectionString))
                   {
                       try
                       {
                           _Connection.Open();
                           string query = "USP_CREATEORDERFORCUSTOMER";
                           SqlCommand cmd = new SqlCommand(query, _Connection);
                           cmd.CommandType = CommandType.StoredProcedure;
                           cmd.Parameters.AddWithValue("@CustomerId", customerId);
                           cmd.Parameters.AddWithValue("@OrderDate", System.DateTime.Now);
                           SqlParameter statusParameter = cmd.Parameters.Add("@OrderId", SqlDbType.Int);
                           statusParameter.Direction = ParameterDirection.Output;
                           response.Status = cmd.ExecuteNonQuery();
                           order.OrderId = Convert.ToInt32(cmd.Parameters["@OrderId"].Value);



                       }
                       catch (Exception)
                       {

                           throw;
                       }

                   }

                   using (_Connection = new SqlConnection(_ConnectionString))
                   {
                       try
                       {    _Connection.Open();

                           foreach (ProductsBE product in products)
                           {


                               string query = "USP_INSERTORDERDETAILS";
                               SqlCommand cmd = new SqlCommand(query, _Connection);
                               cmd.CommandType = CommandType.StoredProcedure;
                               cmd.Parameters.AddWithValue("@OrderId", order.OrderId);
                               cmd.Parameters.AddWithValue("@CustomerId", customerId);
                               cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                               response.Status = cmd.ExecuteNonQuery();



                           }
                       }
                       catch (Exception)
                       {
                           
                           throw;
                       }

                   }

                   using (_Connection=new SqlConnection(_ConnectionString))
                   {
                       _Connection.Open();
                    try
                   {
                           
                          foreach (ProductsBE product in products)
	                        {
		                     string query = "USP_ALTERPRODUCTSTOCK";
                           SqlCommand cmd = new SqlCommand(query, _Connection);
                           cmd.CommandType = CommandType.StoredProcedure;
                           cmd.Parameters.AddWithValue("@ProductId",product.ProductId );
                           cmd.Parameters.AddWithValue("@Quantity",product.Quantity);
                           SqlParameter statusParameter = cmd.Parameters.Add("@Overflow", SqlDbType.Int);
                           statusParameter.Direction = ParameterDirection.Output;
                           cmd.ExecuteNonQuery();

                           int overflow = Convert.ToInt32(cmd.Parameters["@Overflow"].Value);
                              if(overflow==1)
                              {
                                  throw new Exception();
                              }

 
	                        }
                     }
                       catch (Exception)
                       {
                           
                           throw;
                       }
                       
                   }


                   using (_Connection = new SqlConnection(_ConnectionString))
                   {
                       try
                       {
                           _Connection.Open();
                           string query = "USP_DELETECARTITEMS";
                           SqlCommand cmd = new SqlCommand(query, _Connection);
                           cmd.CommandType = CommandType.StoredProcedure;
                           cmd.Parameters.AddWithValue("@CustomerId",customerId);
                          
                           cmd.ExecuteNonQuery();



                       }
                       catch (Exception)
                       {

                           throw;
                       }

                   }



                   transactionScope.Complete();
                  

                  
               }

               catch (TransactionAbortedException ex)
               {
                   
                   throw;
               }



               



           }
         









       }


      public List<OrderBE> GetOrderDetails(int customerId)
       {
           List<OrderBE> orders = new List<OrderBE>();
           using (_Connection=new SqlConnection(_ConnectionString))
           {

               try
               {
                   _Connection.Open();
                   string query = "USP_GETORDERDETAILS";
                   SqlCommand cmd = new SqlCommand(query,_Connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@CustomerId", customerId);
                   SqlDataReader reader = cmd.ExecuteReader();
                   while(reader.Read())
                   {
                       OrderBE order = new OrderBE();
                       order.OrderId = Convert.ToInt32( reader["OrderId"]);
                       order.ProductName=Convert.ToString(reader["ProductName"]);
                           order.ProductPrice=Convert.ToDecimal(reader["ProductPrice"]);
                           order.OrderDate=Convert.ToDateTime(reader["OrderDate"]);
                           order.Quantity = Convert.ToInt32(reader["Quantity"]);
                           orders.Add(order);

                   }




               }
               catch (Exception)
               {
                   
                   throw;
               }
               return orders;
               
           }
       }


    }
}
