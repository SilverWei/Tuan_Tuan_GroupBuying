<%@ Page Title="" Language="C#" MasterPageFile="~/Management-Master.master" AutoEventWireup="true" CodeFile="Management-Goods.aspx.cs" Inherits="Management_Goods" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="CSS/Management-Goods.css" rel="stylesheet" />
    <title>商品管理</title>
    <script>
        function DelG_ID(G_ID) {
            document.cookie = 'DelG_ID = ' + G_ID;//创建Cookies
        }
        $("#waitWork").click(function () {
            var url = "请求地址";
            var data = { type: 1 };
            $.ajax({
                type: "get",
                async: false,  //同步请求  
                url: url,
                data: data,
                timeout: 1000,
                success: function (dates) {
                    //alert(dates);  
                    $("#mainContent").html(dates);//要刷新的div  
                },
                error: function () {
                    // alert("失败，请稍后再试！");  
                }
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <div class="row">
        <div class="box col-md-12">
            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-gift"></i>商品管理</h2>
                </div>

                <div class="box-content">
                    <a class="btn btn-success" href="New_Goods.aspx?Url=<%= Request.Url.ToString() %>"><i class="glyphicon glyphicon-plus"></i>新建商品页</a>
                    <a class="btn btn-primary" href="Management_GoodsSort.aspx"><i class="glyphicon glyphicon-indent-left"></i>管理物品分类</a>
                </div>
                <div class="row" style="margin: 0;">
                    <div class="box col-md-12">
                        <div class="Search_Box">
                            <asp:DropDownList CssClass="Search_Box_DropDownList" ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" runat="server">
                                <asp:ListItem Selected="True" Value="0">名称</asp:ListItem>
                                <asp:ListItem Value="1">品牌</asp:ListItem>
                                <asp:ListItem Value="3">编号</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Panel ID="Panel1" runat="server" DefaultButton="SeaBoxButton">
                                <asp:TextBox ID="SeaBox" CssClass="form-control" runat="server" Visible="true" Text="" style="position: relative;left: 5px; float: left; height: 31px; width: 20%; top: 5px;"></asp:TextBox>
                                <asp:LinkButton ID="SeaBoxButton" runat="server" OnClick="SeaBoxButton_Click"><i class="glyphicon glyphicon-search" style="position: relative; float: left; top: 14px; right: 20px;"></i></asp:LinkButton>
                            </asp:Panel>
                            <asp:DropDownList CssClass="Search_Box_DropDownList Search_Box_DropDownList2" DataSourceID="SqlDataSource3" Visible="false" ID="DropDownList2" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" DataTextField="G_Brand" DataValueField="G_Brand" runat="server">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="Select G_Brand From t_Goods group by G_Brand"></asp:SqlDataSource>
                            <div id="SeaDate" runat="server" visible="true" style="position: relative;float: left;left: 10px;top: 9px;width: 450px;">
                                <p style="color:red;float: left;">发布时间范围：</p>
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
    </div>


    <div class="row" id="mainContent">
        <div class="box col-md-12">
            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2 id="GSBoxTab" runat="server"><i class="glyphicon glyphicon-gift"></i>

                        <asp:Label ID="GS1_Text" runat="server" Style="color: blue;"></asp:Label>-
                        <asp:Label ID="GS2_Text" Style="color: green;" runat="server"></asp:Label>
                    </h2>
                    <h2 id="GSBoxTab2" runat="server" visible="false"><i class="glyphicon glyphicon-search"></i>
                        <asp:Label ID="Label2" runat="server" Style="color: red;">名称搜索：</asp:Label>
                        <asp:Label ID="Label1" runat="server" Style="color: blue;"></asp:Label>
                    </h2>
                    <div class="box-icon">
                    </div>
                </div>
                <div runat="server" id="GSBox" style="height: 123px;" visible="true">
                    <div class="row" style="height: 80px;">
                        <div class="box col-md-12">
                            <div class="box-inner">
                                <div class="box-content">
                                    <p style="color: red; float: left; position: relative; top: 7px; font-size: 16px;">一级菜单：</p>
                                    <telerik:RadListView ID="RadListView1" runat="server" DataSourceID="SqlDataSource1">
                                        <ItemTemplate>
                                            <a class="btn btn-default" href="Management-Goods.aspx?GS1=<%#Eval("GS1_ID") %>"><%#Eval("GS1_Name") %></a>
                                        </ItemTemplate>
                                    </telerik:RadListView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="select * From [t_GoodsSort1st]"></asp:SqlDataSource>
                                </div>
                            </div>
                        </div>
                        <!--/span-->
                    </div>

                    <div class="box-content" style="position: relative; top: -19px;">
                        <ul class="nav nav-tabs">
                            <p style="color: red; float: left; position: relative; top: 7px; font-size: 16px; margin-left: 10px;">二级菜单：</p>

                            <telerik:RadListView ID="RadListView2" runat="server" DataSourceID="SqlDataSource2">
                                <ItemTemplate>
                                    <li>
                                        <a href="Management-Goods.aspx?GS2=<%#Eval("GS2_ID") %>" style="color: red"><%#Eval("GS2_Name") %></a>
                                </ItemTemplate>
                            </telerik:RadListView>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>"></asp:SqlDataSource>
                        </ul>
                    </div>
                </div>
                <telerik:RadListView ID="RadListView3" runat="server" AllowPaging="True" ItemPlaceholderID="item" PageSize="10" DataSourceID="SqlDataSource4">
                    <LayoutTemplate>
                        <table class="table table-striped table-bordered responsive" style="margin-left: 0.5%; width: 99%; margin-top: 10px;">
                            <thead>
                                <tr>
                                    <th>名称</th>
                                    <th>品牌</th>
                                    <th>发布日期</th>
                                    <th>价格</th>
                                    <th>库存</th>
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
                            <td style="width: 30%;"><a href="Goods.aspx?G_ID=<%#Eval("G_ID") %>" target="_blank" style="color: red"><%#Eval("[G_Name]") %></a></td>
                            <td class="center"><%#Eval("[G_Brand]") %></td>
                            <td class="center" style="width: 152px;"><%#Eval("[G_OfferDate]","{0:yyyy年 MM月 dd日}") %></td>
                            <td class="center"><%# float.Parse(Eval("G_UserPrice").ToString()).ToString("C") %></td>
                            <td class="center"><%#Eval("G_Amount") %></td>
                            <td class="center">
                                <a class="btn btn-info" href="Edit_Goods.aspx?Go=<%#Eval("G_ID")  %><%= (Request.QueryString["GS2"]!=null?"&GS2="+Request.QueryString["GS2"].ToString():"") +(Request.QueryString["Ser"]!=null?"&Ser="+Request.QueryString["Ser"].ToString():"") +(Request.QueryString["Wer"]!=null?"&Wer="+Request.QueryString["Wer"].ToString():"") %>">
                                    <i class="glyphicon glyphicon-edit icon-white"></i>
                                    编辑
                                </a>
                                <a onclick="DelG_ID('<%#Eval("G_ID") %>')" class="btn btn-danger btn-setting"><i class="glyphicon glyphicon-trash icon-white"></i>删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </telerik:RadListView>

                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>"></asp:SqlDataSource>
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

