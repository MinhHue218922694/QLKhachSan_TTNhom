<%@ Control Language="C#" ClassName="LstruonglopFields" %>

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
				<td class="literal">Id Truong:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdTruong" DataSourceID="IdTruongDmtruongDataSource" DataTextField="Tentruong" DataValueField="IdTruong" SelectedValue='<%# Bind("IdTruong") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DmtruongDataSource ID="IdTruongDmtruongDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Caphoc:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdCaphoc" DataSourceID="IdCaphocDmcaphocDataSource" DataTextField="Caphoc" DataValueField="IdCaphoc" SelectedValue='<%# Bind("IdCaphoc") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DmcaphocDataSource ID="IdCaphocDmcaphocDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Nganhhoc:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNganhhoc" Text='<%# Bind("Nganhhoc") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Thoigian Batdau:</td>
				<td>
					<asp:TextBox runat="server" ID="dataThoigianBatdau" Text='<%# Bind("ThoigianBatdau", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataThoigianBatdau" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">Thoigian Ketthuc:</td>
				<td>
					<asp:TextBox runat="server" ID="dataThoigianKetthuc" Text='<%# Bind("ThoigianKetthuc", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataThoigianKetthuc" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
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


