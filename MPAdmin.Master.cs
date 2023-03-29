using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TKS_Thuc_Tap_Entity.Admin;
using TKS_Thuc_Tap_Controller.Admin;
using TKS_Thuc_Tap_Utility;
using System.Globalization;
using System.Text;
using DevExpress.Web;
using DevExpress.XtraPrinting;

namespace TKS_Thuc_Tap_Web.WebAdmin
{
    public partial class MPAdmin : System.Web.UI.MasterPage
    {
        private DevExpress.Web.ASPxGridView m_objGrid = null;
        private DevExpress.Web.ASPxButton m_objXoa_Select = null;
        private DevExpress.Web.ASPxGridViewExporter m_objGrid_Exporter = null;
        private DevExpress.Web.ASPxButton m_btnExport_PDF = null;
        private DevExpress.Web.ASPxButton m_btnExport_CSV = null;
        private DevExpress.Web.ASPxButton m_btnExport_XLS = null;
        private DevExpress.Web.ASPxButton m_btnExport_XLSX = null;

        private int m_iGrid_Count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Lang_ID"] != null)
                CSession.Lang_ID = Request.QueryString["Lang_ID"];

            // Check user
            if (CSession.Active_User == null)
            {
                MessageBox.Show("Bạn cần phải đăng nhập để sử dụng chức năng này.", ResolveUrl("~/WebAdmin/Admin/Signin.aspx"));
                if (Request.QueryString["f"] != null)
                    CSession.Url_Referrer = Request.Url.AbsoluteUri;
                Response.End();
                return;
            }

            // Check quyền
            if (CSession.Active_User != null)
            {
                int v_iFuncID = -1;
                if (Request.QueryString["f"] != null)
                    v_iFuncID = int.Parse(Request.QueryString["f"]);

                if (!CCommonFunction.CheckPermission(v_iFuncID, Request.Url.AbsoluteUri))
                {
                    string v_strUrl = ResolveUrl(CCommonData.g_strDefault_Url);
                    if (Request.UrlReferrer != null)
                        v_strUrl = Request.UrlReferrer.AbsoluteUri;
                    MessageBox.Show("Bạn không có quyền sử dụng chức năng này.", v_strUrl);
                    Response.End();
                    return;
                }
            }

            if (!IsPostBack)
            {
                InitUI();
                Format_Control(this);
                if (m_objGrid != null && m_iGrid_Count < 2)
                {
                    m_objGrid.ClientInstanceName = "grdData";
                    CCommonFunction.Grid_Permission(m_objGrid, m_objXoa_Select, CUtility.Convert_To_Int32(Request.QueryString["f"]));
                }
            }

            Format_Style_Grid(this);
            Find_Control(this);

            if (m_objGrid != null && m_objGrid_Exporter != null && m_iGrid_Count < 2)
            {
                m_objGrid_Exporter.GridViewID = m_objGrid.ID;

                if (m_btnExport_PDF != null)
                    m_btnExport_PDF.Click += new System.EventHandler(btnExport_PDF_Click);

                if (m_btnExport_CSV != null)
                    m_btnExport_CSV.Click += new System.EventHandler(btnExport_CSV_Click);

                if (m_btnExport_XLS != null)
                    m_btnExport_XLS.Click += new System.EventHandler(btnExport_XLS_Click);

                if (m_btnExport_XLSX != null)
                    m_btnExport_XLSX.Click += new System.EventHandler(btnExport_XLSX_Click);
            }
        }

