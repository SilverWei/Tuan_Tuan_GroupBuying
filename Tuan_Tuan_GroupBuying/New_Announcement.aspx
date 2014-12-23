<%@ Page Title="" Language="C#" MasterPageFile="~/Management-Master.master" AutoEventWireup="true" CodeFile="New_Announcement.aspx.cs" Inherits="New_Announcement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>新建公告</title>
    <link href="CSS/New_Announcement.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div class="Main">

        <div class="row">
            <div class="box col-md-12">
                <div class="box-inner">
                    <div class="box-header well" data-original-title="">
                        <h2><i class="glyphicon glyphicon-comment"></i>新建公告</h2>
                    </div>
                    <div class="row" style="margin: 0;">
                        <div class="box col-md-12">
                                <div class="form-group">
                                    <label>公告标题</label>
                                    <input class="form-control" id="A_Name" runat="server" type="text" />
                                </div>
                                <div class="form-group">
                                    <label>公告内容</label>
                                    <div class="clearfix"></div>
                                    <textarea class="autogrow" id="A_Text" runat="server" style="height: 214px; margin: 0px; width: 636px;"></textarea>
                                </div>
                               

                                <a href="Management-Announcement.aspx" >
                                   <asp:Button ID="Button2" runat="server" Text="提交"  class="btn btn-default" OnClick="Button2_Click1"  />

                                </a>
                                                                                        <a>
                                    <asp:Button ID="Button1" runat="server" Text="取消" class="btn btn-default" OnClick="Button2_Click" /></a>

                                <asp:Label ID="Label1"  runat="server" Enabled="False" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <!--/span-->
        </div>

    </div>

</asp:Content>

