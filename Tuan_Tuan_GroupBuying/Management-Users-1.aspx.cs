using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;//Please add references

public partial class Management_Users_1 : System.Web.UI.Page
{
    TTGB.BLL.t_Administrators bllt_Administrators = new TTGB.BLL.t_Administrators();
    public string PageUP;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["Del"] != null)
        {
            Response.Write("<script>alert(\"管理员删除成功!\");window.location.href=\"Management-Users-1.aspx\"</script>");
        }
        if (Request.QueryString["err"] != null)
        {
            if (Request.QueryString["err"].ToString() == "1")
            Response.Write("<script>alert(\"无法删除，此账号正在使用中!\");window.location.href=\"Management-Users-1.aspx\"</script>");
            else if(Request.QueryString["err"].ToString() == "2")
                Response.Write("<script>alert(\"无法删除，请确认与账户相关的公告是否删除完毕！!\");window.location.href=\"Management-Users-1.aspx\"</script>");
        }

        if (Request.QueryString["Ser"] != null)
        {
            GSearch(GSDate(Request.QueryString["DateFrom"] != null ? Request.QueryString["DateFrom"].ToString() : "", Request.QueryString["DateTo"] != null ? Request.QueryString["DateTo"].ToString() : ""));
        }
        else
        {
            SqlDataSource4.SelectCommand = "Select * From t_Administrators Where 1=1 " + (GSDate(Request.QueryString["DateFrom"] != null ? Request.QueryString["DateFrom"].ToString() : "", Request.QueryString["DateTo"] != null ? Request.QueryString["DateTo"].ToString() : "")) + " order by UA_ID desc";
        }

    }

    protected void DelButton1_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["DelA_ID"].Value.ToString() != Request.Cookies["AdminId"].Value)
        {
            try
            {
                bllt_Administrators.Delete(int.Parse(Request.Cookies["DelA_ID"].Value.ToString()));
                Response.Redirect("Management-Users-1.aspx?Del=1",false);
            }
            catch
            {
                Response.Redirect("Management-Users-1.aspx?err=2");
            }
        }
        else
        {
            Response.Redirect("Management-Users-1.aspx?&err=1");
        }

    }

    public string GSDate(string DateFrom, string DateWhere)//时间搜索
    {
        string DateText = "";
        if (DateFrom != "")
        {
            if (!Page.IsPostBack)
                SeaDateFrom.SelectedDate = Convert.ToDateTime(DateFrom);
            DateText += " and UA_SignUP >= '" + DateFrom + "'";
        }
        if (DateWhere != "")
        {
            if (!Page.IsPostBack)
                SeaDateTo.SelectedDate = Convert.ToDateTime(DateWhere);
            DateText += " and UA_SignUP <= '" + DateWhere + "'";
        }
        return DateText;
    }

    public void GSearch(string SerDate)
    {
        Label1.Text = Request.QueryString["Ser"].ToString();
        string OrderText = "";
        if (Request.QueryString["Wer"].ToString() == "0")
        {
            Label1.Text = "管理员名搜索：";
            OrderText = "UA_Name";
        }
        else if (Request.QueryString["Wer"].ToString() == "1")
        {
            Label1.Text = "管理员编号搜索：";
            OrderText = "UA_ID";
        }
        else if (Request.QueryString["Wer"].ToString() == "2")
        {
            Label1.Text = "电子邮件搜索：";
            OrderText = "UA_Email";
        }
        if (!Page.IsPostBack)
        {
            DropDownList1.Text = Request.QueryString["Wer"].ToString();
            SeaBox.Text = Request.QueryString["Ser"].ToString();
        }
        string SelText = "Select * From t_Administrators Where " + OrderText + " Like '%" + Request.QueryString["Ser"].ToString() + "%' " + SerDate + " order by UA_ID desc";
        SqlDataSource4.SelectCommand = SelText;
    }

    protected void SeaDateFrom_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        Response.Redirect("Management-Users-1.aspx?" + UrlBack(1) + "&DateFrom=" + (Convert.ToDateTime(SeaDateFrom.SelectedDate).ToString("yyyy-MM-dd") != "0001-01-01" ? Convert.ToDateTime(SeaDateFrom.SelectedDate).ToString("yyyy-MM-dd") : ""));
    }
    protected void SeaDateTo_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        Response.Redirect("Management-Users-1.aspx?" + UrlBack(2) + "&DateTo=" + (Convert.ToDateTime(SeaDateTo.SelectedDate).ToString("yyyy-MM-dd") != "0001-01-01" ? Convert.ToDateTime(SeaDateTo.SelectedDate).ToString("yyyy-MM-dd") : ""));
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

    protected void SeaBoxButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Management-Users-1.aspx?Ser=" + SeaBox.Text + "&Wer=" + DropDownList1.Text);

    }

}