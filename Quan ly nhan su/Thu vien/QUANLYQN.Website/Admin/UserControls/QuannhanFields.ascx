<%@ Control Language="C#" ClassName="QuannhanFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Ma Quannhan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMaQuannhan" Text='<%# Bind("MaQuannhan") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMaQuannhan" runat="server" Display="Dynamic" ControlToValidate="dataMaQuannhan" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Hoten Khaisinh:</td>
				<td>
					<asp:TextBox runat="server" ID="dataHotenKhaisinh" Text='<%# Bind("HotenKhaisinh") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataHotenKhaisinh" runat="server" Display="Dynamic" ControlToValidate="dataHotenKhaisinh" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Hoten Thuongdung:</td>
				<td>
					<asp:TextBox runat="server" ID="dataHotenThuongdung" Text='<%# Bind("HotenThuongdung") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataHotenThuongdung" runat="server" Display="Dynamic" ControlToValidate="dataHotenThuongdung" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Sothe Quannhan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataSotheQuannhan" Text='<%# Bind("SotheQuannhan") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSotheQuannhan" runat="server" Display="Dynamic" ControlToValidate="dataSotheQuannhan" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataSotheQuannhan" runat="server" Display="Dynamic" ControlToValidate="dataSotheQuannhan" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Cmt Quannhan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataCmtQuannhan" Text='<%# Bind("CmtQuannhan") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCmtQuannhan" runat="server" Display="Dynamic" ControlToValidate="dataCmtQuannhan" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataCmtQuannhan" runat="server" Display="Dynamic" ControlToValidate="dataCmtQuannhan" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Anh Quannhan:</td>
				<td>
					<asp:HiddenField runat="server" id="dataAnhQuannhan" Value='<%# Bind("AnhQuannhan") %>'></asp:HiddenField>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ngaysinh:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNgaysinh" Text='<%# Bind("Ngaysinh", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgaysinh" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataNgaysinh" runat="server" Display="Dynamic" ControlToValidate="dataNgaysinh" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Nguyenquan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNguyenquan" Text='<%# Bind("Nguyenquan") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataNguyenquan" runat="server" Display="Dynamic" ControlToValidate="dataNguyenquan" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Sinhquan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataSinhquan" Text='<%# Bind("Sinhquan") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSinhquan" runat="server" Display="Dynamic" ControlToValidate="dataSinhquan" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Truquan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTruquan" Text='<%# Bind("Truquan") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Dc Baotin:</td>
				<td>
					<asp:TextBox runat="server" ID="dataDcBaotin" Text='<%# Bind("DcBaotin") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Hoten Cha:</td>
				<td>
					<asp:TextBox runat="server" ID="dataHotenCha" Text='<%# Bind("HotenCha") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Hoten Me:</td>
				<td>
					<asp:TextBox runat="server" ID="dataHotenMe" Text='<%# Bind("HotenMe") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Hoten Vo( Chong):</td>
				<td>
					<asp:TextBox runat="server" ID="dataSafeNameHotenVoChong" Text='<%# Bind("SafeNameHotenVoChong") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">So Anhchiem:</td>
				<td>
					<asp:TextBox runat="server" ID="dataSoAnhchiem" Text='<%# Bind("SoAnhchiem") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSoAnhchiem" runat="server" Display="Dynamic" ControlToValidate="dataSoAnhchiem" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataSoAnhchiem" runat="server" Display="Dynamic" ControlToValidate="dataSoAnhchiem" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Socon:</td>
				<td>
					<asp:TextBox runat="server" ID="dataSocon" Text='<%# Bind("Socon") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSocon" runat="server" Display="Dynamic" ControlToValidate="dataSocon" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataSocon" runat="server" Display="Dynamic" ControlToValidate="dataSocon" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Capbac:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdCapbac" DataSourceID="IdCapbacDmcapbacDataSource" DataTextField="Capbac" DataValueField="IdCapbac" SelectedValue='<%# Bind("IdCapbac") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DmcapbacDataSource ID="IdCapbacDmcapbacDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Chucvu:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdChucvu" DataSourceID="IdChucvuDmchucvuDataSource" DataTextField="Chucvu" DataValueField="IdChucvu" SelectedValue='<%# Bind("IdChucvu") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DmchucvuDataSource ID="IdChucvuDmchucvuDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Cnqs:</td>
				<td>
					<asp:TextBox runat="server" ID="dataCnqs" Text='<%# Bind("Cnqs") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Backythuat:</td>
				<td>
					<asp:TextBox runat="server" ID="dataBackythuat" Text='<%# Bind("Backythuat") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Trinhdo Vanhoa:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTrinhdoVanhoa" Text='<%# Bind("TrinhdoVanhoa") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTrinhdoVanhoa" runat="server" Display="Dynamic" ControlToValidate="dataTrinhdoVanhoa" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Suckhoe:</td>
				<td>
					<asp:TextBox runat="server" ID="dataSuckhoe" Text='<%# Bind("Suckhoe") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ngoaingu:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNgoaingu" Text='<%# Bind("Ngoaingu") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Hang Thuongtat:</td>
				<td>
					<asp:TextBox runat="server" ID="dataHangThuongtat" Text='<%# Bind("HangThuongtat") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Tp Giadinh:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTpGiadinh" Text='<%# Bind("TpGiadinh") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Tp Banthan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTpBanthan" Text='<%# Bind("TpBanthan") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Dantoc:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdDantoc" DataSourceID="IdDantocDmdantocDataSource" DataTextField="Dantoc" DataValueField="IdDantoc" SelectedValue='<%# Bind("IdDantoc") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DmdantocDataSource ID="IdDantocDmdantocDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Tongiao:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdTongiao" DataSourceID="IdTongiaoDmtongiaoDataSource" DataTextField="Tongiao" DataValueField="IdTongiao" SelectedValue='<%# Bind("IdTongiao") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DmtongiaoDataSource ID="IdTongiaoDmtongiaoDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Gioitinh:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdGioitinh" DataSourceID="IdGioitinhDmgioitinhDataSource" DataTextField="Gioitinh" DataValueField="IdGioitinh" SelectedValue='<%# Bind("IdGioitinh") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DmgioitinhDataSource ID="IdGioitinhDmgioitinhDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Ngay Nhapngu:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNgayNhapngu" Text='<%# Bind("NgayNhapngu", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgayNhapngu" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataNgayNhapngu" runat="server" Display="Dynamic" ControlToValidate="dataNgayNhapngu" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ngay Xuatngu:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNgayXuatngu" Text='<%# Bind("NgayXuatngu", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgayXuatngu" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">Ngay Taingu:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNgayTaingu" Text='<%# Bind("NgayTaingu", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgayTaingu" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">Ngay Vaodoan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNgayVaodoan" Text='<%# Bind("NgayVaodoan", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgayVaodoan" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">Ngay Vaodang:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNgayVaodang" Text='<%# Bind("NgayVaodang", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgayVaodang" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">Ngayvaodang Chinhthuc:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNgayvaodangChinhthuc" Text='<%# Bind("NgayvaodangChinhthuc", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgayvaodangChinhthuc" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">Ngaycapthe Qn:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNgaycaptheQn" Text='<%# Bind("NgaycaptheQn", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgaycaptheQn" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">Ngaychuyen Qncn:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNgaychuyenQncn" Text='<%# Bind("NgaychuyenQncn", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgaychuyenQncn" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">Ngaychuyen Cnv:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNgaychuyenCnv" Text='<%# Bind("NgaychuyenCnv", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgaychuyenCnv" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Donvi:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdDonvi" DataSourceID="IdDonviDmdonviDataSource" DataTextField="MaDonvi" DataValueField="IdDonvi" SelectedValue='<%# Bind("IdDonvi") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DmdonviDataSource ID="IdDonviDmdonviDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Lop:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdLop" DataSourceID="IdLopDmlopDataSource" DataTextField="Malop" DataValueField="IdLop" SelectedValue='<%# Bind("IdLop") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DmlopDataSource ID="IdLopDmlopDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Loaiquannhan:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdLoaiquannhan" DataSourceID="IdLoaiquannhanDmloaiquannhanDataSource" DataTextField="LoaiQuannhan" DataValueField="IdLoaiqn" SelectedValue='<%# Bind("IdLoaiquannhan") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DmloaiquannhanDataSource ID="IdLoaiquannhanDmloaiquannhanDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Trangthai:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTrangthai" Text='<%# Bind("Trangthai") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTrangthai" runat="server" Display="Dynamic" ControlToValidate="dataTrangthai" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ghichu:</td>
				<td>
					<asp:TextBox runat="server" ID="dataGhichu" Text='<%# Bind("Ghichu") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			
		</table>

	</ItemTemplate>
</asp:FormView>


