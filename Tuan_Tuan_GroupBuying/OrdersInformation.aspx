<%@ Page Title="" Language="C#" MasterPageFile="~/Nav-Master.master" AutoEventWireup="true" CodeFile="OrdersInformation.aspx.cs" Inherits="OrdersInformation" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>订单详细信息页</title>
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

    <%--    <div class="row">
        <div class="box col-md-12">
            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-cog"></i>选项</h2>
                </div>
                <div class="row" style="margin: 0;">
                    <div class="box col-md-12">
                        <div class="Search_Box">
                            <input class="form-control" type="text" style="position: relative; float: left; height: 31px; width: 245px; top: 5px; background-image: none; background-position: 0% 0%; background-repeat: repeat;" />
                            <i class="glyphicon glyphicon-search" style="position: relative; float: left; top: 14px; right: 20px;"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/span-->

    </div>--%>


    <div class="row">
        <div class="box col-md-12">
            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-edit"></i>订单详细信息页</h2>
                    <div class="box-icon">
                    </div>
                </div>
                <div class="box-content" style="padding-bottom: 60px;">
                    <table class="table table-striped table-bordered responsive">
                        <tbody>
                            <tr>
                                <td style="text-align: center; width: 10%">订单编号 </td>
                                <td>
                                    <asp:Label ID="O_ID" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; width: 10%">订单状态 </td>
                                <td>
                                    <span class="label  OS_<%= OS_CSS %>">
                                        <asp:Label ID="OS_Text" runat="server" Text="Label"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; width: 10%">用户名 </td>
                                <td>
                                    <asp:Label ID="U_Name" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;">生成时间 </td>
                                <td>
                                    <asp:Label ID="O_Date" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;">收件人 </td>
                                <td>
                                    <asp:Label ID="O_Cnsignee" runat="server" Text="Label"></asp:Label>

                                </td>

                            </tr>
                            <tr>
                                <td style="text-align: center;">收件邮编 </td>
                                <td>
                                    <asp:Label ID="O_ZipCode" runat="server" Text="Label"></asp:Label>

                                </td>

                            </tr>
                            <tr>
                                <td style="text-align: center;">收件地址</td>
                                <td>
                                    <asp:Label ID="O_Address" runat="server" Text="Label"></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td style="text-align: center;">联系电话</td>
                                <td>
                                    <asp:Label ID="O_Phone" runat="server" Text="Label"></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td style="text-align: center;">送货方式</td>
                                <td>
                                    <asp:Label ID="OSM_ID" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;">订货内容</td>
                                <td>
                                    <table class="table table-striped table-bordered responsive">
                                        <thead>
                                            <tr>
                                                <th>名称</th>
                                                <th>单价</th>
                                                <th>数量</th>
                                                <th>小计</th>
                                            </tr>
                                        </thead>
                                        <telerik:RadListView ID="RadListView3" runat="server" DataSourceID="SqlDataSource3">
                                            <ItemTemplate>
                                                <tr>
                                                    <th><a target="_blank" href="Goods.aspx?<%# Eval("O_GB_Y_N").ToString() == "1"?"GB_ID":"G_ID" %>=<%#Eval("ID") %>"><%#Eval("Name").ToString()!=""?Eval("Name"):"*相关产品已被删除*" %></a></th>
                                                    <th><%# Eval("Price").ToString()!=""?float.Parse(Eval("Price").ToString()).ToString("C"):"*相关产品已被删除*" %></th>
                                                    <th><%#Eval("OG_Quantity") %></th>
                                                    <th><%# float.Parse(Eval("OG_TotalPrice").ToString()).ToString("C") %></th>
                                                </tr>
                                            </ItemTemplate>
                                        </telerik:RadListView>
                                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>"></asp:SqlDataSource>

                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;">总价</td>
                                <td>
                                    <asp:Label ID="TotalPriceShow" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="text-align: center;">留言</td>
                                <td>
                                    <asp:Label ID="O_Message" runat="server" Text="Label"></asp:Label>
                                </td>

                            </tr>

                        </tbody>
                    </table>
                    <div id="State1Box" runat="server" style="width: 90px;float: left;">
                        <div onclick="LinkButton2_Click('<%= Orders_ID %>')">
                            <a class="btn btn-info btn-setting" href="#">
                                <i class="glyphicon glyphicon-edit icon-white"></i>
                                付款
                            </a>
                        </div>

                    </div>
                    <a style="width: 90px;float: left;">
                        <asp:Button ID="Button2" runat="server" class="btn btn-default" Text="返回" OnClick="Button2_Click" /></a>

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
                    <p>请选择要执行的选项:</p>
                    <asp:LinkButton ID="addOrderButton" OnClick="addOrderButton_Click" CssClass="btn btn-primary" runat="server">付款</asp:LinkButton>
                    <asp:LinkButton ID="delOrderButton" OnClick="delOrderButton_Click" CssClass="btn btn-danger" runat="server">取消订单</asp:LinkButton>
                </div>
                <input type="hidden" id="RenamingText2" runat="server" value="" />
                <div class="modal-footer">
                    <a class="btn btn-default" data-dismiss="modal">关闭</a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

