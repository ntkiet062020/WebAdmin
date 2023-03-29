<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc1003_DM_Nhom_Quyen.ascx.cs" Inherits="TKS_Thuc_Tap_Web.WebAdmin.Admin.UserControl.uc1003_DM_Nhom_Quyen" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<div class="row">
	<div class="col-md-12">
            <span style="font-size:11px; font-family: Tahoma">
            - Khai báo danh mục các nhóm người sử dụng của hệ thống.<br />
            - Ràng buộc nhập liệu: <span style="color:Red">Tên nhóm là duy nhất.</span> <br />
            </span>
    </div>
</div>

<div class="row-spacer_20"></div>

<div class="row">
	<div class="col-md-12">
        <dx:ASPxGridView ID="grdData" runat="server" 
            DataSourceID="sqlData" 
            Width="100%" 
            KeyFieldName="Auto_ID" 
            Theme="Office2010Blue" ClientInstanceName="grdData" 
            AutoGenerateColumns="False" EnableTheming="True" >    
    
            <Columns>
                <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Width="40px">
                    <HeaderTemplate>
                        <input type="checkbox" onclick="grdData.SelectAllRowsOnPage(this.checked);" style="vertical-align: middle;"
                            title="Select/Unselect all rows on the page"></input>
                    </HeaderTemplate>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn Caption="MSHT" FieldName="Auto_ID" VisibleIndex="1" 
                    Width="60px">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
        
                <dx:GridViewCommandColumn VisibleIndex="6" Width="50px" ShowNewButton="True">
                </dx:GridViewCommandColumn>
        
                <dx:GridViewCommandColumn VisibleIndex="7" Width="40px" ShowEditButton="True">
                </dx:GridViewCommandColumn>
        
                <dx:GridViewCommandColumn VisibleIndex="8" Width="40px" ShowDeleteButton="True">
                </dx:GridViewCommandColumn>
        
                <dx:GridViewDataTextColumn Caption="Tên Nhóm" FieldName="Ten_Nhom" 
                    VisibleIndex="2" Width="100px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataSpinEditColumn Caption="Số Thành Viên" 
                    FieldName="Member_Quantity" VisibleIndex="4" Width="100px">

                    <EditFormSettings Visible="False" />
                </dx:GridViewDataSpinEditColumn>

                <dx:GridViewDataTextColumn Caption="Mô tả" FieldName="Mo_Ta" VisibleIndex="5">
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataSpinEditColumn Caption="Sắp xếp" FieldName="Sort_Priority" 
                    VisibleIndex="3" Width="60px">
                </dx:GridViewDataSpinEditColumn>
            </Columns>
        </dx:ASPxGridView>
                
        <table cellpadding="0" cellspacing="0" width="100%" style="margin-top:15px">
            <tr>
                <td align="left">
                    <dx:ASPxButton ID="btnXoa_Select" runat="server" Text="Xóa Chọn" 
                        onclick="btnXoa_Select_Click" Theme="Office2010Blue">
                    </dx:ASPxButton>
                </td>
                
                <td width="130px" align="right">
                    <dx:ASPxButton ID="btnExport_PDF" runat="server" Text="Kết Xuất PDF" Theme="Office2010Blue">
                    </dx:ASPxButton>
                </td>
                <td width="130px" align="right">
                    <dx:ASPxButton ID="btnExport_CSV" runat="server" Text="Kết Xuất CSV" Theme="Office2010Blue">
                    </dx:ASPxButton>
                </td>
                <td width="130px" align="right">
                    <dx:ASPxButton ID="btnExport_XLS" runat="server" Text="Kết Xuất XLS" Theme="Office2010Blue">
                    </dx:ASPxButton>
                </td>
                <td width="150px" align="right">
                    <dx:ASPxButton ID="btnExport_XLSX" runat="server" Text="Kết Xuất XLSX" Theme="Office2010Blue" Width="120px">
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
        <dx:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="grdData"></dx:ASPxGridViewExporter>

        <asp:SqlDataSource ID="sqlData" runat="server" 
            ConnectionString="<%$ appSettings:TKS_Thuc_Tap_Admin_Conn_String %>" 
            DeleteCommand="sp_del_Nhom_Quyen" DeleteCommandType="StoredProcedure" 
            InsertCommand="F1003_sp_ins_Nhom_Quyen" InsertCommandType="StoredProcedure" 
            SelectCommand="F1002_sp_sel_List_Nhom_Quyen_Sum" SelectCommandType="StoredProcedure" 
            UpdateCommand="F1003_sp_upd_Nhom_Quyen" 
            UpdateCommandType="StoredProcedure">
            <DeleteParameters>
                <asp:Parameter Name="Auto_ID" />
                <asp:SessionParameter Name="Last_Updated_By" SessionField="Active_User_Name" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Auto_ID" Type="Int32" />
                <asp:Parameter Name="Ten_Nhom" Type="String" />
                <asp:Parameter Name="Mo_Ta" Type="String" />
                <asp:Parameter Name="Icon_Index" Type="Int32" />
                <asp:Parameter Name="Parent_Role_ID" Type="Int32" />
                <asp:Parameter Name="Sort_Priority" Type="Int32" />
                <asp:SessionParameter Name="Last_Updated_By" SessionField="Active_User_Name" 
                    Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Ten_Nhom" Type="String" />
                <asp:Parameter Name="Mo_Ta" Type="String" />
                <asp:Parameter Name="Icon_Index" Type="Int32" />
                <asp:Parameter Name="Parent_Role_ID" Type="Int32" />
                <asp:Parameter Name="Sort_Priority" Type="Int32" />
                <asp:SessionParameter Name="Last_Updated_By" SessionField="Active_User_Name" 
                    Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    </div>
</div>

