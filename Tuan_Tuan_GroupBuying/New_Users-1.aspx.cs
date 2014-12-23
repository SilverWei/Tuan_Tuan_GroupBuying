using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class New_Users_1 : System.Web.UI.Page
{
    TTGB.BLL.t_Administrators bllUsers = new TTGB.BLL.t_Administrators();
    TTGB.Model.t_Administrators ModUsers = new TTGB.Model.t_Administrators();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["New"] != null)
        {
            Response.Write("<script>alert(\"新建管理员成功!\");window.location.href=\"Management-Users-1.aspx\"</script>");
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (UA_Name_Text.Value.ToString() == "")
        {
             Label1.Text ="管理员用户名未填写";

        }
        else
        {
            if (UA_Password1.Value.ToString() == "")
                 Label1.Text ="密码未填写";
            else if (UA_Password2.Value.ToString() != UA_Password1.Value.ToString())
                 Label1.Text ="两次输入的密码不一样";
            else
            {
                ModUsers.UA_Name= UA_Name_Text.Value.ToString();
                ModUsers.UA_Password = UA_Password1.Value.ToString();
                string SignUP_Date = DateTime.Now.ToString("yyyy-MM-dd");
                ModUsers.UA_SignUP = Convert.ToDateTime(SignUP_Date );
                bllUsers.Add(ModUsers );
               Label1.Text ="成功";
               Response.Redirect("New_Users-1.aspx?New=1");
            }
        }

    }

  
}