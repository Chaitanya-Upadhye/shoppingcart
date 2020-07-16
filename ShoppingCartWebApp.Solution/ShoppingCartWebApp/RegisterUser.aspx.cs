using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingCartBE;
using ShoppingCartBAL;

namespace ShoppingCartWebApp
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        List<CommonBE> _states = new List<CommonBE>();
        List<CommonBE> _hobbies= new List<CommonBE>();
        UserRegistrationRequestBE _user = new UserRegistrationRequestBE();
        ResponseBE _response = new ResponseBE();
        UserRegistrationBAL _userRegistrationBal = new UserRegistrationBAL();

        CommonBAL _commonBAL = new CommonBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }

        }


        public void BindData()
        {
            try
            {
                _states = _commonBAL.PopulateStatesDdl();
                ddlStatesList.DataSource = _states;
                ddlStatesList.DataValueField = "StateId";
                ddlStatesList.DataTextField = "StateName";
                ddlStatesList.DataBind();
                _hobbies = _commonBAL.PopulatehobbiesDdl();
                ddlHobbiesList.DataSource = _hobbies;
                ddlHobbiesList.DataTextField = "HobbieName";
                ddlHobbiesList.DataValueField = "HobbieId";
                ddlHobbiesList.DataBind();
            }
            catch (Exception)
            {
                
                throw;
            }

        }
      

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            try
            {
                _user.UserName = txtUserName.Text.Trim();
                _user.Password = txtPassword.Text.Trim();
                _user.ConfimredPassword = txtConfirmedPassword.Text.Trim();
                _user.StateId = Convert.ToInt32(ddlStatesList.SelectedValue);
               // _user.HobbieId = Convert.ToInt32(ddlHobbiesList.SelectedValue);
                _user.Email = txtEmail.Text;
                _user.FirstName = txtFirstName.Text.Trim();
                _user.LastName = txtLastName.Text.Trim();
                _user.DateOfBirth = Convert.ToDateTime( txtDateOfBirth.Text);
                _response = _userRegistrationBal.UserRegistration(_user);
                
                if(_response.Status!=0)
                {
                    lblSucessMessage.Visible = true;
                    Session["CustomerId"] = _response.Status;
                    
                    Response.Redirect("ProductsPage.aspx");

                }


            }
            catch (Exception)
            {
                lblRollBack.Visible = true;
                //throw;
            }



        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {

               // Response.Redirect("Login.aspx");
                Server.Transfer("Login.aspx");
            }
            catch (Exception)
            {
                
                throw;
            }



        }




    }
}