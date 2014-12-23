using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class register : System.Web.UI.Page
{
    TTGB.BLL.t_Users bllUsers = new TTGB.BLL.t_Users();
    TTGB.Model.t_Users ModUsers = new TTGB.Model.t_Users();

    protected void Page_Load(object sender, EventArgs e)
    {
        //判断用户是否已登陆，如果登陆跳转首页
        if (Request.Cookies["UserId"] != null && LoginStatus())
        {
            Response.Redirect("Home.aspx");
        }

    }

    /// <summary>
    /// 检测用户状态
    /// </summary>
    public bool LoginStatus()
    {
        DataTable Login1 = bllUsers.GetList("[U_ID]='" + Request.Cookies["UserId"].Value + "'").Tables[0];
        if (Login1.Rows.Count > 0)//是否有数据，有数据则成功否则为游客
            return true;
        else
            return false;
    }


    /// <summary>
    /// 执行注册
    /// </summary>
    protected void Button1_Click(object sender, EventArgs e)
    {
        if(U_Name.Value.ToString() == "")
        {
            Wrong_Show("用户名未填写！");
        }
        else
        {
            string userid = U_Name.Value.ToString();
            DataTable Login1 = bllUsers.GetList("U_Name='" + userid + "'").Tables[0];
            if (Login1.Rows.Count > 0)//是否有数据，有数据则成功否则登陆失败提示用户名或密码错误
            {
                Wrong_Show("此用户名已被注册！");
            }
            else
            {
                if (U_Password1.Value.ToString() == "")
                    Wrong_Show("密码未填写！");
                else if (U_Password2.Value.ToString() != U_Password1.Value.ToString())
                    Wrong_Show("重复密码不吻合！");
                else if (U_Email.Value.ToString() == "")
                    Wrong_Show("E-mail地址未填写！");
                else
                {
                    ModUsers.U_Name = U_Name.Value.ToString();
                    ModUsers.U_Password = U_Password1.Value.ToString();
                    ModUsers.U_Email = U_Email.Value.ToString();
                    string SignUP_Date = DateTime.Now.ToString("yyyy-MM-dd");
                    ModUsers.U_SignUP = Convert.ToDateTime(SignUP_Date);
                    bllUsers.Add(ModUsers);
                    Response.Redirect("Home.aspx?register=0");//跳转页面
                }
            }
        }
    }

    public int Wrong_Show(string WrongText1)
    {
        WrongShow.Visible = true;
        WrongText.InnerText = WrongText1;
        return 0;
    }
}