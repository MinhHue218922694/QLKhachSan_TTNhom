<%@ Control Language="C#" ClassName="DmhinhthuckyluatFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Hinhthuc Kyluat:</td>
				<td>
					<asp:TextBox runat="server" ID="dataHinhthucKyluat" Text='<%# Bind("HinhthucKyluat") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataHinhthucKyluat" runat="server" Display="Dynamic" ControlToValidate="dataHinhthucKyluat" ErrorMessage="Required"></asp:RequiredFieldValidator>
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


