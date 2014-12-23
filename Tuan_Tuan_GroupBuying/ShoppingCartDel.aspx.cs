using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ShoppingCartDel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["Del"]))
        {
            string Delid = Request.QueryString["Del"];
            DeleteShop(Delid);
        }
        Response.Redirect(Request.QueryString["Url"]);
    }
    private void DeleteShop(string Delid)
    {
        if (Request.Cookies["ShoppingCart"] != null)
        {
            HttpCookie ShoppingCart_cookie = Request.Cookies["ShoppingCart"];

            ShoppingCart_cookie.Values.Remove(Delid);
            if (ShoppingCart_cookie.Values.Count == 0)
            {
                ShoppingCart_cookie.Expires = DateTime.Now.AddDays(-1);
            }
            Response.Cookies.Add(ShoppingCart_cookie);
        }
        if (Request.Cookies["ShoppingCartB"] != null)
        {
            HttpCookie ShoppingCart_cookie = Request.Cookies["ShoppingCartB"];

            ShoppingCart_cookie.Values.Remove(Delid);
            if (ShoppingCart_cookie.Values.Count == 0)
            {
                ShoppingCart_cookie.Expires = DateTime.Now.AddDays(-1);
            }
            Response.Cookies.Add(ShoppingCart_cookie);
        }
    }
}