<%@ Page Title="" Language="C#" MasterPageFile="~/Nav-Master.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>搜索结果</title>
    <link href="CSS/buttons.css" rel="stylesheet" />
    <link href="CSS/Search.css" rel="stylesheet" />
    <link href="CSS/Home-GoodsTab.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div class="all">
        <div class="main6">
            <div class="row">
                <div class="box col-md-12">
                    <div class="box-inner">
                        <div class="main1">
                            <div class="txt1" style="">
                                <span id="Main_Label1">
                                    <asp:HyperLink ID="GS1TextShow2" runat="server" NavigateUrl="Search.aspx" Visible="true">HyperLink</asp:HyperLink>
                                    <asp:HyperLink ID="GS2TextShow2" runat="server" Visible="true">HyperLink</asp:HyperLink>
                                    <asp:HyperLink ID="BraTextShow2" runat="server" NavigateUrl="Search.aspx" Visible="false">HyperLink</asp:HyperLink>
                                </span>
                            </div>
                            <div class="txt3">
                                <asp:Panel ID="Panel1" runat="server" DefaultButton="SeaBoxButton">
                                    <input class="form-control" runat="server" id="SeaBox" type="text" style="position: relative; float: left; height: 31px; width: 160px; top: 5px;">
                                    <asp:LinkButton ID="SeaBoxButton" runat="server" OnClick="SeaBoxButton_Click"><i class="glyphicon glyphicon-search" style="position: relative; float: left; top: 14px; right: 20px;"></i></asp:LinkButton>
                                </asp:Panel>
                                <h3 class="SearchName">商品列表</h3>

                            </div>
                        </div>
                        <div class="box-content">
                            <table class="table table-striped table-bordered responsive" style="margin-top: 0px;">
                                <tbody>
                                    <tr>
                                        <td style="width: 10%">
                                            <asp:HyperLink ID="GS1TextShow" runat="server" NavigateUrl="~/Search.aspx">二级分类</asp:HyperLink>
                                        </td>
                                        <td>
                                            <telerik:RadListView ID="RadListView1" runat="server" DataSourceID="SqlDataSource3">
                                                <ItemTemplate>
                                                    <p class="GS2Text"><a href="Search.aspx?GS2=<%#Eval("GS2_ID") %>"><%#Eval("GS2_Name") %></a> </p>
                                                </ItemTemplate>
                                            </telerik:RadListView>
                                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>"></asp:SqlDataSource>
                                            <telerik:RadListView ID="RadListView4" runat="server" DataSourceID="SqlDataSource2">
                                                <ItemTemplate>
                                                    <p class="GS2Text"><a href="Search.aspx?GS1=<%#Eval("GS1_ID") %>"><%#Eval("GS1_Name") %></a> </p>
                                                </ItemTemplate>
                                            </telerik:RadListView>
                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>"></asp:SqlDataSource>
                                        </td>
                                    </tr>
                                </tbody>
                                <tbody>
                                    <tr>
                                        <td>品牌</td>
                                        <td>
                                            <telerik:RadListView ID="RadListView2" runat="server" DataSourceID="SqlDataSource1">
                                                <ItemTemplate>
                                                    <p class="GS2Text"><a href="Search.aspx?<%= SelectUrl%>&Bra=<%#Eval("G_Brand") %>"><%#Eval("G_Brand") %></a> </p>
                                                </ItemTemplate>
                                            </telerik:RadListView>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>"></asp:SqlDataSource>

                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="main7">
            <div class="row">
                <div class="box col-md-12">
                    <div class="box-inner">
                        <div class="box-content">
                            <div class="main5">
                                <div class="main3">
                                    <table border="0" style="width: 350px; height: 15px;">
                                        <tr>
                                            <td>
                                                <p style="color: red; font-size: 18px; position: relative; top: 6px; width: 50px;">排序:</p>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="OrdBurron1" CssClass="btn btn-default" runat="server" OnClick="OrdBurron1_Click">时间</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="OrdBurron2" CssClass="btn btn-default" runat="server" OnClick="OrdBurron2_Click">价格</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="OrdBurron3" CssClass="btn btn-default" runat="server" OnClick="OrdBurron3_Click">产品名</asp:LinkButton>
                                            </td>
                                            <td>
                                                <div id="SeaDate" runat="server" visible="true" style="position: relative; float: left; left: 10px; top: 9px; width: 480px;">
                                                    <p style="color: red; float: left;">商品发布时间范围：</p>
                                                    <telerik:RadDatePicker ID="SeaDateFrom" runat="server" AutoPostBack="true" OnSelectedDateChanged="SeaDateFrom_SelectedDateChanged"></telerik:RadDatePicker>
                                                    <i class="glyphicon glyphicon-resize-horizontal"></i>
                                                    <telerik:RadDatePicker ID="SeaDateTo" runat="server" AutoPostBack="true" OnSelectedDateChanged="SeaDateTo_SelectedDateChanged"></telerik:RadDatePicker>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                                <div runat="server" id="SelectNullShow" visible="false" class="alert alert-danger" style="margin-top: 30px;">没有任何相关产品！</div>

                                <telerik:RadListView ID="RadListView3" runat="server" AllowPaging="True" ItemPlaceholderID="item" PageSize="24" DataSourceID="SqlDataSource4">
                                    <LayoutTemplate>
                                        <thead id="item" runat="server">
                                        </thead>
                                        <div class="clearfix">
                                        </div>
                                        <telerik:RadDataPager ID="RadDataPager1" runat="server" CssClass="CustomDataPager" BorderWidth="0" Skin="Metro" PagedControlID="RadListView3" PageSize="24">
                                            <Fields>
                                                <telerik:RadDataPagerButtonField FieldType="FirstPrev" FirstButtonText="首页" PrevButtonText="上一页" />
                                                <telerik:RadDataPagerButtonField FieldType="Numeric" />
                                                <telerik:RadDataPagerButtonField FieldType="NextLast" LastButtonText="尾页" NextButtonText="下一页" />
                                            </Fields>
                                        </telerik:RadDataPager>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <div class="NewGoods_Box">
                                            <a href="Goods.aspx?G_ID=<%#Eval("G_ID") %>" target="_blank">
                                                <img src='<%#Eval("GP_Url") %>' class="Home-GoodsTab-Picture"></a>
                                            <div class="Home-GoodsTab-Text_Box">
                                                <b class="Home-GoodsTab-Text1"><a href="Goods.aspx?G_ID=<%#Eval("G_ID") %>" target="_blank"><%#Eval("G_Name1") %></a></b>
                                                <p class="Home-GoodsTab-Text2">市场价：</p>
                                                <del class="Home-GoodsTab-Text3"><%# float.Parse(Eval("G_MarketPrice").ToString()).ToString("C") %></del>
                                                <p class="Home-GoodsTab-Text4">会员价：</p>
                                                <b class="Home-GoodsTab-Text5"><%# float.Parse(Eval("G_UserPrice").ToString()).ToString("C") %></b>
                                                <a href="Goods.aspx?G_ID=<%#Eval("G_ID") %>" class="button glow button-rounded button-flat-caution Home-GoodsTab-Button" target="_blank">立即查看！</a>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                </telerik:RadListView>
                            </div>

                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>"></asp:SqlDataSource>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ShoppingCart_Box" runat="Server">
    <a href="ShoppingCart.aspx">
        <div class="ShoppingCart_Box btn btn-danger">
            <p class="ShoppingCart_Text" id="ShoppingCart_Text" runat="server">0</p>
            <div class="ShoppingCart_Image"><i class="glyphicon glyphicon-shopping-cart"></i></div>
        </div>
    </a>
</asp:Content>
