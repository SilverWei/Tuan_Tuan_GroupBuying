using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// 无法更新
/// </summary>


public partial class Users_Center_Modify : System.Web.UI.Page
{
    TTGB.BLL.t_Users bllUsers = new TTGB.BLL.t_Users();
    TTGB.Model.t_Users ModUsers = new TTGB.Model.t_Users();

    protected void Page_Load(object sender, EventArgs e)
    {
        //判断用户是否已登陆，如果没登陆跳转登陆页面
        if (Request.Cookies["UserId"] == null)
        {
            Response.Redirect("Landed.aspx");
        }

        if (Request.QueryString["Modify"] != null)
        {
            Response.Write("<script>alert(\"修改成功!\");window.location.href=\"Users-Center-Modify.aspx\"</script>");
        }
        ModifyUser();
    }

    /// <summary>
    /// 读取原来用户信息
    /// </summary>
    public void ModifyUser()
    {
        DataTable UserSelect = bllUsers.GetList("U_ID='" + Request.Cookies["UserId"].Value + "'").Tables[0];
        if (!Page.IsPostBack)
        {
            U_Name.Text = UserSelect.Rows[0]["U_Name"].ToString();
            U_RealName.Text = UserSelect.Rows[0]["U_RealName"].ToString();
            U_Phone.Text = UserSelect.Rows[0]["U_Phone"].ToString();
            U_Email.Text = UserSelect.Rows[0]["U_Email"].ToString();
            U_Sex.Text = UserSelect.Rows[0]["U_Sex"].ToString();
            UA_SignUP.Value = UserSelect.Rows[0]["U_SignUP"].ToString();

            if (UserSelect.Rows[0]["U_Birthday"].ToString() != "")
                RadDatePicker1.SelectedDate = Convert.ToDateTime(UserSelect.Rows[0]["U_Birthday"].ToString());
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (U_Password.Value != "")
        {
            if (NewU_Password1.Value != NewU_Password2.Value)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('重复密码有误！！')", true);
            }
            else
            {



                DataTable Login1 = bllUsers.GetList("U_ID='" + Request.Cookies["UserId"].Value + "' and U_Password='" + U_Password.Value + "'").Tables[0];
                if (Login1.Rows.Count > 0)//是否有数据，有数据则成功否则登陆失败提示用户名或密码错误
                {
                    DataTable SelText1 = bllUsers.GetList("U_Name='" + U_Name.Text + "'").Tables[0];
                    if (SelText1.Rows.Count > 0 && U_Name.Text != Request.Cookies["UserName"].Value)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('新用户名已被注册过！！')", true);
                    }
                    else
                    {
                        ModUsers.U_Name = U_Name.Text;
                        ModUsers.U_RealName = U_RealName.Text;
                        if (NewU_Password1.Value != "")
                        {
                            ModUsers.U_Password = NewU_Password1.Value;
                        }
                        ModUsers.U_Sex = U_Sex.Text == "False" ? false : true;
                        ModUsers.U_Birthday = RadDatePicker1.SelectedDate;
                        ModUsers.U_Email = U_Email.Text;
                        ModUsers.U_Phone = U_Phone.Text;
                        ModUsers.U_ID = int.Parse(Request.Cookies["UserId"].Value);
                        ModUsers.U_SignUP = Convert.ToDateTime(UA_SignUP.Value);

                        bllUsers.Update(ModUsers);
                        Response.Cookies["UserName"].Value = HttpUtility.UrlEncode(U_Name.Text);
                        Response.Redirect(Request.Url.ToString() + "?Modify=1");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('原密码有误！！')", true);
                }

            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('原密码未填写！！')", true);
        }
    }
}