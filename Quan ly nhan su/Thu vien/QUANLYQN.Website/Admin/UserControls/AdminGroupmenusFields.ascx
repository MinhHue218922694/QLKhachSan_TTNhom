<%@ Control Language="C#" ClassName="AdminGroupmenusFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Menu:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdMenu" DataSourceID="IdMenuAdminMenusDataSource" DataTextField="MenuName" DataValueField="IdMenu" SelectedValue='<%# Bind("IdMenu") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AdminMenusDataSource ID="IdMenuAdminMenusDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Group:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdGroup" DataSourceID="IdGroupAdminGroupsDataSource" DataTextField="GroupName" DataValueField="IdGroup" SelectedValue='<%# Bind("IdGroup") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AdminGroupsDataSource ID="IdGroupAdminGroupsDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">View:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataView" SelectedValue='<%# Bind("View") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			<tr>
				<td class="literal">Add:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataAdd" SelectedValue='<%# Bind("Add") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			<tr>
				<td class="literal">Edit:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataEdit" SelectedValue='<%# Bind("Edit") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			<tr>
				<td class="literal">Delete:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataDelete" SelectedValue='<%# Bind("Delete") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			<tr>
				<td class="literal">Control:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataControl" SelectedValue='<%# Bind("Control") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>				
			
		</table>

	</ItemTemplate>
</asp:FormView>


