<%@ Page Title="" Language="C#" MasterPageFile="~/Nav-Master.master" AutoEventWireup="true" CodeFile="Users-Center.aspx.cs" Inherits="Users_Center" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>个人中心</title>
        <link href="CSS/OS_CSS.css" rel="stylesheet" />
    <link href="CSS/Users-Center.css" rel="stylesheet" />

 <%--   <script>
        function LinkButton2_Click(O_ID) {
            document.cookie = 'EditOrderID = ' + O_ID;//创建Cookies
            var RenamingText1 = document.getElementById("RenamingText1");
            RenamingText1.innerHTML = O_ID + " - 更改订单状态";
        }

    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div class ="all">
    <div class="row Center_Left" style="margin: auto;">
        <div class="box col-md-12">
            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-user"></i>个人资料</h2>
                </div>
                <div class="row" style="margin: 0; text-align: left;">
                    <div class="box col-md-12" id="Left">
                            <div class="form-group">
                                <p>用户名：</p>
                                <p id="U_Name" runat="server"></p>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group">
                                <p>真实姓名：</p>
                                <p id="U_RealName" runat="server"></p>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group">
                                <p>性别：</p>
                                <p id="U_Sex" runat="server"></p>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group">
                                <p>出生日期：</p>
                                <p id="U_Birthday" runat="server"></p>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group">
                                <p>手机：</p>
                                <p id="U_Phone" runat="server"></p>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group">
                                <p>E-mail：</p>
                                <p id="U_Email" runat="server"></p>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group">
                                <p>注册时间：</p>
                                <p id="U_SignUP" runat="server"></p>
                            </div>
                            <div class="clearfix"></div>
<%--                            <div class="form-group">
                                <p>会员等级：</p>
                                <p id="U_Rank" runat="server"></p>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group">
                                <p>会员积分：</p>
                                <p id="U_Points" runat="server"></p>
                            </div>
                            <div class="clearfix"></div>--%>
                            <a href="Users-Center-Modify.aspx" class="btn btn-info"><i class="glyphicon glyphicon-cog"></i>修改个人资料</a>
                    </div>

                    <div class="row" style="margin: 0; text-align: right;">                     
                        
                          </div>
            </div>
            <!--/span-->
   
            </div>


    </div>
        </div> 
           <div class="Main_Right">

            <div class="row">
                <div class="box col-md-12">
                    <div class="box-inner">
                        <div class="box-content" style="background-color: #FFF;">
                            <div class="box-content">
                                <ul class="nav nav-tabs" >
                                    <li class="active"><asp:HyperLink ID="HyperLink2" runat="server"  ForeColor="Red">普通商品</asp:HyperLink></li>                                   
                                    <li><asp:HyperLink ID="HyperLink1" NavigateUrl="~/Users-CenterGB.aspx" runat="server"  ForeColor="Red">团购商品</asp:HyperLink></li>                                 
                                </ul>



                                 <telerik:RadListView ID="RadListView3" runat="server" AllowPaging="True" ItemPlaceholderID="item" PageSize="10" DataSourceID="SqlDataSource4">
                                <LayoutTemplate>
                                    <table class="table table-striped table-bordered responsive">
                                        <thead>
                                            <tr>
                                              <th>订单编号</th>
                                              <th>生成日期</th>
                                              <th>总计</th>
                                              <th>状态</th>
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
                                              
                               <%--     <div onclick="LinkButton2_Click('<%#Eval("[O_ID]") %>')">
                                        <a class="btn btn-info btn-setting" href="#">
                                            <i class="glyphicon glyphicon-edit icon-white"></i>
                                            状态编辑
                                        </a>
                                    </div>--%>
                                
                                      </tr>
                                </ItemTemplate>
                            </telerik:RadListView>
                                 <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>"></asp:SqlDataSource>

                              


                          <%--      <div class="row">
                                    <div class="col-md-12">
                                        <div class="dataTables_info" id="Div3">Showing 1 to 10 of 32 entries</div>
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
                </div>
            </div>
        </div>
        
        </div>

  <%--  <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">×</button>
                    <h3 id="RenamingText1"></h3>
                </div>
                <div class="modal-body">
                    <p>请修改订单状态:</p>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="OS_Name" DataValueField="OS_ID"></asp:RadioButtonList>
                  
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="Select * From t_OrdersSort Where OS_ID >5"></asp:SqlDataSource>
                </div>
                <input type="hidden" id="RenamingText2" runat="server" value="" />
                <div class="modal-footer">
                    <a class="btn btn-default" data-dismiss="modal">关闭</a>
                    <asp:LinkButton ID="EditOrderButton" OnClick="EditOrderButton_Click" CssClass="btn btn-primary" runat="server">保存</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>--%>

</asp:Content>

