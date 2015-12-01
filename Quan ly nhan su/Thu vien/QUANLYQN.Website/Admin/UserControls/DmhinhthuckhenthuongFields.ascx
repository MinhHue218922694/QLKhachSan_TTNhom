<%@ Control Language="C#" ClassName="DmhinhthuckhenthuongFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Hinhthuc Khenthuong:</td>
				<td>
					<asp:TextBox runat="server" ID="dataHinhthucKhenthuong" Text='<%# Bind("HinhthucKhenthuong") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataHinhthucKhenthuong" runat="server" Display="Dynamic" ControlToValidate="dataHinhthucKhenthuong" ErrorMessage="Required"></asp:RequiredFieldValidator>
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


