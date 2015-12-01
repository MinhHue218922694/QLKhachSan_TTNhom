
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DmgioitinhEdit.aspx.cs" Inherits="DmgioitinhEdit" Title="Dmgioitinh Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Dmgioitinh - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdGioitinh" runat="server" DataSourceID="DmgioitinhDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DmgioitinhFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DmgioitinhFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Dmgioitinh not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:DmgioitinhDataSource ID="DmgioitinhDataSource" runat="server"
			SelectMethod="GetByIdGioitinh"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdGioitinh" QueryStringField="IdGioitinh" Type="String" />

			</Parameters>
		</data:DmgioitinhDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewQuannhan" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewQuannhan_SelectedIndexChanged"			 			 
			DataSourceID="QuannhanDataSource"
			DataKeyNames="IdQuannhan"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Quannhan.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="MaQuannhan" HeaderText="Ma Quannhan" SortExpression="MA_QUANNHAN" />				
				<asp:BoundField DataField="HotenKhaisinh" HeaderText="Hoten Khaisinh" SortExpression="HOTEN_KHAISINH" />				
				<asp:BoundField DataField="HotenThuongdung" HeaderText="Hoten Thuongdung" SortExpression="HOTEN_THUONGDUNG" />				
				<asp:BoundField DataField="SotheQuannhan" HeaderText="Sothe Quannhan" SortExpression="SOTHE_QUANNHAN" />				
				<asp:BoundField DataField="CmtQuannhan" HeaderText="Cmt Quannhan" SortExpression="CMT_QUANNHAN" />				
				<asp:BoundField DataField="AnhQuannhan" HeaderText="Anh Quannhan" SortExpression="ANH_QUANNHAN" />				
				<asp:BoundField DataField="Ngaysinh" HeaderText="Ngaysinh" SortExpression="NGAYSINH" />				
				<asp:BoundField DataField="Nguyenquan" HeaderText="Nguyenquan" SortExpression="NGUYENQUAN" />				
				<asp:BoundField DataField="Sinhquan" HeaderText="Sinhquan" SortExpression="SINHQUAN" />				
				<asp:BoundField DataField="Truquan" HeaderText="Truquan" SortExpression="TRUQUAN" />				
				<asp:BoundField DataField="DcBaotin" HeaderText="Dc Baotin" SortExpression="DC_BAOTIN" />				
				<asp:BoundField DataField="HotenCha" HeaderText="Hoten Cha" SortExpression="HOTEN_CHA" />				
				<asp:BoundField DataField="HotenMe" HeaderText="Hoten Me" SortExpression="HOTEN_ME" />				
				<asp:BoundField DataField="SafeNameHotenVoChong" HeaderText="Hoten Vo( Chong)" SortExpression="HOTEN_VO(CHONG)" />				
				<asp:BoundField DataField="SoAnhchiem" HeaderText="So Anhchiem" SortExpression="SO_ANHCHIEM" />				
				<asp:BoundField DataField="Socon" HeaderText="Socon" SortExpression="SOCON" />				
				<asp:BoundField DataField="Cnqs" HeaderText="Cnqs" SortExpression="CNQS" />				
				<asp:BoundField DataField="Backythuat" HeaderText="Backythuat" SortExpression="BACKYTHUAT" />				
				<asp:BoundField DataField="TrinhdoVanhoa" HeaderText="Trinhdo Vanhoa" SortExpression="TRINHDO_VANHOA" />				
				<asp:BoundField DataField="Suckhoe" HeaderText="Suckhoe" SortExpression="SUCKHOE" />				
				<asp:BoundField DataField="Ngoaingu" HeaderText="Ngoaingu" SortExpression="NGOAINGU" />				
				<asp:BoundField DataField="HangThuongtat" HeaderText="Hang Thuongtat" SortExpression="HANG_THUONGTAT" />				
				<asp:BoundField DataField="TpGiadinh" HeaderText="Tp Giadinh" SortExpression="TP_GIADINH" />				
				<asp:BoundField DataField="TpBanthan" HeaderText="Tp Banthan" SortExpression="TP_BANTHAN" />				
				<asp:BoundField DataField="NgayNhapngu" HeaderText="Ngay Nhapngu" SortExpression="NGAY_NHAPNGU" />				
				<asp:BoundField DataField="NgayXuatngu" HeaderText="Ngay Xuatngu" SortExpression="NGAY_XUATNGU" />				
				<asp:BoundField DataField="NgayTaingu" HeaderText="Ngay Taingu" SortExpression="NGAY_TAINGU" />				
				<asp:BoundField DataField="NgayVaodoan" HeaderText="Ngay Vaodoan" SortExpression="NGAY_VAODOAN" />				
				<asp:BoundField DataField="NgayVaodang" HeaderText="Ngay Vaodang" SortExpression="NGAY_VAODANG" />				
				<asp:BoundField DataField="NgayvaodangChinhthuc" HeaderText="Ngayvaodang Chinhthuc" SortExpression="NGAYVAODANG_CHINHTHUC" />				
				<asp:BoundField DataField="NgaycaptheQn" HeaderText="Ngaycapthe Qn" SortExpression="NGAYCAPTHE_QN" />				
				<asp:BoundField DataField="NgaychuyenQncn" HeaderText="Ngaychuyen Qncn" SortExpression="NGAYCHUYEN_QNCN" />				
				<asp:BoundField DataField="NgaychuyenCnv" HeaderText="Ngaychuyen Cnv" SortExpression="NGAYCHUYEN_CNV" />				
				<asp:BoundField DataField="Trangthai" HeaderText="Trangthai" SortExpression="TRANGTHAI" />				
				<asp:BoundField DataField="Ghichu" HeaderText="Ghichu" SortExpression="GHICHU" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Quannhan Found! </b>
				<asp:HyperLink runat="server" ID="hypQuannhan" NavigateUrl="~/admin/QuannhanEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:QuannhanDataSource ID="QuannhanDataSource" runat="server" SelectMethod="Find">
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:QuannhanFilter  Column="IdGioitinh" QueryStringField="IdGioitinh" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:QuannhanDataSource>		
		
		<br />
		

</asp:Content>

