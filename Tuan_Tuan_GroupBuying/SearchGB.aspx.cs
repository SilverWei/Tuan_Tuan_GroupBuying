using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;//Please add references


public partial class SearchGB : System.Web.UI.Page
{
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
        return "select (CASE WHEN LEN([t_GroupBuying].GB_Name) >20 THEN SUBSTRING([t_GroupBuying].GB_Name, 1,20) + '...' ELSE [t_GroupBuying].GB_Name END) AS GB_Name1,t_GroupBuying.*,[t_GroupBuyingPicture].[GBP_Url] From t_GroupBuying left join (select min(GBP_ID) as GBP_ID,min(GBP_Url) as GBP_Url,GB_ID from [t_GroupBuyingPicture] group by GB_ID) as [t_GroupBuyingPicture] on [t_GroupBuying].GB_ID = [t_GroupBuyingPicture].GB_ID Where 1=1 ";
    }

    /// <summary>
    /// Select读取要进行的模糊搜索内容
    /// </summary>
    /// <returns></returns>
    public string SelectSearch()
    {
        if (Request.QueryString["Ser"] != null)
        {
//             SelectAnd = 1;
            return " and GB_Name Like '%" + Request.QueryString["Ser"].ToString() + "%' ";
        }
        return "";
    }


    /// <summary>
    /// Select读取排序方式
    /// </summary>
    /// <returns></returns>
    public string SelectOrder()
    {
        return " order by GB_ID desc ";
    }

    /// <summary>
    /// 输出整段Select语句
    /// </summary>
    /// <param name="SelectText"></param>
    public void GoodsSelectText(string SelectText)
    {
        SqlDataSource2.SelectCommand = SelectText;
//         SqlDataSource4.SelectCommand = SelectText;
    }

    public void SelectButtonBox()
    {
        if (Request.QueryString["Ser"] != null)
        {
            if (!Page.IsPostBack)
            {
                SeaBox.Value = Request.QueryString["Ser"].ToString();
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
        Response.Redirect("SearchGB.aspx?&Ser=" + SeaBox.Value);//跳转页面
    }

    protected void SeaDateFrom_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        Response.Redirect("SearchGB.aspx?" + UrlBack(1) + "&DateFrom=" + (Convert.ToDateTime(SeaDateFrom.SelectedDate).ToString("yyyy-MM-dd") != "0001-01-01" ? Convert.ToDateTime(SeaDateFrom.SelectedDate).ToString("yyyy-MM-dd") : ""));
    }
    protected void SeaDateTo_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        Response.Redirect("SearchGB.aspx?" + UrlBack(2) + "&DateTo=" + (Convert.ToDateTime(SeaDateTo.SelectedDate).ToString("yyyy-MM-dd") != "0001-01-01" ? Convert.ToDateTime(SeaDateTo.SelectedDate).ToString("yyyy-MM-dd") : ""));
    }
    public string UrlBack(int DateFlag)
    {
        string UrlBackText = "";
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
            DateText += " and GB_OfferDate >= '" + DateFrom + "'";
        }
        if (DateWhere != "")
        {
            if (!Page.IsPostBack)
                SeaDateTo.SelectedDate = Convert.ToDateTime(DateWhere);
            DateText += " and GB_OfferDate <= '" + DateWhere + "'";
        }
        return DateText;
    }

}