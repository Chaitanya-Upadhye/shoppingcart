using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartBE;
using System.Data.SqlClient;

namespace ShoppingCartDAL
{
    public class BaseDAL
    {
        protected string _ConnectionString;
        public SqlConnection _Connection;

        public BaseDAL()
        {

            _ConnectionString = "Data Source=SUP53;Initial Catalog=TestDB;User ID=sa";
          //  _Connection = new SqlConnection(_ConnectionString);

    }


    }
}
