<%@ Page Title="" Language="C#" MasterPageFile="~/Nav-Master.master" AutoEventWireup="true" CodeFile="SearchGB.aspx.cs" Inherits="SearchGB" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>搜索结果-团购</title>
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
                            <div class="txt3">
                                <asp:Panel ID="Panel1" runat="server" DefaultButton="SeaBoxButton">
                                    <input class="form-control" runat="server" id="SeaBox" type="text" style="position: relative; float: left; height: 31px; width: 160px; top: 5px;">
                                    <asp:LinkButton ID="SeaBoxButton" runat="server" OnClick="SeaBoxButton_Click"><i class="glyphicon glyphicon-search" style="position: relative; float: left; top: 14px; right: 20px;"></i></asp:LinkButton>
                                </asp:Panel>
                                <h3 class="SearchName">团购活动列表</h3>
                            </div>
                        </div>
                        <div class="box-content">
                            <div style="height: 35px">
                                <div id="SeaDate" runat="server" visible="true" style="position: relative; float: left; left: 10px; top: 9px; width: 480px;">
                                    <p style="color: red; float: left;">活动发布时间范围：</p>
                                    <telerik:RadDatePicker ID="SeaDateFrom" runat="server" AutoPostBack="true" OnSelectedDateChanged="SeaDateFrom_SelectedDateChanged"></telerik:RadDatePicker>
                                    <i class="glyphicon glyphicon-resize-horizontal"></i>
                                    <telerik:RadDatePicker ID="SeaDateTo" runat="server" AutoPostBack="true" OnSelectedDateChanged="SeaDateTo_SelectedDateChanged"></telerik:RadDatePicker>
                                </div>
                            </div>
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
                                <div runat="server" id="SelectNullShow" visible="false" class="alert alert-danger" style="margin-top: 30px;">没有任何相关产品！</div>

                                <telerik:RadListView ID="RadListView3" runat="server" AllowPaging="True" ItemPlaceholderID="item" PageSize="24" DataSourceID="SqlDataSource2">
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
                                            <a href="Goods.aspx?GB_ID=<%#Eval("GB_ID") %>" target="_blank">
                                                <img src='<%#Eval("GBP_Url") %>' class="Home-GoodsTab-Picture"></a>
                                            <div class="Home-GoodsTab-Text_Box">
                                                <b class="Home-GoodsTab-Text1"><a href="Goods.aspx?GB_ID=<%#Eval("GB_ID") %>" target="_blank"><%#Eval("GB_Name1") %></a></b>
                                                <p class="Home-GBTab-Text2">市场价：</p>
                                                <del class="Home-GBTab-Text3"><%# float.Parse(Eval("GB_MarketPrice").ToString()).ToString("C") %></del>
                                                <p class="Home-GBTab-Text4">活动价：</p>
                                                <b class="Home-GBTab-Text5"><%# float.Parse(Eval("GB_GroupPrice").ToString()).ToString("C") %></b>
                                                <p class="Home-GBTab-Text6">成团人数:</p>
                                                <b class="Home-GBTab-Text7"><%#Eval("GB_TotalNumber") %>人</b>
                                                <p class="Home-GBTab-Text8">参与人数:</p>
                                                <b class="Home-GBTab-Text9"><%#Eval("GB_participantsNumber") %>人</b>
                                                <a href="Goods.aspx?GB_ID=<%#Eval("GB_ID") %>" target="_blank" class="button glow button-rounded button-flat-caution Home-GoodsTab-Button">立即查看！</a>
                                            </div>
                                            <span class="label label-<%# Eval("GB_State").ToString() == "True" ? "danger" : "default" %> GB_State" style="color: white;"><%# Eval("GB_State").ToString() == "True" ? "火热进行中" : "已结束" %></span>
                                        </div>

                                    </ItemTemplate>
                                </telerik:RadListView>
                            </div>

                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>"></asp:SqlDataSource>

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
