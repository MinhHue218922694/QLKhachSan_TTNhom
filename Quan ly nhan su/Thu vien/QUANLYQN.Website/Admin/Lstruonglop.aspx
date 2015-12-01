
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Lstruonglop.aspx.cs" Inherits="Lstruonglop" Title="Lstruonglop List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Lstruonglop List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="LstruonglopDataSource"
				DataKeyNames="IdLichsutruonglop"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Lstruonglop.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Id Quannhan" DataNavigateUrlFormatString="QuannhanEdit.aspx?IdQuannhan={0}" DataNavigateUrlFields="IdQuannhan" DataContainer="IdQuannhanSource" DataTextField="MaQuannhan" />
				<data:HyperLinkField HeaderText="Id Truong" DataNavigateUrlFormatString="DmtruongEdit.aspx?IdTruong={0}" DataNavigateUrlFields="IdTruong" DataContainer="IdTruongSource" DataTextField="Tentruong" />
				<data:HyperLinkField HeaderText="Id Caphoc" DataNavigateUrlFormatString="DmcaphocEdit.aspx?IdCaphoc={0}" DataNavigateUrlFields="IdCaphoc" DataContainer="IdCaphocSource" DataTextField="Caphoc" />
				<asp:BoundField DataField="Nganhhoc" HeaderText="Nganhhoc" SortExpression="NGANHHOC"  />
				<asp:BoundField DataField="ThoigianBatdau" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Thoigian Batdau" SortExpression="THOIGIAN_BATDAU"  />
				<asp:BoundField DataField="ThoigianKetthuc" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Thoigian Ketthuc" SortExpression="THOIGIAN_KETTHUC"  />
				<asp:BoundField DataField="Ghichu" HeaderText="Ghichu" SortExpression=""  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Lstruonglop Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnLstruonglop" OnClientClick="javascript:location.href='LstruonglopEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:LstruonglopDataSource ID="LstruonglopDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:LstruonglopProperty Name="Dmtruong"/> 
					<data:LstruonglopProperty Name="Dmcaphoc"/> 
					<data:LstruonglopProperty Name="Quannhan"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:LstruonglopDataSource>
	    		
</asp:Content>



