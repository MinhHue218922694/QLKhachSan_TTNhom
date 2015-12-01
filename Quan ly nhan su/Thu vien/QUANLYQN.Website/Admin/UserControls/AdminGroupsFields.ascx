<%@ Control Language="C#" ClassName="AdminGroupsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Group:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdGroup" Text='<%# Bind("IdGroup") %>' MaxLength="15"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdGroup" runat="server" Display="Dynamic" ControlToValidate="dataIdGroup" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Group Name:</td>
				<td>
					<asp:TextBox runat="server" ID="dataGroupName" Text='<%# Bind("GroupName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataGroupName" runat="server" Display="Dynamic" ControlToValidate="dataGroupName" ErrorMessage="Required"></asp:RequiredFieldValidator>
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
					<asp:TextBox runat="server" ID="dataParent" Text='<%# Bind("Parent") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataParent" runat="server" Display="Dynamic" ControlToValidate="dataParent" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Description:</td>
				<td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Modified:</td>
				<td>
					<asp:TextBox runat="server" ID="dataModified" Text='<%# Bind("Modified", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataModified" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td valign="top" class="literal">Admin Users:</td>
				<td>
					<asp:CheckBoxList ID="AdminUsersList" runat="server"
						DataSourceID="AdminUsersDataSource"
						DataTextField="Password"
						DataValueField="IdUser"
						RepeatColumns="4"
					/>				
					<data:AdminUsersDataSource ID="AdminUsersDataSource" runat="server"
						SelectMethod="GetAll"
					/>
					
					<data:AdminGroupusersDataSource ID="AdminGroupusersDataSource" runat="server"
						SelectMethod="GetByIdGroup"
					>
						<Parameters>							
							<asp:QueryStringParameter Name="IdGroup" QueryStringField="IdGroup" Type="String" />
						</Parameters>
					</data:AdminGroupusersDataSource>	
					
					<data:ManyToManyListRelationship ID="AdminGroupusersRelationship" runat="server">
						<PrimaryMember runat="server"
							DataSourceID="AdminGroupsDataSource"
							EntityKeyName="IdGroup"
						/>
						<LinkMember runat="server"
							DataSourceID="AdminGroupusersDataSource"
							EntityKeyName="IdGroup"
							ForeignKeyName="IdUser"
						/>
						<ReferenceMember runat="server"
							DataSourceID="AdminUsersDataSource"
							ListControlID="AdminUsersList"
							EntityKeyName="IdUser"
						/>
					</data:ManyToManyListRelationship>					
				</td>
			</tr>			
			
		</table>

	</ItemTemplate>
</asp:FormView>


