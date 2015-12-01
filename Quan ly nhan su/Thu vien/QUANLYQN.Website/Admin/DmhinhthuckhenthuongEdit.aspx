
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DmhinhthuckhenthuongEdit.aspx.cs" Inherits="DmhinhthuckhenthuongEdit" Title="Dmhinhthuckhenthuong Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Dmhinhthuckhenthuong - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdHinhthucKhenthuong" runat="server" DataSourceID="DmhinhthuckhenthuongDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DmhinhthuckhenthuongFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DmhinhthuckhenthuongFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Dmhinhthuckhenthuong not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:DmhinhthuckhenthuongDataSource ID="DmhinhthuckhenthuongDataSource" runat="server"
			SelectMethod="GetByIdHinhthucKhenthuong"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdHinhthucKhenthuong" QueryStringField="IdHinhthucKhenthuong" Type="String" />

			</Parameters>
		</data:DmhinhthuckhenthuongDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewLskhenthuong" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewLskhenthuong_SelectedIndexChanged"			 			 
			DataSourceID="LskhenthuongDataSource"
			DataKeyNames="IdLichsukhenthuong"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Lskhenthuong.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="CapKhenthuong" HeaderText="Cap Khenthuong" SortExpression="CAP_KHENTHUONG" />				
				<asp:BoundField DataField="Ngaynhan" HeaderText="Ngaynhan" SortExpression="NGAYNHAN" />				
				<asp:BoundField DataField="Ghichu" HeaderText="Ghichu" SortExpression="GHICHU" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Lskhenthuong Found! </b>
				<asp:HyperLink runat="server" ID="hypLskhenthuong" NavigateUrl="~/admin/LskhenthuongEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:LskhenthuongDataSource ID="LskhenthuongDataSource" runat="server" SelectMethod="Find">
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:LskhenthuongFilter  Column="IdHinhthucKhenthuong" QueryStringField="IdHinhthucKhenthuong" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:LskhenthuongDataSource>		
		
		<br />
		

</asp:Content>

