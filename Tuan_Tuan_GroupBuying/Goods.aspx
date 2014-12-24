<%@ Page Title="" Language="C#" MasterPageFile="~/Nav-Master.master" AutoEventWireup="true" CodeFile="Goods.aspx.cs" Inherits="Goods" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title><%= Label1.Text %> - 商品详情</title>
    <link href="CSS/buttons.css" rel="stylesheet" />
    <link href="CSS/Goods.css" rel="stylesheet" />
    <script>
        //
        //   █████▒█    ██  ▄████▄   ██ ▄█▀       ██████╗ ██╗   ██╗ ██████╗
        // ▓██   ▒ ██  ▓██▒▒██▀ ▀█   ██▄█▒        ██╔══██╗██║   ██║██╔════╝
        // ▒████ ░▓██  ▒██░▒▓█    ▄ ▓███▄░        ██████╔╝██║   ██║██║  ███╗
        // ░▓█▒  ░▓▓█  ░██░▒▓▓▄ ▄██▒▓██ █▄        ██╔══██╗██║   ██║██║   ██║
        // ░▒█░   ▒▒█████▓ ▒ ▓███▀ ░▒██▒ █▄       ██████╔╝╚██████╔╝╚██████╔╝
        //  ▒ ░   ░▒▓▒ ▒ ▒ ░ ░▒ ▒  ░▒ ▒▒ ▓▒       ╚═════╝  ╚═════╝  ╚═════╝
        //  ░     ░░▒░ ░ ░   ░  ▒   ░ ░▒ ▒░
        //  ░ ░    ░░░ ░ ░ ░        ░ ░░ ░
        //           ░     ░ ░      ░  ░
        //                 ░
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div class="all">
        <p style="position: relative; top: 0px; text-align: left; margin: 0; font-size: 13px;">
            <asp:HyperLink ID="Label13" NavigateUrl="~/Search.aspx" runat="server" Text="Label" Target="_blank"></asp:HyperLink>
            >
            <asp:HyperLink ID="Label12" NavigateUrl="~/Search.aspx" runat="server" Text="Label" Target="_blank"></asp:HyperLink>
            >
            <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
        </p>
        <div class="main1">
            <div class="main2">
                <div class="thumbnail main4" style="display: table-cell; vertical-align: middle">
                    <a style="max-width: 310px; max-height: 330px; margin-left: auto; margin-right: auto;" href="<%= Pic1 %>">
                        <img style="max-width: 310px; max-height: 330px; margin-left: auto; margin-right: auto;" src="<%= Pic1 %>">
                    </a>
                </div>
                <div class="main5">
                    <div class="thumbnail pic2" style="padding: 0; margin: 1px; visibility: <%= Pic2!=""?"visible":"hidden" %>">
                        <a class="pic2_Img" style="background: url(<%= Pic2 %>)" href="<%= Pic2 %>">
                            <img style="max-height: 100px;" src="<%= Pic2 %>">
                        </a>
                    </div>
                    <div class="thumbnail pic2" style="padding: 0; margin: 1px; visibility: <%= Pic3!=""?"visible":"hidden" %>">
                        <a class="pic2_Img" style="background: url(<%= Pic3 %>)" href="<%= Pic3 %>">
                            <img style="max-height: 100px;" src="<%= Pic3 %>">
                        </a>
                    </div>
                    <div class="thumbnail pic2" style="padding: 0; margin: 1px; visibility: <%= Pic4!=""?"visible":"hidden" %>">
                        <a class="pic2_Img" style="background: url(<%= Pic4 %>)" href="<%= Pic4 %>">
                            <img style="max-height: 100px;" src="<%= Pic4 %>">
                        </a>
                    </div>
                    <div class="thumbnail pic2" style="padding: 0; margin: 1px; visibility: <%= Pic5!=""?"visible":"hidden" %>">
                        <a class="pic2_Img" style="background: url(<%= Pic5 %>)" href="<%= Pic5 %>">
                            <img style="max-height: 100px;" src="<%= Pic5 %>">
                        </a>
                    </div>
                </div>
            </div>


            <div class="main3">
                <div class="txt1">
                    <b>
                        <asp:Label ID="Label1" runat="server" Text="小米官方旗舰店MIUI/小米 红米Note4G增强版移动版智能手机包邮"></asp:Label></b>

                </div>
                <div class="txt2" id="State1" visible="false" runat="server">
                    <b>
                        <span class="label-success label label-default" style="color: white;">团购活动进行中</span>
                </div>
                <div class="txt2" id="State2" visible="false" runat="server">
                    <b>
                        <span class="label-success label label-default" style="color: white;">热卖进行中</span>
                </div>
                <div class="txt2" id="State3" visible="false" runat="server">
                    <b>
                        <span class="label label-default" style="color: white;">团购活动已停止</span>
                </div>
                <div class="txt2" id="State4" visible="false" runat="server">
                    <b>
                        <span class="label label-default" style="color: white;">商品热卖已结束</span>
                </div>
                <div class="txt7">
                    <b>
                        <asp:Label ID="Label2" runat="server" Text="品牌: 小米公司"></asp:Label>
                    </b>
                    <b style="float: right; font-size: 9px;">
                        <asp:Label ID="Label15" runat="server" Text="发布日期: 1234567"></asp:Label>
                    </b>
                                        <div class="clearfix"></div>

                    <b style="float: right; font-size: 9px;">
                        <asp:Label ID="Label16" runat="server"></asp:Label>
                    </b>
                </div>
                <div class="txt3">
                    <div class="txt4">
                        <div class="txt5">
                            <asp:Label ID="Label3" runat="server" Text="市场价" ForeColor="Gray"></asp:Label>
                            <s>
                                <asp:Label ID="Label4" runat="server" Text="￥700.00" ForeColor="Gray"></asp:Label>
                            </s>
                            <asp:Label ID="Label14" runat="server" Text="" CssClass="GB_TotalNumber"></asp:Label>
                        </div>
                        <asp:Label ID="Label5" Visible="false" runat="server" Text="预定人数: 300人" Style="color: #996600; right: 20px; top: 10px; position: absolute;"></asp:Label>
                        <div class="txt6">
                            <asp:Label ID="Label6" runat="server" Text="会员价" ForeColor="Gray"></asp:Label>

                            <asp:Label ID="Label7" runat="server" Text="￥999.00" ForeColor="Red" Font-Size="18pt"></asp:Label>
                        </div>
                        <asp:Label CssClass="Inventory" Visible="true" ID="Label8" runat="server" Text="库存13920件"></asp:Label>
                        <asp:HiddenField ID="HiddenField1" runat="server" Value=""/>
                    </div>
                    <div class="main6">
                        <table style="width: 400px; font-size: 12px; margin-left: 0px;">
                            <tr>
                                <td style="text-align: left;" class="auto-style1">数量</td>
                                <td class="auto-style1">
                                    <input type="text" id="Quantity" runat="server" onkeypress="if(event.keyCode==13||event.which==13){return false;}" class="form-control" name="points" onkeyup="this.value=this.value.replace(/\D/g,'');if(parseFloat(this.value) > parseFloat(Main_Main_HiddenField1.value) || parseFloat(this.value) == 0){this.value=''}" maxlength="6" onafterpaste="this.value=this.value.replace(/\D/g,'');if(parseFloat(this.value) > parseFloat(Main_Main_HiddenField1.value) || parseFloat(this.value) == 0){this.value=''}" value="1" /></td>
                                <td class="auto-style1">
                                    <asp:Label ID="Label11" runat="server" Width="10px" Text="件"></asp:Label></td>
                            </tr>
                        </table>
                        <div class="btn3">
                            <div class="btn2" id="ShoppingCartAdd" runat="server" visible="false">
                                <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" class="button glow button-rounded button-flat-caution" runat="server">加入购物车</asp:LinkButton>
                                <a id="LinkButton3" visible="false" class="button disabled glow button-rounded button-flat-caution" runat="server">已加入购物车</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>



        <div class="Box_Text_Box" style="width: 830px">
            <i class="glyphicon glyphicon-list-alt" style="top: 8px; left: 9px;"></i>
            <p class="Box_Text">商品详情</p>
        </div>
        <div class="row" style="width: 860px">
            <div class="box col-md-12">
                <div class="box-inner">
                    <div class="box-content" style="text-align: left;">
                        <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ShoppingCart_Box" runat="Server">
    <%--    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">清空购物车</asp:LinkButton>--%>
    <a href="ShoppingCart.aspx">
        <div class="ShoppingCart_Box btn btn-danger">
            <p class="ShoppingCart_Text" id="ShoppingCart_Text" runat="server">0</p>
            <div class="ShoppingCart_Image"><i class="glyphicon glyphicon-shopping-cart"></i></div>
        </div>
    </a>

</asp:Content>
