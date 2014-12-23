using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using Maticsoft.DBUtility;//Please add references


public partial class Edit_Goods : System.Web.UI.Page
{
    TTGB.BLL.t_Goods bllGoods = new TTGB.BLL.t_Goods();
    TTGB.Model.t_Goods ModGoods = new TTGB.Model.t_Goods();
    TTGB.BLL.t_GoodsSort2nd bllGoodsSort2nd = new TTGB.BLL.t_GoodsSort2nd();
    TTGB.BLL.t_GoodsPicture bllt_GoodsPicture = new TTGB.BLL.t_GoodsPicture();
    TTGB.Model.t_GoodsPicture Modt_GoodsPicture = new TTGB.Model.t_GoodsPicture();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["edit"] != null)
        {
            Response.Write("<script>alert(\"商品页修改成功!\");window.location.href=\"Management-Goods.aspx?" +(Request.QueryString["GS2"]!=null?"&GS2="+Request.QueryString["GS2"].ToString():"") +(Request.QueryString["Ser"]!=null?"&Ser="+Request.QueryString["Ser"].ToString():"") +(Request.QueryString["Wer"]!=null?"&Wer="+Request.QueryString["Wer"].ToString():"") + "\"</script>");
        }
        else
        {
            Goods();
        }

    }

    public void Goods()
    {
        DataTable Login1 = bllGoods.GetList("G_ID='" + Request.QueryString["Go"].ToString() + "'").Tables[0];

        if (!Page.IsPostBack)
        {
            AddName.Text= Login1.Rows[0]["G_Name"].ToString();
            AddBrand.Text = Login1.Rows[0]["G_Brand"].ToString();
            AddMarketPrice.Text = Login1.Rows[0]["G_MarketPrice"].ToString();
            AddUserPrice.Text = Login1.Rows[0]["G_UserPrice"].ToString();
            AddAmount.Text = Login1.Rows[0]["G_Amount"].ToString();
            AddText.Text = Login1.Rows[0]["G_Text"].ToString();
            if (Login1.Rows[0]["G_State"].ToString() == "True")
            {
                AddState.Text = "1";
            }
            else
            {
                AddState.Text = "0";
            }
            DataTable Login2 = bllGoodsSort2nd.GetList("GS2_ID = " + Login1.Rows[0]["GS2_ID"].ToString()).Tables[0];
            G_GS1.Text = Login2.Rows[0]["GS1_ID"].ToString();
            SqlDataSource2.SelectCommand = "select * From [t_GoodsSort2nd] Where GS1_ID = " + Login2.Rows[0]["GS1_ID"].ToString();
            G_GS2.Text = Login1.Rows[0]["GS2_ID"].ToString();

        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string SQLtext = "UPDATE [t_Goods] SET G_Name = '" + AddName.Text + "',G_Brand='" + AddBrand.Text + "',GS2_ID='" + G_GS2.Text + "',G_MarketPrice='" + decimal.Parse(AddMarketPrice.Text) + "',G_UserPrice='" + decimal.Parse(AddUserPrice.Text) + "',G_Amount='" + int.Parse(AddAmount.Text) + "',G_Text='" + AddText.Text + "',G_State='" + (AddState.Text == "1" ? "true" : "false") + "' WHERE G_ID = " + Request.QueryString["Go"].ToString();
        DbHelperSQL.Query(SQLtext);
        PicUP();
        Response.Redirect("Edit_Goods.aspx?"+(Request.QueryString["GS2"]!=null?"&GS2="+Request.QueryString["GS2"].ToString():"") +(Request.QueryString["Ser"]!=null?"&Ser="+Request.QueryString["Ser"].ToString():"") +(Request.QueryString["Wer"]!=null?"&Wer="+Request.QueryString["Wer"].ToString():"") +"&edit=1");
    }

    public void PicUP()
    {
        string G_ID = Request.QueryString["Go"].ToString();
        if (exampleInputFile1.UploadedFiles.Count > 0 && exampleInputFile1.UploadedFiles.Count < 6)
        {
            DbHelperSQL.ExecuteSql("DELETE FROM t_GoodsPicture Where G_ID='" + G_ID + "'");
            Telerik.Web.UI.RadAsyncUpload upload = exampleInputFile1;
            foreach (Telerik.Web.UI.UploadedFile file in upload.UploadedFiles)
            {
                Modt_GoodsPicture = new TTGB.Model.t_GoodsPicture();
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + file.GetName() + file.GetExtension();   //以时间格式重命名  
                string folderpath = "/GoodsPicture/";
                string downpath = folderpath + fileName;
                string filePath = Server.MapPath(folderpath) + fileName;    //放入服务器路径 
                file.SaveAs(filePath);
                Modt_GoodsPicture.GP_Url = downpath;
                Modt_GoodsPicture.G_ID = int.Parse(G_ID);
                bllt_GoodsPicture.Add(Modt_GoodsPicture);
            }
        }
    }

    protected void G_GS1_SelectedIndexChanged(object sender, EventArgs e)
    {
        G_GS2.Visible = true;
        SqlDataSource2.SelectCommand = "select * From [t_GoodsSort2nd] Where GS1_ID = " + int.Parse(G_GS1.Text);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Management-Goods.aspx?"+(Request.QueryString["GS2"]!=null?"&GS2="+Request.QueryString["GS2"].ToString():"") +(Request.QueryString["Ser"]!=null?"&Ser="+Request.QueryString["Ser"].ToString():"") +(Request.QueryString["Wer"]!=null?"&Wer="+Request.QueryString["Wer"].ToString():""));
    }
}