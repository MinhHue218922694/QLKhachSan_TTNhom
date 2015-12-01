
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AdminGroupusersEdit.aspx.cs" Inherits="AdminGroupusersEdit" Title="AdminGroupusers Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Admin Groupusers - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdGroup, IdUser" runat="server" DataSourceID="AdminGroupusersDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AdminGroupusersFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AdminGroupusersFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>AdminGroupusers not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:AdminGroupusersDataSource ID="AdminGroupusersDataSource" runat="server"
			SelectMethod="GetByIdGroupIdUser"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdGroup" QueryStringField="IdGroup" Type="String" />
<asp:QueryStringParameter Name="IdUser" QueryStringField="IdUser" Type="String" />

			</Parameters>
		</data:AdminGroupusersDataSource>
		
		<br />


</asp:Content>

