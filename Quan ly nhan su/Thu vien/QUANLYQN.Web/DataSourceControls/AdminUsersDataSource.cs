﻿#region Using Directives
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
	/// Represents the DataRepository.AdminUsersProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AdminUsersDataSourceDesigner))]
	public class AdminUsersDataSource : ProviderDataSource<AdminUsers, AdminUsersKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminUsersDataSource class.
		/// </summary>
		public AdminUsersDataSource() : base(DataRepository.AdminUsersProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AdminUsersDataSourceView used by the AdminUsersDataSource.
		/// </summary>
		protected AdminUsersDataSourceView AdminUsersView
		{
			get { return ( View as AdminUsersDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AdminUsersDataSource control invokes to retrieve data.
		/// </summary>
		public AdminUsersSelectMethod SelectMethod
		{
			get
			{
				AdminUsersSelectMethod selectMethod = AdminUsersSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AdminUsersSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AdminUsersDataSourceView class that is to be
		/// used by the AdminUsersDataSource.
		/// </summary>
		/// <returns>An instance of the AdminUsersDataSourceView class.</returns>
		protected override BaseDataSourceView<AdminUsers, AdminUsersKey> GetNewDataSourceView()
		{
			return new AdminUsersDataSourceView(this, DefaultViewName);
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
	/// Supports the AdminUsersDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AdminUsersDataSourceView : ProviderDataSourceView<AdminUsers, AdminUsersKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminUsersDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AdminUsersDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AdminUsersDataSourceView(AdminUsersDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AdminUsersDataSource AdminUsersOwner
		{
			get { return Owner as AdminUsersDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AdminUsersSelectMethod SelectMethod
		{
			get { return AdminUsersOwner.SelectMethod; }
			set { AdminUsersOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AdminUsersProviderBase AdminUsersProvider
		{
			get { return Provider as AdminUsersProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AdminUsers> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AdminUsers> results = null;
			AdminUsers item;
			count = 0;
			
			System.String idUser;
			System.String idGroup;

			switch ( SelectMethod )
			{
				case AdminUsersSelectMethod.Get:
					AdminUsersKey entityKey  = new AdminUsersKey();
					entityKey.Load(values);
					item = AdminUsersProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<AdminUsers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AdminUsersSelectMethod.GetAll:
                    results = AdminUsersProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case AdminUsersSelectMethod.GetPaged:
					results = AdminUsersProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AdminUsersSelectMethod.Find:
					if ( FilterParameters != null )
						results = AdminUsersProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AdminUsersProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AdminUsersSelectMethod.GetByIdUser:
					idUser = ( values["IdUser"] != null ) ? (System.String) EntityUtil.ChangeType(values["IdUser"], typeof(System.String)) : string.Empty;
					item = AdminUsersProvider.GetByIdUser(GetTransactionManager(), idUser);
					results = new TList<AdminUsers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				case AdminUsersSelectMethod.GetByIdGroupFromAdminGroupusers:
					idGroup = ( values["IdGroup"] != null ) ? (System.String) EntityUtil.ChangeType(values["IdGroup"], typeof(System.String)) : string.Empty;
					results = AdminUsersProvider.GetByIdGroupFromAdminGroupusers(GetTransactionManager(), idGroup, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == AdminUsersSelectMethod.Get || SelectMethod == AdminUsersSelectMethod.GetByIdUser )
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
				AdminUsers entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					AdminUsersProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AdminUsers> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			AdminUsersProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AdminUsersDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AdminUsersDataSource class.
	/// </summary>
	public class AdminUsersDataSourceDesigner : ProviderDataSourceDesigner<AdminUsers, AdminUsersKey>
	{
		/// <summary>
		/// Initializes a new instance of the AdminUsersDataSourceDesigner class.
		/// </summary>
		public AdminUsersDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdminUsersSelectMethod SelectMethod
		{
			get { return ((AdminUsersDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AdminUsersDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AdminUsersDataSourceActionList

	/// <summary>
	/// Supports the AdminUsersDataSourceDesigner class.
	/// </summary>
	internal class AdminUsersDataSourceActionList : DesignerActionList
	{
		private AdminUsersDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AdminUsersDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AdminUsersDataSourceActionList(AdminUsersDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdminUsersSelectMethod SelectMethod
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

	#endregion AdminUsersDataSourceActionList
	
	#endregion AdminUsersDataSourceDesigner
	
	#region AdminUsersSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AdminUsersDataSource.SelectMethod property.
	/// </summary>
	public enum AdminUsersSelectMethod
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
		/// Represents the GetByIdUser method.
		/// </summary>
		GetByIdUser,
		/// <summary>
		/// Represents the GetByIdGroupFromAdminGroupusers method.
		/// </summary>
		GetByIdGroupFromAdminGroupusers
	}
	
	#endregion AdminUsersSelectMethod

	#region AdminUsersFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminUsersFilter : SqlFilter<AdminUsersColumn>
	{
	}
	
	#endregion AdminUsersFilter

	#region AdminUsersExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminUsersExpressionBuilder : SqlExpressionBuilder<AdminUsersColumn>
	{
	}
	
	#endregion AdminUsersExpressionBuilder	

	#region AdminUsersProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AdminUsersChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AdminUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminUsersProperty : ChildEntityProperty<AdminUsersChildEntityTypes>
	{
	}
	
	#endregion AdminUsersProperty
}

