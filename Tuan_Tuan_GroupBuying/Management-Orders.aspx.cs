using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;//Please add references


public partial class Management_Orders : System.Web.UI.Page
{
    TTGB.BLL.t_Orders bllt_Orders = new TTGB.BLL.t_Orders();
    TTGB.Model.t_Orders Modt_Orders = new TTGB.Model.t_Orders();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void EditOrderButton_Click(object sender, EventArgs e)
    {
        string SQLtext = "UPDATE [t_Orders] SET OS_ID = " + RadioButtonList1.SelectedValue + " WHERE O_ID = " + Request.Cookies["EditOrderID"].Value;
        DbHelperSQL.Query(SQLtext);
        Response.Redirect(Request.Url.ToString());

    }

    protected void SeaBoxButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Management-OrdersHistory.aspx?Ser=" + SeaBox.Text + "&Wer=" + DropDownList1.Text);

    }
    protected void SeaDateFrom_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        Response.Redirect("Management-OrdersHistory.aspx?&DateFrom=" + (Convert.ToDateTime(SeaDateFrom.SelectedDate).ToString("yyyy-MM-dd") != "0001-01-01" ? Convert.ToDateTime(SeaDateFrom.SelectedDate).ToString("yyyy-MM-dd") : ""));
    }
    protected void SeaDateTo_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        Response.Redirect("Management-OrdersHistory.aspx?&DateTo=" + (Convert.ToDateTime(SeaDateTo.SelectedDate).ToString("yyyy-MM-dd") != "0001-01-01" ? Convert.ToDateTime(SeaDateTo.SelectedDate).ToString("yyyy-MM-dd") : ""));
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.Text == "1")
        {
            Response.Redirect("Management-OrdersHistory.aspx?");
        }
        if (DropDownList2.Text == "3")
        {

        }
        else
        {
            Response.Redirect("Management-OrdersHistory.aspx?" + "&OS_ID=" + DropDownList2.Text);
        }
    }

}