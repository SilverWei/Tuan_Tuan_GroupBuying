using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;//Please add references


public partial class Edit_GroupBuying : System.Web.UI.Page
{
    TTGB.BLL.t_GroupBuying bllGroupBuying = new TTGB.BLL.t_GroupBuying();
    TTGB.Model.t_GroupBuying ModGroupBuying = new TTGB.Model.t_GroupBuying();
    TTGB.BLL.t_GroupBuyingPicture bllt_GroupBuyingPicture = new TTGB.BLL.t_GroupBuyingPicture();
    TTGB.Model.t_GroupBuyingPicture Modt_GroupBuyingPicture = new TTGB.Model.t_GroupBuyingPicture();
    TTGB.BLL.t_GoodsSort2nd bllGoodsSort2nd = new TTGB.BLL.t_GoodsSort2nd();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["edit"] != null)
        {
            Response.Write("<script>alert(\"团购活动页修改成功!\");window.location.href=\"Management-GroupBuying.aspx?" +(Request.QueryString["GS2"]!=null?"&GS2="+Request.QueryString["GS2"].ToString():"") +(Request.QueryString["Ser"]!=null?"&Ser="+Request.QueryString["Ser"].ToString():"") +(Request.QueryString["Wer"]!=null?"&Wer="+Request.QueryString["Wer"].ToString():"") + "\"</script>");
        }
        else
        {
            GroupBuying();
        }
    }

    public void GroupBuying()
    {
        DataTable Login1 = bllGroupBuying.GetList("GB_ID='" + Request.QueryString["GB"].ToString() + "'").Tables[0];

        if (!Page.IsPostBack)
        {
            AddName.Text = Login1.Rows[0]["GB_Name"].ToString();
            AddBrand.Text = Login1.Rows[0]["GB_Brand"].ToString();
            AddMarketPrice.Text = Login1.Rows[0]["GB_MarketPrice"].ToString();
            AddGroupPrice.Text = Login1.Rows[0]["GB_GroupPrice"].ToString();
            TotleNumber.Text = Login1.Rows[0]["GB_TotalNumber"].ToString();
            AddText.Text = Login1.Rows[0]["GB_Text"].ToString();
            if (Login1.Rows[0]["GB_State"].ToString() == "True")
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
        string SQLtext = "UPDATE [t_GroupBuying] SET GB_Name = '" + AddName.Text + "',GB_Brand='" + AddBrand.Text + "',GS2_ID='" + G_GS2.Text + "',GB_MarketPrice='" + decimal.Parse(AddMarketPrice.Text) + "',GB_GroupPrice='" + decimal.Parse(AddMarketPrice.Text) + "',GB_TotalNumber='" + int.Parse(TotleNumber.Text) + "'," + PicUPTop() + " GB_Text='" + AddText.Text + "',GB_State='" + (AddState.Text == "1" ? "true" : "false") + "' WHERE GB_ID = " + Request.QueryString["GB"].ToString();
        DbHelperSQL.Query(SQLtext);
        PicUP();
        Response.Redirect("Edit_GroupBuying.aspx?"+(Request.QueryString["GS2"]!=null?"&GS2="+Request.QueryString["GS2"].ToString():"") +(Request.QueryString["Ser"]!=null?"&Ser="+Request.QueryString["Ser"].ToString():"") +(Request.QueryString["Wer"]!=null?"&Wer="+Request.QueryString["Wer"].ToString():"") +"&edit=1");
    }

    public void PicUP()
    {
        string GB_ID = Request.QueryString["GB"].ToString();
        if (exampleInputFile1.UploadedFiles.Count > 0 || exampleInputFile1.UploadedFiles.Count < 6)
        {
            DbHelperSQL.ExecuteSql("DELETE FROM t_GroupBuyingPicture Where GB_ID='" + GB_ID + "'");
            Telerik.Web.UI.RadAsyncUpload upload = exampleInputFile1;
            foreach (Telerik.Web.UI.UploadedFile file in upload.UploadedFiles)
            {
                Modt_GroupBuyingPicture = new TTGB.Model.t_GroupBuyingPicture();
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + file.GetName() + file.GetExtension();   //以时间格式重命名  
                string folderpath = "/GoodsPicture/";
                string downpath = folderpath + fileName;
                string filePath = Server.MapPath(folderpath) + fileName;    //放入服务器路径 
                file.SaveAs(filePath);
                Modt_GroupBuyingPicture.GBP_Url = downpath;
                Modt_GroupBuyingPicture.GB_ID = int.Parse(GB_ID);
                bllt_GroupBuyingPicture.Add(Modt_GroupBuyingPicture);
            }
        }
    }

    public string PicUPTop()
    {
        if (exampleInputFile2.UploadedFiles.Count > 0)
        {
            Telerik.Web.UI.RadAsyncUpload upload = exampleInputFile2;
            foreach (Telerik.Web.UI.UploadedFile file in upload.UploadedFiles)
            {
                Modt_GroupBuyingPicture = new TTGB.Model.t_GroupBuyingPicture();
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + file.GetName() + file.GetExtension();   //以时间格式重命名  
                string folderpath = "/GoodsPicture/";
                string downpath = folderpath + fileName;
                string filePath = Server.MapPath(folderpath) + fileName;    //放入服务器路径 
                file.SaveAs(filePath);
                Modt_GroupBuyingPicture.GBP_Url = downpath;
                return "GB_PictureUrl='" + downpath + "' , ";
            }
        }
        return "";

    }

    protected void G_GS1_SelectedIndexChanged(object sender, EventArgs e)
    {
        G_GS2.Visible = true;
        SqlDataSource2.SelectCommand = "select * From [t_GoodsSort2nd] Where GS1_ID = " + int.Parse(G_GS1.Text);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Management-GroupBuying.aspx?"+(Request.QueryString["GS2"]!=null?"&GS2="+Request.QueryString["GS2"].ToString():"") +(Request.QueryString["Ser"]!=null?"&Ser="+Request.QueryString["Ser"].ToString():"") +(Request.QueryString["Wer"]!=null?"&Wer="+Request.QueryString["Wer"].ToString():""));
    }
}