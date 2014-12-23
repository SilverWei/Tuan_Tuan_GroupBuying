<%@ Page Title="" Language="C#" MasterPageFile="~/Nav-Master.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>订单</title>
    <link href="CSS/Orders.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div class="All">
        <div class="Box_Text_Box">
            <i class="glyphicon glyphicon-th-list" style="top: 8px; left: 9px;"></i>
            <p class="Box_Text">订单</p>
        </div>
        <div class="row">
            <div class="box col-md-12">
                <div class="box-inner">
                    <div class="box-content">
                        <table class="table table-striped table-bordered responsive">
                            <%--<thead>
                                <tr>
                                    <th>名称</th>
                                    <th>发布日期</th>
                                    <th>价格</th>
                                    <th>状态</th>
                                    <th>编辑</th>
                                </tr>
                            </thead>--%>
                            <tbody>
                                <tr>
                                    <td style="text-align: center;">收件人 <b style="color:red;">*</b> </td>
                                    <td>
                                        <input class="form-control" id="O_Cnsignee" runat="server" value="" style="width: 200px; height: 30px;" type="text" /></td>

                                </tr>
                                <tr>
                                    <td style="text-align: center;">收件邮编 <b style="color:red;">*</b></td>
                                    <td>
                                        <input class="form-control" id="O_ZipCode" runat="server" value="" style="width: 300px; height: 30px;" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" maxlength="6" onafterpaste="this.value=this.value.replace(/\D/g,'')" /></td>

                                </tr>
                                <tr>
                                    <td style="text-align: center;">收件地址 <b style="color:red;">*</b></td>
                                    <td>
                                        <input class="form-control" id="O_Address" runat="server" value="" style="width: 600px; height: 30px;" type="text" /></td>

                                </tr>
                                <tr>
                                    <td style="text-align: center;">联系电话 <b style="color:red;">*</b></td>
                                    <td>
                                        <input class="form-control" id="O_Phone" runat="server" value="" style="width: 200px; height: 30px;" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" maxlength="15" onafterpaste="this.value=this.value.replace(/\D/g,'')" /></td>

                                </tr>
                                <tr>
                                    <td style="text-align: center;">送货方式 <b style="color:red;">*</b></td>
                                    <td>
                                        <asp:DropDownList ID="OSM_ID" runat="server">
                                            <asp:ListItem Value="1">普通快递送货上门</asp:ListItem>
                                            <asp:ListItem Value="2">加急快递送货上门</asp:ListItem>
                                            <asp:ListItem Value="3">普通邮递</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center;">订货内容<br />
                                        (请详细核对！)</td>
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
                                            <tbody id="G_Show_Box" runat="server">
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center;">总价</td>
                                    <td><asp:Label ID="TotalPriceShow" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align: center;">留言</td>
                                    <td>
                                        <input class="form-control" id="O_Message" style="width: 600px; height: 30px;" type="text" runat="server" /></td>

                                </tr>

                            </tbody>
                        </table>
            <div class="alert alert-danger" runat="server" visible="false" id="ErrorShow">
                    <strong>错误!</strong> * 号文本框为必填内容。
                </div>

                    </div>
                </div>
            </div>
            <!--/span-->
            <asp:LinkButton ID="Submit" runat="server" CssClass="button glow button-rounded button-flat-action" OnClick="Submit_Click" Style="margin: auto; margin-bottom: 10px;margin-right: 50px;">完成</asp:LinkButton>
            <asp:LinkButton ID="LinkButton1" class="button glow button-rounded button-flat-highlight" OnClick="LinkButton1_Click" Style="margin: auto; margin-bottom: 10px;" runat="server">返回购物车</asp:LinkButton>
        </div>
    </div>


</asp:Content>

