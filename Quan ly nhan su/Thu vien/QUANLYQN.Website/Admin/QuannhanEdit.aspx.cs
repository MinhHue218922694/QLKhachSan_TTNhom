
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

public partial class QuannhanEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "QuannhanEdit.aspx?{0}", QuannhanDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "QuannhanEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Quannhan.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdQuannhan");
	}
	protected void GridViewLscapbac_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdLichsucapbac={0}", GridViewLscapbac.SelectedDataKey.Values[0]);
		Response.Redirect("LscapbacEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewLschucvu_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdLichsuchucvu={0}", GridViewLschucvu.SelectedDataKey.Values[0]);
		Response.Redirect("LschucvuEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewLskyluat_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdLichsukyluat={0}", GridViewLskyluat.SelectedDataKey.Values[0]);
		Response.Redirect("LskyluatEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewLskhenthuong_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdLichsukhenthuong={0}", GridViewLskhenthuong.SelectedDataKey.Values[0]);
		Response.Redirect("LskhenthuongEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewLstruonglop_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdLichsutruonglop={0}", GridViewLstruonglop.SelectedDataKey.Values[0]);
		Response.Redirect("LstruonglopEdit.aspx?" + urlParams, true);		
	}	
}


