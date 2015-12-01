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
	/// Represents the DataRepository.AdminGroupusersProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AdminGroupusersDataSourceDesigner))]
	public class AdminGroupusersDataSource : ProviderDataSource<AdminGroupusers, AdminGroupusersKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupusersDataSource class.
		/// </summary>
		public AdminGroupusersDataSource() : base(DataRepository.AdminGroupusersProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AdminGroupusersDataSourceView used by the AdminGroupusersDataSource.
		/// </summary>
		protected AdminGroupusersDataSourceView AdminGroupusersView
		{
			get { return ( View as AdminGroupusersDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AdminGroupusersDataSource control invokes to retrieve data.
		/// </summary>
		public AdminGroupusersSelectMethod SelectMethod
		{
			get
			{
				AdminGroupusersSelectMethod selectMethod = AdminGroupusersSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AdminGroupusersSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AdminGroupusersDataSourceView class that is to be
		/// used by the AdminGroupusersDataSource.
		/// </summary>
		/// <returns>An instance of the AdminGroupusersDataSourceView class.</returns>
		protected override BaseDataSourceView<AdminGroupusers, AdminGroupusersKey> GetNewDataSourceView()
		{
			return new AdminGroupusersDataSourceView(this, DefaultViewName);
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
	/// Supports the AdminGroupusersDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AdminGroupusersDataSourceView : ProviderDataSourceView<AdminGroupusers, AdminGroupusersKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupusersDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AdminGroupusersDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AdminGroupusersDataSourceView(AdminGroupusersDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AdminGroupusersDataSource AdminGroupusersOwner
		{
			get { return Owner as AdminGroupusersDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AdminGroupusersSelectMethod SelectMethod
		{
			get { return AdminGroupusersOwner.SelectMethod; }
			set { AdminGroupusersOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AdminGroupusersProviderBase AdminGroupusersProvider
		{
			get { return Provider as AdminGroupusersProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AdminGroupusers> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AdminGroupusers> results = null;
			AdminGroupusers item;
			count = 0;
			
			System.String idGroup;
			System.String idUser;

			switch ( SelectMethod )
			{
				case AdminGroupusersSelectMethod.Get:
					AdminGroupusersKey entityKey  = new AdminGroupusersKey();
					entityKey.Load(values);
					item = AdminGroupusersProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<AdminGroupusers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AdminGroupusersSelectMethod.GetAll:
                    results = AdminGroupusersProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case AdminGroupusersSelectMethod.GetPaged:
					results = AdminGroupusersProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AdminGroupusersSelectMethod.Find:
					if ( FilterParameters != null )
						results = AdminGroupusersProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AdminGroupusersProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AdminGroupusersSelectMethod.GetByIdGroupIdUser:
					idGroup = ( values["IdGroup"] != null ) ? (System.String) EntityUtil.ChangeType(values["IdGroup"], typeof(System.String)) : string.Empty;
					idUser = ( values["IdUser"] != null ) ? (System.String) EntityUtil.ChangeType(values["IdUser"], typeof(System.String)) : string.Empty;
					item = AdminGroupusersProvider.GetByIdGroupIdUser(GetTransactionManager(), idGroup, idUser);
					results = new TList<AdminGroupusers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case AdminGroupusersSelectMethod.GetByIdGroup:
					idGroup = ( values["IdGroup"] != null ) ? (System.String) EntityUtil.ChangeType(values["IdGroup"], typeof(System.String)) : string.Empty;
					results = AdminGroupusersProvider.GetByIdGroup(GetTransactionManager(), idGroup, this.StartIndex, this.PageSize, out count);
					break;
				case AdminGroupusersSelectMethod.GetByIdUser:
					idUser = ( values["IdUser"] != null ) ? (System.String) EntityUtil.ChangeType(values["IdUser"], typeof(System.String)) : string.Empty;
					results = AdminGroupusersProvider.GetByIdUser(GetTransactionManager(), idUser, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == AdminGroupusersSelectMethod.Get || SelectMethod == AdminGroupusersSelectMethod.GetByIdGroupIdUser )
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
				AdminGroupusers entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					AdminGroupusersProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AdminGroupusers> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			AdminGroupusersProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AdminGroupusersDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AdminGroupusersDataSource class.
	/// </summary>
	public class AdminGroupusersDataSourceDesigner : ProviderDataSourceDesigner<AdminGroupusers, AdminGroupusersKey>
	{
		/// <summary>
		/// Initializes a new instance of the AdminGroupusersDataSourceDesigner class.
		/// </summary>
		public AdminGroupusersDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdminGroupusersSelectMethod SelectMethod
		{
			get { return ((AdminGroupusersDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AdminGroupusersDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AdminGroupusersDataSourceActionList

	/// <summary>
	/// Supports the AdminGroupusersDataSourceDesigner class.
	/// </summary>
	internal class AdminGroupusersDataSourceActionList : DesignerActionList
	{
		private AdminGroupusersDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AdminGroupusersDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AdminGroupusersDataSourceActionList(AdminGroupusersDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdminGroupusersSelectMethod SelectMethod
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

	#endregion AdminGroupusersDataSourceActionList
	
	#endregion AdminGroupusersDataSourceDesigner
	
	#region AdminGroupusersSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AdminGroupusersDataSource.SelectMethod property.
	/// </summary>
	public enum AdminGroupusersSelectMethod
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
		/// Represents the GetByIdGroupIdUser method.
		/// </summary>
		GetByIdGroupIdUser,
		/// <summary>
		/// Represents the GetByIdGroup method.
		/// </summary>
		GetByIdGroup,
		/// <summary>
		/// Represents the GetByIdUser method.
		/// </summary>
		GetByIdUser
	}
	
	#endregion AdminGroupusersSelectMethod

	#region AdminGroupusersFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroupusers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupusersFilter : SqlFilter<AdminGroupusersColumn>
	{
	}
	
	#endregion AdminGroupusersFilter

	#region AdminGroupusersExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroupusers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupusersExpressionBuilder : SqlExpressionBuilder<AdminGroupusersColumn>
	{
	}
	
	#endregion AdminGroupusersExpressionBuilder	

	#region AdminGroupusersProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AdminGroupusersChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroupusers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupusersProperty : ChildEntityProperty<AdminGroupusersChildEntityTypes>
	{
	}
	
	#endregion AdminGroupusersProperty
}

