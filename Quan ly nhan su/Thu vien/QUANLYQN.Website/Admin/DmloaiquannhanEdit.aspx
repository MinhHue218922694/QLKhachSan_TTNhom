
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DmloaiquannhanEdit.aspx.cs" Inherits="DmloaiquannhanEdit" Title="Dmloaiquannhan Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Dmloaiquannhan - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdLoaiqn" runat="server" DataSourceID="DmloaiquannhanDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DmloaiquannhanFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DmloaiquannhanFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Dmloaiquannhan not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:DmloaiquannhanDataSource ID="DmloaiquannhanDataSource" runat="server"
			SelectMethod="GetByIdLoaiqn"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdLoaiqn" QueryStringField="IdLoaiqn" Type="String" />

			</Parameters>
		</data:DmloaiquannhanDataSource>
		
		<br />

		

</asp:Content>

