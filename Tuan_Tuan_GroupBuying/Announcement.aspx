<%@ Page Title="" Language="C#" MasterPageFile="~/Nav-Master.master" AutoEventWireup="true" CodeFile="Announcement.aspx.cs" Inherits="Announcement" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>公告</title>
    <link href="CSS/Announcement.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div class="All">
        <div class="Box_Text_Box">
            <i class="glyphicon glyphicon-bullhorn" style="top: 8px; left: 9px;"></i>
            <p class="Box_Text">公告列表</p>
        </div>

        <div class="row">
            <div class="box col-md-12">
                <div class="box-inner">
                    <div class="box-content">

                        <%--     <div class="well">
                            <div class="main3">
                                <div class="txt2">
                                    <a href="Announcement-show1.aspx">
                                        <asp:Label ID="Label14" runat="server" Text="10月11日-天天嘉年华大促信息总览"></asp:Label></a>
                                </div>
                                <div class="txt4">
                                    <asp:Label ID="Label15" runat="server" Text="发布者：xx &nbsp;&nbsp;&nbsp; 时间：2014-10-10"></asp:Label>
                                </div>
                                <div class="txt3">
                                    <asp:Label ID="Label16" runat="server" Text="为了方便亲们了解大促信息，小编特意制作了11月11日-淘宝嘉年华大促信息总览。所有有关11月11日-淘宝嘉年华的官方信息全部收录在这份目录中，并按照活动的进程进行了编号。不管您在什么时间点关注我们的大促，您都可以通过这份目录了解到11月11日-淘宝嘉年华的点点滴滴。如有新帖发布，小编也会第一时间更新在这份目录中。"></asp:Label>
                                </div>
                            </div>
                        </div>--%>

                          <telerik:RadListView ID="RadListView3" runat="server" AllowPaging="True" ItemPlaceholderID="item" PageSize="10" DataSourceID="SqlDataSource4">  
                             <LayoutTemplate>
                                 <table>
                                     <thead id="item" runat="server"></thead>

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
                            <div class="NewGoods_Box">                            
                                  <div class="txt2">
                                        <a href="Announcement-show.aspx?An=<%#Eval ("A_ID") %>" target="_blank">
                                            <asp:Label ID="AnName" runat="server" Text='<%#Eval ("A_Name") %>'></asp:Label></a>
                                    </div>
                                    <div class="txt4">

                                        <asp:Label ID="AnReleaseDate" runat="server" Text='<%#Eval("[A_ReleaseDate]","{0:yyyy年 MM月 dd日}") %>'></asp:Label>
                                    </div>
                                    <div class="txt3">
                                        <asp:Label ID="AnText" runat="server" Text='<%#Eval ("A_Text2") %>'></asp:Label>
                                    </div>
                            </div>
                        </ItemTemplate>
                     </telerik:RadListView>                                         
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="SELECT *,SUBSTRING(A_Text, 1, 115) + '...' as A_Text2  FROM t_Announcement order by A_ID desc"></asp:SqlDataSource>




                        <%--                        <div class="row">
                            <div class="col-md-12">
                                <div class="dataTables_info" id="DataTables_Table_0_info">Showing 1 to 10 of 32 entries</div>
                            </div>
                            <div class="col-md-12 center-block">
                                <div class="dataTables_paginate paging_bootstrap pagination">
                                    <ul class="pagination">
                                        <li class="prev disabled"><a href="#">← Previous</a></li>
                                        <li class="active"><a href="#">1</a></li>
                                        <li><a href="#">2</a></li>
                                        <li><a href="#">3</a></li>
                                        <li><a href="#">4</a></li>
                                        <li class="next"><a href="#">Next → </a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
            <!--/span-->
        </div>
    </div>



</asp:Content>

