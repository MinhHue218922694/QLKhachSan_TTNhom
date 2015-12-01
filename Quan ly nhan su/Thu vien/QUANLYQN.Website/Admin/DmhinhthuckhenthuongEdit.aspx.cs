
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

public partial class DmhinhthuckhenthuongEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "DmhinhthuckhenthuongEdit.aspx?{0}", DmhinhthuckhenthuongDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "DmhinhthuckhenthuongEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Dmhinhthuckhenthuong.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdHinhthucKhenthuong");
	}
	protected void GridViewLskhenthuong_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdLichsukhenthuong={0}", GridViewLskhenthuong.SelectedDataKey.Values[0]);
		Response.Redirect("LskhenthuongEdit.aspx?" + urlParams, true);		
	}	
}


