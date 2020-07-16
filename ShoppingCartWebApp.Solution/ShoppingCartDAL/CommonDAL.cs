using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartBE;
using System.Data.SqlClient;
using System.Data;


namespace ShoppingCartDAL
{
    public class CommonDAL:BaseDAL
    {
        //populate states and hobbies ddl

       public List<CommonBE> PopulateStatesDdl()
        {
            using (_Connection=new SqlConnection(_ConnectionString))
            {
                List<CommonBE> _statesDdl = new List<CommonBE>();
                try
                {
                    _Connection.Open();
                    
                    string query = "USP_GETSTATES";
                    SqlCommand cmd = new SqlCommand(query,_Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader =cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        CommonBE state = new CommonBE();
                        state.StateId = Convert.ToInt32(reader["StateId"]);
                        state.StateName = Convert.ToString(reader["StateName"]);
                        _statesDdl.Add(state);
                    }



                }
                catch (Exception)
                {
                    
                    throw;
                }
                return _statesDdl;
           
            }
           


        }

        public List<CommonBE> PopulatehobbiesDdl()
       {
           using (_Connection = new SqlConnection(_ConnectionString))
           {
               List<CommonBE> _hobbiesDdl = new List<CommonBE>();
               try
               {
                   _Connection.Open();

                   string query = "USP_GETHOBBIES";
                   SqlCommand cmd = new SqlCommand(query, _Connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   SqlDataReader reader = cmd.ExecuteReader();

                   while (reader.Read())
                   {
                       CommonBE hobbie = new CommonBE();
                       hobbie.HobbieId = Convert.ToInt32(reader["HobbieId"]);
                       hobbie.HobbieName = Convert.ToString(reader["HobbieName"]);
                       _hobbiesDdl.Add(hobbie);
                   }



               }
               catch (Exception)
               {

                   throw;
               }
               return _hobbiesDdl;

           }

       }



       //public  CommonBE PopulateHobbiesDdl()
       //{

       //}




    }
}
