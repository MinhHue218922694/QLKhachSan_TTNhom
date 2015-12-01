
#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using QUANLYQN.Web.UI;
#endregion

public partial class AdminMenusEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AdminMenusEdit.aspx?{0}", AdminMenusDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AdminMenusEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "AdminMenus.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdMenu");
	}
}


