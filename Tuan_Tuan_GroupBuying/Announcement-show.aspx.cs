using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



public partial class _Default : System.Web.UI.Page
{
    TTGB.BLL.t_Announcement bllt_Announcement = new TTGB.BLL.t_Announcement();
    TTGB.BLL.t_Administrators bllt_Administrators = new TTGB.BLL.t_Administrators();

    protected void Page_Load(object sender, EventArgs e)
    {
        Announcement();
       
        //if (!Page.IsPostBack)
        //{
        //    DataTable Login1 = bllt_Announcement.GetList("").Tables[0];
        //    if (Login1.Rows.Count > 0)
        //    {
        //        AnName.Text = Login1.Rows[0]["A_Name"].ToString();
        //        ad_ID.Text = Login1.Rows[0]["UA_ID"].ToString();
        //        An_ReleaseDate.Text = Login1.Rows[0]["A_ReleaseDate"].ToString();
        //        An_Text.Text = Login1.Rows[0]["A_Text"].ToString();
        //        Response.Redirect("Announcement-show.aspx?An=" + Login1.Rows[0]["A_ID"].ToString());
        //    }
           
        //}
       



    }

    public void Announcement()
    {
        DataTable Login1 = bllt_Announcement.GetList("A_ID='" + Request.QueryString["An"].ToString() + "'").Tables[0];
       
        if (!Page.IsPostBack)
        {
            AnName.Text = Login1.Rows[0]["A_Name"].ToString();

            DataTable Login2 = bllt_Administrators.GetList("UA_ID='" + Login1.Rows[0]["UA_ID"].ToString() + "'").Tables[0];
            ad_ID.Text = "发布人：" + Login2.Rows[0]["UA_Name"].ToString();
            An_ReleaseDate.Text = Convert.ToDateTime(Login1.Rows[0]["A_ReleaseDate"].ToString()).ToString("yyyy年MM月dd日 HH:mm:ss");
            An_Text.Text = Login1.Rows[0]["A_Text"].ToString();
           
        }

    
    }











}
