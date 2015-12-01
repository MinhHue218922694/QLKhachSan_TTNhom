<%@ Control Language="C#" ClassName="AdminUsersFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id User:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdUser" Text='<%# Bind("IdUser") %>' MaxLength="15"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdUser" runat="server" Display="Dynamic" ControlToValidate="dataIdUser" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Password:</td>
				<td>
					<asp:HiddenField runat="server" id="dataPassword" Value='<%# Bind("Password") %>'></asp:HiddenField>
				</td>
			</tr>				
			<tr>
				<td class="literal">Full Name:</td>
				<td>
					<asp:TextBox runat="server" ID="dataFullName" Text='<%# Bind("FullName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Active:</td>
				<td>
					<asp:TextBox runat="server" ID="dataActive" Text='<%# Bind("Active") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataActive" runat="server" Display="Dynamic" ControlToValidate="dataActive" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Modified:</td>
				<td>
					<asp:TextBox runat="server" ID="dataModified" Text='<%# Bind("Modified", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataModified" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">Description:</td>
				<td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td valign="top" class="literal">Admin Groups:</td>
				<td>
					<asp:CheckBoxList ID="AdminGroupsList" runat="server"
						DataSourceID="AdminGroupsDataSource"
						DataTextField="GroupName"
						DataValueField="IdGroup"
						RepeatColumns="4"
					/>				
					<data:AdminGroupsDataSource ID="AdminGroupsDataSource" runat="server"
						SelectMethod="GetAll"
					/>
					
					<data:AdminGroupusersDataSource ID="AdminGroupusersDataSource" runat="server"
						SelectMethod="GetByIdUser"
					>
						<Parameters>							
							<asp:QueryStringParameter Name="IdUser" QueryStringField="IdUser" Type="String" />
						</Parameters>
					</data:AdminGroupusersDataSource>	
					
					<data:ManyToManyListRelationship ID="AdminGroupusersRelationship" runat="server">
						<PrimaryMember runat="server"
							DataSourceID="AdminUsersDataSource"
							EntityKeyName="IdUser"
						/>
						<LinkMember runat="server"
							DataSourceID="AdminGroupusersDataSource"
							EntityKeyName="IdUser"
							ForeignKeyName="IdGroup"
						/>
						<ReferenceMember runat="server"
							DataSourceID="AdminGroupsDataSource"
							ListControlID="AdminGroupsList"
							EntityKeyName="IdGroup"
						/>
					</data:ManyToManyListRelationship>					
				</td>
			</tr>			
			
		</table>

	</ItemTemplate>
</asp:FormView>


