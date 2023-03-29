using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TKS_Thuc_Tap_Utility;
using TKS_Thuc_Tap_Entity.Admin;
using TKS_Thuc_Tap_Controller.Admin;

namespace TKS_Thuc_Tap_Web.WebAdmin.Admin.UserControl
{
    public partial class uc1003_DM_Nhom_Quyen : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnXoa_Select_Click(object sender, EventArgs e)
        {
            CNhom_Quyen_Controller v_objCtrNhom_Quyen = new CNhom_Quyen_Controller();
            try
            {
                List<object> Rows = grdData.GetSelectedFieldValues("Auto_ID", "Ten_Nhom");

                int v_iCount = 0;
                foreach (object id in Rows)
                {
                    v_iCount++;
                    object[] v_arrID = (object[])id;

                    int v_iAuto_ID = CUtility.Convert_To_Int32(v_arrID[0]);
                    v_objCtrNhom_Quyen.Delete_Nhom_Quyen(v_iAuto_ID, CSession.Active_User_Name);

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