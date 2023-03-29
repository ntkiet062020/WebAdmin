<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc1004_Phan_Quyen_Chuc_Nang.ascx.cs" Inherits="TKS_Thuc_Tap_Web.WebAdmin.Admin.UserControl.uc1004_Phan_Quyen_Chuc_Nang" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<div class="row">
	<div class="col-md-12">
        <span style="font-size:11px; font-family: Tahoma">
            - Phân quyền sử dụng cho các nhóm người sử dụng của hệ thống.<br />
            - Lưu ý: <br />
            <span style="color:Red">&nbsp;&nbsp;&nbsp;+ Phân quyền sử dụng cho các nhóm người sử dụng của hệ thống.</span> <br />
            <span style="color:Red">&nbsp;&nbsp;&nbsp;+ Quyền tổng của một thành viên là tất cả các quyền thuộc tất cả các nhóm mà thành viên đó trực thuộc gộp lại.</span> <br />
        </span>
    </div>
</div>

<div class="row-spacer_20"></div>

<div class="row">
    <div class="col-md-12">
        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowHeader="False" 
            Theme="Office2010Blue" Width="100%">
            <PanelCollection>
                <dx:PanelContent ID="PanelContent1" runat="server">
                    <div class="row">
                        <div class="col-md-1" style="text-align: right; padding-top: 5px; padding-right: 0px; padding-left: 0px; width: 100px;">Nhóm NSD: </div>
                        <div class="col-md-3">
                            <dx:ASPxComboBox ID="cboNhom_Quyen" runat="server"
                                AutoPostBack="True" TextField="Ten_Nhom" ValueField="Auto_ID" 
                                onselectedindexchanged="cboRole_SelectedIndexChanged" 
                                Theme="Office2010Blue">
                            </dx:ASPxComboBox>  
                        </div>
                        <div class="col-md-1" style="text-align: right; padding-top: 5px; padding-right: 0px; padding-left: 0px; width: 150px;">Nhóm chức năng: </div>
                        <div class="col-md-3">
                            <dx:ASPxComboBox ID="cboFunc_Group" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="cboFunc_Group_SelectedIndexChanged" 
                                ValueType="System.String" Theme="Office2010Blue">
                                <Items>
                                    <dx:ListEditItem Text="Quản Trị" Value="1" />
                                    <dx:ListEditItem Text="Web" Value="2" />
                                </Items>
                            </dx:ASPxComboBox>
                        </div>
                    </div>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxRoundPanel>
    </div>
</div>

<div class="row-spacer_20"></div>

<div class="row">
	<div class="col-md-12">
        <dx:ASPxTreeList ID="trvData" runat="server"
                KeyFieldName="Auto_ID" 
                ParentFieldName="Parent_Func_ID" Width="100%" 
                AutoGenerateColumns="False" ClientInstanceName="trvData" 
                oncelleditorinitialize="trvData_CellEditorInitialize" 
            Theme="Office2003Blue" >
    
            <Styles>
                <AlternatingNode Enabled="True">
                </AlternatingNode>
            </Styles>
        
            <SettingsBehavior AllowDragDrop="False" 
                    AllowSort="False" AllowFocusedNode="True" />
                <ClientSideEvents CustomDataCallback="function(s, e) {
                var key = e.result.split(';');	            	                
                }" NodeCollapsing="function(s, e)
                {
                    e.cancel = true;
                }" />
                <Columns>
                <dx:TreeListTextColumn FieldName="Auto_ID" VisibleIndex="1" 
                        Caption="MSHT" Width="60px">
                        <CellStyle HorizontalAlign="Right">
                        </CellStyle>
                </dx:TreeListTextColumn>
        
                <dx:TreeListTextColumn Caption="Tên chức năng" FieldName="Ten_Chuc_Nang" 
                        VisibleIndex="0">
                </dx:TreeListTextColumn>
        
                <dx:TreeListTextColumn Caption="Xử Lý" 
                    VisibleIndex="2" Width="60px">
                    <DataCellTemplate>
                        <dx:ASPxCheckBox ID="chkIs_View" runat="server"
                            Font-Names="Tahoma" Font-Size="11px"> 
                        </dx:ASPxCheckBox>                            
                    </DataCellTemplate>
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:TreeListTextColumn>
        
                <dx:TreeListTextColumn Caption="Thêm" VisibleIndex="3" Width="60px">
                    <DataCellTemplate>
                        <dx:ASPxCheckBox ID="chkIs_New" runat="server" Checked="false">
                        </dx:ASPxCheckBox>
                    </DataCellTemplate>
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:TreeListTextColumn>
        
                <dx:TreeListTextColumn Caption="Sửa" VisibleIndex="4" Width="60px">
                    <DataCellTemplate>
                        <dx:ASPxCheckBox ID="chkIs_Edit" runat="server" Checked="false">
                        </dx:ASPxCheckBox>
                    </DataCellTemplate>
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:TreeListTextColumn>
        
                <dx:TreeListTextColumn Caption="Xoá" VisibleIndex="5" Width="60px">
                    <DataCellTemplate>
                        <dx:ASPxCheckBox ID="chkIs_Delete" runat="server" Checked="false">
                        </dx:ASPxCheckBox>
                    </DataCellTemplate>
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:TreeListTextColumn>
            </Columns>
        </dx:ASPxTreeList>   
    </div>
</div>

<div class="row-spacer_10"></div>

<div class="row">
    <div class="col-md-12">
        <div align="right">
            <dx:ASPxButton ID="btnUpdate" runat="server" Text="Cập Nhật" Width="100px" 
                onclick="btnUpdate_Click" Theme="Office2010Blue" >
            </dx:ASPxButton>  
        </div>
    </div>
</div> 
