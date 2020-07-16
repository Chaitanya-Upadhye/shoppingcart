using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartBE;
using ShoppingCartDAL;

namespace ShoppingCartBAL
{
    public class CommonBAL
    {
        CommonDAL _commonDAL = new CommonDAL();
        

         public List<CommonBE> PopulateStatesDdl()
        {
            try
            {
                return _commonDAL.PopulateStatesDdl();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

         public List<CommonBE> PopulatehobbiesDdl()
         {
             try
             {
                 return _commonDAL.PopulatehobbiesDdl();
             }
             catch (Exception)
             {

                 throw;
             }
         }



    }
}
