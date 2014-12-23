<%@ Page Title="" Language="C#" MasterPageFile="~/Management-Master.master" AutoEventWireup="true" CodeFile="Management-Users-1.aspx.cs" Inherits="Management_Users_1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>会员管理-管理员</title>
    <script>
        function DelA_ID(A_ID) {
            document.cookie = 'DelA_ID = ' + A_ID;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server"></telerik:RadStyleSheetManager>
    <div class="row">
        <div class="box col-md-12">
            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-cog"></i>选项</h2>
                </div>
                <div class="box-content">
                    <a class="btn btn-success" href="New_Users-1.aspx"><i class="glyphicon glyphicon-user"></i>新建管理员</a>
                </div>
                <div class="row" style="margin: 0;">
                    <div class="box col-md-12">
                        <div class="Search_Box">
                            <asp:DropDownList CssClass="Search_Box_DropDownList" ID="DropDownList1" runat="server">
                                <asp:ListItem Selected="True" Value="0">管理员名</asp:ListItem>
                                <asp:ListItem Value="1">管理员编号</asp:ListItem>
                                <asp:ListItem Value="2">电子邮件</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Panel ID="Panel1" runat="server" DefaultButton="SeaBoxButton">
                                <asp:TextBox ID="SeaBox" CssClass="form-control" runat="server" Visible="true" Text="" Style="position: relative; left: 5px; float: left; height: 31px; width: 20%; top: 5px;"></asp:TextBox>
                                <asp:LinkButton ID="SeaBoxButton" runat="server" OnClick="SeaBoxButton_Click"><i class="glyphicon glyphicon-search" style="position: relative; float: left; top: 14px; right: 20px;"></i></asp:LinkButton>
                            </asp:Panel>
                            <div id="SeaDate" runat="server" visible="true" style="position: relative; float: left; left: 10px; top: 9px; width: 450px;">
                                <p style="color: red; float: left;">注册时间范围：</p>
                                <telerik:RadDatePicker ID="SeaDateFrom" runat="server" AutoPostBack="true" OnSelectedDateChanged="SeaDateFrom_SelectedDateChanged"></telerik:RadDatePicker>
                                <i class="glyphicon glyphicon-resize-horizontal"></i>
                                <telerik:RadDatePicker ID="SeaDateTo" runat="server" AutoPostBack="true" OnSelectedDateChanged="SeaDateTo_SelectedDateChanged"></telerik:RadDatePicker>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/span-->



        <div class="box col-md-12">
            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-edit"></i>
                        <asp:Label ID="Label1" runat="server" Text="管理员管理"></asp:Label></h2>

                    <div class="box-icon">
                    </div>
                </div>
                <div class="box-content">
                    <telerik:RadListView ID="RadListView3" runat="server" AllowPaging="True" ItemPlaceholderID="item" PageSize="10" DataSourceID="SqlDataSource4">
                        <LayoutTemplate>
                            <table class="table table-striped table-bordered responsive">
                                <thead>
                                    <tr>
                                        <th>管理员名</th>
                                        <th>注册日期</th>
                                        <th>E-mail</th>
                                        <th>编辑</th>
                                    </tr>
                                </thead>
                                <thead id="item" runat="server">
                                </thead>

                            </table>
                            <telerik:RadDataPager ID="RadDataPager1" runat="server" CssClass="CustomDataPager" BorderWidth="0" Skin="Metro" PagedControlID="RadListView3" PageSize="10">
                                <Fields>
                                    <telerik:RadDataPagerButtonField FieldType="FirstPrev" FirstButtonText="首页" PrevButtonText="上一页" />
                                    <telerik:RadDataPagerButtonField FieldType="Numeric" />
                                    <telerik:RadDataPagerButtonField FieldType="NextLast" LastButtonText="尾页" NextButtonText="下一页" />
                                </Fields>
                            </telerik:RadDataPager>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="width: 30%;"><%#Eval("[UA_Name]") %></td>
                                <td class="center" style="width: 152px;"><%#Eval("[UA_SignUP]","{0:yyyy年 MM月 dd日}") %></td>
                                <td class="center"><%#Eval("[UA_Email]") %></td>
                                <td class="center" style="width: 20%;">
                                    <a class="btn btn-info" href="Management-Users-1-Center.aspx?UA=<%#Eval("UA_ID") %>"><i class="glyphicon glyphicon-edit icon-white"></i>编辑</a>
                                    <a onclick="DelA_ID('<%#Eval("UA_ID") %>')" class="btn btn-danger btn-setting"><i class="glyphicon glyphicon-trash icon-white"></i>删除</a>
                                </td>

                            </tr>

                        </ItemTemplate>
                    </telerik:RadListView>

                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>"></asp:SqlDataSource>

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

