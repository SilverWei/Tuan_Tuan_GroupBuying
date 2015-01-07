<%@ Page Title="" Language="C#" MasterPageFile="~/Nav-Master.master" AutoEventWireup="true" CodeFile="OrdersSortGB.aspx.cs" Inherits="OrdersSortGB" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>订单状态</title>
    <link href="CSS/OrdersSort.css" rel="stylesheet" />
    <link href="CSS/OS_CSS.css" rel="stylesheet" />
    <script>
        function LinkButton2_Click(O_ID) {
            document.cookie = 'EditOrderID = ' + O_ID;//创建Cookies
            var RenamingText1 = document.getElementById("RenamingText1");
            RenamingText1.innerHTML = O_ID + " - 更改订单状态";
        }

    </script>

    <%-- <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            height: 26px;
            width: 53px;
        }
        .auto-style3 {
            width: 53px;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div class="all">
        <div class="Main_Left">
            <div class="Box_Text_Box">
                <i class="glyphicon glyphicon-chevron-down" style="top: 8px; left: 9px;"></i>
                <p class="Box_Text">总计</p>
            </div>
            <div class="row">
                <div class="box col-md-12">
                    <div class="box-inner">
                        <div class="box-content">
                            <table class="table table-striped table-bordered responsive">
                                <thead>
                                    <tr>
                                        <th>总消费：¥ <%= OG_TotalPrice == ""?"0":OG_TotalPrice %></th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                </div>
               

            </div>
        </div>



        <div class="Main_Right" >
            <div class="row">
                <div class="box col-md-12">
                    <div class="box-inner">
                        <div class="box-content" style="background-color: #FFF;">
                            <div class="box-content">
                                <ul class="nav nav-tabs">  
                                  <li ><asp:HyperLink ID="HyperLink2" NavigateUrl="~/OrdersSort.aspx" runat="server"  ForeColor="Red">普通商品</asp:HyperLink></li>  
                                   <li class="active"><asp:HyperLink ID="HyperLink1" runat="server"  ForeColor="Red">团购商品</asp:HyperLink></li>
                                </ul>

                         
                                <telerik:RadListView ID="RadListView3" runat="server" AllowPaging="True" ItemPlaceholderID="item" PageSize="10" DataSourceID="SqlDataSource4">
                                    <LayoutTemplate>
                                          <div id="myTabContent" class="tab-content" style="margin-top: 20px;">
                                        <table class="table table-striped table-bordered responsive">
                                            <thead>
                                                <tr>
                                                    <th>订单编号</th>
                                                    <th>生成日期</th>
                                                    <th>总计</th>
                                                    <th>状态</th>
<%--                                                    <th>编辑</th>--%>
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
                                            <td><a href="OrdersInformation.aspx?O_ID=<%#Eval("[O_ID]") %>&BUrl=<%= Request.Url.ToString()%>"><%#Eval("[O_ID]") %></a></td>

                                            <td class="center"><%#Eval("[O_buyDate]","{0:yyyy年 MM月 dd日 HH:mm:ss}") %></td>
                                            <td class="center">¥ <%#Eval("[OG_TotalPrice]") %></td>
                                            <td class="center">
                                                <span class="label OS_<%#Eval("[OS_ID]") %>"><%#Eval("[OS_Name]") %></span>
                                            </td>
<%--                                              <td class="center" style="width: 10%">
                                                <div onclick="LinkButton2_Click('<%#Eval("[O_ID]") %>')">
                                                    <a class="btn btn-info btn-setting" href="#">
                                                        <i class="glyphicon glyphicon-edit icon-white"></i>
                                                        状态编辑
                                                    </a>
                                                </div>--%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>                                   
                                </telerik:RadListView>
                                 

                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>"></asp:SqlDataSource>
                                                                     
                            </div>
                             </div>
                        </div>

                    </div>





                        <div class="alert alert-info">
                            请您在一周内依据您选择的支付方式进行汇款，汇款时请注明您的订单号。为了更及时地为您服务，当您汇完款，请至网站留言！
                         
                        
                    </div>
                </div>
            </div>
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
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="OS_Name" DataValueField="OS_ID"></asp:RadioButtonList>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="Select * From t_OrdersSort Where OS_ID >=3 and OS_ID<=5"></asp:SqlDataSource>
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

