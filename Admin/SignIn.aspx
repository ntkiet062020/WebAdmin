<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="TKS_Thuc_Tap_Web.WebAdmin.Admin.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <!-- Basic Page Needs
    ================================================== -->
    <meta charset="utf-8">
    <title>TKSolution - Core System</title>
    <!-- Favicon
        ============================================== -->
    <!-- Favicon <link rel="shortcut icon" href="/WebAdmin/media/img/favicon.png">
    <!-- Mobile Specific
    ================================================== -->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <!-- CSS Files
    ================================================== -->
    <link rel="stylesheet" type="text/css" href="/WebAdmin/media/css/bootstrap.css">
    <link rel="stylesheet" type="text/css" href="/WebAdmin/media/css/font-awesome.css">
    <link rel="stylesheet" type="text/css" href="/WebAdmin/media/css/login.css">
    <link rel="stylesheet" type="text/css" href="/WebAdmin/media/css/responsive.css">

    <!--[if lt IE 9]>
	    <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
</head>
<body id="particles">

    <div class="VD" style="display: inline-block; position:fixed;">
        <div class="pull-right">
            <div class="group-box-login">
                <div class="title">
                    <img src="/webadmin/media/img/logo.png">
                    <span><h4 style="color:#fff;">TKSOLUTION CORE V4</h4>
                    </span>
                </div>
                <form id="loginForm" method="POST" runat="server">
                <asp:Literal ID="litError" runat="server"></asp:Literal>
                <div class="content">
                    <div class="form-group">
                        <input type="text" runat="server" class="form-control" id="txtMa_Dang_Nhap" placeholder="Mã đăng nhập" style="border-radius: 10px 10px 0 0;height:38px;" />
                    </div>
                    <div class="form-group">
                        <input type="password" runat="server" class="form-control" id="txtMat_Khau" placeholder="Mật khẩu" style="border-radius: 0 0 10px 10px;height:38px;" />
                    </div>
                    <div class="button-dangnhap">
                        <asp:Button ID="btnSignIn" Text="Đăng Nhập" class="btn btn-default" runat="server"
                            OnClick="btnSignIn_Click"  style="padding: 6px 12px;border-radius: 4px;" />
                    </div>
                </div>
                </form>
                <div class="footer">
                	<h5>Công Ty TNHH Giải Pháp Tiên Khanh</h5>
                    <h5>Your Trust Solution</h5>
                </div>
            </div>
        </div>
        <div class="pull-left">
            <div class="background-Coty"> 
            </div>
        </div>
	</div>
    <script src="/WebAdmin/media/js/jquery.min.js"></script>
    <script src="/WebAdmin/media/js/bootstrap.min.js"></script>
    <script src="/WebAdmin/media/js/twitter-bootstrap-hover-dropdown.min.js"></script>

    <script type='text/javascript' src='/WebAdmin/media/js/jquery.particleground.min.js'></script>

    <script> 
        $(function(){ 
          center()
            $(window).resize(function(){center()})
          function center(){
            $('.VD').css({left:($(window).width()-$('.VD').width())/2,top:($(window).height()-$('div').height())/2}) 
          } 
        }) 
	
	
    $(document).ready(function() {
      $('#particles').particleground({
        dotColor: '#fff',
        lineColor: '#fff'
      });
      $('.intro').css({
        'margin-top': -($('.intro').height() / 2)
      });
    });
      </script> 

</body>
</html>
