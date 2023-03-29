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
    public partial class uc1008_Doi_Mat_Khau : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                txtMat_Khau_Cu.Focus();
        }

        protected void btnDoi_Mat_Khau_Click(object sender, EventArgs e)
        {
            CThanh_Vien_Controller v_objCtrlThanh_Vien = new CThanh_Vien_Controller();
            litError.Text = "";

            try
            {
                //Kiểm tra không cho password rỗng           
                if (txtMat_Khau_Moi.Text == string.Empty)
                {
                    txtMat_Khau_Cu.Focus();
                    throw new Exception("Mật khẩu mới không được rỗng.");
                }

                //Kiểm tra không cho password có khoản trắng
                string v_strValid = CUtility.Is_Valid_Password_Format(txtMat_Khau_Moi.Text);
                if (v_strValid != "")
                {
                    txtMat_Khau_Cu.Focus();
                    throw new Exception(v_strValid);
                }

                // Ki?m tra m?t kh?u m?i
                if (txtMat_Khau_Moi.Text != txtConfirm_Mat_Khau_Moi.Text)
                {
                    txtMat_Khau_Cu.Focus();
                    throw new Exception("Mật khẩu mới và mật khẩu được nhập lại mới phải giống nhau.");
                }

                // Mã hoá các m?t kh?u
                string v_strOldPassword = CUtility.MD5_Encrypt(txtMat_Khau_Cu.Text);
                string v_strNewPassword = CUtility.MD5_Encrypt(txtMat_Khau_Moi.Text);

                // So sánh m?t kh?u cu
                CThanh_Vien v_objThanh_Vien = v_objCtrlThanh_Vien.Get_Thanh_Vien_By_ID(CSession.Active_User.Auto_ID);
                if (v_objThanh_Vien != null)
                {
                    if (v_objThanh_Vien.Password != v_strOldPassword)
                    {
                        txtMat_Khau_Cu.Focus();
                        throw new Exception("Mật khẩu cũ không đúng.");
                    }

                    v_objThanh_Vien.Password = v_strNewPassword;
                    v_objCtrlThanh_Vien.F1002_Update_Thanh_Vien(v_objThanh_Vien);

                    MessageBox.Show("Đổi mật khẩu thành công, Xin mời bạn đăng nhập lại để sử dụng hệ thống.", "/Webadmin/Admin/Signout.aspx");
                }
            }
            catch (Exception ex)
            {
                litError.Text = CCommonFunction.Set_Error_MessageBox(ex.Message);
            }
        }
    }
}