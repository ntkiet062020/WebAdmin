using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TKS_Thuc_Tap_Web.WebAdmin.Admin
{
    public partial class SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string v_strLang_ID = CSession.Lang_ID;
            Session.Clear();
            Session["Session_ID"] = Session.SessionID;
            CSession.Lang_ID = v_strLang_ID;

            CCommonFunction.RedirectLink_javascript("/WebAdmin/Admin/SignIn.aspx");
        }
    }
}