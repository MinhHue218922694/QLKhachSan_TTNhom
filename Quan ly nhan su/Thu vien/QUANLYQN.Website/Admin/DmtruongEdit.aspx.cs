
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

public partial class DmtruongEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "DmtruongEdit.aspx?{0}", DmtruongDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "DmtruongEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Dmtruong.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdTruong");
	}
	protected void GridViewLstruonglop_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdLichsutruonglop={0}", GridViewLstruonglop.SelectedDataKey.Values[0]);
		Response.Redirect("LstruonglopEdit.aspx?" + urlParams, true);		
	}	
}


