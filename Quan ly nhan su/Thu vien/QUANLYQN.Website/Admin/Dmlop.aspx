
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Dmlop.aspx.cs" Inherits="Dmlop" Title="Dmlop List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Dmlop List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="DmlopDataSource"
				DataKeyNames="IdLop"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Dmlop.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Malop" HeaderText="Malop" SortExpression="MALOP"  />
				<asp:BoundField DataField="Tenlop" HeaderText="Tenlop" SortExpression="TENLOP"  />
				<data:HyperLinkField HeaderText="Id Daidoi" DataNavigateUrlFormatString="DmdonviEdit.aspx?IdDonvi={0}" DataNavigateUrlFields="IdDonvi" DataContainer="IdDaidoiSource" DataTextField="MaDonvi" />
				<asp:BoundField DataField="Ghichu" HeaderText="Ghichu" SortExpression=""  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Dmlop Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnDmlop" OnClientClick="javascript:location.href='DmlopEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:DmlopDataSource ID="DmlopDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:DmlopProperty Name="Dmdonvi"/> 
					<%--<data:DmlopProperty Name="QuannhanCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:DmlopDataSource>
	    		
</asp:Content>



