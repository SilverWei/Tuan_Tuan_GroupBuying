using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;//Please add references


public partial class Management_GroupBuying : System.Web.UI.Page
{
    TTGB.BLL.t_GoodsSort1st bllt_GoodsSort1st = new TTGB.BLL.t_GoodsSort1st();
    TTGB.BLL.t_GroupBuying bllt_GroupBuying = new TTGB.BLL.t_GroupBuying();
    TTGB.BLL.t_GoodsSort2nd bllt_GoodsSort2nd = new TTGB.BLL.t_GoodsSort2nd();

    public string PageUP;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Ser"] != null)
        {
            GSBox.Visible = false;
            GSearch(GSDate(Request.QueryString["DateFrom"] != null ? Request.QueryString["DateFrom"].ToString() : "", Request.QueryString["DateTo"] != null ? Request.QueryString["DateTo"].ToString() : ""));
        }
        else
        {
            GS2Find(GSDate(Request.QueryString["DateFrom"] != null ? Request.QueryString["DateFrom"].ToString() : "", Request.QueryString["DateTo"] != null ? Request.QueryString["DateTo"].ToString() : ""));

        }

        //PageMain(Request.QueryString["GS2"].ToString());
    }


    public void GSearch(string SerDate)
    {
        GSBoxTab.Visible = false;
        GSBoxTab2.Visible = true;
        Label1.Text = Request.QueryString["Ser"].ToString();
        string OrderText = "";
        if (Request.QueryString["Wer"].ToString() == "0")
        {
            Label2.Text = "名称搜索：";
            OrderText = "GB_Name";
            DropDownList2Show(1);
        }
        else if (Request.QueryString["Wer"].ToString() == "1")
        {
            Label2.Text = "品牌搜索：";
            OrderText = "GB_Brand";
            DropDownList2Show(0);
            if (!Page.IsPostBack)
            {
                DropDownList2.Text = Request.QueryString["Ser"].ToString();
            }
        }
        else if (Request.QueryString["Wer"].ToString() == "3")
        {
            Label2.Text = "编号搜索：";
            OrderText = "GB_ID";
            DropDownList2Show(1);
        }
        if (!Page.IsPostBack)
        {
            DropDownList1.Text = Request.QueryString["Wer"].ToString();
            SeaBox.Text = Request.QueryString["Ser"].ToString();
        }
        SqlDataSource4.SelectCommand = "Select [t_GroupBuying].*,A.OrdersGoodsNumber From [t_GroupBuying] left join (select COUNT(*) as OrdersGoodsNumber,GB_ID from [t_OrdersGoods] group by GB_ID) as A on A.GB_ID = [t_GroupBuying].GB_ID Where [t_GroupBuying]." + OrderText + " Like '%" + Request.QueryString["Ser"].ToString() + "%' " + SerDate + " order by [t_GroupBuying].GB_ID desc";
    }


    /// <summary>
    /// 判断Url最终是否有GS2返回值
    /// </summary>
    public void GS2Find(string SerDate)
    {
        if (Request.QueryString["GS2"] == null)
        {
            if (Request.QueryString["GS1"] == null)
            {
                DataTable Login1 = bllt_GoodsSort1st.GetList("").Tables[0];
                Response.Redirect("Management-GroupBuying.aspx?GS1=" + Login1.Rows[0]["GS1_ID"].ToString());
            }
            else
            {
                DataTable Login1 = bllt_GoodsSort2nd.GetList("GS1_ID='" + Request.QueryString["GS1"].ToString() + "'").Tables[0];
                if (Login1.Rows.Count > 0)//是否有数据，有数据则跳转，没数据则弹到分类页面
                {
                    Response.Redirect("Management-GroupBuying.aspx?GS2=" + Login1.Rows[0]["GS2_ID"].ToString());
                }
                else
                {
                    Response.Redirect("Management_GoodsSort.aspx?GS1=" + Request.QueryString["GS1"].ToString() + "&GS2Null=1");
                }
            }
        }
        else
        {
            DataTable Login1 = bllt_GoodsSort2nd.GetList("GS2_ID='" + Request.QueryString["GS2"].ToString() + "'").Tables[0];
            DataTable Login2 = bllt_GoodsSort1st.GetList("GS1_ID='" + Login1.Rows[0]["GS1_ID"].ToString() + "'").Tables[0];
            //二级菜单查询
            SqlDataSource2.SelectCommand = "select * From [t_GoodsSort2nd] Where [GS1_ID]='" + Login2.Rows[0]["GS1_ID"].ToString() + "'";
            //标题显示一级菜单
            GS1_Text.Text = Login2.Rows[0]["GS1_Name"].ToString();
            //标题显示二级菜单
            GS2_Text.Text = Login1.Rows[0]["GS2_Name"].ToString();

        }
        SqlDataSource4.SelectCommand = "Select [t_GroupBuying].*,A.OrdersGoodsNumber From [t_GroupBuying] left join (select COUNT(*) as OrdersGoodsNumber,GB_ID from [t_OrdersGoods] group by GB_ID) as A on A.GB_ID = [t_GroupBuying].GB_ID Where [t_GroupBuying].GS2_ID='" + Request.QueryString["GS2"].ToString() + "' " + SerDate + " order by [t_GroupBuying].GB_ID desc";

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

    //protected void DelButton_Click(object sender, EventArgs e)
    //{
    //    bllt_GroupBuying.Delete(int.Parse(DelText.Text.ToString()));
    //    Response.Redirect(Request.Url.ToString());
    //}
    protected void DelButton1_Click(object sender, EventArgs e)
    {
        DbHelperSQL.ExecuteSql("DELETE FROM [t_GroupBuyingPicture] Where GB_ID='" + Request.Cookies["DelGB_ID"].Value.ToString() + "'");
        bllt_GroupBuying.Delete(int.Parse(Request.Cookies["DelGB_ID"].Value.ToString()));
        Response.Redirect(Request.Url.ToString());
    }

    protected void SeaBoxButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Management-GroupBuying.aspx?Ser=" + SeaBox.Text + "&Wer=" + DropDownList1.Text);

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.Text == "1")
        {
            DropDownList2Show(0);
            DataTable Login1 = DbHelperSQL.Query("Select GB_Brand From t_GroupBuying group by GB_Brand").Tables[0];
            Response.Redirect("Management-GroupBuying.aspx?Ser=" + Login1.Rows[0]["GB_Brand"].ToString() + "&Wer=" + DropDownList1.Text);

        }
        else if (DropDownList1.Text == "2")
        {
            DropDownList2Show(1);
        }
        else
        {
            DropDownList2Show(1);
        }
    }

    public void DropDownList2Show(int A)
    {
        if (A == 0)//品牌选择
        {
            SeaBox.Visible = false;
            SeaBoxButton.Visible = false;
            DropDownList2.Visible = true;

        }
        else if (A == 1)//输入文字
        {
            SeaBox.Visible = true;
            SeaBoxButton.Visible = true;
            DropDownList2.Visible = false;
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Management-GroupBuying.aspx?Ser=" + DropDownList2.Text + "&Wer=" + DropDownList1.Text);
    }
    protected void SeaDateFrom_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        Response.Redirect("Management-GroupBuying.aspx?" + UrlBack(1) + "&DateFrom=" + (Convert.ToDateTime(SeaDateFrom.SelectedDate).ToString("yyyy-MM-dd") != "0001-01-01" ? Convert.ToDateTime(SeaDateFrom.SelectedDate).ToString("yyyy-MM-dd") : ""));
    }
    protected void SeaDateTo_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        Response.Redirect("Management-GroupBuying.aspx?" + UrlBack(2) + "&DateTo=" + (Convert.ToDateTime(SeaDateTo.SelectedDate).ToString("yyyy-MM-dd") != "0001-01-01" ? Convert.ToDateTime(SeaDateTo.SelectedDate).ToString("yyyy-MM-dd") : ""));
    }

    public string UrlBack(int DateFlag)
    {
        string UrlBackText = "";
        if (Request.QueryString["Wer"] != null)
            UrlBackText += "&Wer=" + Request.QueryString["Wer"].ToString();
        if (Request.QueryString["Ser"] != null)
            UrlBackText += "&Ser=" + Request.QueryString["Ser"].ToString();
        if (Request.QueryString["GS2"] != null)
            UrlBackText += "&GS2=" + Request.QueryString["GS2"].ToString();
        if (Request.QueryString["DateFrom"] != null && DateFlag != 1)
            UrlBackText += "&DateFrom=" + Request.QueryString["DateFrom"].ToString();
        if (Request.QueryString["DateTo"] != null && DateFlag != 2)
            UrlBackText += "&DateTo=" + Request.QueryString["DateTo"].ToString();
        return UrlBackText;
    }

}