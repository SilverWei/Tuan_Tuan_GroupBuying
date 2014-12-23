<%@ Page Title="" Language="C#" MasterPageFile="~/Home-Master.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="CSS/Home.css" rel="stylesheet" />
    <link href="CSS/Home-GoodsTab.css" rel="stylesheet" />

    <link href="CSS/down.admin5.com.css" rel="stylesheet" />
    <script src="JS/jquery.Loading.js"></script>
    <script src="JS/zcommon.js"></script>


    <script type="text/javascript">
        jQuery(document).ready(function () { AcerUi.init(); });

        jQuery(document).ready(function () {
            jQuery("#Sort_Top_Left_Show").hover(function () {
                jQuery(".Sort_Left2").toggle();
            });
        });
    </script>
    <title>团团数码商城</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server"></telerik:RadStyleSheetManager>
    <div style="height: 3222px;">
        <div class="Sort">
            <div class="Sort_Top_Box">
                <div id="Sort_Top_Left_Show">
                    <div class="Sort_Top_Left_Text">所有商品分类▼</div>
                    <div class="Sort_Left2">
                        <ol style="margin: 0; padding: 0; list-style: none;">
                            <telerik:RadListView ID="RadListView3" runat="server" DataSourceID="SqlDataSource3">
                                <ItemTemplate>
                                    <li><a href="Search.aspx?GS1=<%#Eval("GS1_ID") %>"><%#Eval("GS1_Name") %></a> </li>
                                </ItemTemplate>
                            </telerik:RadListView>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="select * From [t_GoodsSort1st]"></asp:SqlDataSource>
                        </ol>
                    </div>
                </div>
                <a href="Home.aspx" class="Sort_Top_Text">首页</a>
                <a href="Search.aspx" class="Sort_Top_Text">商品</a>
                <a href="SearchGB.aspx" class="Sort_Top_Text">团购</a>
                <a href="Announcement.aspx" class="Sort_Top_Text">公告</a>
                
            </div>
            <div class="Sort_Left">
                <ol style="margin: 0; padding: 0; list-style: none;">
                    <telerik:RadListView ID="RadListView1" runat="server" DataSourceID="SqlDataSource1">
                        <ItemTemplate>
                            <li><a href="Search.aspx?GS1=<%#Eval("GS1_ID") %>"><%#Eval("GS1_Name") %></a> </li>
                        </ItemTemplate>
                    </telerik:RadListView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="select top 7 * From [t_GoodsSort1st]"></asp:SqlDataSource>
                </ol>
            </div>

            <div class="Sort_Right">
                <div id="showcase" class="cloud row-content showcase">
                    <div class="container">
                        <div class="slide" style="display: block;">
                            <div class="content-main-visual">
                                <telerik:RadListView ID="RadListView8" runat="server" DataSourceID="SqlDataSource7">
                                    <ItemTemplate>
                                        <a class="pc" href="Goods.aspx?GB_ID=<%#Eval("GB_ID") %>" target="_blank">
                                            <img src="<%#Eval("GB_PictureUrl") %>" /></a>
                                    </ItemTemplate>
                                </telerik:RadListView>
                            </div>
                            <div class="content-main-feature">
                                <telerik:RadListView ID="RadListView7" runat="server" DataSourceID="SqlDataSource7">
                                    <ItemTemplate>
                                        <div class="feature">
                                            <a href="#" class="current">
                                                <img src="<%#Eval("GB_PictureUrl") %>" />
                                                <div style="background-color:#FFF;" class="timerLine dark-green"></div>
                                                <!-- 进度条 -->
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </telerik:RadListView>
                            </div>
                            <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="Select top 4 * From [t_GroupBuying] Where GB_PictureUrl != '' order by GB_ID desc"></asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="NewGoods">
            <div class="Title_Name_Box">
                <div class="Title_Name_Image"><i class="glyphicon glyphicon-gift red" style="font-size: 30px;"></i></div>
                <div class="Title_Name_Text">最新商品</div>
            </div>
            <div class="NewGoods_All_Box">


                <telerik:RadListView ID="RadListView2" runat="server" DataSourceID="SqlDataSource2">
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
                                <a href="Goods.aspx?G_ID=<%#Eval("G_ID") %>" target="_blank" class="button glow button-rounded button-flat-caution Home-GoodsTab-Button">立即查看！</a>
                            </div>
                        </div>
                    </ItemTemplate>
                </telerik:RadListView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="select top 15 (CASE WHEN LEN([t_Goods].G_Name) >20 THEN SUBSTRING([t_Goods].G_Name, 1,20) + '...' ELSE [t_Goods].G_Name END) AS G_Name1,[t_Goods].*,[t_GoodsPicture].[GP_Url] From [t_Goods] left join (select min(GP_ID) as GP_ID,min(GP_Url) as GP_Url,G_ID from [t_GoodsPicture] group by G_ID) as [t_GoodsPicture] on [t_Goods].G_ID = [t_GoodsPicture].G_ID Where t_Goods.G_State != 'False' order by G_ID desc"></asp:SqlDataSource>

            </div>
        </div>
        <div class="NewGroupBuying">
            <div class="Title_Name_Box">
                <div class="Title_Name_Image"><i class="glyphicon glyphicon-fire red" style="font-size: 30px;"></i></div>
                <div class="Title_Name_Text">最新团购活动</div>
            </div>
            <div class="NewGoods_All_Box">


                <telerik:RadListView ID="RadListView6" runat="server" DataSourceID="SqlDataSource6">
                    <ItemTemplate>
                        <div class="NewGoods_Box">
                                            <a href="Goods.aspx?GB_ID=<%#Eval("GB_ID") %>" target="_blank">
                                                <img src='<%#Eval("GBP_Url") %>' alt="Goods.aspx?G_ID=<%#Eval("GB_ID") %>" class="Home-GoodsTab-Picture">
                                            </a>
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
                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="select top 15 (CASE WHEN LEN([t_GroupBuying].GB_Name) >20 THEN SUBSTRING([t_GroupBuying].GB_Name, 1,20) + '...' ELSE [t_GroupBuying].GB_Name END) AS GB_Name1,t_GroupBuying.*,[t_GroupBuyingPicture].[GBP_Url] From t_GroupBuying left join (select min(GBP_ID) as GBP_ID,min(GBP_Url) as GBP_Url,GB_ID from [t_GroupBuyingPicture] group by GB_ID) as [t_GroupBuyingPicture] on [t_GroupBuying].GB_ID = [t_GroupBuyingPicture].GB_ID order by GB_ID desc"></asp:SqlDataSource>


            </div>
        </div>
        <div class="Announcement">
            <div class="Title_Name_Box">
                <div class="Title_Name_Image"><i class="glyphicon glyphicon-bullhorn red" style="font-size: 30px;"></i></div>
                <div class="Title_Name_Text">最新公告</div>
            </div>
            <telerik:RadListView ID="RadListView5" runat="server" DataSourceID="SqlDataSource5">
                <ItemTemplate>
                    <div class="Announcement_First_Box">
                        <a href="Announcement-show.aspx?An=<%#Eval ("A_ID") %>" target="_blank"><b style="top: 5px; left: 20px; position: relative;"><%#Eval ("A_Name") %></b></a>
                        <p style="width: 95%; margin: auto; position: relative; top: 10px;"><%#Eval ("A_Text1") %></p>
                    </div>
                </ItemTemplate>
            </telerik:RadListView>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="Select top 1 *,(CASE WHEN datalength(A_Text) <= 100 THEN A_Text ELSE SUBSTRING(A_Text, 1, 100) + '...' END) AS A_Text1 From t_Announcement order by A_ID desc"></asp:SqlDataSource>

            <telerik:RadListView ID="RadListView4" runat="server" DataSourceID="SqlDataSource4">
                <ItemTemplate>
                    <div class="Announcement_Box">
                        <a href="Announcement-show.aspx?An=<%#Eval ("A_ID") %>" target="_blank"><b style="top: 5px; left: 20px; position: relative;"><%#Eval ("A_Name") %></b></a>
                        <p style="width: 95%; margin: auto; position: relative; top: 10px;"><%#Eval ("A_Text1") %></p>
                    </div>
                </ItemTemplate>
            </telerik:RadListView>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="Select top 4 *,(CASE WHEN datalength(A_Text) <= 100 THEN A_Text ELSE SUBSTRING(A_Text, 1, 100) + '...' END) AS A_Text1 From t_Announcement Where A_ID not in(Select top 1 A_ID From t_Announcement order by A_ID desc) order by A_ID desc"></asp:SqlDataSource>

        </div>

    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ShoppingCart_Box" runat="Server">
    <a href="ShoppingCart.aspx">
        <div class="ShoppingCart_Box btn btn-danger">
            <p class="ShoppingCart_Text" id="ShoppingCart_Text" runat="server">0</p>
            <div class="ShoppingCart_Image"><i class="glyphicon glyphicon-shopping-cart"></i></div>
        </div>
    </a>
</asp:Content>
