<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc1001_DM_Chuc_Nang.ascx.cs" Inherits="TKS_Thuc_Tap_Web.WebAdmin.Admin.UserControl.uc1001_DM_Chuc_Nang" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<div class="row">
	<div class="col-md-12">
            <span style="font-size:11px; font-family: Tahoma">
                - Khai báo cây tính năng của hệ thống.<br />
                - Lưu ý: <br />
                <span style="color:Red">&nbsp;&nbsp;&nbsp;+ Mã chức năng là duy nhất.</span> <br />
                <span style="color:Red">&nbsp;&nbsp;&nbsp;+ Chức năng này chỉ nên được duy nhất người quản trị của hệ thống hoặc công ty phát triển phần mềm sử dụng.</span> <br />
            </span>
    </div>
</div>

<div class="row-spacer_20"></div>

<div class="row">
	<div class="col-md-12">
        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowHeader="False" Width="100%" Theme="Office2010Blue">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <div class="row">
                        <div class="col-md-2" style="text-align: right; width: 130px; padding-top: 6px;">Nhóm chức năng:</div>
                        <div class="col-md-3">
                            <dx:ASPxComboBox ID="cboNhom_Chuc_Nang" runat="server" SelectedIndex="0" AutoPostBack="True" 
                                    onselectedindexchanged="lbFeatures_SelectedIndexChanged" Theme="Office2010Blue">
                                    <Items>
                                        <dx:ListEditItem Selected="True" Text="Quản Trị" Value="1" />
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
        <dx:ASPxTreeList ID="grdData" runat="server" AutoGenerateColumns="False"
            ClientInstanceName="treeList" 
            DataSourceID="SqlChucNang" 
            KeyFieldName="Auto_ID" ParentFieldName="Parent_Func_ID" Width="100%" 
            oninitnewnode="grdData_InitNewNode" AutoGenerateServiceColumns="True" 
            onnodevalidating="grdData_NodeValidating" 
            oncelleditorinitialize="grdData_CellEditorInitialize" Theme="Office2003Blue" EnableTheming="True" >
            <Columns>
                <dx:TreeListTextColumn Caption="Func Name" FieldName="Ten_Chuc_Nang" 
                    VisibleIndex="1">             
                </dx:TreeListTextColumn>
                <dx:TreeListSpinEditColumn Caption="Func ID" FieldName="Auto_ID" 
                    VisibleIndex="2" Width="60px">
                    <PropertiesSpinEdit DisplayFormatString="######" NumberFormat="Custom">
                    </PropertiesSpinEdit>
                    <GroupFooterCellStyle HorizontalAlign="Center">
                    </GroupFooterCellStyle>
                </dx:TreeListSpinEditColumn>
                <dx:TreeListMemoColumn FieldName="Func_Code" Visible="False" Width="40px">
                    <PropertiesMemo Rows="1" />
                    <EditFormCaptionStyle VerticalAlign="top" />
                </dx:TreeListMemoColumn>
                <dx:TreeListSpinEditColumn Caption="Sort" FieldName="Sort_Priority" 
                    VisibleIndex="3" Width="60px">
                    <PropertiesSpinEdit DisplayFormatString="g" MaxLength="6">
                    </PropertiesSpinEdit>
                    <GroupFooterCellStyle HorizontalAlign="Center">
                    </GroupFooterCellStyle>
                </dx:TreeListSpinEditColumn>
                <dx:TreeListMemoColumn FieldName="Parent_Func_ID" Visible="False" 
                    Width="40px" VisibleIndex="0">
                    <PropertiesMemo Rows="1" />
                    <EditFormCaptionStyle VerticalAlign="top" />
                </dx:TreeListMemoColumn>
                <dx:TreeListTextColumn FieldName="Func_URL" 
                        VisibleIndex="4" Width="200px" Caption="Func URL">
                </dx:TreeListTextColumn>
                <dx:TreeListTextColumn FieldName="Image_URL" VisibleIndex="5" 
                    Width="100px" Caption="Image URL">
                </dx:TreeListTextColumn>
                <dx:TreeListCheckColumn FieldName="Is_View" 
                    GroupFooterCellStyle-HorizontalAlign="Center" VisibleIndex="6" 
                    Width="40px">
                    <GroupFooterCellStyle HorizontalAlign="Center">
                    </GroupFooterCellStyle>
                </dx:TreeListCheckColumn>
                <dx:TreeListTextColumn Caption="Mô tả" Visible="False" 
                    VisibleIndex="7" FieldName="Mo_Ta_Chuc_Nang" Width="100px">                        
                </dx:TreeListTextColumn>
                <dx:TreeListCommandColumn ShowNewButtonInHeader="True" Width="40px" 
                    VisibleIndex="8">
                    <NewButton Visible="True">
                    </NewButton>
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:TreeListCommandColumn>
                <dx:TreeListCommandColumn Width="40px" 
                    VisibleIndex="9">
                    <EditButton Visible="True">
                    </EditButton>
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:TreeListCommandColumn>
                <dx:TreeListCommandColumn Width="40px" 
                    VisibleIndex="14">
                    <DeleteButton Visible="true" />
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:TreeListCommandColumn>
                <dx:TreeListTextColumn FieldName="Old_Auto_ID" Visible="False" 
                    VisibleIndex="10" Width="40px">
                </dx:TreeListTextColumn>
                <dx:TreeListCheckColumn Caption="Is_New" FieldName="Is_New" Visible="False" 
                    VisibleIndex="11" Width="40px">
                    <EditFormSettings Visible="True" VisibleIndex="10" />
                </dx:TreeListCheckColumn>
                <dx:TreeListCheckColumn Caption="Is_Edit" FieldName="Is_Edit" 
                    Visible="False" VisibleIndex="12" Width="40px">
                    <EditFormSettings Visible="True" VisibleIndex="11" />
                </dx:TreeListCheckColumn>
                <dx:TreeListCheckColumn Caption="Is_Delete" FieldName="Is_Delete" 
                    Visible="False" VisibleIndex="13" Width="40px">
                    <EditFormSettings Visible="True" VisibleIndex="12" />
                </dx:TreeListCheckColumn>
            </Columns>
        </dx:ASPxTreeList>
        <asp:SqlDataSource ID="SqlChucNang" runat="server" 
            ConnectionString="<%$ appSettings:TKS_Thuc_Tap_Admin_Conn_String %>" 
            DeleteCommandType="StoredProcedure" InsertCommand="F1001_sp_ins_Chuc_Nang" 
            InsertCommandType="StoredProcedure" 
            SelectCommand="F1001_sp_sel_List_Chuc_Nang_Func_Group_ID_Lang_ID" 
            SelectCommandType="StoredProcedure" UpdateCommand="sp_upd_Chuc_Nang" 
            UpdateCommandType="StoredProcedure" DeleteCommand="sp_del_Chuc_Nang" >
            <SelectParameters>
                <asp:SessionParameter Name="Func_Group_ID" 
                    SessionField="Func_Group_ID" />
                <asp:SessionParameter Name="Lang_ID" 
                    SessionField="Lang_ID" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Auto_ID"/>
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Auto_ID"  />
                <asp:Parameter Name="Func_Code" />
                <asp:Parameter Name="Sort_Priority" />
                <asp:Parameter Name="Parent_Func_ID"/>
                <asp:SessionParameter Name="Func_Group_ID" SessionField="Func_Group_ID"/>
                <asp:Parameter Name="Is_View" />
                <asp:Parameter Name="Is_New" />
                <asp:Parameter Name="Is_Edit" />
                <asp:Parameter Name="Is_Delete" />
                <asp:SessionParameter Name="Lang_ID" SessionField="Lang_ID" />
                <asp:Parameter Name="Ten_Chuc_Nang" />
                <asp:Parameter Name="Image_URL" />
                <asp:Parameter Name="Func_URL" />
                <asp:Parameter Name="Mo_Ta_Chuc_Nang" />
                <asp:Parameter Name="So_Dong" />
                <asp:SessionParameter Name="Last_Updated_By" SessionField="Active_User_Name"/>
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Auto_ID" />
                <asp:Parameter Name="Func_Code" />
                <asp:Parameter Name="Sort_Priority" />
                <asp:Parameter Name="Parent_Func_ID" />
                <asp:SessionParameter Name="Func_Group_ID" SessionField="Func_Group_ID" 
                    />
                <asp:Parameter Name="Is_View"/>
                <asp:Parameter Name="Is_New" />
                <asp:Parameter Name="Is_Edit" />
                <asp:Parameter Name="Is_Delete" />
                <asp:SessionParameter Name="Last_Updated_By" SessionField="Active_User_Name"/>
                <asp:SessionParameter Name="Lang_ID" SessionField="Lang_ID"/>
                <asp:Parameter Name="Ten_Chuc_Nang"/>
                <asp:Parameter Name="Image_URL"/>
                <asp:Parameter Name="Func_URL"/>
                <asp:Parameter Name="Mo_Ta_Chuc_Nang"/>
            </InsertParameters>
        </asp:SqlDataSource>
    </div>
</div>
