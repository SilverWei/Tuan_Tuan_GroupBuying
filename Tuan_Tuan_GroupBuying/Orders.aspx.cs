using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using Maticsoft.DBUtility;//Please add references


public partial class Orders : System.Web.UI.Page
{
    TTGB.BLL.t_Goods bllt_Goods = new TTGB.BLL.t_Goods();
    TTGB.BLL.t_GroupBuying bllt_GroupBuying = new TTGB.BLL.t_GroupBuying();
    TTGB.BLL.t_Orders bllt_Orders = new TTGB.BLL.t_Orders();
    TTGB.Model.t_Goods Modt_Goods = new TTGB.Model.t_Goods();
    TTGB.Model.t_Orders Modt_Orders = new TTGB.Model.t_Orders();
    TTGB.BLL.t_OrdersGoods bllt_OrdersGoods = new TTGB.BLL.t_OrdersGoods();
    TTGB.Model.t_OrdersGoods Modt_OrdersGoods = new TTGB.Model.t_OrdersGoods();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserId"] != null && Request.Cookies["UserName"] != null)
        {

        }
        else
        {
            Response.Redirect("Landed.aspx");
        }
        G_Show();
        GB_Show();
    }
    public void G_Show()
    {
        if (Request.Cookies["OrdersGoods"] != null && Request.QueryString["GB"] == null)
        {
            HttpCookie ShoppingCart_cookie = Request.Cookies["OrdersGoods"];
            StringBuilder sp = new StringBuilder();
            float TotalPrice = 0;
            for (int i = 0; i < ShoppingCart_cookie.Values.Count; i++)
            {
                string[] Box = ShoppingCart_cookie.Values[i].Split(',');
                if (Box[1] == "G")
                {
                    DataTable Login1 = DbHelperSQL.Query("select * from t_Goods Left Join t_GoodsPicture On t_Goods.G_ID = t_GoodsPicture.G_ID Where t_Goods.G_ID =" + Box[0]).Tables[0];
                    sp.Append("<tr>");
                    sp.Append("<td><a href=\"Goods.aspx?G_ID=" + Box[0] + "\">" + Login1.Rows[0]["G_Name"].ToString() + "</a></td>");
                    sp.Append("<td>" + float.Parse(Login1.Rows[0]["G_UserPrice"].ToString()).ToString("C") + "</td>");
                    sp.Append("<td>" + Box[2] + "</td>");
                    float Price = float.Parse(Box[2].ToString()) * float.Parse(Login1.Rows[0]["G_UserPrice"].ToString());
                    sp.Append("<td runat=\"server\">" + Price.ToString("C") + "</td>");
                    sp.Append("</tr>");
                    TotalPrice += Price;
                }
            }
            G_Show_Box.InnerHtml = sp.ToString();
            TotalPriceShow.Text = TotalPrice.ToString("C");
        }
    }

    public void GB_Show()
    {
        if (Request.Cookies["ShoppingCartB"] != null && Request.QueryString["GB"] != null)
        {
            HttpCookie ShoppingCart_cookie = Request.Cookies["ShoppingCartB"];
            StringBuilder sp = new StringBuilder();
            float TotalPrice = 0;
            for (int i = 0; i < ShoppingCart_cookie.Values.Count; i++)
            {
                string[] Box = ShoppingCart_cookie.Values[i].Split(',');
                if (ShoppingCart_cookie.Values.AllKeys[i] == Request.QueryString["GB"])
                {
                    DataTable Login1 = DbHelperSQL.Query("select * from t_GroupBuying Left Join t_GroupBuyingPicture On t_GroupBuying.GB_ID = t_GroupBuyingPicture.GB_ID Where t_GroupBuying.GB_ID =" + Box[0]).Tables[0];
                    sp.Append("<tr>");
                    sp.Append("<td><a href=\"Goods.aspx?GB_ID=" + Box[0] + "\">" + Login1.Rows[0]["GB_Name"].ToString() + "</a></td>");
                    sp.Append("<td>" + float.Parse(Login1.Rows[0]["GB_GroupPrice"].ToString()).ToString("C") + "</td>");
                    sp.Append("<td>" + Box[2] + "</td>");
                    float Price = float.Parse(Box[2].ToString()) * float.Parse(Login1.Rows[0]["GB_GroupPrice"].ToString());
                    sp.Append("<td runat=\"server\">" + Price.ToString("C") + "</td>");
                    sp.Append("</tr>");
                    TotalPrice += Price;
                }
            }
            G_Show_Box.InnerHtml = sp.ToString();
            TotalPriceShow.Text = TotalPrice.ToString("C");
        }
    }


    /// <summary>
    /// 点击提交
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Submit_Click(object sender, EventArgs e)
    {
        if (O_Cnsignee.Value == "" || O_ZipCode.Value == "" || O_Address.Value == "" || O_Phone.Value == "")
        {
            ErrorShow.Visible = true;
        }
        else if (!IsZipCode(O_ZipCode.Value))
        {
            ErrorShow.Visible = true;
            ErrorShow.InnerHtml = "输入的邮编不合法！";
        }

        else if (!IsMobilePhone(O_Phone.Value))
        {
            ErrorShow.Visible = true;
            ErrorShow.InnerHtml = "输入的电话号码不合法！";
        }
        else
        {
            OrderUP();
            Response.Redirect("Home.aspx");
        }

    }

    /// <summary>
    /// 验证电话
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsMobilePhone(string input)
    {
        const string regPattern = @"^(130|131|132|133|156|134|135|136|137|138|139)\d{8}$";
        return Regex.IsMatch(input, regPattern);
    }
    /// <summary>
    /// 验证邮编
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsZipCode(string input)
    {
        const string regPattern = @"^[1-9]\d{5}$";
        return Regex.IsMatch(input, regPattern);
    }

    /// <summary>
    /// 提交数据过程
    /// </summary>
    public void OrderUP()
    {
        Modt_Orders.U_ID = Int32.Parse(Request.Cookies["UserId"].Value);
        Modt_Orders.O_Cnsignee = O_Cnsignee.Value;
        Modt_Orders.O_ZipCode = O_ZipCode.Value;
        Modt_Orders.O_Address = O_Address.Value;
        Modt_Orders.O_Phone = O_Phone.Value;
        Modt_Orders.OSM_ID = int.Parse(OSM_ID.Text);
        Modt_Orders.O_Message = O_Message.Value;
        if (Request.QueryString["GB"] == null)
        {
            Modt_Orders.O_GB_Y_N = false;
            Modt_Orders.OS_ID = 4;
        }
        else if (Request.QueryString["GB"] != null)
        {
            Modt_Orders.O_GB_Y_N = true;
            Modt_Orders.OS_ID = 5;
        }
        string ReleaseDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Modt_Orders.O_buyDate = Convert.ToDateTime(ReleaseDate);
        bllt_Orders.Add(Modt_Orders);
        OrderGoodsUP();
    }

    public void OrderGoodsUP()
    {
        if (Request.Cookies["ShoppingCart"] != null && Request.QueryString["GB"] == null)
        {
            HttpCookie ShoppingCart_cookie = Request.Cookies["ShoppingCart"];
            DataTable OrderID = bllt_Orders.GetList("U_ID='" + Request.Cookies["UserId"].Value + "' order by O_ID desc").Tables[0];
            for (int i = 0; i < ShoppingCart_cookie.Values.Count; i++)
            {
                string[] Box = ShoppingCart_cookie.Values[i].Split(',');
                if (Box[1] == "G")
                {
                    Modt_OrdersGoods.O_ID = Int32.Parse(OrderID.Rows[0]["O_ID"].ToString());
                    Modt_OrdersGoods.G_ID = Int32.Parse(Box[0]);
                    DataTable GoodsQuantity = bllt_Goods.GetList("G_ID = '" + Box[0] + "'").Tables[0];
                    Modt_OrdersGoods.OG_Quantity = Int32.Parse(Box[2]);
                    Modt_OrdersGoods.OG_TotalPrice = Int32.Parse(Box[2]) * Decimal.Parse(GoodsQuantity.Rows[0]["G_UserPrice"].ToString());
                    bllt_OrdersGoods.Add(Modt_OrdersGoods);
                    FullDetectionG(Box[0],Int32.Parse(Box[2]));
                }
            }
            DelShoppingCart();
            Response.Redirect("OrdersSort.aspx?NewOrders=1");
        }
        else if (Request.Cookies["ShoppingCartB"] != null && Request.QueryString["GB"] != null)
        {
            HttpCookie ShoppingCart_cookie = Request.Cookies["ShoppingCartB"];
            DataTable OrderID = bllt_Orders.GetList("U_ID='" + Request.Cookies["UserId"].Value + "' order by O_ID desc").Tables[0];
            for (int i = 0; i < ShoppingCart_cookie.Values.Count; i++)
            {
                string[] Box = ShoppingCart_cookie.Values[i].Split(',');
                if (ShoppingCart_cookie.Values.AllKeys[i] == Request.QueryString["GB"])
                {
                    Modt_OrdersGoods.O_ID = Int32.Parse(OrderID.Rows[0]["O_ID"].ToString());
                    Modt_OrdersGoods.GB_ID = Int32.Parse(Box[0]);
                    DataTable GoodsQuantity = bllt_GroupBuying.GetList("GB_ID = '" + Box[0] + "'").Tables[0];
                    Modt_OrdersGoods.OG_Quantity = Int32.Parse(Box[2]);
                    Modt_OrdersGoods.OG_TotalPrice = Int32.Parse(Box[2]) * Decimal.Parse(GoodsQuantity.Rows[0]["GB_GroupPrice"].ToString());
                    bllt_OrdersGoods.Add(Modt_OrdersGoods);
                    FullDetectionGB(Box[0]);
                }
            }
            DelShoppingCartGB(Request.QueryString["GB"]);
            Response.Redirect("OrdersSort.aspx?NewOrders=1");
        }
    }

    public void DelShoppingCart()
    {
        if (Request.Cookies["ShoppingCart"] != null)
        {
            HttpCookie ShoppingCart_cookie = Request.Cookies["ShoppingCart"];
            ShoppingCart_cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(ShoppingCart_cookie);
        }
    }

    public void DelShoppingCartGB(string DelGB)
    {
        DeleteShop(DelGB);
    }

    private void DeleteShop(string Delid)
    {
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

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["GB"] != null)
        {
            Response.Redirect("ShoppingCartGB.aspx");
        }
        else
        {
            Response.Redirect("ShoppingCart.aspx");

        }
    }

    public void FullDetectionG(string G_ID,int Amount)
    {
        DataTable Login1 = bllt_Goods.GetList("G_ID = " + G_ID).Tables[0];
        int AmountGet = Int32.Parse(Login1.Rows[0]["G_Amount"].ToString()) - Amount;
        DbHelperSQL.Query("UPDATE t_Goods SET G_Amount = " + AmountGet + " WHERE G_ID = " + G_ID);
    }

    public void FullDetectionGB(string GB_ID)
    {
        DataTable Login1 = DbHelperSQL.Query("Select count(*) as [GB_participantsNumber] From t_OrdersGoods Where GB_ID = " + GB_ID).Tables[0];
        DbHelperSQL.Query("UPDATE t_GroupBuying SET GB_participantsNumber = " + Login1.Rows[0]["GB_participantsNumber"].ToString() + " WHERE GB_ID = " + GB_ID);
        DataTable Login2 = bllt_GroupBuying.GetList("GB_ID = " + GB_ID).Tables[0];
        if (Int32.Parse(Login1.Rows[0]["GB_participantsNumber"].ToString()) > (Int32.Parse(Login2.Rows[0]["GB_TotalNumber"].ToString()))-1)
        {
            DbHelperSQL.Query("UPDATE A SET A.[OS_ID] = 4 from (Select [t_Orders].*,t_OrdersGoods.GB_ID From [t_Orders] Left Join t_OrdersGoods on t_Orders.O_ID=t_OrdersGoods.O_ID) as A  WHERE A.GB_ID =" + GB_ID);
        }
    }
}