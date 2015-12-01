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
	/// Represents the DataRepository.AdminMenusProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AdminMenusDataSourceDesigner))]
	public class AdminMenusDataSource : ProviderDataSource<AdminMenus, AdminMenusKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminMenusDataSource class.
		/// </summary>
		public AdminMenusDataSource() : base(DataRepository.AdminMenusProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AdminMenusDataSourceView used by the AdminMenusDataSource.
		/// </summary>
		protected AdminMenusDataSourceView AdminMenusView
		{
			get { return ( View as AdminMenusDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AdminMenusDataSource control invokes to retrieve data.
		/// </summary>
		public AdminMenusSelectMethod SelectMethod
		{
			get
			{
				AdminMenusSelectMethod selectMethod = AdminMenusSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AdminMenusSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AdminMenusDataSourceView class that is to be
		/// used by the AdminMenusDataSource.
		/// </summary>
		/// <returns>An instance of the AdminMenusDataSourceView class.</returns>
		protected override BaseDataSourceView<AdminMenus, AdminMenusKey> GetNewDataSourceView()
		{
			return new AdminMenusDataSourceView(this, DefaultViewName);
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
	/// Supports the AdminMenusDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AdminMenusDataSourceView : ProviderDataSourceView<AdminMenus, AdminMenusKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminMenusDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AdminMenusDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AdminMenusDataSourceView(AdminMenusDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AdminMenusDataSource AdminMenusOwner
		{
			get { return Owner as AdminMenusDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AdminMenusSelectMethod SelectMethod
		{
			get { return AdminMenusOwner.SelectMethod; }
			set { AdminMenusOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AdminMenusProviderBase AdminMenusProvider
		{
			get { return Provider as AdminMenusProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AdminMenus> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AdminMenus> results = null;
			AdminMenus item;
			count = 0;
			
			System.String idMenu;
			System.String idGroup;

			switch ( SelectMethod )
			{
				case AdminMenusSelectMethod.Get:
					AdminMenusKey entityKey  = new AdminMenusKey();
					entityKey.Load(values);
					item = AdminMenusProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<AdminMenus>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AdminMenusSelectMethod.GetAll:
                    results = AdminMenusProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case AdminMenusSelectMethod.GetPaged:
					results = AdminMenusProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AdminMenusSelectMethod.Find:
					if ( FilterParameters != null )
						results = AdminMenusProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AdminMenusProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AdminMenusSelectMethod.GetByIdMenu:
					idMenu = ( values["IdMenu"] != null ) ? (System.String) EntityUtil.ChangeType(values["IdMenu"], typeof(System.String)) : string.Empty;
					item = AdminMenusProvider.GetByIdMenu(GetTransactionManager(), idMenu);
					results = new TList<AdminMenus>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				case AdminMenusSelectMethod.GetByIdGroupFromAdminGroupmenus:
					idGroup = ( values["IdGroup"] != null ) ? (System.String) EntityUtil.ChangeType(values["IdGroup"], typeof(System.String)) : string.Empty;
					results = AdminMenusProvider.GetByIdGroupFromAdminGroupmenus(GetTransactionManager(), idGroup, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == AdminMenusSelectMethod.Get || SelectMethod == AdminMenusSelectMethod.GetByIdMenu )
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
				AdminMenus entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					AdminMenusProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AdminMenus> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			AdminMenusProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AdminMenusDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AdminMenusDataSource class.
	/// </summary>
	public class AdminMenusDataSourceDesigner : ProviderDataSourceDesigner<AdminMenus, AdminMenusKey>
	{
		/// <summary>
		/// Initializes a new instance of the AdminMenusDataSourceDesigner class.
		/// </summary>
		public AdminMenusDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdminMenusSelectMethod SelectMethod
		{
			get { return ((AdminMenusDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AdminMenusDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AdminMenusDataSourceActionList

	/// <summary>
	/// Supports the AdminMenusDataSourceDesigner class.
	/// </summary>
	internal class AdminMenusDataSourceActionList : DesignerActionList
	{
		private AdminMenusDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AdminMenusDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AdminMenusDataSourceActionList(AdminMenusDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdminMenusSelectMethod SelectMethod
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

	#endregion AdminMenusDataSourceActionList
	
	#endregion AdminMenusDataSourceDesigner
	
	#region AdminMenusSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AdminMenusDataSource.SelectMethod property.
	/// </summary>
	public enum AdminMenusSelectMethod
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
		/// Represents the GetByIdMenu method.
		/// </summary>
		GetByIdMenu,
		/// <summary>
		/// Represents the GetByIdGroupFromAdminGroupmenus method.
		/// </summary>
		GetByIdGroupFromAdminGroupmenus
	}
	
	#endregion AdminMenusSelectMethod

	#region AdminMenusFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminMenus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminMenusFilter : SqlFilter<AdminMenusColumn>
	{
	}
	
	#endregion AdminMenusFilter

	#region AdminMenusExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminMenus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminMenusExpressionBuilder : SqlExpressionBuilder<AdminMenusColumn>
	{
	}
	
	#endregion AdminMenusExpressionBuilder	

	#region AdminMenusProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AdminMenusChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AdminMenus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminMenusProperty : ChildEntityProperty<AdminMenusChildEntityTypes>
	{
	}
	
	#endregion AdminMenusProperty
}

