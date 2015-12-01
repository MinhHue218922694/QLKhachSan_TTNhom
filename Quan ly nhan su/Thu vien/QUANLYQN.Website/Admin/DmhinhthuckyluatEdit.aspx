
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DmhinhthuckyluatEdit.aspx.cs" Inherits="DmhinhthuckyluatEdit" Title="Dmhinhthuckyluat Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Dmhinhthuckyluat - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdHinhthucKyluat" runat="server" DataSourceID="DmhinhthuckyluatDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DmhinhthuckyluatFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DmhinhthuckyluatFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Dmhinhthuckyluat not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:DmhinhthuckyluatDataSource ID="DmhinhthuckyluatDataSource" runat="server"
			SelectMethod="GetByIdHinhthucKyluat"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdHinhthucKyluat" QueryStringField="IdHinhthucKyluat" Type="String" />

			</Parameters>
		</data:DmhinhthuckyluatDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewLskyluat" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewLskyluat_SelectedIndexChanged"			 			 
			DataSourceID="LskyluatDataSource"
			DataKeyNames="IdLichsukyluat"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Lskyluat.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="CapKyluat" HeaderText="Cap Kyluat" SortExpression="CAP_KYLUAT" />				
				<asp:BoundField DataField="NgayQuyetdinh" HeaderText="Ngay Quyetdinh" SortExpression="NGAY_QUYETDINH" />				
				<asp:BoundField DataField="Ghichu" HeaderText="Ghichu" SortExpression="GHICHU" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Lskyluat Found! </b>
				<asp:HyperLink runat="server" ID="hypLskyluat" NavigateUrl="~/admin/LskyluatEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:LskyluatDataSource ID="LskyluatDataSource" runat="server" SelectMethod="Find">
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:LskyluatFilter  Column="IdHinhthucKyluat" QueryStringField="IdHinhthucKyluat" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:LskyluatDataSource>		
		
		<br />
		

</asp:Content>

