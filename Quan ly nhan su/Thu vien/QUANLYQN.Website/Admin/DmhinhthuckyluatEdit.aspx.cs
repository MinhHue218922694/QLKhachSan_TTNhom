
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

public partial class DmhinhthuckyluatEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "DmhinhthuckyluatEdit.aspx?{0}", DmhinhthuckyluatDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "DmhinhthuckyluatEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Dmhinhthuckyluat.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdHinhthucKyluat");
	}
	protected void GridViewLskyluat_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdLichsukyluat={0}", GridViewLskyluat.SelectedDataKey.Values[0]);
		Response.Redirect("LskyluatEdit.aspx?" + urlParams, true);		
	}	
}


