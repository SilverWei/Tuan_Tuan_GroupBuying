using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Management_Master : System.Web.UI.MasterPage
{
    TTGB.BLL.t_Administrators bllUsers = new TTGB.BLL.t_Administrators();
    TTGB.Model.t_Administrators ModUsers = new TTGB.Model.t_Administrators();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["AdminId"] == null)
        {
            Response.Redirect("Management-Landed.aspx");

        }
        Ad_Name.InnerText = Request.Cookies["AdminName"].Value;

    }
  


    protected void Ad_Text_Click(object sender, EventArgs e)
    {
 HttpCookie myCookie = new HttpCookie("AdminId");
        myCookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(myCookie);


        Response.Redirect("Management-Landed.aspx");
    }
}
