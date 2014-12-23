using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Management_GoodsSort : System.Web.UI.Page
{
    TTGB.BLL.t_GoodsSort1st bllGoodsSort1st = new TTGB.BLL.t_GoodsSort1st();
    TTGB.Model.t_GoodsSort1st ModGoodsSort1st = new TTGB.Model.t_GoodsSort1st();
    TTGB.BLL.t_GoodsSort2nd bllGoodsSort2nd = new TTGB.BLL.t_GoodsSort2nd();
    TTGB.Model.t_GoodsSort2nd ModGoodsSort2nd = new TTGB.Model.t_GoodsSort2nd();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Del"] != null)
        {
            if (Request.QueryString["Del"].ToString() == "0")
            {
                Response.Write("<script>alert(\"该分类删除成功!\");window.location.href=\"Management_GoodsSort.aspx?GS1=" + Request.QueryString["GS1"].ToString() + "\"</script>");
            }
            else if (Request.QueryString["Del"].ToString() == "1")
            {
                Response.Write("<script>alert(\"错误！无法删除该分类，请确认是否有相关子信息是否被清理干净!\");window.location.href=\"Management_GoodsSort.aspx?GS1=" + Request.QueryString["GS1"].ToString() + "\"</script>");
            }
        }
        else
        {
            if (Request.QueryString["New"] != null)
            {
                Response.Write("<script>alert(\"创建该分类成功!\");window.location.href=\"Management_GoodsSort.aspx?GS1=" + Request.QueryString["GS1"].ToString() + "\"</script>");
            }

            if (Request.QueryString["GS2Null"] != null)
            {
                Response.Write("<script>alert(\"未有相关子分类，将跳到物品分类管理页面!\");window.location.href=\"Management_GoodsSort.aspx?GS1=" + Request.QueryString["GS1"].ToString() + "\"</script>");
            }
            GS2_Show();
        }
    }

    /// <summary>
    /// 一级分类添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GS1_Add_Button_Click(object sender, EventArgs e)
    {
        if (GS1_Add.Text.ToString() == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('请输入一级分类名称')", true);
        }
        else
        {
            DataTable SQLText1 = bllGoodsSort1st.GetList("[GS1_Name]='" + GS1_Add.Text.ToString() + "'").Tables[0];
            if (SQLText1.Rows.Count > 0)//是否有数据，有数据则不能增添一级分类
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('该分类已有！')", true);
            }
            else
            {
                ModGoodsSort1st.GS1_Name = GS1_Add.Text.ToString();
                bllGoodsSort1st.Add(ModGoodsSort1st);
                Response.Redirect(UrlText());
            }

        }
    }

    public string UrlText()
    {
        return "Management_GoodsSort.aspx?GS1=" + Request.QueryString["GS1"].ToString() + "&New=1";
    }

    public void GS2_Show()
    {
        if (Request.QueryString["GS1"] == null)
        {
            DataTable SQLText3 = bllGoodsSort1st.GetList("").Tables[0];

            Response.Redirect("Management_GoodsSort.aspx?GS1=" + SQLText3.Rows[0]["GS1_ID"].ToString());
        }
        string SQLText1 = "select * From [t_GoodsSort2nd] Where GS1_ID=" + Request.QueryString["GS1"].ToString();
        SqlDataSource2.SelectCommand = SQLText1;
        DataTable SQLText2 = bllGoodsSort1st.GetList("GS1_ID='" + Request.QueryString["GS1"].ToString() + "'").Tables[0];
        if (SQLText2.Rows.Count > 0)
        {
            GS2_Box.Text = SQLText2.Rows[0]["GS1_Name"].ToString();
        }
        else
        {
            Response.Redirect("Management_GoodsSort.aspx");
        }
    }

    /// <summary>
    /// 二级分类添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GS2_Add_Button_Click(object sender, EventArgs e)
    {
        if (GS2_Add.Text.ToString() == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('请输入二级分类名称')", true);
        }
        else
        {
            DataTable SQLText1 = bllGoodsSort2nd.GetList("[GS2_Name]='" + GS2_Add.Text.ToString() + "'").Tables[0];
            if (SQLText1.Rows.Count > 0)//是否有数据，有数据则不能增添一级分类
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('该分类已有！')", true);
            }
            else
            {
                ModGoodsSort2nd.GS2_Name = GS2_Add.Text.ToString();
                ModGoodsSort2nd.GS1_ID = int.Parse(Request.QueryString["GS1"].ToString());
                bllGoodsSort2nd.Add(ModGoodsSort2nd);
                Response.Redirect(UrlText());
            }

        }
    }
    protected void GS2Del_Click(object sender, EventArgs e)
    {
        try
        {
            bllGoodsSort2nd.Delete(int.Parse(((LinkButton)sender).CommandArgument.ToString()));
            Response.Redirect(Request.Url.ToString() + "&Del=0", false);
        }
        catch
        {
            Response.Redirect(Request.Url.ToString() + "&Del=1");
        }
    }
    protected void GS1Del_Click(object sender, EventArgs e)
    {
        try
        {
            bllGoodsSort1st.Delete(int.Parse(((LinkButton)sender).CommandArgument.ToString()));
            Response.Redirect(Request.Url.ToString() + "&Del=0", false);
        }
        catch
        {
            Response.Redirect(Request.Url.ToString() + "&Del=1");
        }
    }

    /// <summary>
    /// 编辑分类
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RenamingSave1_Click(object sender, EventArgs e)
    {
        if (RenamingTextBox.Text.ToString() == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('输入内容不能为空！')", true);
        }
        else
        {
            if (Request.Cookies["RenamingText3"].Value.ToString() == "1")
            {
                DataTable SQLText1 = bllGoodsSort1st.GetList("[GS1_Name]='" + RenamingTextBox.Text.ToString() + "'").Tables[0];
                if (SQLText1.Rows.Count > 0)//是否有数据，有数据则不能增添一级分类
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('该分类已有！')", true);
                }
                else//更新一级分类
                {
                    ModGoodsSort1st.GS1_Name = RenamingTextBox.Text.ToString();
                    ModGoodsSort1st.GS1_ID = int.Parse(Request.Cookies["RenamingText2"].Value.ToString());
                    bllGoodsSort1st.Update(ModGoodsSort1st);
                    Response.Redirect(Request.Url.ToString());
                }
            }
            else
            {
                DataTable SQLText1 = bllGoodsSort2nd.GetList("[GS2_Name]='" + RenamingTextBox.Text.ToString() + "'").Tables[0];
                if (SQLText1.Rows.Count > 0)//是否有数据，有数据则不能增添一级分类
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('该分类已有！')", true);
                }
                else//更新一级分类
                {
                    ModGoodsSort2nd.GS2_Name = RenamingTextBox.Text.ToString();
                    ModGoodsSort2nd.GS2_ID = int.Parse(Request.Cookies["RenamingText2"].Value.ToString());
                    ModGoodsSort2nd.GS1_ID = int.Parse(Request.QueryString["GS1"].ToString());
                    bllGoodsSort2nd.Update(ModGoodsSort2nd);
                    Response.Redirect(Request.Url.ToString());
                }
            }
        }
    }
}