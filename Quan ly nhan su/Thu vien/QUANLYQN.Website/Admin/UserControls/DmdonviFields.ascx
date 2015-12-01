<%@ Control Language="C#" ClassName="DmdonviFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Ma Donvi:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMaDonvi" Text='<%# Bind("MaDonvi") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Donvi:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenDonvi" Text='<%# Bind("TenDonvi") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Donvicha:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdDonvicha" Text='<%# Bind("IdDonvicha") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataIdDonvicha" runat="server" Display="Dynamic" ControlToValidate="dataIdDonvicha" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
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


