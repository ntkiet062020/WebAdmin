<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc1005_Phan_Nhom_Thanh_Vien.ascx.cs" Inherits="TKS_Thuc_Tap_Web.WebAdmin.Admin.UserControl.uc1005_Phan_Nhom_Thanh_Vien" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<div class="row">
	<div class="col-md-12">
        <span style="font-size:11px; font-family: Tahoma">
        - Cho biết thành viên thuộc nhóm quyền nào.<br />
        - Lưu ý: <br />
        <span style="color:Red">&nbsp;&nbsp;&nbsp;+ Một thành viên có thể thuộc nhiều nhóm khác nhau.</span> <br />
        </span>
    </div>
</div>

<div class="row-spacer_20"></div>

<div class="row">
	<div class="col-md-7">
        <h6><strong><i class='fa fa-circle'></i>&nbsp;&nbsp;Phân nhóm</strong></h6>
        <div class="TKS_Editor_Form">
            <div class="row border-top background">
                <div class="col-md-2 part-01"><h5>Nhóm NSD:</h5></div>
                <div class="col-md-6 part-01" style="padding-top:2px;">
                    <dx:ASPxComboBox ID="cboNhom_Quyen" runat="server"
                        AutoPostBack="True" TextField="Ten_Nhom" ValueField="Auto_ID" 
                        onselectedindexchanged="cboNhom_Quyen_SelectedIndexChanged" 
                        Theme="Office2010Blue">
                    </dx:ASPxComboBox>  
                </div>
            </div>
        </div>

        <div class="row-spacer_10"></div>

        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-10" style="padding-left: 0px; padding-right: 0px;">
                <dx:ASPxGridView ID="grdData" runat="server" 
                    DataSourceID="SqlDataSource1" 
                    KeyFieldName="Auto_ID" Width="100%" AutoGenerateColumns="False" 
                    oncelleditorinitialize="grdData_CellEditorInitialize" 
                    Theme="Office2010Blue" >
                    <Columns>
                            <dx:GridViewDataComboBoxColumn Caption="User" FieldName="Ma_Thanh_Vien" 
                            Name="colUserName" VisibleIndex="3" Width="100px" Visible="False">
                            <PropertiesComboBox DataSourceID="SqlDataSource2" TextField="Ma_Dang_Nhap" 
                                ValueField="Auto_ID" ValueType="System.Int32">
                            </PropertiesComboBox>
                            <EditFormSettings ColumnSpan="2" Visible="True" />
                            <EditFormCaptionStyle Wrap="False">
                            </EditFormCaptionStyle>
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                        </dx:GridViewDataComboBoxColumn>
                
                        <dx:GridViewDataTextColumn FieldName="Ma_Dang_Nhap" Caption="Thành viên" 
                            VisibleIndex="1" Width="100px">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
               
                        <dx:GridViewDataTextColumn Caption="Vai Trò" FieldName="Role_Level_Name" 
                            VisibleIndex="2">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                
                        <dx:GridViewDataTextColumn FieldName="Auto_ID" Visible="False" 
                            VisibleIndex="6" Caption="MSHT" Width="40px">
                        </dx:GridViewDataTextColumn>
                
                        <dx:GridViewCommandColumn VisibleIndex="4" Width="40px" ShowNewButton="True">
                        </dx:GridViewCommandColumn>
                
                        <dx:GridViewCommandColumn VisibleIndex="5" Width="40px" ShowDeleteButton="True">
                        </dx:GridViewCommandColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div> <!-- /.row -->
    </div>
</div>

<asp:SqlDataSource ID="SqlDataSource1" runat="server"
    ConnectionString="<%$ appSettings:TKS_Thuc_Tap_Admin_Conn_String %>" 
    DeleteCommand="F1002_sp_del_Quan_Ly_Thanh_Vien" DeleteCommandType="StoredProcedure" 
    InsertCommand="F1002_sp_ins_Quan_Ly_Thanh_Vien" InsertCommandType="StoredProcedure" 
    SelectCommand="F1002_sp_sel_List_Quan_Ly_Thanh_Vien_By_Ma_Nhom_Quyen_DelManager" 
    SelectCommandType="StoredProcedure" >
    <SelectParameters>
        <asp:SessionParameter Name="Ma_Nhom_Quyen" SessionField="Ma_Nhom_Quyen_2" 
            Type="Int32" />
    </SelectParameters>
    <DeleteParameters>
        <asp:Parameter Name="Auto_ID" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:SessionParameter Name="Ma_Nhom_Quyen" SessionField="Ma_Nhom_Quyen_2" 
            Type="Int32" />
        <asp:Parameter Name="Ma_Thanh_Vien" Type="Int32" />
        <asp:Parameter Name="Role_Level" Type="Int32" DefaultValue="3" />
        <asp:SessionParameter Name="Last_Updated_By" SessionField="Active_User_Name" 
            Type="String" />
    </InsertParameters>
</asp:SqlDataSource>

<asp:SqlDataSource ID="SqlDataSource2" runat="server"
    ConnectionString="<%$ appSettings:TKS_Thuc_Tap_Admin_Conn_String %>" 
    SelectCommand="F1002_sp_sel_List_Thanh_Vien_NotExist_By_Ma_Nhom_Quyen" 
    SelectCommandType="StoredProcedure" 
    UpdateCommand="F1002_sp_upd_Thanh_Vien" >
    <SelectParameters>
        <asp:SessionParameter Name="Ma_Nhom_Quyen" SessionField="Ma_Nhom_Quyen_2" 
            Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>