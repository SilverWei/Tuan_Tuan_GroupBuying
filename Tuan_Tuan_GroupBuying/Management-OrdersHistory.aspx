<%@ Page Title="" Language="C#" MasterPageFile="~/Management-Master.master" AutoEventWireup="true" CodeFile="Management-OrdersHistory.aspx.cs" Inherits="Management_OrdersHistory" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>历史订单管理</title>
    <link href="CSS/OS_CSS.css" rel="stylesheet" />
    <script>
        function LinkButton2_Click(O_ID) {
            document.cookie = 'EditOrderID = ' + O_ID;//创建Cookies
            var RenamingText1 = document.getElementById("RenamingText1");
            RenamingText1.innerHTML = O_ID + " - 更改订单状态";
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
                <div class="row" style="margin: 0;">
                    <div class="box col-md-12">
                        <div class="Search_Box">
                            <asp:DropDownList CssClass="Search_Box_DropDownList" ID="DropDownList1" runat="server">
                                <asp:ListItem Selected="True" Value="0">订单编号</asp:ListItem>
                                <asp:ListItem Value="1">用户名</asp:ListItem>
                                <asp:ListItem Value="2">订单状态</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Panel ID="Panel1" runat="server" DefaultButton="SeaBoxButton">
                                <asp:TextBox ID="SeaBox" CssClass="form-control" runat="server" Visible="true" Text="" Style="position: relative; left: 5px; float: left; height: 31px; width: 20%; top: 5px;"></asp:TextBox>
                                <asp:LinkButton ID="SeaBoxButton" runat="server" OnClick="SeaBoxButton_Click"><i class="glyphicon glyphicon-search" style="position: relative; float: left; top: 14px; right: 20px;"></i></asp:LinkButton>
                            </asp:Panel>
                            <div id="SeaDate" runat="server" visible="true" style="position: relative; float: left; left: 10px; top: 9px; width: 476px;">
                                <p style="color: red; float: left;">订单生成时间范围：</p>
                                <telerik:RadDatePicker ID="SeaDateFrom" runat="server" AutoPostBack="true" OnSelectedDateChanged="SeaDateFrom_SelectedDateChanged"></telerik:RadDatePicker>
                                <i class="glyphicon glyphicon-resize-horizontal"></i>
                                <telerik:RadDatePicker ID="SeaDateTo" runat="server" AutoPostBack="true" OnSelectedDateChanged="SeaDateTo_SelectedDateChanged"></telerik:RadDatePicker>
                            </div>
                            <div style="position: relative; float: left; left: 10px; top: 9px; width: 190px;">
                                <p style="color: red; float: left;font-size: 17px;">状态：</p>
                                <asp:DropDownList CssClass="Search_Box_DropDownList Search_Box_DropDownList2" DataSourceID="SqlDataSource3" style="top: -4px;" Visible="true" ID="DropDownList2" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true" DataTextField="OS_Name" DataValueField="OS_ID" runat="server">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="select * From t_OrdersSort UNION (select 1 as OS_ID,'所有' as OS_Name,0 as OS_B_Y_N)"></asp:SqlDataSource>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/span-->

    </div>


    <div class="row">
        <div class="box col-md-12">
            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-edit"></i>
                        <asp:Label ID="Label1" runat="server" Text="历史订单管理"></asp:Label></h2>

                    <div class="box-icon">
                    </div>
                </div>
                <div class="box-content">
                    <telerik:RadListView ID="RadListView3" runat="server" AllowPaging="True" ItemPlaceholderID="item" PageSize="10" DataSourceID="SqlDataSource4">
                        <LayoutTemplate>
                            <table class="table table-striped table-bordered responsive">
                                <thead>
                                    <tr>
                                        <th>订单编号</th>
                                        <th>客户</th>
                                        <th>生成日期</th>
                                        <th>订单总计</th>
                                        <th>状态</th>
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
                                <td><a href="Management-OrdersInformation.aspx?O_ID=<%#Eval("[O_ID]") %>"><%#Eval("[O_ID]") %></a></td>
                                <td class="center"><%#Eval("U_Name").ToString() != ""?Eval("U_Name"):"*已被删除*" %></td>
                                <td class="center"><%#Eval("[O_buyDate]","{0:yyyy年 MM月 dd日 HH:mm:ss}") %></td>
                                <td class="center">¥<%#Eval("[OG_TotalPrice]") %></td>
                                <td class="center">
                                    <span class="label label-default OS_<%#Eval("[OS_ID]") %>"><%#Eval("[OS_Name]") %></span>
                                </td>
                                <td class="center" style="width: 10%">
                                    <div onclick="LinkButton2_Click('<%#Eval("[O_ID]") %>')">
                                        <a class="btn btn-info btn-setting" href="#">
                                            <i class="glyphicon glyphicon-edit icon-white"></i>
                                            状态编辑
                                        </a>
                                    </div>
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
                    <h3 id="RenamingText1"></h3>
                </div>
                <div class="modal-body">
                    <p>请修改订单状态:</p>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="OS_Name" DataValueField="OS_ID">
                    </asp:RadioButtonList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="Select * From t_OrdersSort Where OS_ID != 5"></asp:SqlDataSource>
                </div>
                <input type="hidden" id="RenamingText2" runat="server" value="" />
                <div class="modal-footer">
                    <a class="btn btn-default" data-dismiss="modal">关闭</a>
                    <asp:LinkButton ID="EditOrderButton" OnClick="EditOrderButton_Click" CssClass="btn btn-primary" runat="server">保存</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

