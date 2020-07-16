using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingCartBAL;
using ShoppingCartBE;

namespace ShoppingCartWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        LoginBAL _loginBal = new LoginBAL();
        ResponseBE _responseBE = new ResponseBE();
        LoginRequestBE _requestBE = new LoginRequestBE();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }


        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                _requestBE.UserName = Convert.ToString(txtUserName.Text.Trim());
                _requestBE.Password = Convert.ToString(txtPassword.Text.Trim());



                _responseBE = _loginBal.LoginCredentials(_requestBE);

                if(_responseBE.IsSuccess)
                {
                    _responseBE = _loginBal.GetCustomerId(_requestBE);
                    Session["CustomerId"] = _responseBE.CustomerId;
                    Response.Redirect("ProductsPage.aspx");

                }
                else
                {
                    lblLoginFailed.Visible = true;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            

        }

      
    }
}