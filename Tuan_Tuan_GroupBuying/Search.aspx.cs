using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;//Please add references


public partial class Search : System.Web.UI.Page
{
    TTGB.BLL.t_GoodsSort1st bllt_GoodsSort1st = new TTGB.BLL.t_GoodsSort1st();
    TTGB.BLL.t_GoodsSort2nd bllt_GoodsSort2nd = new TTGB.BLL.t_GoodsSort2nd();


    public int SelectAnd = 0;
    public string SelectUrl = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ShoppingCart_Show();//购物车数量显示

        SelectString();
        SelectButtonBox();

    }

    public void SelectString()
    {
        StringBuilder SelectText = new StringBuilder();
        SelectText.Append(SelectFrom());
        SelectText.Append(SelectSearch());
        SelectText.Append(SelectGS1());
        SelectText.Append(SelectGS2());
        SelectText.Append(SelectBrand());
        SelectText.Append(SelectState());
        SelectText.Append((GSDate(Request.QueryString["DateFrom"] != null ? Request.QueryString["DateFrom"].ToString() : "", Request.QueryString["DateTo"] != null ? Request.QueryString["DateTo"].ToString() : "")));
        SelectText.Append(SelectOrder());
        GoodsSelectText(SelectText.ToString());
        DataTable SelectTextData = DbHelperSQL.Query(SelectText.ToString()).Tables[0];
        if (!(SelectTextData.Rows.Count > 0))//是否有数据，没有则显示"无相关产品内容!"
        {
            SelectNullShow.Visible = true;
        }

    }

    /// <summary>
    /// Select读取数据源
    /// </summary>
    /// <returns></returns>
    public string SelectFrom()
    {
        return "select (CASE WHEN LEN([t_Goods].G_Name) >20 THEN SUBSTRING([t_Goods].G_Name, 1,20) + '...' ELSE [t_Goods].G_Name END) AS G_Name1,[t_Goods].*,t_GoodsSort2nd.*,[t_GoodsPicture].[GP_Url] From [t_Goods] left join (select min(GP_ID) as GP_ID,min(GP_Url) as GP_Url,G_ID from [t_GoodsPicture] group by G_ID) as [t_GoodsPicture] on [t_Goods].G_ID = [t_GoodsPicture].G_ID Left join t_GoodsSort2nd on t_GoodsSort2nd.GS2_ID = [t_Goods].GS2_ID ";
    }

    /// <summary>
    /// Select读取要进行的模糊搜索内容
    /// </summary>
    /// <returns></returns>
    public string SelectSearch()
    {
        if (Request.QueryString["Ser"] != null)
        {
            SelectAnd = 1;
            return " Where G_Name Like '%" + Request.QueryString["Ser"].ToString() + "%' ";
        }
        return " Where ";
    }

    /// <summary>
    /// Select判断GS1分类
    /// </summary>
    /// <returns></returns>
    public string SelectGS1()
    {
        if (Request.QueryString["GS1"] != null)
        {
            string AndText = "";
            if (SelectAnd == 1)
            {
                AndText = " And ";
            }
            SelectAnd = 1;
            return AndText + " GS1_ID = " + Request.QueryString["GS1"].ToString();
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// Select判断GS2分类
    /// </summary>
    /// <returns></returns>
    public string SelectGS2()
    {
        if (Request.QueryString["GS2"] != null && Request.QueryString["GS1"] == null)
        {
            string AndText = "";
            if (SelectAnd == 1)
            {
                AndText = " And ";
            }
            SelectAnd = 1;
            return AndText + " t_Goods.GS2_ID = " + Request.QueryString["GS2"].ToString();
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// Select读取品牌
    /// </summary>
    /// <returns></returns>
    public string SelectBrand()
    {
        if (Request.QueryString["Bra"] != null)
        {
            string AndText = "";
            if (SelectAnd == 1)
            {
                AndText = " And ";
            }
            SelectAnd = 1;
            return AndText + " G_Brand Like '%" + Request.QueryString["Bra"].ToString() + "%'";
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// 清除Select内未开放的产品
    /// </summary>
    /// <returns></returns>
    public string SelectState()
    {
        string AndText = "";
        if (SelectAnd == 1)
        {
            AndText = " And ";
        }
        return AndText + " t_Goods.G_State != 'False' ";
    }

    /// <summary>
    /// Select读取排序方式
    /// </summary>
    /// <returns></returns>
    public string SelectOrder()
    {
        if (Request.QueryString["Ord"] != null)
        {
            string OrderText = "";
            switch (Request.QueryString["Ord"].ToString())
            {
                case "0":
                    OrderText = " G_ID ";
                    break;
                case "1":
                    OrderText = " G_ID desc ";
                    break;
                case "2":
                    OrderText = " G_UserPrice ";
                    break;
                case "3":
                    OrderText = " G_UserPrice desc ";
                    break;
                case "4":
                    OrderText = " G_Name ";
                    break;
                case "5":
                    OrderText = " G_Name desc ";
                    break;
            }
            return " order by " + OrderText;
        }
        else
        {
            return " order by G_ID desc ";
        }

    }

    /// <summary>
    /// 输出整段Select语句
    /// </summary>
    /// <param name="SelectText"></param>
    public void GoodsSelectText(string SelectText)
    {
        SqlDataSource4.SelectCommand = SelectText;
    }

    public void SelectButtonBox()
    {
        if (Request.QueryString["GS1"] != null)
        {
            GS1TextShow.Text = "二级分类";
            DataTable GS1Text = bllt_GoodsSort1st.GetList("GS1_ID = " + Request.QueryString["GS1"].ToString()).Tables[0];
            GS1TextShow2.Text = GS1Text.Rows[0]["GS1_Name"].ToString() + " > ";
            GS2TextShow2.Visible = false;
            SqlDataSource3.SelectCommand = "select * From [t_GoodsSort2nd] Where GS1_ID = " + Request.QueryString["GS1"].ToString();
            SqlDataSource1.SelectCommand = "Select G_Brand From t_GoodsSort1st Join t_GoodsSort2nd on t_GoodsSort1st.GS1_ID = t_GoodsSort2nd.GS1_ID Join t_Goods on t_Goods.GS2_ID=t_GoodsSort2nd.GS2_ID Where t_GoodsSort1st.GS1_ID = " + Request.QueryString["GS1"].ToString() + " group by G_Brand";
            SelectUrl = "GS1=" + Request.QueryString["GS1"].ToString();
        }
        else if (Request.QueryString["GS2"] != null)
        {
            GS1TextShow.Text = "二级分类";
            DataTable GS2Text = bllt_GoodsSort2nd.GetList("GS2_ID = " + Request.QueryString["GS2"].ToString()).Tables[0];
            SqlDataSource3.SelectCommand = "select * From [t_GoodsSort2nd] Where GS1_ID = " + GS2Text.Rows[0]["GS1_ID"].ToString();
            DataTable GS1Text = bllt_GoodsSort1st.GetList("GS1_ID = " + GS2Text.Rows[0]["GS1_ID"].ToString()).Tables[0];
            GS1TextShow2.Text = GS1Text.Rows[0]["GS1_Name"].ToString() + " > ";
            GS2TextShow2.Text = GS2Text.Rows[0]["GS2_Name"].ToString() + " > ";
            GS2TextShow2.NavigateUrl = "Search.aspx?GS1=" + GS1Text.Rows[0]["GS1_ID"].ToString();
            SqlDataSource1.SelectCommand = "Select t_Goods.G_Brand From t_GoodsSort2nd Left join t_Goods on t_Goods.GS2_ID = t_GoodsSort2nd.GS2_ID Where t_Goods.GS2_ID= " + Request.QueryString["GS2"].ToString() + " group by G_Brand";
            SelectUrl = "GS2=" + Request.QueryString["GS2"].ToString();
        }
        else
        {
            GS2TextShow2.Visible = false;
            GS1TextShow2.Visible = false;
            GS1TextShow.Text = "一级分类";
            SqlDataSource2.SelectCommand = "select * From [t_GoodsSort1st]";
            SqlDataSource1.SelectCommand = "Select t_Goods.G_Brand From t_Goods group by G_Brand";
        }
        if (Request.QueryString["Bra"] != null)
        {
            BraTextShow2.Visible = true;
            BraTextShow2.Text = Request.QueryString["Bra"].ToString() + " > ";
        }
        if (Request.QueryString["Ser"] != null)
        {
            if (!Page.IsPostBack)
            {
                SeaBox.Value = Request.QueryString["Ser"].ToString();

            }
        }
        if (Request.QueryString["Ord"] != null)
        {
            switch (Request.QueryString["Ord"].ToString())
            {
                case "0":
                    OrdBurron1.CssClass = "btn btn-danger";
                    OrdBurron1.Text = "时间▲";
                    break;
                case "1":
                    OrdBurron1.CssClass = "btn btn-danger";
                    OrdBurron1.Text = "时间▼";
                    break;
                case "2":
                    OrdBurron2.CssClass = "btn btn-danger";
                    OrdBurron2.Text = "价格▲";

                    break;
                case "3":
                    OrdBurron2.CssClass = "btn btn-danger";
                    OrdBurron2.Text = "价格▼";
                    break;
                case "4":
                    OrdBurron3.CssClass = "btn btn-danger";
                    OrdBurron3.Text = "产品名▲";
                    break;
                case "5":
                    OrdBurron3.CssClass = "btn btn-danger";
                    OrdBurron3.Text = "产品名▼";
                    break;
            }
        }

    }


    /// <summary>
    /// 购物车显示数量
    /// </summary>
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

    protected void SeaBoxButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Search.aspx?" + SelectUrlBack(0) + "&Ser=" + SeaBox.Value);//跳转页面
    }

    public string SelectUrlBack(int Flag)
    {
        string SelectUrlBack = "";
        if (Request.QueryString["GS1"] != null)
            SelectUrlBack = "GS1=" + Request.QueryString["GS1"].ToString();
        else if (Request.QueryString["GS2"] != null)
            SelectUrlBack = "GS2=" + Request.QueryString["GS2"].ToString();
        if (Request.QueryString["Bra"] != null)
            SelectUrlBack += "&Bra=" + Request.QueryString["Bra"].ToString();
        if (Request.QueryString["Ser"] != null && Flag != 0)
            SelectUrlBack += "&Ser=" + Request.QueryString["Ser"].ToString();
        return SelectUrlBack;
    }

    protected void OrdBurron1_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Ord"] != null && Request.QueryString["Ord"].ToString() != "1")
            Response.Redirect("Search.aspx?" + SelectUrlBack(1) + "&Ord=1");//跳转页面
        else
            Response.Redirect("Search.aspx?" + SelectUrlBack(1) + "&Ord=0");//跳转页面
    }
    protected void OrdBurron2_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Ord"] != null && Request.QueryString["Ord"].ToString() != "3")
            Response.Redirect("Search.aspx?" + SelectUrlBack(1) + "&Ord=3");//跳转页面
        else
            Response.Redirect("Search.aspx?" + SelectUrlBack(1) + "&Ord=2");//跳转页面
    }
    protected void OrdBurron3_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Ord"] != null && Request.QueryString["Ord"].ToString() != "5")
            Response.Redirect("Search.aspx?" + SelectUrlBack(1) + "&Ord=5");//跳转页面
        else
            Response.Redirect("Search.aspx?" + SelectUrlBack(1) + "&Ord=4");//跳转页面
    }

    protected void SeaDateFrom_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        Response.Redirect("Search.aspx?" + UrlBack(1) + "&DateFrom=" + (Convert.ToDateTime(SeaDateFrom.SelectedDate).ToString("yyyy-MM-dd") != "0001-01-01" ? Convert.ToDateTime(SeaDateFrom.SelectedDate).ToString("yyyy-MM-dd") : ""));
    }
    protected void SeaDateTo_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        Response.Redirect("Search.aspx?" + UrlBack(2) + "&DateTo=" + (Convert.ToDateTime(SeaDateTo.SelectedDate).ToString("yyyy-MM-dd") != "0001-01-01" ? Convert.ToDateTime(SeaDateTo.SelectedDate).ToString("yyyy-MM-dd") : ""));
    }
    public string UrlBack(int DateFlag)
    {
        string UrlBackText = "";
        if (Request.QueryString["GS1"] != null)
            UrlBackText += "&GS1=" + Request.QueryString["GS1"].ToString();
        if (Request.QueryString["GS2"] != null)
            UrlBackText += "&GS2=" + Request.QueryString["GS2"].ToString();
        if (Request.QueryString["Bra"] != null)
            UrlBackText += "&Bra=" + Request.QueryString["Bra"].ToString();
        if (Request.QueryString["Ord"] != null)
            UrlBackText += "&Ord=" + Request.QueryString["Ord"].ToString();
        if (Request.QueryString["Ser"] != null)
            UrlBackText += "&Ser=" + Request.QueryString["Ser"].ToString();
        if (Request.QueryString["DateFrom"] != null && DateFlag != 1)
            UrlBackText += "&DateFrom=" + Request.QueryString["DateFrom"].ToString();
        if (Request.QueryString["DateTo"] != null && DateFlag != 2)
            UrlBackText += "&DateTo=" + Request.QueryString["DateTo"].ToString();
        return UrlBackText;
    }
    public string GSDate(string DateFrom, string DateWhere)//时间搜索
    {
        string DateText = "";
        if (DateFrom != "")
        {
            if (!Page.IsPostBack)
                SeaDateFrom.SelectedDate = Convert.ToDateTime(DateFrom);
            DateText += " and G_OfferDate >= '" + DateFrom + "'";
        }
        if (DateWhere != "")
        {
            if (!Page.IsPostBack)
                SeaDateTo.SelectedDate = Convert.ToDateTime(DateWhere);
            DateText += " and G_OfferDate <= '" + DateWhere + "'";
        }
        return DateText;
    }

}