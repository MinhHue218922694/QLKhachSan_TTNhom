
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="QuannhanEdit.aspx.cs" Inherits="QuannhanEdit" Title="Quannhan Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Quannhan - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdQuannhan" runat="server" DataSourceID="QuannhanDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/QuannhanFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/QuannhanFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Quannhan not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:QuannhanDataSource ID="QuannhanDataSource" runat="server"
			SelectMethod="GetByIdQuannhan"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdQuannhan" QueryStringField="IdQuannhan" Type="String" />

			</Parameters>
		</data:QuannhanDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewLscapbac" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewLscapbac_SelectedIndexChanged"			 			 
			DataSourceID="LscapbacDataSource"
			DataKeyNames="IdLichsucapbac"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Lscapbac.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Ngaynhan" HeaderText="Ngaynhan" SortExpression="NGAYNHAN" />				
				<asp:BoundField DataField="Ghichu" HeaderText="Ghichu" SortExpression="GHICHU" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Lscapbac Found! </b>
				<asp:HyperLink runat="server" ID="hypLscapbac" NavigateUrl="~/admin/LscapbacEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:LscapbacDataSource ID="LscapbacDataSource" runat="server" SelectMethod="Find">
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:LscapbacFilter  Column="IdQuannhan" QueryStringField="IdQuannhan" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:LscapbacDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewLschucvu" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewLschucvu_SelectedIndexChanged"			 			 
			DataSourceID="LschucvuDataSource"
			DataKeyNames="IdLichsuchucvu"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Lschucvu.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Ngaynhan" HeaderText="Ngaynhan" SortExpression="NGAYNHAN" />				
				<asp:BoundField DataField="Ghichu" HeaderText="Ghichu" SortExpression="GHICHU" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Lschucvu Found! </b>
				<asp:HyperLink runat="server" ID="hypLschucvu" NavigateUrl="~/admin/LschucvuEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:LschucvuDataSource ID="LschucvuDataSource" runat="server" SelectMethod="Find">
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:LschucvuFilter  Column="IdQuannhan" QueryStringField="IdQuannhan" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:LschucvuDataSource>		
		
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
						<data:LskyluatFilter  Column="IdQuannhan" QueryStringField="IdQuannhan" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:LskyluatDataSource>		
		
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
						<data:LskhenthuongFilter  Column="IdQuannhan" QueryStringField="IdQuannhan" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:LskhenthuongDataSource>		
		
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
						<data:LstruonglopFilter  Column="IdQuannhan" QueryStringField="IdQuannhan" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:LstruonglopDataSource>		
		
		<br />
		

</asp:Content>

