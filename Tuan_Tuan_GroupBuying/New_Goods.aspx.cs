using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls; 

public partial class New_Goods : System.Web.UI.Page
{
    TTGB.BLL.t_Goods bllgoods = new TTGB.BLL.t_Goods();
    TTGB.Model.t_Goods Modgoods = new TTGB.Model.t_Goods();
    TTGB.BLL.t_GoodsPicture bllt_GoodsPicture = new TTGB.BLL.t_GoodsPicture();
    TTGB.Model.t_GoodsPicture Modt_GoodsPicture = new TTGB.Model.t_GoodsPicture();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["new"] != null)
        {
            Response.Write("<script>alert(\"新建商品页成功!\");window.location.href=\"Management-Goods.aspx\"</script>");
        }
    }

 
    protected void LinkButton1_Click(object sender, EventArgs e)
    {


        if (G_Name.Value.ToString() == "" && G_Brand.Value.ToString() == "" && G_UserPrice.Value.ToString() == "" && G_MarketPrice.Value.ToString() == "" && G_Amount.Value.ToString() == "")
        {
            Label1.Text = "请填写完整";

        }
        else
        {
            string LoginG_Name = G_Name.Value.ToString();
            DataTable Login1 = bllgoods.GetList(" G_Name='" + LoginG_Name + "' ").Tables[0];
            if (Login1.Rows.Count > 0)
            {
                Label1.Text = "此内容已存在";
            }
            else
            {
                Modgoods.G_Name = G_Name.Value.ToString();
                Modgoods.G_Brand = G_Brand.Value.ToString();
                Modgoods.GS2_ID = int.Parse(G_GS2.Text);
                Modgoods.G_State = true;
                Modgoods.G_MarketPrice = decimal.Parse(G_MarketPrice.Value.ToString());
                Modgoods.G_UserPrice = decimal.Parse(G_UserPrice.Value.ToString());
                Modgoods.G_Amount = int.Parse(G_Amount.Value.ToString());
                Modgoods.G_Text = G_Text.Value.ToString();
               
                string ReleaseDate = DateTime.Now.ToString("yyyy-MM-dd");
                Modgoods.G_OfferDate = Convert.ToDateTime(ReleaseDate);
                bllgoods.Add(Modgoods);
                PicUP();
                Label1.Text = "成功";
                Response.Redirect("Management-Goods.aspx?new=1");

            }


        }
    }

    public void PicUP()
    {
        DataTable Login1 = bllgoods.GetList(" G_Name='" + G_Name.Value.ToString() + "' ").Tables[0];
        string G_ID = Login1.Rows[0]["G_ID"].ToString();
        if (exampleInputFile1.UploadedFiles.Count > 0 || exampleInputFile1.UploadedFiles.Count < 6)
        {
            Telerik.Web.UI.RadAsyncUpload upload = exampleInputFile1;
            foreach (Telerik.Web.UI.UploadedFile file in upload.UploadedFiles)
            {
                Modt_GoodsPicture = new TTGB.Model.t_GoodsPicture();
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") +file.GetName() + file.GetExtension();   //以时间格式重命名  
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
        Response.Redirect(Request.QueryString["Url"].ToString());
    }
}