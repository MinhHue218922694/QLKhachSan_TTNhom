<%@ Control Language="C#" ClassName="AdminMenusFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Menu:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdMenu" Text='<%# Bind("IdMenu") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdMenu" runat="server" Display="Dynamic" ControlToValidate="dataIdMenu" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Menu Name:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMenuName" Text='<%# Bind("MenuName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMenuName" runat="server" Display="Dynamic" ControlToValidate="dataMenuName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Active:</td>
				<td>
					<asp:TextBox runat="server" ID="dataActive" Text='<%# Bind("Active") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataActive" runat="server" Display="Dynamic" ControlToValidate="dataActive" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Parent:</td>
				<td>
					<asp:TextBox runat="server" ID="dataParent" Text='<%# Bind("Parent") %>' MaxLength="15"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataParent" runat="server" Display="Dynamic" ControlToValidate="dataParent" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Image Name:</td>
				<td>
					<asp:TextBox runat="server" ID="dataImageName" Text='<%# Bind("ImageName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Is Create Icon:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIsCreateIcon" Text='<%# Bind("IsCreateIcon") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataIsCreateIcon" runat="server" Display="Dynamic" ControlToValidate="dataIsCreateIcon" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Description:</td>
				<td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Checked:</td>
				<td>
					<asp:TextBox runat="server" ID="dataSafeNameChecked" Text='<%# Bind("SafeNameChecked") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSafeNameChecked" runat="server" Display="Dynamic" ControlToValidate="dataSafeNameChecked" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Modified:</td>
				<td>
					<asp:TextBox runat="server" ID="dataModified" Text='<%# Bind("Modified", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataModified" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">Menu Order:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMenuOrder" Text='<%# Bind("MenuOrder") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMenuOrder" runat="server" Display="Dynamic" ControlToValidate="dataMenuOrder" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			
		</table>

	</ItemTemplate>
</asp:FormView>


