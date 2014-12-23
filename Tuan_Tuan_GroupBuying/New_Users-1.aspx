<%@ Page Title="" Language="C#" MasterPageFile="~/Management-Master.master" AutoEventWireup="true" CodeFile="New_Users-1.aspx.cs" Inherits="New_Users_1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>新建管理员</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div class="Main">

        <div class="row">
            <div class="box col-md-12">
                <div class="box-inner">
                    <div class="box-header well" data-original-title="">
                        <h2><i class="glyphicon glyphicon-comment"></i>新建管理员</h2>
                    </div>
                    <div class="row" style="margin: 0;">
                        <div class="box col-md-12">
                            <form role="form">
                                <div class="form-group">
                                    <label>管理员用户名</label>
                                    <input id="UA_Name_Text" type="text" runat="server" class="form-control" />
                                </div>
                                <div class="form-group">
                                    <label>管理员密码</label>
                                    <input id="UA_Password1" type="password" runat="server" class="form-control" />
                                </div>
                                <div class="form-group">
                                    <label>确认管理员密码</label>
                                    <input id="UA_Password2" class="form-control" runat="server" type="password" />
                                </div>

                                <a href="Management-Users-1.aspx">
                                    <asp:Button ID="Button1" runat="server" class="btn btn-default"  Text=" 提交" OnClick="Button1_Click" />
                                </a>
                                <asp:Label ID="Label1" runat="server" Text="" Enabled="False"></asp:Label>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <!--/span-->
        </div>

    </div>
</asp:Content>

