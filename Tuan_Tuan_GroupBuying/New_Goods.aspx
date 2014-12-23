<%@ Page Title="" Language="C#" MasterPageFile="~/Management-Master.master" AutoEventWireup="true" CodeFile="New_Goods.aspx.cs" Inherits="New_Goods" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>新建产品页</title>
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
                        <h2><i class="glyphicon glyphicon-gift"></i>新建产品页</h2>
                    </div>
                    <div class="row" style="margin: 0;">
                        <div class="box col-md-12">
                            <div class="form-group">
                                <label>产品名称</label>
                                <input type="text" runat="server" id="G_Name" class="form-control" />
                            </div>
                            <div class="form-group">
                                <label>产品品牌</label>
                                <input type="text" runat="server" id="G_Brand" class="form-control" />
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
                                <input type="text" runat="server" id="G_MarketPrice" class="form-control" name="points" maxlength="10" onkeyup="javascript:CheckInputIntFloat(this);" />
                            </div>
                            <div class="form-group">
                                <label>会员价</label>
                                <input type="text" runat="server" id="G_UserPrice" class="form-control" name="points" maxlength="10" onkeyup="javascript:CheckInputIntFloat(this);" />
                            </div>
                            <div class="form-group">
                                <label>产品库存</label>
                                <input type="text" runat="server" id="G_Amount" class="form-control" name="points" onkeyup="this.value=this.value.replace(/\D/g,'')" maxlength="8" onafterpaste="this.value=this.value.replace(/\D/g,'')" />
                            </div>
                            <div class="form-group">
                                <label for="exampleInputFile">产品照片</label>
                                <telerik:RadAsyncUpload ID="exampleInputFile1" MultipleFileSelection="Automatic" Culture="zh-CN" runat="server" MaxFileInputsCount="5">
                                    <Localization Cancel="取消" DropZone="拖动文件到此处" Remove="移除" Select="选择" />
                                </telerik:RadAsyncUpload>
                                <p class="help-block" id="G_PictureUrl">请选择要发布的产品效果图。最多可上传五张。</p>

                            </div>

                            <div class="form-group">
                                <label>产品详情</label>
                                <div class="clearfix"></div>
                                <textarea class="autogrow" runat="server" id="G_Text" style="height: 214px; margin: 0px; width: 636px;"></textarea>
                            </div>

                            <asp:LinkButton ID="LinkButton1" class="btn btn-default" runat="server" OnClick="LinkButton1_Click">提交</asp:LinkButton>
                                                            <a>
                                    <asp:Button ID="Button2" runat="server" Text="取消" class="btn btn-default"  OnClick="Button2_Click" /></a>

                            <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red" Enabled="False"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <!--/span-->
        </div>

    </div>

</asp:Content>

