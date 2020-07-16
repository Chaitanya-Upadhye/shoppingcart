using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartBE;
using ShoppingCartDAL;

namespace ShoppingCartBAL
{


    public class LoginBAL
    {
        ResponseBE response = new ResponseBE();
        LoginDAL _LoginDal = new LoginDAL();

        public ResponseBE LoginCredentials(LoginRequestBE request)
        {
            try
            {
                response = _LoginDal.LoginCredentials(request);
                response.IsSuccess = (response.Status >= 1);
            }
            catch (Exception ex)
            {
                if (response == null)
                {
                    response = new ResponseBE();
                }

                response.ErrorCode = 123;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public ResponseBE GetCustomerId(LoginRequestBE request)
        {

            try
            {
                return _LoginDal.GetCustomerId(request);
            }
            catch (Exception)
            {
                
                throw;
            }
        }




    }
}
