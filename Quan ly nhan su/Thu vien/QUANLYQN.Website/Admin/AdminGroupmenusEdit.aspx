
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AdminGroupmenusEdit.aspx.cs" Inherits="AdminGroupmenusEdit" Title="AdminGroupmenus Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Admin Groupmenus - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdMenu, IdGroup" runat="server" DataSourceID="AdminGroupmenusDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AdminGroupmenusFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AdminGroupmenusFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>AdminGroupmenus not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:AdminGroupmenusDataSource ID="AdminGroupmenusDataSource" runat="server"
			SelectMethod="GetByIdMenuIdGroup"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdMenu" QueryStringField="IdMenu" Type="String" />
<asp:QueryStringParameter Name="IdGroup" QueryStringField="IdGroup" Type="String" />

			</Parameters>
		</data:AdminGroupmenusDataSource>
		
		<br />


</asp:Content>

