using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

using ShoppingCartBE;
using ShoppingCartBAL;

namespace ShoppingCartWebApp
{
    public partial class ViewProducts : System.Web.UI.Page
    {
        ProductsBAL _productsBAL = new ProductsBAL();
        ProductsBE _product = new ProductsBE();
        List<int> _quantity = new List<int> {1,2,3,4,5,6,7,8,9,10 };
        Dictionary<string, string> _productQuantity = new Dictionary<string, string>();
        
        


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
                BindData();
            }

        }
        void CreateCookie(string cookieName)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            Response.Cookies.Add(cookie);

        }

        void BindData()
        {
            _product = _productsBAL.GetProduct(Convert.ToInt32(Session["ProductId"]));

            lblSetProductName.Text = _product.ProductName;
            lblProductPrice.Text = Convert.ToString(_product.ProductPrice);

            lblUnitsInStock.Text = Convert.ToString(_product.UnitsInStock);

            ddlSelectQuantity.DataSource = _quantity;
            ddlSelectQuantity.DataBind();




            //grdProductsInCart.DataBind();




        }
        protected void AddToProductQuantityDictionary(Dictionary<string,string> dictionary,string key,string value)
        {
            if(dictionary.ContainsKey(key))
            {
                string quantity =Convert.ToString(Convert.ToInt32(dictionary[key])+Convert.ToInt32(value));

                dictionary[key] = quantity;

            }
            else
            {
                dictionary.Add(key, value);

            }

        }

        public void SetMultipleCookies(string CookieName, Dictionary<string, string> dic)
        {
            
            if (Request.Cookies[CookieName] == null)
            {
                HttpCookie hc = new HttpCookie(CookieName);


                foreach (KeyValuePair<string, string> val in dic)
                {
                    if (hc[val.Key] != null)
                    {
                        hc[val.Key] = Convert.ToString(Convert.ToInt32(val.Value) + 1);

                    }
                    else
                        hc[val.Key] = val.Value;

                    
                }
                hc.Expires = DateTime.Now.Add(TimeSpan.FromHours(24));
                Response.Cookies.Add(hc);
                
            }
            else
            {
                HttpCookie hc = Request.Cookies[CookieName];


                foreach (KeyValuePair<string, string> val in dic)
                {
                    if (Request.Cookies[CookieName][val.Key] != null)
                    {
                        
                        hc.Values[val.Key]= Convert.ToString(Convert.ToInt32(val.Value) + 1);
                        Response.Cookies.Set(hc);



                    }
                    else
                    {
                        hc.Values[val.Key] = val.Value;
                        Response.Cookies.Set(hc);
                }


                }

            }

            
        }




        protected void btnBuy_Click(object sender, EventArgs e)
        {

            try
            {

                // AddToProductQuantityDictionary(_productQuantity, Convert.ToString(Session["ProductId"]), ddlSelectQuantity.SelectedValue);
                //SetMultipleCookies("CartEssentials", _productQuantity);
                _product.ProductId = Convert.ToInt32(Session["ProductId"]);
                _product.CustomerId = Convert.ToInt32(Session["CustomerId"]);
                _product.Quantity =Convert.ToInt32 (ddlSelectQuantity.SelectedValue);
                if((_productsBAL.InsertToCart(_product)).IsSuccess)
                {
                    Session["CartCount"] = Convert.ToInt32(Session["CartCount"]) + 1;
                    lblCartItems.Text = "ADDED SUCCESFULLY";
                }
            
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("ProductsPage.aspx");
        }
    }
}