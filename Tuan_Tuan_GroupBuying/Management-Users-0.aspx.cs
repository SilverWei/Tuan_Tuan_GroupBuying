using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;//Please add references

public partial class Management_Users_0 : System.Web.UI.Page
{
    TTGB.BLL.t_Users bllt_Users = new TTGB.BLL.t_Users();
    TTGB.BLL.t_Orders bllt_Orders = new TTGB.BLL.t_Orders();
    public string PageUP;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Ser"] != null)
        {
            GSearch(GSDate(Request.QueryString["DateFrom"] != null ? Request.QueryString["DateFrom"].ToString() : "", Request.QueryString["DateTo"] != null ? Request.QueryString["DateTo"].ToString() : ""));
        }
        else
        {
            SqlDataSource4.SelectCommand = "Select * From t_Users Where 1=1 " + (GSDate(Request.QueryString["DateFrom"] != null ? Request.QueryString["DateFrom"].ToString() : "", Request.QueryString["DateTo"] != null ? Request.QueryString["DateTo"].ToString() : "")) + " order by U_ID desc";
        }
        if (Request.QueryString["Err"] != null)
        {
            string BackText =   HttpUtility.UrlDecode(Request.Cookies["Back"].Value);
            Response.Write("<script>alert(\"无法删除，账户已购买过相关物品！!\");window.location.href=\"" + BackText + "\"</script>");
        }

    }

    public string GSDate(string DateFrom, string DateWhere)//时间搜索
    {
        string DateText = "";
        if (DateFrom != "")
        {
            if (!Page.IsPostBack)
                SeaDateFrom.SelectedDate = Convert.ToDateTime(DateFrom);
            DateText += " and U_SignUP >= '" + DateFrom + "'";
        }
        if (DateWhere != "")
        {
            if (!Page.IsPostBack)
                SeaDateTo.SelectedDate = Convert.ToDateTime(DateWhere);
            DateText += " and U_SignUP <= '" + DateWhere + "'";
        }
        return DateText;
    }


    protected void DelButton1_Click(object sender, EventArgs e)
    {
        DataTable Login1 = bllt_Orders.GetList("[U_ID]='" + Request.Cookies["DelU_ID"].Value + "'").Tables[0];
        if (Login1.Rows.Count == 0)//没有数据则删除
        {
            bllt_Users.Delete(int.Parse(Request.Cookies["DelU_ID"].Value.ToString()));
            Response.Redirect(Request.Url.ToString());
        }
        else
        {
            Response.Cookies["Back"].Value = HttpUtility.UrlEncode(Request.Url.ToString());//存储Cookies值
            //中文存Cookies
            //cookie.Value = HttpUtility.UrlEncode("上海");
            //取cookie时候,进行解码:
            //cookieValue = HttpUtility.UrlDecode(cookie.Value);
            Response.Cookies["Back"].Expires = DateTime.Now.AddDays(1); //确定Cookies保存时间
            Response.Redirect("Management-Users-0.aspx?Err=1");
        }
    }

    public void GSearch(string SerDate)
    {
        Label1.Text = Request.QueryString["Ser"].ToString();
        string OrderText = "";
        if (Request.QueryString["Wer"].ToString() == "0")
        {
            Label1.Text = "用户名搜索：";
            OrderText = "U_Name";
        }
        else if (Request.QueryString["Wer"].ToString() == "1")
        {
            Label1.Text = "用户编号搜索：";
            OrderText = "U_ID";
        }
        else if (Request.QueryString["Wer"].ToString() == "2")
        {
            Label1.Text = "电子邮件搜索：";
            OrderText = "U_Email";
        }
        if (!Page.IsPostBack)
        {
            DropDownList1.Text = Request.QueryString["Wer"].ToString();
            SeaBox.Text = Request.QueryString["Ser"].ToString();
        }
        string SelText = "Select * From t_Users Where " + OrderText + " Like '%" + Request.QueryString["Ser"].ToString() + "%' " + SerDate + " order by U_ID desc";
        SqlDataSource4.SelectCommand = SelText;
    }

    protected void SeaDateFrom_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        Response.Redirect("Management-Users-0.aspx?" + UrlBack(1) + "&DateFrom=" + (Convert.ToDateTime(SeaDateFrom.SelectedDate).ToString("yyyy-MM-dd") != "0001-01-01" ? Convert.ToDateTime(SeaDateFrom.SelectedDate).ToString("yyyy-MM-dd") : ""));
    }
    protected void SeaDateTo_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        Response.Redirect("Management-Users-0.aspx?" + UrlBack(2) + "&DateTo=" + (Convert.ToDateTime(SeaDateTo.SelectedDate).ToString("yyyy-MM-dd") != "0001-01-01" ? Convert.ToDateTime(SeaDateTo.SelectedDate).ToString("yyyy-MM-dd") : ""));
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
        Response.Redirect("Management-Users-0.aspx?Ser=" + SeaBox.Text + "&Wer=" + DropDownList1.Text);

    }

}