        private void Find_Control(Control p_objControl)
        {
            m_iGrid_Count = 0;

            // Format các item menu trên toolbar cho hiện loading...
            if (p_objControl.GetType().ToString() == "DevExpress.Web.ASPxButton")
            {
                DevExpress.Web.ASPxButton v_objButton = (DevExpress.Web.ASPxButton)p_objControl;
                if (v_objButton.Width.Value < 95)
                    v_objButton.Width = new Unit(95, UnitType.Pixel);

                if (v_objButton.Height.Value == 0)
                    v_objButton.Height = new Unit(25, UnitType.Pixel);

                if (v_objButton.ID == "btnExport_PDF")
                    m_btnExport_PDF = v_objButton;

                if (v_objButton.ID == "btnExport_CSV")
                    m_btnExport_CSV = v_objButton;

                if (v_objButton.ID == "btnExport_XLS")
                    m_btnExport_XLS = v_objButton;

                if (v_objButton.ID == "btnExport_XLSX")
                    m_btnExport_XLSX = v_objButton;

                if (v_objButton.ID == "btnXoa_Select")
                    m_objXoa_Select = v_objButton;
            }

            // format grid
            if (p_objControl.GetType().ToString() == "DevExpress.Web.ASPxGridView")
            {
                m_iGrid_Count++;
                m_objGrid = (DevExpress.Web.ASPxGridView)p_objControl;
            }

            if (p_objControl.GetType().ToString() == "DevExpress.Web.ASPxGridViewExporter")
            {
                m_objGrid_Exporter = (DevExpress.Web.ASPxGridViewExporter)p_objControl;
            }

            if (p_objControl.Controls != null)
            {
                foreach (Control v_objCon in p_objControl.Controls)
                    Find_Control(v_objCon);
            }
        }

        private void Format_Style_Grid(Control p_objControl)
        {
            if (p_objControl.GetType().ToString() == "DevExpress.Web.ASPxGridView")
                CCommonFunction.Format_Style_Grid((DevExpress.Web.ASPxGridView)p_objControl);

            if (p_objControl.Controls != null)
            {
                foreach (Control v_objCon in p_objControl.Controls)
                    Format_Style_Grid(v_objCon);
            }
        }

