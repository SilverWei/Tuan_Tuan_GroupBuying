<%@ Page Title="" Language="C#" MasterPageFile="~/Nav-Master.master" AutoEventWireup="true" CodeFile="ShoppingCartGB.aspx.cs" Inherits="ShoppingCartGB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>购物车</title>
    <link href="CSS/ShoppingCart.css" rel="stylesheet" />
    <script>
        function NumberEdit_Click(SC_ID1, SC_ID2, SC_Name) {
            document.cookie = 'SC_ID1 = ' + SC_ID1;//创建Cookies检测ID
            document.cookie = 'SC_ID2 = ' + SC_ID2;//创建Cookies检测G/GB
            document.getElementById("EditText1").innerHTML = SC_Name + "-修改购买数量";
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div class="All">
        <div class="Box_Text_Box">
            <i class="glyphicon glyphicon-shopping-cart" style="top: 8px; left: 9px;"></i>
            <p class="Box_Text">购物车</p>
        </div>
        <div class="row">
            <div class="box col-md-12">
                <div class="box-inner">
                    <div class="box-content" style="background-color: #FFF;">
                        <div class="box-content">
                            <ul class="nav nav-tabs">
                                <li>
                                    <asp:HyperLink ID="HyperLink2" NavigateUrl="~/ShoppingCart.aspx" runat="server" ForeColor="Red">普通商品</asp:HyperLink></li>
                                <li class="active">
                                    <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Red">团购商品</asp:HyperLink></li>
                            </ul>

                            <div id="myTabContent" class="tab-content" style="margin-top: 20px;">

                                <%-- 要进行分页 --%>
                                <%-- 要进行分页 --%>
                                <%-- 要进行分页 --%>
                                <%-- 要进行分页 --%>
                                <%-- 要进行分页 --%>
                                <%-- 要进行分页 --%>
                                <%-- 要进行分页 --%>
                                <%-- 要进行分页 --%>
                                <%-- 要进行分页 --%>
                                <div class="tab-pane active" id="tab2">
                                    <table class="table table-striped table-bordered responsive">
                                        <thead>
                                            <tr>
                                                <th>名称</th>
                                                <th style="width: 10%;">缩略图</th>
                                                <th>团购价</th>
                                                <th>数量</th>
                                                <th>小计</th>
                                                <th style="width: 20%;">编辑</th>
                                            </tr>
                                        </thead>

                                        <tbody id="GB_Show_Box" runat="server">
                                            <tr>
                                                <p>您还没有选择商品!</p>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <a href="Search.aspx" class="button glow button-rounded button-flat-highlight">继续购物</a>

                                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="button glow button-rounded button-flat-caution" OnClick="LinkButton2_Click">清空购物车</asp:LinkButton>

                                </div>
                            </div>
                        </div>
                    </div>
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
                    <h3 id="EditText1">修改购买数量</h3>
                </div>
                <div class="modal-body">
                    <input type="text" id="NumberEdit" runat="server" class="form-control" name="points" maxlength="6" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" value="1" />
                </div>
                <input type="hidden" id="DelText2" runat="server" value="" />
                <div class="modal-footer">
                    <a class="btn btn-default" data-dismiss="modal">关闭</a>
                    <asp:LinkButton ID="DelButton1" OnClick="DelButton1_Click" class="btn btn-primary" runat="server">确定</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

