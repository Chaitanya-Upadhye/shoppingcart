using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ShoppingCartBE;


namespace ShoppingCartDAL
{
    public class LoginDAL:BaseDAL
    {
    public ResponseBE LoginCredentials(LoginRequestBE request)
    {


        using (_Connection=new SqlConnection(_ConnectionString))
        {
            ResponseBE response = new ResponseBE();
            try
            {

                SqlCommand cmd = new SqlCommand("USP_LOGIN",_Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", request.UserName);
                cmd.Parameters.AddWithValue("@Password", request.Password);
                SqlParameter statusParameter = cmd.Parameters.Add("@Status", SqlDbType.Int);
                statusParameter.Direction = ParameterDirection.Output;

                _Connection.Open();
                response.UserName = Convert.ToString(cmd.ExecuteScalar());
                response.Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);



            }
               
            catch (Exception)
            {
                
                throw;
            }
            return response;

        }


        }



    public ResponseBE GetCustomerId(LoginRequestBE request)
    {


        using (_Connection = new SqlConnection(_ConnectionString))
        {
            ResponseBE response = new ResponseBE();
            try
            {
                _Connection.Open();

                SqlCommand cmd = new SqlCommand("USP_GETCUSTOMERID", _Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", request.UserName);
                //SqlParameter statusParameter = cmd.Parameters.Add("@CustomerId", SqlDbType.Int);
                //statusParameter.Direction = ParameterDirection.Output;

               // response.UserName = Convert.ToString(cmd.ExecuteScalar());
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                response.CustomerId = Convert.ToInt32(reader["CustomerId"]);



            }

            catch (Exception)
            {

                throw;
            }
            return response;

        }


    }




    }
}