        private void Format_Control(Control p_objControl)
        {
            // Button
            if (p_objControl.GetType().ToString() == "DevExpress.Web.ASPxButton")
            {
                DevExpress.Web.ASPxButton v_objButton = (DevExpress.Web.ASPxButton)p_objControl;

                if (v_objButton.ClientSideEvents.Click == ""
                    && v_objButton.ID != "btnExport_PDF" && v_objButton.ID != "btnExport_CSV"
                    && v_objButton.ID != "btnExport_XLS" && v_objButton.ID != "btnExport_XLSX")
                {
                    if (v_objButton.ID != "btnXoa_Select")
                        v_objButton.ClientSideEvents.Click = "function(s, e) { Callback.PerformCallback(); LoadingPanel.Show(); }";
                    else
                    {
                        v_objButton.ClientSideEvents.Click = "function(s, e) { var v_fConfirm = ConfirmDelete(); if (v_fConfirm == false){e.processOnServer = false;} else {Callback.PerformCallback(); LoadingPanel.Show();} }";
                    }

                    v_objButton.AutoPostBack = false;
                }

                if (v_objButton.ID == "btnExport_PDF")
                    m_btnExport_PDF = v_objButton;

                if (v_objButton.ID == "btnExport_CSV")
                    m_btnExport_CSV = v_objButton;

                if (v_objButton.ID == "btnExport_XLS")
                    m_btnExport_XLS = v_objButton;

                if (v_objButton.ID == "btnExport_XLSX")
                    m_btnExport_XLSX = v_objButton;

                if (v_objButton.ID == "btnXoa_Select")
                    m_objXoa_Select = v_objButton;
            }

            // Spin Edit
            if (p_objControl.GetType().ToString() == "DevExpress.Web.ASPxSpinEdit")
            {
                DevExpress.Web.ASPxSpinEdit v_objSpin_Edit = (DevExpress.Web.ASPxSpinEdit)p_objControl;

                v_objSpin_Edit.Increment = 0;
                v_objSpin_Edit.DisplayFormatString = CCommonData.Number_Format_String;
                v_objSpin_Edit.SpinButtons.Visible = false;
                v_objSpin_Edit.SpinButtons.ShowIncrementButtons = false;
                v_objSpin_Edit.Height = new Unit(25, UnitType.Pixel);
                v_objSpin_Edit.ClientInstanceName = v_objSpin_Edit.ID;

                if (v_objSpin_Edit.Width.Value == 0)
                    v_objSpin_Edit.Width = new Unit(100, UnitType.Percentage);
            }

            // ASPX Combo box
            if (p_objControl.GetType().ToString() == "DevExpress.Web.ASPxComboBox")
            {
                DevExpress.Web.ASPxComboBox v_cboCombo = (DevExpress.Web.ASPxComboBox)p_objControl;

                v_cboCombo.DropDownStyle = DevExpress.Web.DropDownStyle.DropDown;
                v_cboCombo.IncrementalFilteringMode = DevExpress.Web.IncrementalFilteringMode.Contains;
                v_cboCombo.ItemStyle.Height = new Unit(25, UnitType.Pixel);
                v_cboCombo.Height = new Unit(25, UnitType.Pixel);
                v_cboCombo.ValueType = Type.GetType("System.Int32");

                if (v_cboCombo.Width.Value == 0)
                    v_cboCombo.Width = new Unit(100, UnitType.Percentage);
            }

            // Datetime Edit
            if (p_objControl.GetType().ToString() == "DevExpress.Web.ASPxDateEdit")
            {
                DevExpress.Web.ASPxDateEdit v_objDate_Edit = (DevExpress.Web.ASPxDateEdit)p_objControl;
                v_objDate_Edit.DisplayFormatString = CCommonData.DateTime_Format_String;
                v_objDate_Edit.EditFormatString = CCommonData.DateTime_Format_String;
                v_objDate_Edit.Height = new Unit(25, UnitType.Pixel);

                if (v_objDate_Edit.Width.Value == 0)
                    v_objDate_Edit.Width = new Unit(100, UnitType.Percentage);
            }

            // Time Edit
            if (p_objControl.GetType().ToString() == "DevExpress.Web.ASPxTimeEdit")
            {
                DevExpress.Web.ASPxTimeEdit v_objTime_Edit = (DevExpress.Web.ASPxTimeEdit)p_objControl;
                v_objTime_Edit.DisplayFormatString = "HH:mm";
                v_objTime_Edit.EditFormatString = "HH:mm";
                v_objTime_Edit.Height = new Unit(25, UnitType.Pixel);

                if (v_objTime_Edit.Width.Value == 0)
                    v_objTime_Edit.Width = new Unit(100, UnitType.Percentage);
            }

            if (p_objControl.GetType().ToString() == "DevExpress.Web.ASPxTextBox")
            {
                DevExpress.Web.ASPxTextBox v_objText = (DevExpress.Web.ASPxTextBox)p_objControl;
                v_objText.Height = new Unit(25, UnitType.Pixel);

                if (v_objText.Width.Value == 0)
                    v_objText.Width = new Unit(100, UnitType.Percentage);
            }

            if (p_objControl.GetType().ToString() == "DevExpress.Web.ASPxMemo")
            {
                DevExpress.Web.ASPxMemo v_objMemo = (DevExpress.Web.ASPxMemo)p_objControl;

                if (v_objMemo.Width.Value == 0)
                    v_objMemo.Width = new Unit(100, UnitType.Percentage);
            }

            // format grid
            if (p_objControl.GetType().ToString() == "DevExpress.Web.ASPxGridView")
            {
                m_iGrid_Count++;
                m_objGrid = (DevExpress.Web.ASPxGridView)p_objControl;
                CCommonFunction.Format_Grid(m_objGrid);
            }

            if (p_objControl.GetType().ToString() == "DevExpress.Web.ASPxGridViewExporter")
            {
                m_objGrid_Exporter = (DevExpress.Web.ASPxGridViewExporter)p_objControl;
            }

            // format treelist
            if (p_objControl.GetType().ToString() == "DevExpress.Web.ASPxTreeList.ASPxTreeList")
            {
                DevExpress.Web.ASPxTreeList.ASPxTreeList v_objTreelist = (DevExpress.Web.ASPxTreeList.ASPxTreeList)p_objControl;
                CCommonFunction.Format_Treelist(v_objTreelist);
            }

            // Format chart control
            if (p_objControl.GetType().ToString() == "DevExpress.XtraCharts.Web.WebChartControl")
            {
                DevExpress.XtraCharts.Web.WebChartControl v_objChart = (DevExpress.XtraCharts.Web.WebChartControl)p_objControl;

                DevExpress.XtraCharts.XYDiagram v_objXYDiagram = (DevExpress.XtraCharts.XYDiagram)v_objChart.Diagram;
                v_objXYDiagram.AxisY.Label.TextPattern = "V:N0";

                foreach (DevExpress.XtraCharts.Series v_objSerie in v_objChart.Series)
                {
                    v_objSerie.CrosshairLabelPattern = " {A} : {V:N0}";
                }
            }

            if (p_objControl.Controls != null)
            {
                foreach (Control v_objCon in p_objControl.Controls)
                    Format_Control(v_objCon);
            }
        }

