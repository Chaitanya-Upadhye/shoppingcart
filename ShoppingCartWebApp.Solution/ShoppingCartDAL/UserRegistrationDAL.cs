using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using System.Data;
using ShoppingCartBE;


namespace ShoppingCartDAL
{
   public class UserRegistrationDAL:BaseDAL
    {
       public ResponseBE UserRegistration(UserRegistrationRequestBE request)
       {
           ResponseBE response = new ResponseBE();
          
               using (_Connection=new SqlConnection(_ConnectionString))
               {
                   using (TransactionScope transactionScope = new TransactionScope())
                   {
                       try
                       {
                           _Connection.Open();
                           string query="USP_REGISTERCUSTOMER";
                               SqlCommand cmd=new SqlCommand(query,_Connection);
                               cmd.CommandType = CommandType.StoredProcedure;
                               SqlParameter statusParameter = cmd.Parameters.Add("@CustomerId", SqlDbType.Int);
                               statusParameter.Direction = ParameterDirection.Output;

                               cmd.Parameters.AddWithValue("@UserName", request.UserName);
                               cmd.Parameters.AddWithValue("@Password", request.Password);
                               cmd.Parameters.AddWithValue("@EmailId", request.Email);
                               cmd.Parameters.AddWithValue("@StateId", request.StateId);
                           cmd.Parameters.AddWithValue("@FirstName",request.FirstName);
                           cmd.Parameters.AddWithValue("@LastName",request.LastName);
                           cmd.Parameters.AddWithValue("@DateOfBirth", request.DateOfBirth);
                           cmd.ExecuteNonQuery();
                           response.Status = Convert.ToInt32(cmd.Parameters["@CustomerId"].Value);



                              
                        




                          
                               transactionScope.Complete();
                           



                       }
                       catch (TransactionAbortedException ex)
                       {
                           

                           throw;
                       }
                    
                       return response;
                   }
                   
               }

              



           }


        





       }
       





    }

