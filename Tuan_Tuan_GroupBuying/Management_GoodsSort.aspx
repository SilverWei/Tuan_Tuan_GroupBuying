<%@ Page Title="" Language="C#" MasterPageFile="~/Management-Master.master" AutoEventWireup="true" CodeFile="Management_GoodsSort.aspx.cs" Inherits="Management_GoodsSort" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>商品分类管理</title>
    <link href="CSS/Management_GoodsSort.css" rel="stylesheet" />
    <script type="text/javascript">
        function LinkButton2_Click(GS1_ID, GS1_Name) {
            document.cookie = 'RenamingText2 = ' + GS1_ID;//创建Cookies
            var RenamingText1 = document.getElementById("RenamingText1");
            document.cookie = 'RenamingText3 = 1';//创建Cookies检测是否为GS1
            var GS1_Text1 = GS1_Name;
            RenamingText1.innerHTML = GS1_Text1 + " - 重命名";
        }
        function LinkButton3_Click(GS2_ID, GS2_Name) {
            document.cookie = 'RenamingText2 = ' + GS2_ID;//创建Cookies
            var RenamingText1 = document.getElementById("RenamingText1");
            document.cookie = 'RenamingText3 = 2';//创建Cookies检测是否为GS1
            var GS2_Text1 = GS2_Name;
            RenamingText1.innerHTML = GS2_Text1 + " - 重命名";
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div class="Main">
        <div class="row">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server"></telerik:RadStyleSheetManager>
            <div class="box col-md-12">
                <div class="box-inner">
                    <div class="box-header well" data-original-title="">
                        <h2><i class="glyphicon glyphicon-indent-left"></i>商品分类管理 —— 一级</h2>
                    </div>
                    <div class="row">
                        <div class="box col-md-12">
                            <div class="box-content">
                                <telerik:RadListView ID="RadListView1" runat="server" DataSourceID="SqlDataSource1">
                                    <ItemTemplate>
                                        <div class="btn-group">
                                            <a class="btn btn-default" href="Management_GoodsSort.aspx?GS1=<%#Eval("GS1_ID") %>"><%#Eval("GS1_Name") %></a>
                                            <a class="btn btn-default dropdown-toggle" data-toggle="dropdown" href="#"><span class="caret"></span></a>
                                            <ul class="dropdown-menu">
                                                <li onclick="LinkButton2_Click('<%#Eval("GS1_ID") %>','<%#Eval("GS1_Name") %>')">
                                                    <asp:LinkButton ID="LinkButton2" CssClass="btn-setting" CommandArgument='<%#Eval("GS1_ID") %>' CommandName='<%#Eval("GS1_Name") %>' runat="server"><i class="glyphicon glyphicon-pencil"></i> 重命名</asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton ID="GS1Del" CommandArgument='<%#Eval("GS1_ID") %>' OnClick="GS1Del_Click" runat="server"><i class="glyphicon glyphicon-trash"></i> 删除</asp:LinkButton>
                                                </li>
                                            </ul>
                                        </div>
                                    </ItemTemplate>
                                </telerik:RadListView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="select * From [t_GoodsSort1st]"></asp:SqlDataSource>
                                <div class="btn-group">
                                    <a class="btn btn-default">
                                        <asp:TextBox ID="GS1_Add" Style="height: 20px; width: 70px; color: #000;" runat="server" Text="" MaxLength="7"></asp:TextBox>
                                    </a>
                                    <asp:LinkButton ID="GS1_Add_Button" CssClass="btn btn-default" runat="server" OnClick="GS1_Add_Button_Click"> <i class="glyphicon glyphicon-plus"></i>添加分类</asp:LinkButton>

                                </div>
                            </div>
                        </div>
                        <!--/span-->
                    </div>
                </div>
            </div>
            <div class="box col-md-12">
                <div class="box-inner">
                    <div class="box-header well" data-original-title="">
                        <h2><i class="glyphicon glyphicon-indent-left"></i>
                            <asp:Label ID="GS2_Box" runat="server" Text="" ForeColor="Blue"></asp:Label></h2>
                    </div>
                    <div class="row">
                        <div class="box col-md-12">
                            <div class="box-content">
                                <telerik:RadListView ID="RadListView2" runat="server" DataSourceID="SqlDataSource2">
                                    <ItemTemplate>
                                        <div class="btn-group">
                                            <a class="btn btn-default dropdown-toggle" data-toggle="dropdown"><%#Eval("GS2_Name") %> <span class="caret"></span></a>
                                            <ul class="dropdown-menu">
                                                <li onclick="LinkButton3_Click('<%#Eval("GS2_ID") %>','<%#Eval("GS2_Name") %>')">
                                                    <asp:LinkButton ID="LinkButton2" CssClass="btn-setting" CommandArgument='<%#Eval("GS2_ID") %>' CommandName='<%#Eval("GS2_Name") %>' runat="server"><i class="glyphicon glyphicon-pencil"></i> 重命名</asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton ID="GS2Del" CommandArgument='<%#Eval("GS2_ID") %>' OnClick="GS2Del_Click" runat="server"><i class="glyphicon glyphicon-trash"></i> 删除</asp:LinkButton>
                                                </li>
                                            </ul>
                                        </div>
                                    </ItemTemplate>
                                </telerik:RadListView>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>"></asp:SqlDataSource>
                                <div class="btn-group">
                                    <a class="btn btn-default">
                                        <asp:TextBox ID="GS2_Add" Style="height: 20px; width: 70px; color: #000;" runat="server" Text="" MaxLength="7"></asp:TextBox>
                                    </a>
                                    <asp:LinkButton ID="GS2_Add_Button" CssClass="btn btn-default" runat="server" OnClick="GS2_Add_Button_Click"><i class="glyphicon glyphicon-plus"></i>添加分类</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <!--/span-->
                    </div>
                </div>
            </div>

            <!--/span-->
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
                    <p>请输入重命名:</p>
                    <asp:TextBox ID="RenamingTextBox" CssClass="form-control" runat="server" Text="" MaxLength="7"></asp:TextBox>
                </div>
                <input type="hidden" id="RenamingText2" runat="server" value="" />
                <div class="modal-footer">
                    <a class="btn btn-default" data-dismiss="modal">关闭</a>
                    <asp:LinkButton ID="RenamingSave1" OnClick="RenamingSave1_Click" class="btn btn-primary" runat="server">保存</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

