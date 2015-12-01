<%@ Control Language="C#" ClassName="AdminGroupusersFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Group:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdGroup" DataSourceID="IdGroupAdminGroupsDataSource" DataTextField="GroupName" DataValueField="IdGroup" SelectedValue='<%# Bind("IdGroup") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AdminGroupsDataSource ID="IdGroupAdminGroupsDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id User:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdUser" DataSourceID="IdUserAdminUsersDataSource" DataTextField="Password" DataValueField="IdUser" SelectedValue='<%# Bind("IdUser") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AdminUsersDataSource ID="IdUserAdminUsersDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			
		</table>

	</ItemTemplate>
</asp:FormView>


