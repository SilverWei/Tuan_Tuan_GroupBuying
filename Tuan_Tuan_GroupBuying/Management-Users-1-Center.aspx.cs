using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;//Please add references

public partial class Management_Users_1_Center : System.Web.UI.Page
{
    TTGB.BLL.t_Administrators bllt_Administrators = new TTGB.BLL.t_Administrators();
    TTGB.Model.t_Administrators Modt_Administrators = new TTGB.Model.t_Administrators();

    string UA_NameBack;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["err"] != null)
        {
            Response.Write("<script>alert(\"无法删除，此账号正在使用中!\");window.location.href=\"Management-Users-1-Center.aspx?UA=" + Request.QueryString["UA"].ToString() + "\"</script>");
        }
        if (Request.QueryString["edit"] != null)
        {
            Response.Write("<script>alert(\"管理员修改成功!\");window.location.href=\"Management-Users-1.aspx\"</script>");
        }


        ModifyUser();
    }

    /// <summary>
    /// 读取原来用户信息
    /// </summary>
    public void ModifyUser()
    {
        DataTable UserSelect = bllt_Administrators.GetList("UA_ID='" + Request.QueryString["UA"].ToString() + "'").Tables[0];
        if (!Page.IsPostBack)
        {
            U_Name.Text = UA_NameBack = UserSelect.Rows[0]["UA_Name"].ToString();
            U_RealName.Text = UserSelect.Rows[0]["UA_RealName"].ToString();
            U_Phone.Text = UserSelect.Rows[0]["UA_Phone"].ToString();
            U_Email.Text = UserSelect.Rows[0]["UA_Email"].ToString();
            U_Sex.Text = UserSelect.Rows[0]["UA_Sex"].ToString();
            UA_SignUP.Value = UserSelect.Rows[0]["UA_SignUP"].ToString();
            if (UserSelect.Rows[0]["UA_Birthday"].ToString() != "")
                RadDatePicker1.SelectedDate = Convert.ToDateTime(UserSelect.Rows[0]["UA_Birthday"].ToString());
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (NewU_Password1.Text != NewU_Password2.Text)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('重复密码有误！！')", true);
        }
        else
        {



            DataTable SelText1 = bllt_Administrators.GetList("UA_Name='" + UA_NameBack + "'").Tables[0];
            if (SelText1.Rows.Count > 0 && U_Name.Text != UA_NameBack)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('新用户名已被注册过！！')", true);
            }
            else
            {
                Modt_Administrators.UA_Name = U_Name.Text;
                Modt_Administrators.UA_RealName = U_RealName.Text;
                if (NewU_Password1.Text != "")
                {
                    Modt_Administrators.UA_Password = NewU_Password1.Text;
                }
                Modt_Administrators.UA_Sex = U_Sex.Text == "False" ? false : true;
                Modt_Administrators.UA_Birthday = RadDatePicker1.SelectedDate;
                Modt_Administrators.UA_Email = U_Email.Text;
                Modt_Administrators.UA_Phone = U_Phone.Text;
                Modt_Administrators.UA_SignUP = Convert.ToDateTime(UA_SignUP.Value);
                Modt_Administrators.UA_ID = int.Parse(Request.QueryString["UA"].ToString());
                bllt_Administrators.Update(Modt_Administrators);
                if (Request.Cookies["AdminId"].Value == Request.QueryString["UA"].ToString())
                    Response.Cookies["AdminName"].Value = HttpUtility.UrlEncode(U_Name.Text);
                Response.Redirect(Request.Url.ToString() + "&edit=1");
            }
        }
    }


    protected void DelButton1_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["UA"].ToString() != Request.Cookies["AdminId"].Value)
        {
            bllt_Administrators.Delete(int.Parse(Request.QueryString["UA"].ToString()));
            Response.Redirect("Management-Users-1.aspx?Del=1");

        }
        else
        {
            Response.Redirect(Request.Url.ToString() + "&err=1");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Management-Users-1.aspx");
    }
}