<%@ Control Language="C#" ClassName="LskyluatFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Quannhan:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdQuannhan" DataSourceID="IdQuannhanQuannhanDataSource" DataTextField="MaQuannhan" DataValueField="IdQuannhan" SelectedValue='<%# Bind("IdQuannhan") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:QuannhanDataSource ID="IdQuannhanQuannhanDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Hinhthuc Kyluat:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdHinhthucKyluat" DataSourceID="IdHinhthucKyluatDmhinhthuckyluatDataSource" DataTextField="HinhthucKyluat" DataValueField="IdHinhthucKyluat" SelectedValue='<%# Bind("IdHinhthucKyluat") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DmhinhthuckyluatDataSource ID="IdHinhthucKyluatDmhinhthuckyluatDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Cap Kyluat:</td>
				<td>
					<asp:TextBox runat="server" ID="dataCapKyluat" Text='<%# Bind("CapKyluat") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCapKyluat" runat="server" Display="Dynamic" ControlToValidate="dataCapKyluat" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ngay Quyetdinh:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNgayQuyetdinh" Text='<%# Bind("NgayQuyetdinh", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgayQuyetdinh" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
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


