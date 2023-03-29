﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc1009_Thong_Tin_Account.ascx.cs" Inherits="TKS_Thuc_Tap_Web.WebAdmin.Admin.UserControl.uc1009_Thong_Tin_Account" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<div class="TKS_Editor_Form">
    
    <div class="row">
	    <div class="col-md-4">
            <div class="row border-top background">
                <div class="col-md-6 part-01">
                    <h5>Mã đăng nhập</h5>
                </div>
                <div class="col-md-6 part-03">
                    <strong><%=TKS_Thuc_Tap_Web.CSession.Active_User_Name %></strong>
                </div>
            </div>

            <div class="row border-top background">
                <div class="col-md-6 part-01">
                    <h5>Họ tên </h5>
                </div>
                <div class="col-md-6 part-03">
                    <strong><%=TKS_Thuc_Tap_Web.CSession.Active_User.Ho_Lot%> <%=TKS_Thuc_Tap_Web.CSession.Active_User.Ten%></strong>
                </div>
            </div>

            <div class="row border-top background">
                <div class="col-md-6 part-01">
                    <h5>Điện thoại </h5>
                </div>
                <div class="col-md-6 part-03">
                    <strong><%=TKS_Thuc_Tap_Web.CSession.Active_User.Dien_Thoai%></strong>
                </div>
            </div>

            <div class="row border-top background">
                <div class="col-md-6 part-01">
                    <h5>Email</h5>
                </div>
                <div class="col-md-6 part-03">
                    <strong><%=TKS_Thuc_Tap_Web.CSession.Active_User.Email%></strong>
                </div>
            </div>

            <div class="row border-top background">
                <div class="col-md-6 part-01">
                    <h5>Lần đăng nhập cuối cùng </h5>
                </div>
                <div class="col-md-6 part-03">
                </div>
            </div>
        </div>
    </div>
</div>

<div class="row-spacer_20"></div>

<div class="row">
    <div class="col-md-4">
        <dx:ASPxGridView ID="grdData" runat="server" 
            DataSourceID="sqlNhom" Width="100%" 
            KeyFieldName="Auto_ID" Theme="Office2010Blue" ClientInstanceName="grdNhom" 
            AutoGenerateColumns="False" >    
            <Columns>
                <dx:GridViewDataTextColumn Caption="Tên Nhóm" FieldName="Ten_Nhom" 
                    VisibleIndex="5">
                    <CellStyle HorizontalAlign="Left">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
        <asp:SqlDataSource ID="sqlNhom" runat="server"
            ConnectionString="<%$ appSettings:TKS_Thuc_Tap_Admin_Conn_String %>" 
            SelectCommand="F1002_sp_sel_List_Nhom_Quyen_By_Ma_Thanh_Vien" 
            SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="Ma_Dang_Nhap" SessionField="Active_User_Name" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</div>