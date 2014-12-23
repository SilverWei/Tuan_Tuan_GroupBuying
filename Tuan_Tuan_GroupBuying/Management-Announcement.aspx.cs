using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;//Please add references

public partial class Management_Announcement : System.Web.UI.Page
{
    TTGB.BLL.t_Announcement bllt_Announcement = new TTGB.BLL.t_Announcement();
    TTGB.BLL.t_Administrators bllt_Administrators = new TTGB.BLL.t_Administrators();
    public string PageUP;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["del"] != null)
        {
            Response.Write("<script>alert(\"公告删除成功!\");window.location.href=\"Management-Announcement.aspx\"</script>");
        }

        if (Request.QueryString["Ser"] != null)
        {
            GSearch(GSDate(Request.QueryString["DateFrom"] != null ? Request.QueryString["DateFrom"].ToString() : "", Request.QueryString["DateTo"] != null ? Request.QueryString["DateTo"].ToString() : ""));
        }
        else
        {
            SqlDataSource4.SelectCommand = "Select [t_Announcement].*,[t_Administrators].UA_Name  From t_Announcement join [t_Administrators]  on [t_Administrators].UA_ID =[t_Announcement].UA_ID Where 1 = 1 " + (GSDate(Request.QueryString["DateFrom"] != null ? Request.QueryString["DateFrom"].ToString() : "", Request.QueryString["DateTo"] != null ? Request.QueryString["DateTo"].ToString() : "")) + " order by A_ID desc";
        }

    }

    public string GSDate(string DateFrom, string DateWhere)//时间搜索
    {
        string DateText = "";
        if (DateFrom != "")
        {
            if (!Page.IsPostBack)
                SeaDateFrom.SelectedDate = Convert.ToDateTime(DateFrom);
            DateText += " and A_ReleaseDate >= '" + DateFrom + "'";
        }
        if (DateWhere != "")
        {
            if (!Page.IsPostBack)
                SeaDateTo.SelectedDate = Convert.ToDateTime(DateWhere);
            DateText += " and A_ReleaseDate <= '" + DateWhere + "'";
        }
        return DateText;
    }


    public void GSearch(string SerDate)
    {
        Label1.Text = Request.QueryString["Ser"].ToString();
        string OrderText = "";
        if (Request.QueryString["Wer"].ToString() == "0")
        {
            Label1.Text = "公告名称搜索：";
            OrderText = "A_Name";
        }
        else if (Request.QueryString["Wer"].ToString() == "1")
        {
            Label1.Text = "发布人搜索：";
            OrderText = "UA_Name";
        }
        else if (Request.QueryString["Wer"].ToString() == "3")
        {
            Label1.Text = "公告编号搜索：";
            OrderText = "A_ID";
        }
        if (!Page.IsPostBack)
        {
            DropDownList1.Text = Request.QueryString["Wer"].ToString();
            SeaBox.Text = Request.QueryString["Ser"].ToString();
        }
        string SelText = "Select [t_Announcement].*,[t_Administrators].UA_Name  From t_Announcement join [t_Administrators]  on [t_Administrators].UA_ID =[t_Announcement].UA_ID Where " + OrderText + " Like '%" + Request.QueryString["Ser"].ToString() + "%' " + SerDate + " order by UA_ID desc";
        SqlDataSource4.SelectCommand = SelText;
    }

    protected void DelButton1_Click(object sender, EventArgs e)
    {
        bllt_Announcement.Delete(int.Parse(Request.Cookies["DelA_ID"].Value.ToString()));
        Response.Redirect(Request.Url.ToString() + "?del=1");
    }

    protected void SeaBoxButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Management-Announcement.aspx?Ser=" + SeaBox.Text + "&Wer=" + DropDownList1.Text);

    }
    protected void SeaDateFrom_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        Response.Redirect("Management-Announcement.aspx?" + UrlBack(1) + "&DateFrom=" + (Convert.ToDateTime(SeaDateFrom.SelectedDate).ToString("yyyy-MM-dd") != "0001-01-01" ? Convert.ToDateTime(SeaDateFrom.SelectedDate).ToString("yyyy-MM-dd") : ""));
    }
    protected void SeaDateTo_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        Response.Redirect("Management-Announcement.aspx?" + UrlBack(2) + "&DateTo=" + (Convert.ToDateTime(SeaDateTo.SelectedDate).ToString("yyyy-MM-dd") != "0001-01-01" ? Convert.ToDateTime(SeaDateTo.SelectedDate).ToString("yyyy-MM-dd") : ""));
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

}
