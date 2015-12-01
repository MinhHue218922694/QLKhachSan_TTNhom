<%@ Control Language="C#" ClassName="DmloaiquannhanFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Loai Quannhan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataLoaiQuannhan" Text='<%# Bind("LoaiQuannhan") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataLoaiQuannhan" runat="server" Display="Dynamic" ControlToValidate="dataLoaiQuannhan" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ghichu:</td>
				<td>
					<asp:TextBox runat="server" ID="dataGhichu" Text='<%# Bind("Ghichu") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>				
			
		</table>

	</ItemTemplate>
</asp:FormView>


