
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="LskhenthuongEdit.aspx.cs" Inherits="LskhenthuongEdit" Title="Lskhenthuong Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Lskhenthuong - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdLichsukhenthuong" runat="server" DataSourceID="LskhenthuongDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LskhenthuongFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LskhenthuongFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Lskhenthuong not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:LskhenthuongDataSource ID="LskhenthuongDataSource" runat="server"
			SelectMethod="GetByIdLichsukhenthuong"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdLichsukhenthuong" QueryStringField="IdLichsukhenthuong" Type="String" />

			</Parameters>
		</data:LskhenthuongDataSource>
		
		<br />

		

</asp:Content>

