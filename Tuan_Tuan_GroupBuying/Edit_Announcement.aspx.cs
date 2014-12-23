using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Edit_Announcement : System.Web.UI.Page
{
    TTGB.BLL.t_Announcement bllAnnouncement = new TTGB.BLL.t_Announcement();
    TTGB.Model.t_Announcement ModAnnouncement = new TTGB.Model.t_Announcement();
    TTGB.BLL.t_Administrators bllAdministrators = new TTGB.BLL.t_Administrators();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Edi"] != null)
        {
            Response.Write("<script>alert(\"公告修改成功!\");window.location.href=\"Management-Announcement.aspx\"</script>");
        }

        Announcement();
    }

    public void Announcement()
    {
        DataTable Login1 = bllAnnouncement.GetList("A_ID='" + Request.QueryString["An"].ToString() + "'").Tables[0];

        if (!Page.IsPostBack)
        {
            AddName.Text = Login1.Rows[0]["A_Name"].ToString();
            AddText.Text = Login1.Rows[0]["A_Text"].ToString();

        }
    
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        ModAnnouncement.A_Name = AddName.Text;
        ModAnnouncement.A_Text = AddText.Text;
        ModAnnouncement.A_ID = int.Parse(Request.QueryString["An"].ToString());
        ModAnnouncement.UA_ID = int.Parse(Request.Cookies["AdminId"].Value);
        string ReleaseDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        ModAnnouncement.A_ReleaseDate = Convert.ToDateTime(ReleaseDate);
        bllAnnouncement.Update(ModAnnouncement);
        Response.Redirect(Request.Url.ToString()+"&Edi=1");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Management-Announcement.aspx");
    }


}