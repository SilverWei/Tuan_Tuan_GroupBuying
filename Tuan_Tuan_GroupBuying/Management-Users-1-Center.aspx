<%@ Page Title="" Language="C#" MasterPageFile="~/Management-Master.master" AutoEventWireup="true" CodeFile="Management-Users-1-Center.aspx.cs" Inherits="Management_Users_1_Center" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>会员管理-管理员</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server"></telerik:RadStyleSheetManager>
    <div class="row">
        <div class="box col-md-12">
            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-cog"></i>编辑管理员信息</h2>
                </div>
                <div class="row" style="margin: 0;">
                    <div class="box col-md-12">
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
                                    <asp:TextBox ID="NewU_Password1" runat="server"></asp:TextBox>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group">
                                    <p>确认新密码：</p>
                                    <asp:TextBox ID="NewU_Password2" runat="server"></asp:TextBox>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group">
                                    <p>性别：</p>
                                    <asp:RadioButtonList ID="U_Sex" runat="server" RepeatDirection="Horizontal" >
                                        <asp:ListItem Value="False">男</asp:ListItem>
                                        <asp:ListItem Value="True">女</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group">
                                    <p>出生日期：</p>
                                    <telerik:RadDatePicker ID="RadDatePicker1" runat="server"></telerik:RadDatePicker>
                                    <input type="hidden" id="UA_SignUP" name="UA_SignUP" value="" runat="server"/>
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
                        </div>
                                                    <asp:LinkButton ID="LinkButton1" class="btn btn-default" runat="server"   OnClick="LinkButton1_Click">修改</asp:LinkButton>
                                                                                    <a class="btn btn-default">
                                    <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" /></a>

                        <a class="btn btn-danger btn-setting"><i class="glyphicon glyphicon-trash icon-white"></i>删除该管理员</a>
                    </div>
                </div>
            </div>
        </div>
        <!--/span-->
    </div>


    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">×</button>
                    <h3 id="DelText1">确认删除？</h3>
                </div>
                <input type="hidden" id="DelText2" runat="server" value="" />
                <div class="modal-footer">
                    <a class="btn btn-default" data-dismiss="modal">关闭</a>
                    <asp:LinkButton ID="DelButton1" class="btn btn-primary" runat="server" OnClick="DelButton1_Click">删除</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>



</asp:Content>