        private CChuc_Nang GetRootChuc_Nang(CChuc_Nang p_objChuc_Nang, IList<CChuc_Nang> p_arrChuc_Nang)
        {
            CChuc_Nang v_objRes = p_objChuc_Nang;
            if (p_objChuc_Nang.Parent_Func_ID != 0)
            {
                CChuc_Nang v_objParent = null;
                foreach (CChuc_Nang v_objChuc_Nang in p_arrChuc_Nang)
                    if (p_objChuc_Nang.Parent_Func_ID == v_objChuc_Nang.Auto_ID)
                    {
                        v_objParent = v_objChuc_Nang;
                        break;
                    }
                if (v_objParent != null)
                    v_objRes = GetRootChuc_Nang(v_objParent, p_arrChuc_Nang);
            }

            return v_objRes;
        }

        private void InitUI()
        {

            CChuc_Nang_Controller v_objCtrChuc_Nang = new CChuc_Nang_Controller();
            try
            {
                CChuc_Nang v_objActive_Func = v_objCtrChuc_Nang.F1001_Get_Chuc_Nang_By_AutoID(int.Parse(Request.QueryString["f"]), CCommonData.g_strLangVN);

                StringBuilder sb = new StringBuilder();
                string v_strUrl = CCommonData.g_strDefault_Url;

                if (v_objActive_Func.Parent_Func_ID == 0)
                {
                    sb.AppendLine("<div class=\"content-title-nav\"><a href=\"" + ResolveUrl(v_strUrl) + "\">Trang chủ</a> --> " + v_objActive_Func.Ten_Chuc_Nang + " </div>");
                }
                else
                {
                    // Lấy danh sách function
                    IList<CChuc_Nang> v_arrChuc_Nang1 = v_objCtrChuc_Nang.F1001_List_Chuc_Nang_Func_Group_ID(v_objActive_Func.Func_Group_ID, CCommonData.g_strLangVN);

                    // Lấy function gốc
                    CChuc_Nang v_objRootChuc_Nang = new CChuc_Nang();
                    v_objRootChuc_Nang = GetRootChuc_Nang(v_objActive_Func, v_arrChuc_Nang1);

                    sb.AppendLine("<div class=\"content-title-nav\"><a href=\"" + ResolveUrl(v_strUrl) + "\">Trang chủ</a> --> </span>"
                        + " <a href=\"" + ResolveUrl(CCommonFunction.GetFuncUrl(v_objRootChuc_Nang)) + "\">"
                        + v_objRootChuc_Nang.Ten_Chuc_Nang + "</a> </div>");
                }

                sb.AppendLine("<div class=\"content-title-subject\"><h3>" + v_objActive_Func.Auto_ID + " " + '-' + " " + v_objActive_Func.Ten_Chuc_Nang + "</h3></div>");
                //}
                litTitle.Text = sb.ToString();
            }

            catch (Exception ex)
            {
                CCommonFunction.ShowWarning(ex.Message);
            }
        }

        protected void btnExport_PDF_Click(object sender, EventArgs e)
        {
            m_objGrid_Exporter.WritePdfToResponse();
        }

        protected void btnExport_CSV_Click(object sender, EventArgs e)
        {
            m_objGrid_Exporter.WriteCsvToResponse();
        }

        protected void btnExport_XLS_Click(object sender, EventArgs e)
        {
            m_objGrid_Exporter.WriteXlsToResponse();
        }

        protected void btnExport_XLSX_Click(object sender, EventArgs e)
        {
            m_objGrid_Exporter.WriteXlsxToResponse();
        }
    }
}