
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

public partial class AdminGroupusersEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AdminGroupusersEdit.aspx?{0}", AdminGroupusersDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AdminGroupusersEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "AdminGroupusers.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdGroup");
	}
}


