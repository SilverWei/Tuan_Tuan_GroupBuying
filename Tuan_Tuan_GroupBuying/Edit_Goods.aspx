<%@ Page Title="" Language="C#" MasterPageFile="~/Management-Master.master" AutoEventWireup="true" CodeFile="Edit_Goods.aspx.cs" Inherits="Edit_Goods" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>编辑产品页</title>
    <link href="CSS/New_Goods.css" rel="stylesheet" />
        <script>
            function CheckInputIntFloat(oInput) {
                if ('' != oInput.value.replace(/\d{1,}\.{0,1}\d{0,}/, '')) {
                    oInput.value = oInput.value.match(/\d{1,}\.{0,1}\d{0,}/) == null ? '' : oInput.value.match(/\d{1,}\.{0,1}\d{0,}/);
                }
            }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server"></telerik:RadStyleSheetManager>
    <div class="Main">

        <div class="row">
            <div class="box col-md-12">
                <div class="box-inner">
                    <div class="box-header well" data-original-title="">
                        <h2><i class="glyphicon glyphicon-gift"></i>编辑产品页</h2>
                    </div>
                    <div class="row" style="margin: 0;">
                        <div class="box col-md-12">
                            <form role="form">
                                <div class="form-group">
                                    <label>产品名称</label>
                                    <asp:TextBox ID="AddName" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>产品品牌</label>
                                    <asp:TextBox ID="AddBrand" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>产品类型</label>
                                    <div class="clearfix"></div>
                                <asp:DropDownList ID="G_GS1" runat="server" DataSourceID="SqlDataSource1" DataTextField="GS1_Name" DataValueField="GS1_ID" AutoPostBack="true" OnSelectedIndexChanged="G_GS1_SelectedIndexChanged"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="select * From [t_GoodsSort1st]"></asp:SqlDataSource>
                                <asp:DropDownList ID="G_GS2" runat="server" DataSourceID="SqlDataSource2" DataTextField="GS2_Name" DataValueField="GS2_ID"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ConnectionStrings:Tuan Tuan GroupBuying%>" SelectCommand="select * From [t_GoodsSort2nd] Where GS1_ID = (Select top 1 GS1_ID From t_GoodsSort1st)"></asp:SqlDataSource>
                                </div>
                                <div class="form-group">
                                    <label>市场价</label>
                                    <asp:TextBox ID="AddMarketPrice" class="form-control" runat="server" MaxLength="10" onkeyup="javascript:CheckInputIntFloat(this);"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <label>会员价</label>
                                    <asp:TextBox ID="AddUserPrice" class="form-control" MaxLength="10" runat="server" onkeyup="javascript:CheckInputIntFloat(this);"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <label>产品库存</label>
                                    <asp:TextBox ID="AddAmount" class="form-control" runat="server" onkeyup="this.value=this.value.replace(/\D/g,'')" maxlength="8" onafterpaste="this.value=this.value.replace(/\D/g,'')"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputFile">产品照片</label>
                                    <telerik:RadAsyncUpload ID="exampleInputFile1" MultipleFileSelection="Automatic" Culture="zh-CN" runat="server" MaxFileInputsCount="5">
                                        <Localization Cancel="取消" DropZone="拖动文件到此处" Remove="移除" Select="选择" />
                                    </telerik:RadAsyncUpload>
                                    <p class="help-block">请选择要重新发布的产品效果图。</p>
                                </div>
                                <div class="form-group">
                                    <label>产品状态</label>
                                    <asp:RadioButtonList ID="AddState" runat="server">
                                        <asp:ListItem Value="1">发布中</asp:ListItem>
                                        <asp:ListItem Value="0">停用</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>

                                <div class="form-group">
                                    <label>产品详情</label>
                                    <div class="clearfix"></div>
                                    <asp:TextBox ID="AddText" runat="server" CssClass="autogrow" TextMode="MultiLine" Style="height: 214px; margin: 0px; width: 636px;"></asp:TextBox>

                                </div>
                                <a href="Management-Goods.aspx" class="btn btn-default">
                                    <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" /></a>
                                <a>
                                    <asp:Button ID="Button2" runat="server" class="btn btn-default" Text="取消" OnClick="Button2_Click" /></a>
                                <asp:Label ID="Label1" runat="server" Text="" Enabled="False"></asp:Label>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <!--/span-->
        </div>

    </div>


</asp:Content>

