
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

public partial class LstruonglopEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "LstruonglopEdit.aspx?{0}", LstruonglopDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "LstruonglopEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Lstruonglop.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdLichsutruonglop");
	}
}


