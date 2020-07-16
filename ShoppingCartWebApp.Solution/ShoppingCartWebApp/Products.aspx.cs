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
    public partial class Products : System.Web.UI.Page
    {
        ProductsBAL _productsBAL = new ProductsBAL();

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
                gvwProducts.DataSource = _productsBAL.GetAllProducts();
                gvwProducts.DataBind();

            }
            catch (Exception)
            {
                
               // throw;
            }
        

        }

      protected void gvwProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
      {
          gvwProducts.PageIndex = e.NewPageIndex;
          BindData();
      }




    }
}