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
	/// Represents the DataRepository.AdminGroupmenusProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AdminGroupmenusDataSourceDesigner))]
	public class AdminGroupmenusDataSource : ProviderDataSource<AdminGroupmenus, AdminGroupmenusKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupmenusDataSource class.
		/// </summary>
		public AdminGroupmenusDataSource() : base(DataRepository.AdminGroupmenusProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AdminGroupmenusDataSourceView used by the AdminGroupmenusDataSource.
		/// </summary>
		protected AdminGroupmenusDataSourceView AdminGroupmenusView
		{
			get { return ( View as AdminGroupmenusDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AdminGroupmenusDataSource control invokes to retrieve data.
		/// </summary>
		public AdminGroupmenusSelectMethod SelectMethod
		{
			get
			{
				AdminGroupmenusSelectMethod selectMethod = AdminGroupmenusSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AdminGroupmenusSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AdminGroupmenusDataSourceView class that is to be
		/// used by the AdminGroupmenusDataSource.
		/// </summary>
		/// <returns>An instance of the AdminGroupmenusDataSourceView class.</returns>
		protected override BaseDataSourceView<AdminGroupmenus, AdminGroupmenusKey> GetNewDataSourceView()
		{
			return new AdminGroupmenusDataSourceView(this, DefaultViewName);
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
	/// Supports the AdminGroupmenusDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AdminGroupmenusDataSourceView : ProviderDataSourceView<AdminGroupmenus, AdminGroupmenusKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupmenusDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AdminGroupmenusDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AdminGroupmenusDataSourceView(AdminGroupmenusDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AdminGroupmenusDataSource AdminGroupmenusOwner
		{
			get { return Owner as AdminGroupmenusDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AdminGroupmenusSelectMethod SelectMethod
		{
			get { return AdminGroupmenusOwner.SelectMethod; }
			set { AdminGroupmenusOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AdminGroupmenusProviderBase AdminGroupmenusProvider
		{
			get { return Provider as AdminGroupmenusProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AdminGroupmenus> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AdminGroupmenus> results = null;
			AdminGroupmenus item;
			count = 0;
			
			System.String idMenu;
			System.String idGroup;

			switch ( SelectMethod )
			{
				case AdminGroupmenusSelectMethod.Get:
					AdminGroupmenusKey entityKey  = new AdminGroupmenusKey();
					entityKey.Load(values);
					item = AdminGroupmenusProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<AdminGroupmenus>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AdminGroupmenusSelectMethod.GetAll:
                    results = AdminGroupmenusProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case AdminGroupmenusSelectMethod.GetPaged:
					results = AdminGroupmenusProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AdminGroupmenusSelectMethod.Find:
					if ( FilterParameters != null )
						results = AdminGroupmenusProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AdminGroupmenusProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AdminGroupmenusSelectMethod.GetByIdMenuIdGroup:
					idMenu = ( values["IdMenu"] != null ) ? (System.String) EntityUtil.ChangeType(values["IdMenu"], typeof(System.String)) : string.Empty;
					idGroup = ( values["IdGroup"] != null ) ? (System.String) EntityUtil.ChangeType(values["IdGroup"], typeof(System.String)) : string.Empty;
					item = AdminGroupmenusProvider.GetByIdMenuIdGroup(GetTransactionManager(), idMenu, idGroup);
					results = new TList<AdminGroupmenus>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case AdminGroupmenusSelectMethod.GetByIdGroup:
					idGroup = ( values["IdGroup"] != null ) ? (System.String) EntityUtil.ChangeType(values["IdGroup"], typeof(System.String)) : string.Empty;
					results = AdminGroupmenusProvider.GetByIdGroup(GetTransactionManager(), idGroup, this.StartIndex, this.PageSize, out count);
					break;
				case AdminGroupmenusSelectMethod.GetByIdMenu:
					idMenu = ( values["IdMenu"] != null ) ? (System.String) EntityUtil.ChangeType(values["IdMenu"], typeof(System.String)) : string.Empty;
					results = AdminGroupmenusProvider.GetByIdMenu(GetTransactionManager(), idMenu, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
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
			if ( SelectMethod == AdminGroupmenusSelectMethod.Get || SelectMethod == AdminGroupmenusSelectMethod.GetByIdMenuIdGroup )
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
				AdminGroupmenus entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					AdminGroupmenusProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AdminGroupmenus> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			AdminGroupmenusProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AdminGroupmenusDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AdminGroupmenusDataSource class.
	/// </summary>
	public class AdminGroupmenusDataSourceDesigner : ProviderDataSourceDesigner<AdminGroupmenus, AdminGroupmenusKey>
	{
		/// <summary>
		/// Initializes a new instance of the AdminGroupmenusDataSourceDesigner class.
		/// </summary>
		public AdminGroupmenusDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdminGroupmenusSelectMethod SelectMethod
		{
			get { return ((AdminGroupmenusDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AdminGroupmenusDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AdminGroupmenusDataSourceActionList

	/// <summary>
	/// Supports the AdminGroupmenusDataSourceDesigner class.
	/// </summary>
	internal class AdminGroupmenusDataSourceActionList : DesignerActionList
	{
		private AdminGroupmenusDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AdminGroupmenusDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AdminGroupmenusDataSourceActionList(AdminGroupmenusDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdminGroupmenusSelectMethod SelectMethod
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

	#endregion AdminGroupmenusDataSourceActionList
	
	#endregion AdminGroupmenusDataSourceDesigner
	
	#region AdminGroupmenusSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AdminGroupmenusDataSource.SelectMethod property.
	/// </summary>
	public enum AdminGroupmenusSelectMethod
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
		/// Represents the GetByIdMenuIdGroup method.
		/// </summary>
		GetByIdMenuIdGroup,
		/// <summary>
		/// Represents the GetByIdGroup method.
		/// </summary>
		GetByIdGroup,
		/// <summary>
		/// Represents the GetByIdMenu method.
		/// </summary>
		GetByIdMenu
	}
	
	#endregion AdminGroupmenusSelectMethod

	#region AdminGroupmenusFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroupmenus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupmenusFilter : SqlFilter<AdminGroupmenusColumn>
	{
	}
	
	#endregion AdminGroupmenusFilter

	#region AdminGroupmenusExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroupmenus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupmenusExpressionBuilder : SqlExpressionBuilder<AdminGroupmenusColumn>
	{
	}
	
	#endregion AdminGroupmenusExpressionBuilder	

	#region AdminGroupmenusProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AdminGroupmenusChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroupmenus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupmenusProperty : ChildEntityProperty<AdminGroupmenusChildEntityTypes>
	{
	}
	
	#endregion AdminGroupmenusProperty
}

