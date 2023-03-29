using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using TKS_Thuc_Tap_Utility;
using TKS_Thuc_Tap_Controller.Admin;
using TKS_Thuc_Tap_Entity.Admin;

namespace TKS_Thuc_Tap_Web.WebAdmin.Admin.UserControl
{
    public partial class uc1004_Phan_Quyen_Chuc_Nang : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cboFunc_Group.SelectedIndex = 0;
                InitUI();

                CCommonFunction.TreeList_Permission(trvData, CUtility.Convert_To_Int32(Request.QueryString["f"]));
            }

            DrawTree();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            CNhom_Quyen_Controller v_objCtrRole = new CNhom_Quyen_Controller();
            try
            {
                int v_iRole = 0;
                // Lấy role đang active
                if (cboNhom_Quyen.Value == null)
                    throw new Exception("Bạn cần phải chọn nhóm quyền để phân quyền.");

                v_iRole = int.Parse(cboNhom_Quyen.Value.ToString());

                // Tạo danh sách nhóm quyền cần phân
                IList<CPhan_Quyen_Chuc_Nang> v_arrFP = new List<CPhan_Quyen_Chuc_Nang>();

                foreach (DevExpress.Web.ASPxTreeList.TreeListNode v_ntNode in trvData.GetAllNodes())
                {
                    CChuc_Nang v_objFunc = (CChuc_Nang)v_ntNode.DataItem;
                    string v_strPS = "";

                    // Is_View
                    ASPxCheckBox v_chk1 = trvData.FindDataCellTemplateControl(v_ntNode.Key,
                            (TreeListDataColumn)trvData.Columns["Is_View"], "chkIs_View") as ASPxCheckBox;
                    if (v_chk1.Checked)
                        v_strPS += '1';
                    else
                        v_strPS += '0';

                    // Is_New
                    if (v_objFunc.Is_New)
                    {
                        ASPxCheckBox v_chk = trvData.FindDataCellTemplateControl(v_ntNode.Key,
                            (TreeListDataColumn)trvData.Columns["Is_New"], "chkIs_New") as ASPxCheckBox;

                        if (v_chk.Checked)
                            v_strPS += '1';
                        else
                            v_strPS += '0';
                    }
                    else
                        v_strPS += '0';

                    // Is_Edit
                    if (v_objFunc.Is_Edit)
                    {
                        ASPxCheckBox v_chk = trvData.FindDataCellTemplateControl(v_ntNode.Key,
                            (TreeListDataColumn)trvData.Columns["Is_Edit"], "chkIs_Edit") as ASPxCheckBox;

                        if (v_chk.Checked)
                            v_strPS += '1';
                        else
                            v_strPS += '0';
                    }
                    else
                        v_strPS += '0';

                    // Is_Delete
                    if (v_objFunc.Is_Delete)
                    {
                        ASPxCheckBox v_chk = trvData.FindDataCellTemplateControl(v_ntNode.Key,
                            (TreeListDataColumn)trvData.Columns["Is_Delete"], "chkIs_Delete") as ASPxCheckBox;

                        if (v_chk.Checked)
                            v_strPS += '1';
                        else
                            v_strPS += '0';
                    }
                    else
                        v_strPS += '0';

                    if (v_strPS != "0000")
                    {
                        CPhan_Quyen_Chuc_Nang v_objFP = new CPhan_Quyen_Chuc_Nang();
                        v_objFP.Ma_Thanh_Vien = CSession.Active_User.Auto_ID;
                        v_objFP.Ma_Nhom_Quyen = v_iRole;
                        v_objFP.Ma_Chuc_Nang = Convert.ToInt32(v_ntNode["Auto_ID"].ToString());
                        v_objFP.Permission_String = v_strPS;
                        v_objFP.Created = DateTime.Now;
                        v_objFP.Created_By = CSession.Active_User_Name;
                        v_objFP.Last_Updated_By = CSession.Active_User_Name;
                        v_arrFP.Add(v_objFP);
                    }
                }

                v_objCtrRole.Phan_Quyen_Chuc_Nang(v_arrFP, int.Parse(cboFunc_Group.Value.ToString()), v_iRole);
                MessageBox.Show("Phân quyền thành công.");
            }

            catch (Exception ex)
            {
                CCommonFunction.ShowWarning(ex.Message);
            }
        }

        protected void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhom_Quyen.SelectedIndex >= 0)
            {
                DrawTree();
                Selected();
            }
        }

        protected void cboFunc_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhom_Quyen.SelectedIndex >= 0)
            {
                DrawTree();
                Selected();
            }
        }

        /// <summary>
        /// Load dữ liệu
        /// </summary>
        private void InitUI()
        {

            CNhom_Quyen_Controller v_objCtrNhom_Quyen = new CNhom_Quyen_Controller();
            try
            {
                // L?y danh sách role
                IList<CNhom_Quyen> v_arrNhom_Quyen = v_objCtrNhom_Quyen.List_Nhom_Quyen();
                // Bind vào combo box
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

        /// <summary>
        /// Select nh?ng 
        /// </summary>
        private void Selected()
        {
            CNhom_Quyen_Controller v_objCtrRole = new CNhom_Quyen_Controller();
            try
            {
                IList<CPhan_Quyen_Chuc_Nang> v_arrFP = v_objCtrRole.F1004_List_Phan_Quyen_Chuc_Nang_By_Ma_Nhom_Quyen(int.Parse(cboNhom_Quyen.Value.ToString()));
                foreach (CPhan_Quyen_Chuc_Nang v_objFP in v_arrFP)
                {
                    DevExpress.Web.ASPxTreeList.TreeListNode v_ntNode = trvData.FindNodeByKeyValue(v_objFP.Ma_Chuc_Nang.ToString());
                    if (v_ntNode != null)
                    {
                        CChuc_Nang v_objFunc = (CChuc_Nang)v_ntNode.DataItem;

                        // Is_View
                        ASPxCheckBox v_chk1 = trvData.FindDataCellTemplateControl(v_ntNode.Key,
                                (TreeListDataColumn)trvData.Columns["Is_View"], "chkIs_View") as ASPxCheckBox;
                        v_chk1.Checked = true;

                        // Is_New
                        if (v_objFunc.Is_New && v_objFP.Permission_String[1] == '1')
                        {
                            ASPxCheckBox v_chk = trvData.FindDataCellTemplateControl(v_ntNode.Key,
                                (TreeListDataColumn)trvData.Columns["Is_New"], "chkIs_New") as ASPxCheckBox;
                            v_chk.Checked = true;
                        }

                        // Is_Edit
                        if (v_objFunc.Is_Edit && v_objFP.Permission_String[2] == '1')
                        {
                            ASPxCheckBox v_chk = trvData.FindDataCellTemplateControl(v_ntNode.Key,
                                (TreeListDataColumn)trvData.Columns["Is_Edit"], "chkIs_Edit") as ASPxCheckBox;
                            v_chk.Checked = true;
                        }

                        // Is_Delete
                        if (v_objFunc.Is_Delete && v_objFP.Permission_String[3] == '1')
                        {
                            ASPxCheckBox v_chk = trvData.FindDataCellTemplateControl(v_ntNode.Key,
                                (TreeListDataColumn)trvData.Columns["Is_Delete"], "chkIs_Delete") as ASPxCheckBox;
                            v_chk.Checked = true;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                CCommonFunction.ShowWarning(ex.Message);
            }
        }

        /// <summary>
        /// v? cây
        /// </summary>
        private void DrawTree()
        {
            CChuc_Nang_Controller v_objCtrFunc = new CChuc_Nang_Controller();

            try
            {
                // l?y danh sách function
                IList<CChuc_Nang> v_arrFunc = v_objCtrFunc.F1001_List_Chuc_Nang(int.Parse(cboFunc_Group.Value.ToString()), CSession.Lang_ID);

                // Bind lên tree
                trvData.DataSource = v_arrFunc;
                trvData.ParentFieldName = "Parent_Func_ID";
                trvData.DataBind();
                trvData.ExpandToLevel(5);

                // ?n các check box thêm, xoá, s?a không c?n thi?t
                foreach (DevExpress.Web.ASPxTreeList.TreeListNode v_ntNode in trvData.GetAllNodes())
                {
                    CChuc_Nang v_objFunc = (CChuc_Nang)v_ntNode.DataItem;

                    if (!v_objFunc.Is_New)
                    {
                        ASPxCheckBox v_chk = trvData.FindDataCellTemplateControl(v_ntNode.Key,
                            (TreeListDataColumn)trvData.Columns["Is_New"], "chkIs_New") as ASPxCheckBox;

                        v_chk.Visible = false;
                    }

                    if (!v_objFunc.Is_Edit)
                    {
                        ASPxCheckBox v_chk = trvData.FindDataCellTemplateControl(v_ntNode.Key,
                            (TreeListDataColumn)trvData.Columns["Is_Edit"], "chkIs_Edit") as ASPxCheckBox;

                        v_chk.Visible = false;
                    }

                    if (!v_objFunc.Is_Delete)
                    {
                        ASPxCheckBox v_chk = trvData.FindDataCellTemplateControl(v_ntNode.Key,
                            (TreeListDataColumn)trvData.Columns["Is_Delete"], "chkIs_Delete") as ASPxCheckBox;

                        v_chk.Visible = false;
                    }
                }
            }

            catch (Exception ex)
            {
                CCommonFunction.ShowWarning(ex.Message);
            }
        }

        protected void trvData_CellEditorInitialize(object sender, DevExpress.Web.ASPxTreeList.TreeListColumnEditorEventArgs e)
        {
            if (e.Column.FieldName == "Ten_Chuc_Nang")
                e.Editor.Focus();
        }
    }
}