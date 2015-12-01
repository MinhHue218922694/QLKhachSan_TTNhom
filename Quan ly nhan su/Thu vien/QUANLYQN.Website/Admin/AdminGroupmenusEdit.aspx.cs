
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

public partial class AdminGroupmenusEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AdminGroupmenusEdit.aspx?{0}", AdminGroupmenusDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AdminGroupmenusEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "AdminGroupmenus.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdMenu");
	}
}


