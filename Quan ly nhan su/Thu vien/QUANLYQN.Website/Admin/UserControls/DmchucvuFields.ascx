<%@ Control Language="C#" ClassName="DmchucvuFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Chucvu:</td>
				<td>
					<asp:TextBox runat="server" ID="dataChucvu" Text='<%# Bind("Chucvu") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataChucvu" runat="server" Display="Dynamic" ControlToValidate="dataChucvu" ErrorMessage="Required"></asp:RequiredFieldValidator>
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


