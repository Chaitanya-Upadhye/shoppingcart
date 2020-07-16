using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingCartBE;
using ShoppingCartBAL;
using System.Text;
using System.Web.Services;

namespace ShoppingCartWebApp
{
    public partial class ProductsPage : System.Web.UI.Page
    {
        ProductsBAL _productsBAL = new ProductsBAL();
        List<int> ratingList = new List<int> { 1, 2, 3, 4, 5 };
        List<decimal> priceRange = new List<decimal> { 1000,5000,10000,200000};

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }


        public void BindData()
        {
            try
            {
                ddlProductPriceRange.DataSource = priceRange;
                ddlProductPriceRange.DataBind();

                ddlProductRating.DataSource = ratingList;
                ddlProductRating.DataBind();


                grdProducts.DataSource = _productsBAL.GetAllProducts();
                grdProducts.DataBind();

            }
            catch (Exception)
            {

                 throw;
            }


        }

        protected void gvwProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProducts.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void gvwProducts_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int ProductId = Convert.ToInt32(grdProducts.DataKeys[e.NewSelectedIndex].Value);
            Session["ProductId"] = ProductId;

            //mp1.Show();
            Response.Redirect("ViewProducts.aspx");
        }

        protected void btnShowCart_Click(object sender, EventArgs e)
        {



        }

        protected void btnShowCartContent_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShoppingCart.aspx");

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string productName=null;
            int rating=0;
            decimal price=0;
            try
            {

                if(txtProductName.Text.Trim()!="")
                {
                    productName = txtProductName.Text.Trim();
                }
                if (Convert.ToDecimal(ddlProductPriceRange.SelectedValue)!=0)
                {
                    price = Convert.ToDecimal(ddlProductPriceRange.SelectedValue);
                }

                if(Convert.ToInt32( ddlProductRating.SelectedValue)!=0)
                {
                    rating = Convert.ToInt32(ddlProductRating.SelectedValue);
                }


              
                grdProducts.DataSource = _productsBAL.SearchProducts(productName,price,rating);
                grdProducts.DataBind();


            }
            catch (Exception)
            {
                
                throw;
            }
        }

        [WebMethod]
        public static List<string> GetProductName(string productName)
        {
            List<string> productNames = new List<string>();
            ProductsBAL productBAL = new ProductsBAL();
            try
            {
                productNames = productBAL.GetProductName(productName);

            }
            catch (Exception)
            {
                
                throw;
            }
            return productNames;

        }


    }
}