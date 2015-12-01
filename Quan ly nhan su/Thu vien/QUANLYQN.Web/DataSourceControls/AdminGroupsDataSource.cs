#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using QUANLYQN.Entities;
using QUANLYQN.Data;
using QUANLYQN.Data.Bases;
#endregion

namespace QUANLYQN.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.AdminGroupsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AdminGroupsDataSourceDesigner))]
	public class AdminGroupsDataSource : ProviderDataSource<AdminGroups, AdminGroupsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupsDataSource class.
		/// </summary>
		public AdminGroupsDataSource() : base(DataRepository.AdminGroupsProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AdminGroupsDataSourceView used by the AdminGroupsDataSource.
		/// </summary>
		protected AdminGroupsDataSourceView AdminGroupsView
		{
			get { return ( View as AdminGroupsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AdminGroupsDataSource control invokes to retrieve data.
		/// </summary>
		public AdminGroupsSelectMethod SelectMethod
		{
			get
			{
				AdminGroupsSelectMethod selectMethod = AdminGroupsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AdminGroupsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AdminGroupsDataSourceView class that is to be
		/// used by the AdminGroupsDataSource.
		/// </summary>
		/// <returns>An instance of the AdminGroupsDataSourceView class.</returns>
		protected override BaseDataSourceView<AdminGroups, AdminGroupsKey> GetNewDataSourceView()
		{
			return new AdminGroupsDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the AdminGroupsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AdminGroupsDataSourceView : ProviderDataSourceView<AdminGroups, AdminGroupsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AdminGroupsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AdminGroupsDataSourceView(AdminGroupsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AdminGroupsDataSource AdminGroupsOwner
		{
			get { return Owner as AdminGroupsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AdminGroupsSelectMethod SelectMethod
		{
			get { return AdminGroupsOwner.SelectMethod; }
			set { AdminGroupsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AdminGroupsProviderBase AdminGroupsProvider
		{
			get { return Provider as AdminGroupsProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AdminGroups> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AdminGroups> results = null;
			AdminGroups item;
			count = 0;
			
			System.String idGroup;
			System.String idUser;
			System.String idMenu;

			switch ( SelectMethod )
			{
				case AdminGroupsSelectMethod.Get:
					AdminGroupsKey entityKey  = new AdminGroupsKey();
					entityKey.Load(values);
					item = AdminGroupsProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<AdminGroups>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AdminGroupsSelectMethod.GetAll:
                    results = AdminGroupsProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case AdminGroupsSelectMethod.GetPaged:
					results = AdminGroupsProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AdminGroupsSelectMethod.Find:
					if ( FilterParameters != null )
						results = AdminGroupsProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AdminGroupsProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AdminGroupsSelectMethod.GetByIdGroup:
					idGroup = ( values["IdGroup"] != null ) ? (System.String) EntityUtil.ChangeType(values["IdGroup"], typeof(System.String)) : string.Empty;
					item = AdminGroupsProvider.GetByIdGroup(GetTransactionManager(), idGroup);
					results = new TList<AdminGroups>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				case AdminGroupsSelectMethod.GetByIdUserFromAdminGroupusers:
					idUser = ( values["IdUser"] != null ) ? (System.String) EntityUtil.ChangeType(values["IdUser"], typeof(System.String)) : string.Empty;
					results = AdminGroupsProvider.GetByIdUserFromAdminGroupusers(GetTransactionManager(), idUser, this.StartIndex, this.PageSize, out count);
					break;
				case AdminGroupsSelectMethod.GetByIdMenuFromAdminGroupmenus:
					idMenu = ( values["IdMenu"] != null ) ? (System.String) EntityUtil.ChangeType(values["IdMenu"], typeof(System.String)) : string.Empty;
					results = AdminGroupsProvider.GetByIdMenuFromAdminGroupmenus(GetTransactionManager(), idMenu, this.StartIndex, this.PageSize, out count);
					break;
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == AdminGroupsSelectMethod.Get || SelectMethod == AdminGroupsSelectMethod.GetByIdGroup )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				AdminGroups entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					AdminGroupsProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<AdminGroups> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			AdminGroupsProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AdminGroupsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AdminGroupsDataSource class.
	/// </summary>
	public class AdminGroupsDataSourceDesigner : ProviderDataSourceDesigner<AdminGroups, AdminGroupsKey>
	{
		/// <summary>
		/// Initializes a new instance of the AdminGroupsDataSourceDesigner class.
		/// </summary>
		public AdminGroupsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdminGroupsSelectMethod SelectMethod
		{
			get { return ((AdminGroupsDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new AdminGroupsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AdminGroupsDataSourceActionList

	/// <summary>
	/// Supports the AdminGroupsDataSourceDesigner class.
	/// </summary>
	internal class AdminGroupsDataSourceActionList : DesignerActionList
	{
		private AdminGroupsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AdminGroupsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AdminGroupsDataSourceActionList(AdminGroupsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdminGroupsSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion AdminGroupsDataSourceActionList
	
	#endregion AdminGroupsDataSourceDesigner
	
	#region AdminGroupsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AdminGroupsDataSource.SelectMethod property.
	/// </summary>
	public enum AdminGroupsSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByIdGroup method.
		/// </summary>
		GetByIdGroup,
		/// <summary>
		/// Represents the GetByIdUserFromAdminGroupusers method.
		/// </summary>
		GetByIdUserFromAdminGroupusers,
		/// <summary>
		/// Represents the GetByIdMenuFromAdminGroupmenus method.
		/// </summary>
		GetByIdMenuFromAdminGroupmenus
	}
	
	#endregion AdminGroupsSelectMethod

	#region AdminGroupsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroups"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupsFilter : SqlFilter<AdminGroupsColumn>
	{
	}
	
	#endregion AdminGroupsFilter

	#region AdminGroupsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroups"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupsExpressionBuilder : SqlExpressionBuilder<AdminGroupsColumn>
	{
	}
	
	#endregion AdminGroupsExpressionBuilder	

	#region AdminGroupsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AdminGroupsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroups"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupsProperty : ChildEntityProperty<AdminGroupsChildEntityTypes>
	{
	}
	
	#endregion AdminGroupsProperty
}

