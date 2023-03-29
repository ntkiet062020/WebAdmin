using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using TKS_Thuc_Tap_Utility;
using TKS_Thuc_Tap_Entity.Admin;
using TKS_Thuc_Tap_Controller.Admin;

namespace TKS_Thuc_Tap_Web.WebAdmin.Admin.UserControl
{
    public partial class ucHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitUI();
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


        /// <summary>
        /// Khởi tạo giao diện ban đầu
        /// </summary>
        private void InitUI()
        {
            CChuc_Nang_Controller v_objCtrChuc_Nang = new CChuc_Nang_Controller();
            CThanh_Vien_Controller v_objCtrThanh_Vien = new CThanh_Vien_Controller();
            CNhom_Quyen_Controller v_objCtrNhom_Quyen = new CNhom_Quyen_Controller();

            try
            {
                //string v_strUrl1 = Request.Url.AbsoluteUri;
                //v_strUrl1 = v_strUrl1.Replace("&Lang_ID=en-US", "").Replace("&Lang_ID=vi-VN", "");

                //HyperLink1.NavigateUrl = v_strUrl1 + "&Lang_ID=en-US";
                //HyperLink2.NavigateUrl = v_strUrl1 + "&Lang_ID=vi-VN";


                // Lấy function Group
                CChuc_Nang v_objActive_Func = v_objCtrChuc_Nang.F1001_Get_Chuc_Nang_By_AutoID(int.Parse(Request.QueryString["f"]), CCommonData.g_strLangVN);

                if (CSession.Active_User != null)
                    litWelcome.Text = "<a href='/WebAdmin/Admin/Thong_Tin_Account.aspx'>" + "Chào mừng " + CSession.Active_User.Ma_Dang_Nhap + "</a>";

                // Lấy danh sách function
                IList<CChuc_Nang> v_arrChuc_Nang = v_objCtrChuc_Nang.F1001_List_Chuc_Nang_Func_Group_ID(v_objActive_Func.Func_Group_ID, CCommonData.g_strLangVN);

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

                //// Loại các function ko thuộc quyền
                for (int v_i = v_arrChuc_Nang.Count - 1; v_i >= 0; v_i--)
                    if (!v_dicFunc.ContainsKey(v_arrChuc_Nang[v_i].Auto_ID))
                        v_arrChuc_Nang.RemoveAt(v_i);

                // Lấy function gốc
                CChuc_Nang v_objRootChuc_Nang = new CChuc_Nang();
                if (Request.QueryString["f"] == null && v_arrChuc_Nang.Count > 0)
                {
                    v_objRootChuc_Nang = v_objCtrChuc_Nang.F1001_Get_Chuc_Nang_By_AutoID(CCommonData.g_iDefaultFuncID, CCommonData.g_strLangVN);
                }
                else
                {
                    v_objRootChuc_Nang = v_objCtrChuc_Nang.F1001_Get_Chuc_Nang_By_AutoID(int.Parse(Request.QueryString["f"]), CCommonData.g_strLangVN);
                    v_objRootChuc_Nang = GetRootChuc_Nang(v_objRootChuc_Nang, v_arrChuc_Nang);
                }

                StringBuilder sb = new StringBuilder();

                // Loại các function có is_view là false trước khi vẽ
                for (int v_i = v_arrChuc_Nang.Count - 1; v_i >= 0; v_i--)
                    if (!v_arrChuc_Nang[v_i].Is_View)
                        v_arrChuc_Nang.RemoveAt(v_i);

                // Lấy cái function có parent_id = 0 để bind lên tree
                foreach (CChuc_Nang v_objChuc_Nang in v_arrChuc_Nang)
                    if (v_objChuc_Nang.Parent_Func_ID == 0)
                    {
                        string v_strUrl = CCommonFunction.GetFuncUrl(v_objChuc_Nang);

                        if (v_objChuc_Nang.Auto_ID == v_objRootChuc_Nang.Auto_ID)
                            sb.Append("<li id=\"current\"><a href=\"" + ResolveUrl(v_strUrl) + "\"><span>" + v_objChuc_Nang.Ten_Chuc_Nang + "</span></a></li>");
                        else
                            sb.Append("<li><a href=\"" + ResolveUrl(v_strUrl) + "\"><span>" + v_objChuc_Nang.Ten_Chuc_Nang + "</span></a></li>");
                    }

                litMenu.Text = sb.ToString();
            }

            catch (Exception ex)
            {
                CCommonFunction.ShowWarning(ex.Message);
            }
        }
    }
}