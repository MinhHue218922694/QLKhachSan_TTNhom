
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

public partial class DmchucvuEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "DmchucvuEdit.aspx?{0}", DmchucvuDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "DmchucvuEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Dmchucvu.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdChucvu");
	}
	protected void GridViewLschucvu_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdLichsuchucvu={0}", GridViewLschucvu.SelectedDataKey.Values[0]);
		Response.Redirect("LschucvuEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewQuannhan_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdQuannhan={0}", GridViewQuannhan.SelectedDataKey.Values[0]);
		Response.Redirect("QuannhanEdit.aspx?" + urlParams, true);		
	}	
}


