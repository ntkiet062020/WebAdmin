using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using TKS_Thuc_Tap_Controller.Admin;
using TKS_Thuc_Tap_Entity.Admin;
using TKS_Thuc_Tap_Utility;

namespace TKS_Thuc_Tap_Web.WebAdmin.Admin.UserControl
{
    public partial class ucLeftMenuBar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                InitUI();
        }

        /// <summary>
        /// Lấy thông tin level tính năng
        /// </summary>
        /// <param name="p_objChuc_Nang"></param>
        /// <param name="p_arrChuc_Nang"></param>
        /// <returns></returns>
        private int GetLevel(CChuc_Nang p_objChuc_Nang, IList<CChuc_Nang> p_arrChuc_Nang)
        {
            int v_iRes = 0;
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
                    v_iRes = GetLevel(v_objParent, p_arrChuc_Nang) + 1;
            }

            return v_iRes;
        }

        /// <summary>
        /// Lấy function gốc của một tính năng nào đó   
        /// </summary>
        /// <param name="p_objChuc_Nang"></param>
        /// <param name="p_arrChuc_Nang"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Khởi tạo giao diện
        /// </summary>
        private void InitUI()
        {
            CChuc_Nang_Controller v_objCtrChuc_Nang = new CChuc_Nang_Controller();
            CThanh_Vien_Controller v_objCtrThanh_Vien = new CThanh_Vien_Controller();
            CNhom_Quyen_Controller v_objCtrNhom_Quyen = new CNhom_Quyen_Controller();

            try
            {
                // Lấy function Group
                CChuc_Nang v_objActive_Func = v_objCtrChuc_Nang.F1001_Get_Chuc_Nang_By_AutoID(int.Parse(Request.QueryString["f"]), CCommonData.g_strLangVN);

                // Lấy danh sách function
                IList<CChuc_Nang> v_arrChuc_Nang = v_objCtrChuc_Nang.F1001_List_Chuc_Nang(v_objActive_Func.Func_Group_ID, CCommonData.g_strLangVN);

                // Lấy danh sách nhóm quyền mà user có
                IList<CQuan_Ly_Thanh_Vien> v_arrUR = v_objCtrThanh_Vien.F1002_List_Quan_Ly_Thanh_Vien_By_Ma_Thanh_Vien(CSession.Active_User.Auto_ID);

                // Lấy dictionary function dựa trên các nhóm quyền
                IDictionary<int, string> v_dicFunc = new Dictionary<int, string>();
                foreach (CQuan_Ly_Thanh_Vien v_objQuan_Ly_Thanh_Vien in v_arrUR)
                {
                    IList<CPhan_Quyen_Chuc_Nang> v_arrFR = v_objCtrNhom_Quyen.F1004_List_Phan_Quyen_Chuc_Nang_By_Ma_Nhom_Quyen(v_objQuan_Ly_Thanh_Vien.Ma_Nhom_Quyen);
                    foreach (CPhan_Quyen_Chuc_Nang v_objFR in v_arrFR)
                    {
                        if (!v_dicFunc.ContainsKey(v_objFR.Ma_Chuc_Nang))
                            v_dicFunc.Add(v_objFR.Ma_Chuc_Nang, v_objFR.Func_URL);
                    } // end for
                } // end for

                // Loại các function ko thuộc quyền
                for (int v_i = v_arrChuc_Nang.Count - 1; v_i >= 0; v_i--)
                    if (!v_dicFunc.ContainsKey(v_arrChuc_Nang[v_i].Auto_ID))
                        v_arrChuc_Nang.RemoveAt(v_i);

                // Lấy function id đang active
                CChuc_Nang v_objFuncActive = v_objCtrChuc_Nang.F1001_Get_Chuc_Nang_By_AutoID(CCommonData.g_iDefaultFuncID, CCommonData.g_strLangVN);
                if (Request.QueryString["f"] != null)
                    v_objFuncActive = v_objCtrChuc_Nang.F1001_Get_Chuc_Nang_By_AutoID(int.Parse(Request.QueryString["f"]), CCommonData.g_strLangVN);

                // Lấy function root
                CChuc_Nang v_objRoot = GetRootChuc_Nang(v_objFuncActive, v_arrChuc_Nang);

                // Loại các function có is_view là false trước khi vẽ
                for (int v_i = v_arrChuc_Nang.Count - 1; v_i >= 0; v_i--)
                    if (!v_arrChuc_Nang[v_i].Is_View)
                        v_arrChuc_Nang.RemoveAt(v_i);

                StringBuilder sb = new StringBuilder();

                // Vẽ cây
                foreach (CChuc_Nang v_objChuc_Nang in v_arrChuc_Nang)
                {
                    string v_strTen_Tinh_Nang = v_objChuc_Nang.Ten_Chuc_Nang;

                    if (GetLevel(v_objChuc_Nang, v_arrChuc_Nang) == 1 && GetRootChuc_Nang(v_objChuc_Nang, v_arrChuc_Nang).Auto_ID == v_objRoot.Auto_ID)
                    {
                        sb.AppendLine("<li class=\"title\">");
                        sb.AppendLine("<a href=\"#\">");
                        sb.AppendLine("<strong>" + v_strTen_Tinh_Nang + "</strong>");
                        sb.AppendLine("</a>");
                        sb.AppendLine("</li>");

                        foreach (CChuc_Nang v_objChild in v_arrChuc_Nang)
                            if (v_objChild.Parent_Func_ID == v_objChuc_Nang.Auto_ID)
                            {
                                string v_strTen_Tinh_Nang_Child = v_objChild.Ten_Chuc_Nang;
                                string v_strUrl = CCommonFunction.GetFuncUrl(v_objChild);

                                if (v_strUrl == "")
                                    v_strUrl = Request.Url + "#";

                                sb.AppendLine("<li class=\"title-sub\">");

                                if (v_objChild.Image_URL.ToLower() != "popup")
                                    sb.AppendLine("<a href=\"" + ResolveUrl(v_strUrl) + "\">");
                                else
                                    sb.AppendLine("<a href=\"javascript:openWin('" + ResolveUrl(v_strUrl) + "', 1050, 600)\">");

                                sb.AppendLine(v_objChild.Auto_ID + " " + '-' + " " + v_strTen_Tinh_Nang_Child);
                                sb.AppendLine("</a>");
                                sb.AppendLine("</li>");
                            }
                    }

                }

                litLeftMenu.Text = sb.ToString();
            }

            catch (Exception ex)
            {
                CCommonFunction.ShowWarning(ex.Message);
            }
        }
    }
}