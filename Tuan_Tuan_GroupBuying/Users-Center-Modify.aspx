<%@ Page Title="" Language="C#" MasterPageFile="~/Nav-Master.master" AutoEventWireup="true" CodeFile="Users-Center-Modify.aspx.cs" Inherits="Users_Center_Modify" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="CSS/Users-Center-Modify.css" rel="stylesheet" />
    <script src="JS/Birthday-Calendar.js"></script>
    <title>修改个人资料</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div class="row Center_Main" style="margin: auto;">
        <div class="box col-md-12">
            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-cog"></i>修改个人资料</h2>
                </div>
                <div class="row" style="margin: 0; text-align: left;">
                    <div class="box col-md-12" id="Main">
                        <div class="form-group">
                            <p>用户名：</p>
                            <asp:TextBox ID="U_Name" runat="server"></asp:TextBox>
                        </div>
                        <div class="clearfix"></div>
                        <div class="form-group">
                            <p>真实姓名：</p>
                            <asp:TextBox ID="U_RealName" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <p>新密码：</p>
                            <input type="password" id="NewU_Password1"  runat="server"/>
                           <%-- <asp:TextBox ID="NewU_Password1"  runat="server"></asp:TextBox>--%>
                        </div>
                        <div class="clearfix"></div>
                        <div class="form-group">
                            <p>确认新密码：</p>
                            <input type="password" id="NewU_Password2"  runat="server"/>
                           <%-- <asp:TextBox ID="NewU_Password2" runat="server"></asp:TextBox>--%>
                        </div>
                        <div class="clearfix"></div>
                        <div class="form-group">
                            <p>性别：</p>
                            <asp:RadioButtonList ID="U_Sex" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="False">男</asp:ListItem>
                                <asp:ListItem Value="True">女</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="clearfix"></div>
                        <div class="form-group">
                            <p>出生日期：</p>
                            <telerik:RadDatePicker ID="RadDatePicker1" runat="server"></telerik:RadDatePicker>
                            <input type="hidden" id="UA_SignUP" name="UA_SignUP" value="" runat="server" />

                        </div>
                        <div class="clearfix"></div>
                        <div class="form-group">
                            <p>E-mail：</p>
                            <asp:TextBox ID="U_Email" type="email" runat="server"></asp:TextBox>
                        </div>
                        <div class="clearfix"></div>
                        <div class="form-group">
                            <p>手机：</p>
                            <asp:TextBox ID="U_Phone" runat="server"></asp:TextBox>
                        </div>
                        <div class="clearfix"></div>
                        <div class="form-group">
                            <p>原密码：</p>
                             <input type="password" id="U_Password"  runat="server"/>
                          <%--  <asp:TextBox ID="U_Password" runat="server" ></asp:TextBox>--%>
                            <span class="label-default label label-danger">必填！</span>
                        </div>
                        <div class="clearfix"></div>
                        <asp:LinkButton ID="LinkButton1" class="btn btn-default" runat="server" OnClick="LinkButton1_Click">修改</asp:LinkButton>
                    </div>
                </div>

            </div>
        </div>
        <!--/span-->
    </div>
</asp:Content>

