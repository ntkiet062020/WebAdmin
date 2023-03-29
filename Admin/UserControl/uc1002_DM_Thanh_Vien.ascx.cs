using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TKS_Thuc_Tap_Utility;
using TKS_Thuc_Tap_Entity.Admin;
using TKS_Thuc_Tap_Controller.Admin;
using DevExpress.Web;

namespace TKS_Thuc_Tap_Web.WebAdmin.Admin.UserControl
{
    public partial class uc1002_DM_Thanh_Vien : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdData_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            GridViewDataColumn col = (GridViewDataColumn)grdData.Columns["Ma_Dang_Nhap"];
            col.ReadOnly = true;
        }

        protected void grdData_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            e.NewValues["Password"] = CUtility.MD5_Encrypt(e.NewValues["Password"].ToString());
        }

        protected void grdData_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            if (e.NewValues["Password"].ToString() != e.OldValues["Password"].ToString() || e.NewValues["Password"].ToString() == "")
                e.NewValues["Password"] = CUtility.MD5_Encrypt(e.NewValues["Password"].ToString());
        }

        private void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }

        protected void grdData_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            string v_strError4 = "Email không hợp lệ";
            string v_strError5 = "Điện thoại không hợp lệ";
            string v_strError1 = "Password không được rỗng.";
            string v_strError2 = "Mã đăng nhập không được rỗng.";

            if (e.NewValues["Password"] == null)
            {
                e.RowError = v_strError1;
                AddError(e.Errors, grdData.Columns["Password"], v_strError1);
            }

            if (e.NewValues["Ma_Dang_Nhap"] == null)
            {
                e.RowError = v_strError2;
                AddError(e.Errors, grdData.Columns["Ma_Dang_Nhap"], v_strError2);
            }

            //Kiểm tra email coi có hợp lệ hay không?
            if (e.NewValues["Email"] != null)
                if (!CCommonFunction.Is_Valid_Email(e.NewValues["Email"].ToString()))
                {
                    e.RowError = v_strError4;
                    AddError(e.Errors, grdData.Columns["Email"], v_strError4);
                }

            //Kiểm tra email coi có hợp lệ hay không?
            if (e.NewValues["Dien_Thoai"] != null)
                if (!CUtility.Is_Valid_Phone(e.NewValues["Dien_Thoai"].ToString()))
                {
                    e.RowError = v_strError5;
                    AddError(e.Errors, grdData.Columns["Dien_Thoai"], v_strError5);
                }
        }

        protected void grdData_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "Ma_Dang_Nhap")
                e.Editor.Focus();
        }

        protected void btnXoa_Select_Click(object sender, EventArgs e)
        {
            CThanh_Vien_Controller v_objCtrThanh_Vien = new CThanh_Vien_Controller();
            try
            {
                List<object> Rows = grdData.GetSelectedFieldValues("Auto_ID", "Ma_Dang_Nhap");

                int v_iCount = 0;
                foreach (object id in Rows)
                {
                    v_iCount++;
                    object[] v_arrID = (object[])id;

                    int v_iAuto_ID = CUtility.Convert_To_Int32(v_arrID[0]);
                    v_objCtrThanh_Vien.Delete_Thanh_Vien(v_iAuto_ID, CSession.Active_User_Name);

                }

                if (v_iCount <= 0)
                    throw new Exception("Xin vui lòng chọn danh sách cần xóa.");

                CCommonFunction.ShowMessage("Xóa danh sách được chọn thành công.");
                grdData.DataBind();

            }
            catch (Exception ex)
            {
                CCommonFunction.ShowWarning(ex.Message);
            }
        }
    }
}