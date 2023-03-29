using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TKS_Thuc_Tap_Web.WebAdmin.Admin.UserControl
{
    public partial class uc1009_Thong_Tin_Account : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grdData.SettingsSearchPanel.Visible = false;
            }
        }
    }
}