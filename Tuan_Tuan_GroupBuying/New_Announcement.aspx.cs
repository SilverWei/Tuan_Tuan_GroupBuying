using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class New_Announcement : System.Web.UI.Page
{
    TTGB.BLL.t_Announcement bllUsers = new TTGB.BLL.t_Announcement();
    TTGB.Model.t_Announcement ModUsers = new TTGB.Model.t_Announcement();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["new"] != null)
        {
            Response.Write("<script>alert(\"新建公告页成功!\");window.location.href=\"Management-Announcement.aspx\"</script>");
        }
    }

   
    protected void Button2_Click1(object sender, EventArgs e)
    {
        if (A_Name.Value.ToString() == "" && A_Text.Value.ToString() == "")
        {
            Label1.Text = "请填写完整";
            
        }
        else
        {
            string A_id = A_Name.Value.ToString();
            DataTable Login1 = bllUsers.GetList(" A_Name='" + A_id + "' ").Tables[0];
            if (Login1.Rows.Count > 0)
            {
               Label1.Text = "此公告已存在";
            }
            else
            {
                ModUsers.A_Name = A_Name.Value.ToString();
                ModUsers.A_Text = A_Text.Value.ToString();
                ModUsers.UA_ID = int.Parse(Request.Cookies["AdminId"].Value);
                string ReleaseDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ModUsers.A_ReleaseDate = Convert.ToDateTime(ReleaseDate);
                bllUsers.Add(ModUsers);
                Label1.Text = "成功";
                Response.Redirect(Request.Url.ToString() + "?new=1");
            }


        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Management-Announcement.aspx");
    }

   
}