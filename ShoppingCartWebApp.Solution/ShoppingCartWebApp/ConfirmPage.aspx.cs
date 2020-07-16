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
    public partial class ConfirmPage : System.Web.UI.Page
    {
        OrdersBAL objOrder = new OrdersBAL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                BindData();
            }

        }

        void BindData()
        {
            try
            {
                grdOrderDetails.DataSource = objOrder.GetOrderDetails(Convert.ToInt32(Session["CustomerId"]));
                grdOrderDetails.DataBind();

            }
            catch (Exception)
            {
                
                throw;
            }

        }

        protected void grdOrderDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdOrderDetails.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

    }
}