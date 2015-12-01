
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

public partial class DmcapbacEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "DmcapbacEdit.aspx?{0}", DmcapbacDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "DmcapbacEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Dmcapbac.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdCapbac");
	}
	protected void GridViewLscapbac_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdLichsucapbac={0}", GridViewLscapbac.SelectedDataKey.Values[0]);
		Response.Redirect("LscapbacEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewQuannhan_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdQuannhan={0}", GridViewQuannhan.SelectedDataKey.Values[0]);
		Response.Redirect("QuannhanEdit.aspx?" + urlParams, true);		
	}	
}


