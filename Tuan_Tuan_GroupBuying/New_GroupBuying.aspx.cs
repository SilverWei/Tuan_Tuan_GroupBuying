using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls; 


public partial class New_GroupBuying : System.Web.UI.Page
{

    TTGB.BLL.t_GroupBuying bllGroupBuying = new TTGB.BLL.t_GroupBuying();
    TTGB.Model.t_GroupBuying ModGroupBuying = new TTGB.Model.t_GroupBuying();
    TTGB.BLL.t_GroupBuyingPicture bllt_GroupBuyingPicture = new TTGB.BLL.t_GroupBuyingPicture();
    TTGB.Model.t_GroupBuyingPicture Modt_GroupBuyingPicture = new TTGB.Model.t_GroupBuyingPicture();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["new"] != null)
        {
            Response.Write("<script>alert(\"新建团购活动页成功!\");window.location.href=\"Management-GroupBuying.aspx\"</script>");
        }
    }




    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (GB_Name.Value.ToString() == "" && GB_Brand.Value.ToString() == "" && GB_MarketPrice.Value.ToString() == "" && GB_GroupPrice.Value.ToString() == "" && GB_TotalNumber.Value.ToString() == "")
        {
            Label1.Text = "请填写完整";

        }
        else
        {
            string GB_id = GB_Name.Value.ToString();
            DataTable Login1 = bllGroupBuying.GetList(" GB_Name='" + GB_id + "' ").Tables[0];
            if (Login1.Rows.Count > 0)
            {
                Label1.Text = "此内容已存在";
            }
            else
            {
                ModGroupBuying.GB_Name = GB_Name.Value.ToString();
                ModGroupBuying.GB_Brand = GB_Brand.Value.ToString();
                ModGroupBuying.GS2_ID = int.Parse(G_GS2.Text);

                ModGroupBuying.GB_MarketPrice = decimal.Parse(GB_MarketPrice.Value.ToString());
                ModGroupBuying.GB_GroupPrice = decimal.Parse(GB_GroupPrice.Value.ToString());
                ModGroupBuying.GB_Text = GB_Text.Value.ToString();
                ModGroupBuying.GB_State = true;

                string ReleaseDate = DateTime.Now.ToString("yyyy-MM-dd");
                ModGroupBuying.GB_TotalNumber = int.Parse(GB_TotalNumber.Value.ToString());
                ModGroupBuying.GB_OfferDate = Convert.ToDateTime(ReleaseDate);
                ModGroupBuying.GB_PictureUrl = PicUPTop();
                ModGroupBuying.GB_EndDate = RadDatePicker1.SelectedDate;
                bllGroupBuying.Add(ModGroupBuying);
                PicUP();
                Label1.Text = "成功";
                Response.Redirect("New_GroupBuying.aspx?new=1");
            }


        }
    }


    public void PicUP()
    {
        DataTable Login1 = bllGroupBuying.GetList(" GB_Name='" + GB_Name.Value.ToString() + "' ").Tables[0];
        string GB_ID = Login1.Rows[0]["GB_ID"].ToString();
        if (exampleInputFile1.UploadedFiles.Count > 0 || exampleInputFile1.UploadedFiles.Count <6)
        {
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
                return downpath;
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
        Response.Redirect(Request.QueryString["Url"].ToString());
    }
}