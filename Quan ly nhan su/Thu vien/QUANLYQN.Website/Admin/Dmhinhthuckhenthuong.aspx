
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Dmhinhthuckhenthuong.aspx.cs" Inherits="Dmhinhthuckhenthuong" Title="Dmhinhthuckhenthuong List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Dmhinhthuckhenthuong List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="DmhinhthuckhenthuongDataSource"
				DataKeyNames="IdHinhthucKhenthuong"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Dmhinhthuckhenthuong.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="HinhthucKhenthuong" HeaderText="Hinhthuc Khenthuong" SortExpression="HINHTHUC_KHENTHUONG"  />
				<asp:BoundField DataField="Ghichu" HeaderText="Ghichu" SortExpression=""  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Dmhinhthuckhenthuong Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnDmhinhthuckhenthuong" OnClientClick="javascript:location.href='DmhinhthuckhenthuongEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:DmhinhthuckhenthuongDataSource ID="DmhinhthuckhenthuongDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
>			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:DmhinhthuckhenthuongDataSource>
	    		
</asp:Content>



