using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartBE;
using ShoppingCartDAL;

namespace ShoppingCartBAL
{
    public class UserRegistrationBAL
    {
        ResponseBE _response = new ResponseBE();
        UserRegistrationDAL _userDAL = new UserRegistrationDAL();


         public ResponseBE UserRegistration(UserRegistrationRequestBE request)
        {
            try
            {

               return _userDAL.UserRegistration(request);
            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}
