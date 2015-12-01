<%@ Control Language="C#" ClassName="DmlopFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Malop:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMalop" Text='<%# Bind("Malop") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMalop" runat="server" Display="Dynamic" ControlToValidate="dataMalop" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Tenlop:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenlop" Text='<%# Bind("Tenlop") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTenlop" runat="server" Display="Dynamic" ControlToValidate="dataTenlop" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Daidoi:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdDaidoi" DataSourceID="IdDaidoiDmdonviDataSource" DataTextField="MaDonvi" DataValueField="IdDonvi" SelectedValue='<%# Bind("IdDaidoi") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DmdonviDataSource ID="IdDaidoiDmdonviDataSource" runat="server" SelectMethod="GetAll"  />
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


