<%@ Page Title="" Language="C#" MasterPageFile="~/Nav-Master.master" AutoEventWireup="true" CodeFile="Landed.aspx.cs" Inherits="Landed" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>登录</title>
    <link href="CSS/buttons.css" rel="stylesheet" />
    <link href="CSS/Landed.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="Server">
    <div class="all">
        <div class="row">

            <div class="row" style="height: 70px;">
                <div class="col-md-12 login-header" style="padding: 0;height: 0px;">
                    <h2>登录</h2>
                </div>
                <!--/span-->
            </div>
            <!--/row-->

            <div class="row">
                <div class="well login-box" style="width: 470px; position: relative;margin: auto;">
                    <div class="input-group input-group-lg">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-user red"></i></span>
                        <input class="form-control" id="UserName_Text" placeholder="用户名" type="text" runat="server" />
                    </div>
                    <div class="clearfix"></div>
                    <br />

                    <div class="input-group input-group-lg">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock red"></i></span>
                        <input class="form-control" id="Password_Text" placeholder="密码" type="password" runat="server"/>
                    </div>
                    <div class="clearfix"></div>
                    <div class="alert alert-info" style="margin-top: 30px;">没有账号？<a href="register.aspx">立即注册</a> <%--登陆名:abc 密码:456123--%></div>
                    <div class="clearfix"></div>
                    <div class="alert alert-danger" id="WrongShow" runat="server" visible="false">
                        <p runat="server" id="WrongText"></p>
                    </div>
                    <div class="clearfix"></div>

                    <p class="center" style="width: 120px">
                        <asp:Button ID="Login_Button" runat="server" class="btn btn-primary" Text="登录" OnClick="Login_Button_Click" />
                    </p>

                </div>
                <!--/span-->
            </div>
            <!--/row-->
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ShoppingCart_Box" runat="Server">
</asp:Content>
