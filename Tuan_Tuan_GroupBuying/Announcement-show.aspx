<%@ Page Title="" Language="C#" MasterPageFile="~/Nav-Master.master" AutoEventWireup="true" CodeFile="Announcement-show.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title >公告列表</title>
     <link href="CSS/buttons.css" rel="stylesheet" />
    <link href="CSS/Announcement-show.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <div class="All">
        <div class="Box_Text_Box">
            <i class="glyphicon glyphicon-bullhorn" style="top: 8px; left: 9px;"></i>
            <p class="Box_Text">公告</p>
        </div>
        <div class="row">
            <div class="box col-md-12">
                <div class="box-inner">
                    <div class="box-content">

                        <div class="well">
                            <div class="main3">
                                <div class="txt2" >
                                      <b><asp:Label id="AnName" runat="server" Text='<%#Eval ("A_Name") %>'></asp:Label></b>  
                                </div>
                                <div class="txt4" >
                                    <asp:Label id="ad_ID" runat="server" Text='<%#Eval ("UA_ID") %>'></asp:Label>
                                    <asp:Label id="An_ReleaseDate" runat="server" Text='<%#Eval ("A_ReleaseDate") %>'></asp:Label>
                                </div>
                               
                                <div class="txt3"  >
                                    <asp:Label id="An_Text" style="text-align :center ;" runat="server"  Text='<%#Eval ("A_Text") %>'></asp:Label>
                                </div>
                            </div>
                        </div>
                         <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>"></asp:SqlDataSource>
               
                 

                    </div>
            </div>
        </div>
        <!--/span-->
    </div>
    </div>

</asp:Content>

