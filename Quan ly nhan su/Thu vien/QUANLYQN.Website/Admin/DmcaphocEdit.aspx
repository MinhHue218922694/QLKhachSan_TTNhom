
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DmcaphocEdit.aspx.cs" Inherits="DmcaphocEdit" Title="Dmcaphoc Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Dmcaphoc - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdCaphoc" runat="server" DataSourceID="DmcaphocDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DmcaphocFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DmcaphocFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Dmcaphoc not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:DmcaphocDataSource ID="DmcaphocDataSource" runat="server"
			SelectMethod="GetByIdCaphoc"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdCaphoc" QueryStringField="IdCaphoc" Type="String" />

			</Parameters>
		</data:DmcaphocDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewLstruonglop" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewLstruonglop_SelectedIndexChanged"			 			 
			DataSourceID="LstruonglopDataSource"
			DataKeyNames="IdLichsutruonglop"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Lstruonglop.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Nganhhoc" HeaderText="Nganhhoc" SortExpression="NGANHHOC" />				
				<asp:BoundField DataField="ThoigianBatdau" HeaderText="Thoigian Batdau" SortExpression="THOIGIAN_BATDAU" />				
				<asp:BoundField DataField="ThoigianKetthuc" HeaderText="Thoigian Ketthuc" SortExpression="THOIGIAN_KETTHUC" />				
				<asp:BoundField DataField="Ghichu" HeaderText="Ghichu" SortExpression="GHICHU" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Lstruonglop Found! </b>
				<asp:HyperLink runat="server" ID="hypLstruonglop" NavigateUrl="~/admin/LstruonglopEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:LstruonglopDataSource ID="LstruonglopDataSource" runat="server" SelectMethod="Find">
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:LstruonglopFilter  Column="IdCaphoc" QueryStringField="IdCaphoc" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:LstruonglopDataSource>		
		
		<br />
		

</asp:Content>

