using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingCartBAL;
using ShoppingCartBE;

namespace ShoppingCartWebApp
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        List<ProductsBE> _products = new List<ProductsBE>();
        OrdersBAL _ordersBAL = new OrdersBAL();
        public ProductsBE _product = new ProductsBE();
        ProductsBAL _productBAL = new ProductsBAL();
        List<int> _populateAlterDdl = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
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
                //Dictionary<string, string> dictionary = new Dictionary<string, string>();
                //HttpCookie cok = Request.Cookies["CartEssentials"];

                //if (cok != null)
                //{
                //    //Getting multiple values from single cookie.
                //    NameValueCollection nameValueCollection = Request.Cookies["CartEssentials"].Values;

                //    //Iterate the unique keys.
                //    foreach (string key in nameValueCollection.AllKeys)
                //    {
                //        dictionary.Add(key, Request.Cookies["CartEssentials"][key]);
                //    }

                //}

                //foreach (KeyValuePair<string,string> kvp in dictionary)
                //{
                //    _products.Add(_productBAL.GetProduct(Convert.ToInt32(kvp.Key))); 

                //}
                _products = _productBAL.GetCartDetails(Convert.ToInt32(Session["CustomerId"]));

                if (_products.Count > 0)
                {
                   // Session["CartCount"] = _products.Count;
                    
                    grdCart.DataSource = _products;
                    grdCart.DataBind();
                    
                    
                    
                    _product = _productBAL.TotalCartAmount(Convert.ToInt32(Session["CustomerId"]));

                    // (lblSetTotalCartAmount.Text) = Convert.ToString(_product.TotalCartAmount);
                    lblSetTotalCartAmount.Text = String.Format("{0:C}", _product.TotalCartAmount);
                }
                else
                {
                    lblYourCart.Visible = false;
                    lblEmptyCartPrompt.Visible = true;
                    lblTotalCartAmount.Visible = false;
                    btConfirm.Visible = false;


                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void grdCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }

        protected void btConfirm_Click(object sender, EventArgs e)
        {
            _products = _productBAL.GetCartDetails(Convert.ToInt32(Session["CustomerId"]));
           


            //fetch all products from his cart and save productids in some sort of
            //a list create new order for this customer and add all details in the cart to orderdetails with order id recieved from the usp

            _ordersBAL.CreateOrder(Convert.ToInt32(Session["CustomerId"]), _products);

            
            Response.Redirect("ConfirmPage.aspx");





        }

        protected void btnProductsPage_Click(object sender, EventArgs e)
        {

            Response.Redirect("ProductsPage.aspx");
        }





    }
}