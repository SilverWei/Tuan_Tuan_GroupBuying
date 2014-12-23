<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Management-Landed.aspx.cs" Inherits="Management_Landed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登陆-团团商城后台管理系统</title>
    <link href="CSS/Management-Landed.css" rel="stylesheet" />
    <meta http-equiv="x-ua-compatible" content="IE=Edge" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="usmanhalalit/css/charisma-app.css" rel="stylesheet" />
    <link href="usmanhalalit/css/bootstrap-cerulean.min.css" rel="stylesheet" />
    <script src="usmanhalalit/bower_components/jquery/jquery.min.js"></script>

    <!-- The styles -->

    <link href="usmanhalalit/css/charisma-app.css" rel="stylesheet" />
    <link href='usmanhalalit/bower_components/fullcalendar/dist/fullcalendar.css' rel='stylesheet' />
    <link href='usmanhalalit/bower_components/fullcalendar/dist/fullcalendar.print.css' rel='stylesheet' media='print' />
    <link href='usmanhalalit/bower_components/chosen/chosen.min.css' rel='stylesheet' />
    <link href='usmanhalalit/bower_components/colorbox/example3/colorbox.css' rel='stylesheet' />
    <link href='usmanhalalit/bower_components/responsive-tables/responsive-tables.css' rel='stylesheet' />
    <link href='usmanhalalit/bower_components/bootstrap-tour/build/css/bootstrap-tour.min.css' rel='stylesheet' />
    <link href='usmanhalalit/css/jquery.noty.css' rel='stylesheet' />
    <link href='usmanhalalit/css/noty_theme_default.css' rel='stylesheet' />
    <link href='usmanhalalit/css/elfinder.min.css' rel='stylesheet' />
    <link href='usmanhalalit/css/elfinder.theme.css' rel='stylesheet' />
    <link href='usmanhalalit/css/jquery.iphone.toggle.css' rel='stylesheet' />
    <link href='usmanhalalit/css/uploadify.css' rel='stylesheet' />
    <link href='usmanhalalit/css/animate.min.css' rel='stylesheet' />
    <link rel="Shortcut Icon" href="images/Logo3.png" />

</head>
<body class="All">
    <form id="form1" runat="server">
        <div class="Main">
            <div class="Logo_Box">

                <img src="/images/logo2.png" alt="" class="Logo_Image" />
                <a href="Home.aspx" class="Logo_Text1">团团商城</a>
                <a href="Home.aspx" class="Logo_Text2">tuantuan.com</a>
                <a href="Management-Goods.aspx" class="Logo_Text3">后台管理系统</a>

            </div>
            <div class="Landed">

                <div class="row">


                    <div class="row">

                        <div class="well center login-box">
                            <fieldset>
                                <div class="row" style="height: 70px;">
                                    <div class="col-md-12 center login-header" style="padding: 0; position: relative; top: 0;">
                                        <h2>登录</h2>
                                    </div>
                                    <!--/span-->
                                </div>
                                <!--/row-->

                                <div class="input-group input-group-lg">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user red"></i></span>

                                    <input id="UA_Name_Text" class="form-control" runat="server" placeholder="用户名" type="text" style="background-image: none; background-position: 0% 0%; background-repeat: repeat;" />
                                </div>
                                <div class="clearfix"></div>
                                <br />

                                <div class="input-group input-group-lg">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock red"></i></span>
                                    <input id="UA_Password_Text" class="form-control" runat="server" placeholder="密码" type="password" />
                                </div>
                                <div class="clearfix"></div>
                                <div class="alert alert-danger" id="WrongShow" runat="server" visible="false">
                                    <p runat="server" id="WrongText"></p>
                                </div>
                                <div class="clearfix"></div>
                                <p class="center col-md-5" style="position: relative; top: 0;">
                                    <a href="Management-Goods.aspx">
                                        <asp:Button ID="Button1" runat="server" Text="登录" class="btn btn-primary" OnClick="Button1_Click" /></a>

                                </p>
                                <%--                                <p>登陆名:abc 密码:456123</p>--%>
                            </fieldset>

                        </div>
                        <!--/span-->
                    </div>
                    <!--/row-->
                </div>
            </div>
        </div>
    </form>
    <script src="usmanhalalit/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>

    <!-- library for cookie management -->
    <script src="usmanhalalit/js/jquery.cookie.js"></script>
    <!-- calender plugin -->
    <script src='usmanhalalit/bower_components/moment/min/moment.min.js'></script>
    <script src='usmanhalalit/bower_components/fullcalendar/dist/fullcalendar.min.js'></script>
    <!-- data table plugin -->
    <script src='usmanhalalit/js/jquery.dataTables.min.js'></script>

    <!-- select or dropdown enhancer -->
    <script src="usmanhalalit/bower_components/chosen/chosen.jquery.min.js"></script>
    <!-- plugin for gallery image view -->
    <script src="usmanhalalit/bower_components/colorbox/jquery.colorbox-min.js"></script>
    <!-- notification plugin -->
    <script src="usmanhalalit/js/jquery.noty.js"></script>
    <!-- library for making tables responsive -->
    <script src="usmanhalalit/bower_components/responsive-tables/responsive-tables.js"></script>
    <!-- tour plugin -->
    <script src="usmanhalalit/bower_components/bootstrap-tour/build/js/bootstrap-tour.min.js"></script>
    <!-- star rating plugin -->
    <script src="usmanhalalit/js/jquery.raty.min.js"></script>
    <!-- for iOS style toggle switch -->
    <script src="usmanhalalit/js/jquery.iphone.toggle.js"></script>
    <!-- autogrowing textarea plugin -->
    <script src="usmanhalalit/js/jquery.autogrow-textarea.js"></script>
    <!-- multiple file upload plugin -->
    <script src="usmanhalalit/js/jquery.uploadify-3.1.min.js"></script>
    <!-- history.js for cross-browser state change on ajax -->
    <script src="usmanhalalit/js/jquery.history.js"></script>
    <!-- application script for Charisma demo -->
    <script src="usmanhalalit/js/charisma.js"></script>

</body>
</html>
