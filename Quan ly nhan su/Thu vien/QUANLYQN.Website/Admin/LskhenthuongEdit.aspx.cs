
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

public partial class LskhenthuongEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "LskhenthuongEdit.aspx?{0}", LskhenthuongDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "LskhenthuongEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Lskhenthuong.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdLichsukhenthuong");
	}
}


