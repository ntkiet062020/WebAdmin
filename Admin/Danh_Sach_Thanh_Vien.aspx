<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/MPAdmin.Master" AutoEventWireup="true" CodeBehind="Danh_Sach_Thanh_Vien.aspx.cs" Inherits="TKS_Thuc_Tap_Web.WebAdmin.Admin.Danh_Sach_Thanh_Vien" %>
<%@ Register src="UserControl/uc1002_DM_Thanh_Vien.ascx" tagname="uc1002_DM_Thanh_Vien" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:uc1002_DM_Thanh_Vien ID="uc1002_DM_Thanh_Vien1" runat="server" />
</asp:Content>
