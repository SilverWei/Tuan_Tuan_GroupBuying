<%@ Page Title="" Language="C#" MasterPageFile="~/Nav-Master.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>注册</title>
    <link href="CSS/buttons.css" rel="stylesheet" />
    <link href="CSS/register.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div class="all">
        <div class="row">

            <div class="row" style="height: 70px; top: 0;">
                <div class="col-md-12 login-header" style="padding: 0; height: 0;">
                    <h2>注册</h2>
                </div>
                <!--/span-->
            </div>
            <!--/row-->


            <div class="row">
                <div class="well login-box" style="position: relative; width: 500px; margin: auto;">
                    <div class="input-group input-group-lg">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-user red"></i></span>
                        <input class="form-control" id="U_Name" placeholder="用户名" type="text" runat="server">
                    </div>
                    <div class="clearfix"></div>
                    <br>

                    <div class="input-group input-group-lg">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock red"></i></span>
                        <input class="form-control" id="U_Password1" placeholder="密码" type="password" runat="server">
                    </div>
                    <div class="clearfix"></div>
                    <br>

                    <div class="input-group input-group-lg">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock red"></i></span>
                        <input class="form-control" id="U_Password2" placeholder="确认密码" type="password" runat="server">
                    </div>
                    <div class="clearfix"></div>
                    <br>

                    <div class="input-group input-group-lg">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-envelope red"></i></span>
                        <input class="form-control" id="U_Email" placeholder="邮箱" type="email" runat="server">
                    </div>
                    <div class="clearfix"></div>

                    <div class="alert alert-info" style="margin-top: 13px;">已有账号？<a href="Landed.aspx">请登录</a></div>
                    <div class="clearfix"></div>
                    <div class="alert alert-danger" id="WrongShow" runat="server" visible="false">
                        <p runat="server" id="WrongText"></p>
                    </div>
                    <div class="clearfix"></div>

                    <p class="center">
                        <asp:Button ID="Register_Button" class="btn btn-primary" Style="width: 120px;" runat="server" Text="注册" OnClick="Button1_Click" />
                    </p>

                </div>
                <!--/span-->
            </div>
            <!--/row-->
        </div>
    </div>
</asp:Content>

