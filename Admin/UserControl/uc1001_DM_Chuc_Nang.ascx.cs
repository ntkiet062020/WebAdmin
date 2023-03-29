using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TKS_Thuc_Tap_Utility;


namespace TKS_Thuc_Tap_Web.WebAdmin.Admin.UserControl
{
    public partial class uc1001_DM_Chuc_Nang : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cboNhom_Chuc_Nang.SelectedIndex = 0;
                Session["Func_Group_ID"] = 1;

                CCommonFunction.TreeList_Permission(grdData, CUtility.Convert_To_Int32(Request.QueryString["f"]));
            }
        }

        protected void lbFeatures_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["Func_Group_ID"] = int.Parse(cboNhom_Chuc_Nang.Value.ToString());
                grdData.DataBind();
            }
            catch (Exception ex)
            {
                CCommonFunction.ShowWarning(ex.Message);
            }
        }

        protected void grdData_InitNewNode(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["Is_View"] = false;
            e.NewValues["Is_New"] = false;
            e.NewValues["Is_Edit"] = false;
            e.NewValues["Is_Delete"] = false;
        }

        protected void grdData_NodeValidating(object sender, DevExpress.Web.ASPxTreeList.TreeListNodeValidationEventArgs e)
        {

            if (e.NewValues["Auto_ID"] == null)
            {
                e.Errors["Auto_ID"] = "Auto_ID Không Được Rỗng.";
            }
            if (e.HasErrors)
            {
                e.NodeError = "Auto_ID Không được rỗng";
            }
        }

        protected void grdData_CellEditorInitialize(object sender, DevExpress.Web.ASPxTreeList.TreeListColumnEditorEventArgs e)
        {
            if (e.Column.FieldName == "Ten_Chuc_Nang")
                e.Editor.Focus();
        }
    }
}