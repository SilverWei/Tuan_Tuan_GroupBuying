using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;//Please add references

public partial class Management_OrdersHistory : System.Web.UI.Page
{
    TTGB.BLL.t_Orders bllt_Orders = new TTGB.BLL.t_Orders();
    TTGB.Model.t_Orders Modt_Orders = new TTGB.Model.t_Orders();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Ser"] != null)
        {
            GSearch(GSDate(Request.QueryString["DateFrom"] != null ? Request.QueryString["DateFrom"].ToString() : "", Request.QueryString["DateTo"] != null ? Request.QueryString["DateTo"].ToString() : ""), OS(Request.QueryString["OS_ID"] != null ? Request.QueryString["OS_ID"].ToString() : ""));
        }
        else
        {
            SqlDataSource4.SelectCommand = "Select * From (Select [O_ID],sum(OG_TotalPrice)as OG_TotalPrice From [t_OrdersGoods] Left join t_Goods on t_Goods.G_ID=t_OrdersGoods.G_ID group by [O_ID]) as A Left join t_Orders on t_Orders.O_ID=A.O_ID Left join t_OrdersShippingMethod on t_OrdersShippingMethod.OSM_ID = t_Orders.OSM_ID Left join t_Users on t_Users.U_ID = t_Orders.U_ID Left join t_OrdersSort on t_OrdersSort.OS_ID = t_Orders.OS_ID Where t_Orders.OS_ID != 3 " + GSDate(Request.QueryString["DateFrom"] != null ? Request.QueryString["DateFrom"].ToString() : "", Request.QueryString["DateTo"] != null ? Request.QueryString["DateTo"].ToString() : "") + OS(Request.QueryString["OS_ID"] != null ? Request.QueryString["OS_ID"].ToString() : "") + "  order by A.O_ID desc";
        }

    }
    protected void EditOrderButton_Click(object sender, EventArgs e)
    {
        string SQLtext = "UPDATE [t_Orders] SET OS_ID = " + RadioButtonList1.SelectedValue + " WHERE O_ID = " + Request.Cookies["EditOrderID"].Value;
        DbHelperSQL.Query(SQLtext);
        Response.Redirect(Request.Url.ToString());

    }

    public string GSDate(string DateFrom, string DateWhere)//时间搜索
    {
        string DateText = "";
        if (DateFrom != "")
        {
            if (!Page.IsPostBack)
                SeaDateFrom.SelectedDate = Convert.ToDateTime(DateFrom);
            DateText += " and O_buyDate >= '" + DateFrom + "'";
        }
        if (DateWhere != "")
        {
            if (!Page.IsPostBack)
                SeaDateTo.SelectedDate = Convert.ToDateTime(DateWhere);
            DateText += " and O_buyDate <= '" + DateWhere + "'";
        }
        return DateText;
    }

    public string OS(string OS_ID)//状态检索
    {
        string OSText = "";
        if (OS_ID != "")
        {
            if (!Page.IsPostBack)
                DropDownList2.Text = OS_ID;
            OSText += " and t_Orders.OS_ID = '" + OS_ID + "'";
        }
        return OSText;
    }

    public void GSearch(string SerDate, string OS_ID)
    {
        Label1.Text = Request.QueryString["Ser"].ToString();
        string OrderText = "";
        if (Request.QueryString["Wer"].ToString() == "0")
        {
            Label1.Text = "订单编号搜索：";
            OrderText = "A.O_ID";
        }
        else if (Request.QueryString["Wer"].ToString() == "1")
        {
            Label1.Text = "订单用户名搜索：";
            OrderText = "U_Name";
        }
        else if (Request.QueryString["Wer"].ToString() == "2")
        {
            Label1.Text = "订单状态搜索：";
            OrderText = "t_Orders.OS_ID";
        }
        if (!Page.IsPostBack)
        {
            DropDownList1.Text = Request.QueryString["Wer"].ToString();
            SeaBox.Text = Request.QueryString["Ser"].ToString();
        }
        string SelText = "Select * From (Select [O_ID],sum(OG_TotalPrice)as OG_TotalPrice From [t_OrdersGoods] Left join t_Goods on t_Goods.G_ID=t_OrdersGoods.G_ID group by [O_ID]) as A Left join t_Orders on t_Orders.O_ID=A.O_ID Left join t_OrdersShippingMethod on t_OrdersShippingMethod.OSM_ID = t_Orders.OSM_ID Left join t_Users on t_Users.U_ID = t_Orders.U_ID Left join t_OrdersSort on t_OrdersSort.OS_ID = t_Orders.OS_ID Where " + OrderText + " Like '%" + Request.QueryString["Ser"].ToString() + "%' " + SerDate + OS_ID + "  order by A.O_ID desc";
        SqlDataSource4.SelectCommand = SelText;
    }

    protected void SeaBoxButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Management-OrdersHistory.aspx?Ser=" + SeaBox.Text + "&Wer=" + DropDownList1.Text);

    }
    protected void SeaDateFrom_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        Response.Redirect("Management-OrdersHistory.aspx?" + UrlBack(1) + "&DateFrom=" + (Convert.ToDateTime(SeaDateFrom.SelectedDate).ToString("yyyy-MM-dd") != "0001-01-01" ? Convert.ToDateTime(SeaDateFrom.SelectedDate).ToString("yyyy-MM-dd") : ""));
    }
    protected void SeaDateTo_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        Response.Redirect("Management-OrdersHistory.aspx?" + UrlBack(2) + "&DateTo=" + (Convert.ToDateTime(SeaDateTo.SelectedDate).ToString("yyyy-MM-dd") != "0001-01-01" ? Convert.ToDateTime(SeaDateTo.SelectedDate).ToString("yyyy-MM-dd") : ""));
    }
    public string UrlBack(int DateFlag)
    {
        string UrlBackText = "";
        if (Request.QueryString["Wer"] != null)
            UrlBackText += "&Wer=" + Request.QueryString["Wer"].ToString();
        if (Request.QueryString["Ser"] != null)
            UrlBackText += "&Ser=" + Request.QueryString["Ser"].ToString();
        if (Request.QueryString["DateFrom"] != null && DateFlag != 1)
            UrlBackText += "&DateFrom=" + Request.QueryString["DateFrom"].ToString();
        if (Request.QueryString["DateTo"] != null && DateFlag != 2)
            UrlBackText += "&DateTo=" + Request.QueryString["DateTo"].ToString();
        return UrlBackText;
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.Text == "1")
        {
            Response.Redirect("Management-OrdersHistory.aspx?" + UrlBack(0));
        }
        else
        {
            Response.Redirect("Management-OrdersHistory.aspx?" + UrlBack(0) + "&OS_ID=" + DropDownList2.Text);
        }
    }
}