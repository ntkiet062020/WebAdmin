using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TKS_Thuc_Tap_Utility;
using TKS_Thuc_Tap_Controller.Admin;
using TKS_Thuc_Tap_Entity.Admin;

namespace TKS_Thuc_Tap_Web.WebAdmin.Admin
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CSession.Active_User != null)
                    CCommonFunction.RedirectLink(ResolveUrl(CCommonData.g_strDefault_Url));
            }

            this.txtMa_Dang_Nhap.Focus();
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            CThanh_Vien_Controller v_objUserCtrl = new CThanh_Vien_Controller();
            CThanh_Vien v_objUser = v_objUserCtrl.Get_Thanh_Vien_By_Ma_Dang_Nhap(txtMa_Dang_Nhap.Value);

            litError.Text = "";

            if (v_objUser != null)
            {
                if (v_objUser.Password != CUtility.MD5_Encrypt(txtMat_Khau.Value).ToString())
                {
                    litError.Text = CCommonFunction.Set_Error_MessageBox("Bạn nhập Password sai! Xin vui lòng nhập lai Password...");
                    txtMat_Khau.Value = "";
                    txtMat_Khau.Focus();
                }
                else
                {
                    CSession.Active_User = v_objUser;
                    CSession.Active_User_Name = v_objUser.Ma_Dang_Nhap;

                    if (CSession.Url_Referrer != "")
                        CCommonFunction.RedirectLink(CSession.Url_Referrer);
                    else
                        CCommonFunction.RedirectLink(ResolveUrl(CCommonData.g_strDefault_Url));
                }
            }
            else
            {
                txtMa_Dang_Nhap.Value = "";
                txtMat_Khau.Value = "";
                txtMa_Dang_Nhap.Focus();
                litError.Text = CCommonFunction.Set_Error_MessageBox("Tên đăng nhập không tồn tại.");
            }
        }
    }
}