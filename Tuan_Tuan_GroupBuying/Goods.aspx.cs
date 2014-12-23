using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Goods : System.Web.UI.Page
{
    TTGB.BLL.t_Goods bllt_Goods = new TTGB.BLL.t_Goods();
    TTGB.BLL.t_GoodsPicture bllt_GoodsPicture = new TTGB.BLL.t_GoodsPicture();
    TTGB.BLL.t_GoodsSort2nd  bllt_GoodsSort2nd= new TTGB.BLL.t_GoodsSort2nd();
    TTGB.BLL.t_GoodsSort1st bllt_GoodsSort1st = new TTGB.BLL.t_GoodsSort1st();
    TTGB.BLL.t_GroupBuying bllt_GroupBuying = new TTGB.BLL.t_GroupBuying();
    TTGB.BLL.t_GroupBuyingPicture bllt_GroupBuyingPicture = new TTGB.BLL.t_GroupBuyingPicture();

    public string Pic1 = "";
    public string Pic2 = "";
    public string Pic3 = "";
    public string Pic4 = "";
    public string Pic5 = "";
    public string Amount = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            GoodsShow();
        }
        catch
        {
            Response.Write("<script>alert(\"相关产品信息已被管理员删除!\");self.close()</script>");
        }
        ShoppingCart_Show();
        ShoppingCart_Inspection();
    }

    public void GoodsShow()
    {
        if (Request.QueryString["G_ID"] != null)///如果Url的显示为？G_ID则显示Goods商品显示
        {
            DataTable Login1 = bllt_Goods.GetList("[G_ID]='" + Request.QueryString["G_ID"].ToString() + "'").Tables[0];
            Label1.Text = Label10.Text = Login1.Rows[0]["G_Name"].ToString();
            DataTable Login2 = bllt_GoodsSort2nd.GetList("[GS2_ID]='" + Login1.Rows[0]["GS2_ID"].ToString() + "'").Tables[0];
            Label12.Text = Login2.Rows[0]["GS2_Name"].ToString();
            Label12.NavigateUrl = "~/Search.aspx?GS2=" + Login2.Rows[0]["GS2_ID"].ToString();
            DataTable Login3 = bllt_GoodsSort1st.GetList("[GS1_ID]='" + Login2.Rows[0]["GS1_ID"].ToString() + "'").Tables[0];
            Label13.Text = Login3.Rows[0]["GS1_Name"].ToString();
            Label13.NavigateUrl = "~/Search.aspx?GS1=" + Login2.Rows[0]["GS1_ID"].ToString();

            Label2.Text = "品牌: " + Login1.Rows[0]["G_Brand"].ToString();
            Label15.Text = "发布日期: " + Convert.ToDateTime(Login1.Rows[0]["G_OfferDate"].ToString()).ToString("yyyy年MM月dd日");
            if (Login1.Rows[0]["G_State"].ToString() == "True")
            {
                State2.Visible = true;
                ShoppingCartAdd.Visible = true;
                LinkButton1.Text = "加入购物车";
            }
            else
            {
                State4.Visible = true;
            }
            Label4.Text = float.Parse(Login1.Rows[0]["G_MarketPrice"].ToString()).ToString("C");
            Label7.Text = float.Parse(Login1.Rows[0]["G_UserPrice"].ToString()).ToString("C");
            Label8.Text = "库存 " + Login1.Rows[0]["G_Amount"].ToString() + " 件";
            HiddenField1.Value = Login1.Rows[0]["G_Amount"].ToString();
            Label9.Text = Login1.Rows[0]["G_Text"].ToString();

            PicShow();
        }
        else if (Request.QueryString["GB_ID"] != null)///如果Url的显示为？GB_ID则显示GroupBuying商品显示
        {
            DataTable Login1 = bllt_GroupBuying.GetList("[GB_ID]='" + Request.QueryString["GB_ID"].ToString() + "'").Tables[0];
            Label1.Text = Label10.Text = Login1.Rows[0]["GB_Name"].ToString();
            DataTable Login2 = bllt_GoodsSort2nd.GetList("[GS2_ID]='" + Login1.Rows[0]["GS2_ID"].ToString() + "'").Tables[0];
            Label12.Text = Login2.Rows[0]["GS2_Name"].ToString();
            DataTable Login3 = bllt_GoodsSort1st.GetList("[GS1_ID]='" + Login2.Rows[0]["GS1_ID"].ToString() + "'").Tables[0];
            Label13.Text = Login3.Rows[0]["GS1_Name"].ToString();

            Label2.Text = "品牌: " + Login1.Rows[0]["GB_Brand"].ToString();
            Label15.Text = "发布日期: " + Convert.ToDateTime(Login1.Rows[0]["GB_OfferDate"].ToString()).ToString("yyyy年MM月dd日");
            if (Login1.Rows[0]["GB_State"].ToString() == "True")
            {
                State1.Visible = true;
                ShoppingCartAdd.Visible = true;
                LinkButton1.Text = "参与团购";
            }
            else
            {
                State3.Visible = true;
            }

            Label4.Text = float.Parse(Login1.Rows[0]["GB_MarketPrice"].ToString()).ToString("C");
            Label6.Text = "团购价";
            Label14.Text = "预定人数 " + Login1.Rows[0]["GB_TotalNumber"].ToString() + " 人";
            Label7.Text = float.Parse(Login1.Rows[0]["GB_GroupPrice"].ToString()).ToString("C");
            Label8.Text = "参与人数 " + Login1.Rows[0]["GB_participantsNumber"].ToString() + " 人";
            Label9.Text = Login1.Rows[0]["GB_Text"].ToString();
            PicShow();
        }

    }

    public void ShoppingCart_Show()
    {
        int ShoppingCart_Number = 0;

        if (Request.Cookies["ShoppingCart"] != null)
        {
            HttpCookie ShoppingCart_cookie = Request.Cookies["ShoppingCart"];
            for (int i = 0; i < ShoppingCart_cookie.Values.Count; i++)
            {
                //cookies第一条
                //ShoppingCart_cookie.Values.AllKeys[i];

                ////cookies第二条
                //string[] shops = ShoppingCart_cookie.Values[i].Split(',');
                //shops[1]；

                ShoppingCart_Number += 1;
            }
        }
        if (Request.Cookies["ShoppingCartB"] != null)
        {
            HttpCookie ShoppingCart_cookie = Request.Cookies["ShoppingCartB"];
            for (int i = 0; i < ShoppingCart_cookie.Values.Count; i++)
            {
                //cookies第一条
                //ShoppingCart_cookie.Values.AllKeys[i];

                ////cookies第二条
                //string[] shops = ShoppingCart_cookie.Values[i].Split(',');
                //shops[1]；

                ShoppingCart_Number += 1;
            }
        }
        ShoppingCart_Text.InnerText = ShoppingCart_Number.ToString();
    }

    /// <summary>
    /// 加入购物车按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Quantity.Value.ToString() == "" || Quantity.Value.ToString() == "0")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('数量不能为空和0！')", true);
        }
        else if (Request.QueryString["G_ID"] != null)//购物车放入Goods商品
        {
            HttpCookie ShoppingCart_cookie;
            if (Request.Cookies["ShoppingCart"] == null)
            {
                ShoppingCart_cookie = new HttpCookie("ShoppingCart");
            }
            else
            {
                ShoppingCart_cookie = Request.Cookies["ShoppingCart"];
            }
            ShoppingCart_cookie.Values.Add("G" + Request.QueryString["G_ID"].ToString(), Request.QueryString["G_ID"].ToString() + ",G," + Quantity.Value.ToString());
            ShoppingCart_cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(ShoppingCart_cookie);
            ShoppingCart_Show();
            ShoppingCart_Inspection();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('加入购物车成功！')", true);

        }
        else if (Request.QueryString["GB_ID"] != null)//购物车放入GroupBuying活动商品
        {
            HttpCookie ShoppingCart_cookie;
            if (Request.Cookies["ShoppingCartB"] == null)
            {
                ShoppingCart_cookie = new HttpCookie("ShoppingCartB");
            }
            else
            {
                ShoppingCart_cookie = Request.Cookies["ShoppingCartB"];
            }
            ShoppingCart_cookie.Values.Add("GB" + Request.QueryString["GB_ID"].ToString(), Request.QueryString["GB_ID"].ToString() + ",GB," + Quantity.Value.ToString());
            ShoppingCart_cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(ShoppingCart_cookie);
            ShoppingCart_Show();
            ShoppingCart_Inspection();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('加入购物车成功！')", true);
        }
        //ShoppingCart_Show();
        //cookie.values集合能够存储多个键值对，其中add方法的第一个参数是商品编号，第二个参数是商品名称和价格，中间用都好分隔。  
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('加入购物车成功！')", true);
    }

    /// <summary>
    /// 检测此商品在购物车是否包含
    /// </summary>
    public void ShoppingCart_Inspection()
    {
        if (Request.Cookies["ShoppingCart"] != null)
        {
            HttpCookie ShoppingCart_cookie = Request.Cookies["ShoppingCart"];
            int Inspection = 0;
            for (int i = 0; i < ShoppingCart_cookie.Values.Count; i++)
            {
                string[] shops = ShoppingCart_cookie.Values[i].Split(',');
                if (Request.QueryString["G_ID"] != null && shops[1].ToString() == "G")
                {
                    if (shops[0].ToString() == Request.QueryString["G_ID"].ToString())
                    {
                        Inspection = 1;
                    }
                }
            }
            if (Inspection == 1)
            {
                LinkButton1.Visible = false;
                LinkButton3.Visible = true;
            }
        }
        if (Request.Cookies["ShoppingCartB"] != null)
        {
            HttpCookie ShoppingCart_cookie = Request.Cookies["ShoppingCartB"];
            int Inspection = 0;
            for (int i = 0; i < ShoppingCart_cookie.Values.Count; i++)
            {
                string[] shops = ShoppingCart_cookie.Values[i].Split(',');
                if (Request.QueryString["GB_ID"] != null && shops[1].ToString() == "GB")
                {
                    if (shops[0].ToString() == Request.QueryString["GB_ID"].ToString())
                    {
                        Inspection = 1;
                    }
                }
            }
            if (Inspection == 1)
            {
                LinkButton1.Visible = false;
                LinkButton3.Visible = true;
            }
        }
    }

    /// <summary>
    /// 图片显示
    /// </summary>
    public void PicShow()
    {
        DataTable LoginPicture= null;
        if (Request.QueryString["G_ID"] != null)///如果Url的显示为？G_ID则显示Goods图片显示
        {
            LoginPicture = bllt_GoodsPicture.GetList("[G_ID]='" + Request.QueryString["G_ID"].ToString() + "'").Tables[0];
        }
        else if (Request.QueryString["GB_ID"] != null)///如果Url的显示为？GB_ID则显示GroupBuying图片显示
        {
            LoginPicture = bllt_GroupBuyingPicture.GetList("[GB_ID]='" + Request.QueryString["GB_ID"].ToString() + "'").Tables[0];
        }
        for (int i = 0; LoginPicture.Rows.Count>i; i++)
        {
            switch (i)
            {
                case 0:
                    Pic1 = Request.QueryString["G_ID"] != null ? LoginPicture.Rows[i]["GP_Url"].ToString() : LoginPicture.Rows[i]["GBP_Url"].ToString();
                    //Pic1.Src = Request.QueryString["G_ID"] != null ? LoginPicture.Rows[i]["GP_Url"].ToString() : LoginPicture.Rows[i]["GBP_Url"].ToString();
                    break;
                case 1:
                    Pic2 = Request.QueryString["G_ID"] != null ? LoginPicture.Rows[i]["GP_Url"].ToString() : LoginPicture.Rows[i]["GBP_Url"].ToString();
                    break;
                case 2:
                    Pic3 = Request.QueryString["G_ID"] != null ? LoginPicture.Rows[i]["GP_Url"].ToString() : LoginPicture.Rows[i]["GBP_Url"].ToString();
                    break;
                case 3:
                    Pic4 = Request.QueryString["G_ID"] != null ? LoginPicture.Rows[i]["GP_Url"].ToString() : LoginPicture.Rows[i]["GBP_Url"].ToString();
                    break;
                case 4:
                    Pic5 = Request.QueryString["G_ID"] != null ? LoginPicture.Rows[i]["GP_Url"].ToString() : LoginPicture.Rows[i]["GBP_Url"].ToString();
                    break;
            }
        }
    }

    /// <summary>
    /// 清空购物车
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ShoppingCartDel(object sender, EventArgs e)
    {
        if (Request.Cookies["ShoppingCart"] != null)
        {
            HttpCookie ShoppingCart_cookie = Request.Cookies["ShoppingCart"];
            ShoppingCart_cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(ShoppingCart_cookie);
        }
        Response.Redirect(Request.Url.ToString());
    }

}