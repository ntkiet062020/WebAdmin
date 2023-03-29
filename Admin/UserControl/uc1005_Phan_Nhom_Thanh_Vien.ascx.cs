using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TKS_Thuc_Tap_Controller.Admin;
using TKS_Thuc_Tap_Entity.Admin;
using TKS_Thuc_Tap_Utility;

namespace TKS_Thuc_Tap_Web.WebAdmin.Admin.UserControl
{
    public partial class uc1005_Phan_Nhom_Thanh_Vien : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Ma_Nhom_Quyen_2"] = null;
                LoadRoleComboBox();

                grdData.SettingsSearchPanel.Visible = false;
                grdData.SettingsPager.Mode = DevExpress.Web.GridViewPagerMode.ShowAllRecords;
            }
        }

        /// <summary>
        /// Load những thông tin liên quan đến 
        /// </summary>
        private void LoadRoleComboBox()
        {
            CNhom_Quyen_Controller v_objCtrNhom_Quyen = new CNhom_Quyen_Controller();

            try
            {
                // Lấy danh sách những nhóm quyền do user này làm quản lý
                IList<CNhom_Quyen> v_arrNhom_Quyen = v_objCtrNhom_Quyen.List_Nhom_Quyen();

                cboNhom_Quyen.DataSource = v_arrNhom_Quyen;
                cboNhom_Quyen.TextField = "Ten_Nhom";
                cboNhom_Quyen.ValueField = "Auto_ID";
                cboNhom_Quyen.DataBind();
            }

            catch (Exception ex)
            {
                CCommonFunction.ShowWarning(ex.Message);
            }
        }

        protected void cboNhom_Quyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Ma_Nhom_Quyen_2"] = int.Parse(cboNhom_Quyen.Value.ToString());
        }

        protected void grdData_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "Ma_Thanh_Vien")
                e.Editor.Focus();
        }
    }
}