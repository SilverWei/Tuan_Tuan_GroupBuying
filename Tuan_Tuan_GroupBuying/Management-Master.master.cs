using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;//Please add references

public partial class Management_Master : System.Web.UI.MasterPage
{
    TTGB.BLL.t_Administrators bllUsers = new TTGB.BLL.t_Administrators();
    TTGB.Model.t_Administrators ModUsers = new TTGB.Model.t_Administrators();
    TTGB.BLL.t_GroupBuying bllGroupBuying = new TTGB.BLL.t_GroupBuying();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["AdminId"] == null)
        {
            Response.Redirect("Management-Landed.aspx");

        }
        Ad_Name.InnerText = Request.Cookies["AdminName"].Value;
        GroupBuyingDetection();
    }
  


    protected void Ad_Text_Click(object sender, EventArgs e)
    {
 HttpCookie myCookie = new HttpCookie("AdminId");
        myCookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(myCookie);


        Response.Redirect("Management-Landed.aspx");
    }


    /// <summary>
    /// 活动商品页状态检测
    /// </summary>
    public void GroupBuyingDetection()
    {
        DataTable Login1 = bllGroupBuying.GetList("[GB_EndDate] < GetDate() and GB_State = 1").Tables[0];
        for (int i = 0; i < Login1.Rows.Count; i++)
        {
            string SQLtext = "UPDATE [t_GroupBuying] SET [GB_State] = 0 WHERE GB_ID = " + Login1.Rows[i]["GB_ID"].ToString();
            DbHelperSQL.Query(SQLtext);
            SQLtext = "UPDATE [t_Orders] SET [OS_ID] = 8 where O_ID = (select O_ID from [t_OrdersGoods] where GB_ID = " + Login1.Rows[i]["GB_ID"].ToString() + ")";
            DbHelperSQL.Query(SQLtext);
        }
    }
}
