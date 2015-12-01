<%@ Control Language="C#" ClassName="LskhenthuongFields" %>

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
				<td class="literal">Id Hinhthuc Khenthuong:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdHinhthucKhenthuong" DataSourceID="IdHinhthucKhenthuongDmhinhthuckhenthuongDataSource" DataTextField="HinhthucKhenthuong" DataValueField="IdHinhthucKhenthuong" SelectedValue='<%# Bind("IdHinhthucKhenthuong") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DmhinhthuckhenthuongDataSource ID="IdHinhthucKhenthuongDmhinhthuckhenthuongDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Cap Khenthuong:</td>
				<td>
					<asp:TextBox runat="server" ID="dataCapKhenthuong" Text='<%# Bind("CapKhenthuong") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCapKhenthuong" runat="server" Display="Dynamic" ControlToValidate="dataCapKhenthuong" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ngaynhan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNgaynhan" Text='<%# Bind("Ngaynhan", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgaynhan" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
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


