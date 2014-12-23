<%@ Page Title="" Language="C#" MasterPageFile="~/Management-Master.master" AutoEventWireup="true" CodeFile="Edit_Announcement.aspx.cs" Inherits="Edit_Announcement" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>编辑公告</title>
    <link href="CSS/New_Announcement.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <div class="Main">

        <div class="row">
            <div class="box col-md-12">
                <div class="box-inner">
                    <div class="box-header well" data-original-title="">
                        <h2><i class="glyphicon glyphicon-comment"></i>编辑公告</h2>
                    </div>
                    <div class="row" style="margin: 0;">
                        <div class="box col-md-12">
                                <div class="form-group">
                                    <label>公告标题</label>
                                    <asp:TextBox ID="AddName" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>公告内容</label>
                                    <div class="clearfix"></div>
                                    <asp:TextBox ID="AddText" CssClass="autogrow" runat="server" TextMode="MultiLine" style="height: 214px;margin: 0px;width: 636px;" ></asp:TextBox>
                                </div>
                                <a href="Management-Announcement.aspx">
                                    <asp:Button ID="Button1" runat="server" Text="提交"  class="btn btn-default" OnClick="Button1_Click"/></a>
                                                            <a>
                                    <asp:Button ID="Button2" runat="server" class="btn btn-default" Text="取消" OnClick="Button2_Click" /></a>

                            <asp:Label ID="Label1" runat="server" Enabled="False"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <!--/span-->
        </div>

    </div>
</asp:Content>

