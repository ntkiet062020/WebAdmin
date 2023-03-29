<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHeader.ascx.cs" Inherits="TKS_Thuc_Tap_Web.WebAdmin.Admin.UserControl.ucHeader" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<header class="row">
	<div class="top-header">
    	<div class="col-md-6">
        	<div class="part-left">
                &nbsp;
            </div>
        </div>
        <div class="col-md-6">
        	<div class="part-right">
                <asp:Literal ID="litWelcome" runat="server"></asp:Literal>
                <span>|</span>
                <a href="/WebAdmin/Admin/SignOut.aspx">Thoát</a>
            </div>
        </div>
    </div>
    <div class="botoom-header">
        <div class="row info_title">
            <div class="col-md-8 part-01">
                <h3>TKSolution - Core System</h3>
            </div>
            <div class="col-md-4 part-02">
                <div class="row">
                    <div class="col-md-3">
                    </div>
                    <div class="col-md-9" style="padding-right: 0px">
                        <dx:ASPxComboBox ID="cboChu_Hang" runat="server" ValueType="System.Int32" 
                            Theme="Office2010Blue" Width="100%">
                        </dx:ASPxComboBox>
                    </div>
                </div>
            </div>
        </div>
        <div id="tabsF" class="row">
           <div id="tabsF">
            <ul>
                <asp:Literal ID="litMenu" runat="server"></asp:Literal>
    	    </ul>
        </div>
    </div>
</header><!--HEADER-->