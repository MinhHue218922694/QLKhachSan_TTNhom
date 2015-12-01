
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Quannhan.aspx.cs" Inherits="Quannhan" Title="Quannhan List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Quannhan List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="QuannhanDataSource"
				DataKeyNames="IdQuannhan"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Quannhan.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="MaQuannhan" HeaderText="Ma Quannhan" SortExpression="MA_QUANNHAN"  />
				<asp:BoundField DataField="HotenKhaisinh" HeaderText="Hoten Khaisinh" SortExpression="HOTEN_KHAISINH"  />
				<asp:BoundField DataField="HotenThuongdung" HeaderText="Hoten Thuongdung" SortExpression="HOTEN_THUONGDUNG"  />
				<asp:BoundField DataField="SotheQuannhan" HeaderText="Sothe Quannhan" SortExpression="SOTHE_QUANNHAN"  />
				<asp:BoundField DataField="CmtQuannhan" HeaderText="Cmt Quannhan" SortExpression="CMT_QUANNHAN"  />
				<asp:BoundField DataField="AnhQuannhan" HeaderText="Anh Quannhan" SortExpression="ANH_QUANNHAN"  />
				<asp:BoundField DataField="Ngaysinh" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngaysinh" SortExpression="NGAYSINH"  />
				<asp:BoundField DataField="Nguyenquan" HeaderText="Nguyenquan" SortExpression=""  />
				<asp:BoundField DataField="Sinhquan" HeaderText="Sinhquan" SortExpression=""  />
				<asp:BoundField DataField="Truquan" HeaderText="Truquan" SortExpression=""  />
				<asp:BoundField DataField="DcBaotin" HeaderText="Dc Baotin" SortExpression=""  />
				<asp:BoundField DataField="HotenCha" HeaderText="Hoten Cha" SortExpression="HOTEN_CHA"  />
				<asp:BoundField DataField="HotenMe" HeaderText="Hoten Me" SortExpression="HOTEN_ME"  />
				<asp:BoundField DataField="SafeNameHotenVoChong" HeaderText="Hoten Vo( Chong)" SortExpression="HOTEN_VO(CHONG)"  />
				<asp:BoundField DataField="SoAnhchiem" HeaderText="So Anhchiem" SortExpression="SO_ANHCHIEM"  />
				<asp:BoundField DataField="Socon" HeaderText="Socon" SortExpression="SOCON"  />
				<data:HyperLinkField HeaderText="Id Capbac" DataNavigateUrlFormatString="DmcapbacEdit.aspx?IdCapbac={0}" DataNavigateUrlFields="IdCapbac" DataContainer="IdCapbacSource" DataTextField="Capbac" />
				<data:HyperLinkField HeaderText="Id Chucvu" DataNavigateUrlFormatString="DmchucvuEdit.aspx?IdChucvu={0}" DataNavigateUrlFields="IdChucvu" DataContainer="IdChucvuSource" DataTextField="Chucvu" />
				<asp:BoundField DataField="Cnqs" HeaderText="Cnqs" SortExpression="CNQS"  />
				<asp:BoundField DataField="Backythuat" HeaderText="Backythuat" SortExpression="BACKYTHUAT"  />
				<asp:BoundField DataField="TrinhdoVanhoa" HeaderText="Trinhdo Vanhoa" SortExpression="TRINHDO_VANHOA"  />
				<asp:BoundField DataField="Suckhoe" HeaderText="Suckhoe" SortExpression="SUCKHOE"  />
				<asp:BoundField DataField="Ngoaingu" HeaderText="Ngoaingu" SortExpression="NGOAINGU"  />
				<asp:BoundField DataField="HangThuongtat" HeaderText="Hang Thuongtat" SortExpression="HANG_THUONGTAT"  />
				<asp:BoundField DataField="TpGiadinh" HeaderText="Tp Giadinh" SortExpression="TP_GIADINH"  />
				<asp:BoundField DataField="TpBanthan" HeaderText="Tp Banthan" SortExpression="TP_BANTHAN"  />
				<data:HyperLinkField HeaderText="Id Dantoc" DataNavigateUrlFormatString="DmdantocEdit.aspx?IdDantoc={0}" DataNavigateUrlFields="IdDantoc" DataContainer="IdDantocSource" DataTextField="Dantoc" />
				<data:HyperLinkField HeaderText="Id Tongiao" DataNavigateUrlFormatString="DmtongiaoEdit.aspx?IdTongiao={0}" DataNavigateUrlFields="IdTongiao" DataContainer="IdTongiaoSource" DataTextField="Tongiao" />
				<data:HyperLinkField HeaderText="Id Gioitinh" DataNavigateUrlFormatString="DmgioitinhEdit.aspx?IdGioitinh={0}" DataNavigateUrlFields="IdGioitinh" DataContainer="IdGioitinhSource" DataTextField="Gioitinh" />
				<asp:BoundField DataField="NgayNhapngu" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngay Nhapngu" SortExpression="NGAY_NHAPNGU"  />
				<asp:BoundField DataField="NgayXuatngu" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngay Xuatngu" SortExpression="NGAY_XUATNGU"  />
				<asp:BoundField DataField="NgayTaingu" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngay Taingu" SortExpression="NGAY_TAINGU"  />
				<asp:BoundField DataField="NgayVaodoan" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngay Vaodoan" SortExpression="NGAY_VAODOAN"  />
				<asp:BoundField DataField="NgayVaodang" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngay Vaodang" SortExpression="NGAY_VAODANG"  />
				<asp:BoundField DataField="NgayvaodangChinhthuc" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngayvaodang Chinhthuc" SortExpression="NGAYVAODANG_CHINHTHUC"  />
				<asp:BoundField DataField="NgaycaptheQn" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngaycapthe Qn" SortExpression="NGAYCAPTHE_QN"  />
				<asp:BoundField DataField="NgaychuyenQncn" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngaychuyen Qncn" SortExpression="NGAYCHUYEN_QNCN"  />
				<asp:BoundField DataField="NgaychuyenCnv" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngaychuyen Cnv" SortExpression="NGAYCHUYEN_CNV"  />
				<data:HyperLinkField HeaderText="Id Donvi" DataNavigateUrlFormatString="DmdonviEdit.aspx?IdDonvi={0}" DataNavigateUrlFields="IdDonvi" DataContainer="IdDonviSource" DataTextField="MaDonvi" />
				<data:HyperLinkField HeaderText="Id Lop" DataNavigateUrlFormatString="DmlopEdit.aspx?IdLop={0}" DataNavigateUrlFields="IdLop" DataContainer="IdLopSource" DataTextField="Malop" />
				<data:HyperLinkField HeaderText="Id Loaiquannhan" DataNavigateUrlFormatString="DmloaiquannhanEdit.aspx?IdLoaiqn={0}" DataNavigateUrlFields="IdLoaiqn" DataContainer="IdLoaiquannhanSource" DataTextField="LoaiQuannhan" />
				<asp:BoundField DataField="Trangthai" HeaderText="Trangthai" SortExpression="TRANGTHAI"  />
				<asp:BoundField DataField="Ghichu" HeaderText="Ghichu" SortExpression=""  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Quannhan Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnQuannhan" OnClientClick="javascript:location.href='QuannhanEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:QuannhanDataSource ID="QuannhanDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:QuannhanProperty Name="Dmgioitinh"/> 
					<data:QuannhanProperty Name="Dmloaiquannhan"/> 
					<data:QuannhanProperty Name="Dmdantoc"/> 
					<data:QuannhanProperty Name="Dmtongiao"/> 
					<data:QuannhanProperty Name="Dmdonvi"/> 
					<data:QuannhanProperty Name="Dmcapbac"/> 
					<data:QuannhanProperty Name="Dmchucvu"/> 
					<data:QuannhanProperty Name="Dmlop"/> 
					<%--<data:QuannhanProperty Name="LschucvuCollection" />--%>
					<%--<data:QuannhanProperty Name="LscapbacCollection" />--%>
					<%--<data:QuannhanProperty Name="LskyluatCollection" />--%>
					<%--<data:QuannhanProperty Name="LskhenthuongCollection" />--%>
					<%--<data:QuannhanProperty Name="LstruonglopCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:QuannhanDataSource>
	    		
</asp:Content>



