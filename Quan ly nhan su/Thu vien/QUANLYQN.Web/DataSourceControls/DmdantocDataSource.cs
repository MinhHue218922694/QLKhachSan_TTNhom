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
	/// Represents the DataRepository.DmdantocProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DmdantocDataSourceDesigner))]
	public class DmdantocDataSource : ProviderDataSource<Dmdantoc, DmdantocKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmdantocDataSource class.
		/// </summary>
		public DmdantocDataSource() : base(DataRepository.DmdantocProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DmdantocDataSourceView used by the DmdantocDataSource.
		/// </summary>
		protected DmdantocDataSourceView DmdantocView
		{
			get { return ( View as DmdantocDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DmdantocDataSource control invokes to retrieve data.
		/// </summary>
		public DmdantocSelectMethod SelectMethod
		{
			get
			{
				DmdantocSelectMethod selectMethod = DmdantocSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DmdantocSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DmdantocDataSourceView class that is to be
		/// used by the DmdantocDataSource.
		/// </summary>
		/// <returns>An instance of the DmdantocDataSourceView class.</returns>
		protected override BaseDataSourceView<Dmdantoc, DmdantocKey> GetNewDataSourceView()
		{
			return new DmdantocDataSourceView(this, DefaultViewName);
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
	/// Supports the DmdantocDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DmdantocDataSourceView : ProviderDataSourceView<Dmdantoc, DmdantocKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmdantocDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DmdantocDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DmdantocDataSourceView(DmdantocDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DmdantocDataSource DmdantocOwner
		{
			get { return Owner as DmdantocDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DmdantocSelectMethod SelectMethod
		{
			get { return DmdantocOwner.SelectMethod; }
			set { DmdantocOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DmdantocProviderBase DmdantocProvider
		{
			get { return Provider as DmdantocProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Dmdantoc> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Dmdantoc> results = null;
			Dmdantoc item;
			count = 0;
			
			System.Int32 idDantoc;

			switch ( SelectMethod )
			{
				case DmdantocSelectMethod.Get:
					DmdantocKey entityKey  = new DmdantocKey();
					entityKey.Load(values);
					item = DmdantocProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Dmdantoc>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DmdantocSelectMethod.GetAll:
                    results = DmdantocProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DmdantocSelectMethod.GetPaged:
					results = DmdantocProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DmdantocSelectMethod.Find:
					if ( FilterParameters != null )
						results = DmdantocProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DmdantocProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DmdantocSelectMethod.GetByIdDantoc:
					idDantoc = ( values["IdDantoc"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdDantoc"], typeof(System.Int32)) : (int)0;
					item = DmdantocProvider.GetByIdDantoc(GetTransactionManager(), idDantoc);
					results = new TList<Dmdantoc>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
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
			if ( SelectMethod == DmdantocSelectMethod.Get || SelectMethod == DmdantocSelectMethod.GetByIdDantoc )
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
				Dmdantoc entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DmdantocProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Dmdantoc> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DmdantocProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DmdantocDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DmdantocDataSource class.
	/// </summary>
	public class DmdantocDataSourceDesigner : ProviderDataSourceDesigner<Dmdantoc, DmdantocKey>
	{
		/// <summary>
		/// Initializes a new instance of the DmdantocDataSourceDesigner class.
		/// </summary>
		public DmdantocDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmdantocSelectMethod SelectMethod
		{
			get { return ((DmdantocDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DmdantocDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DmdantocDataSourceActionList

	/// <summary>
	/// Supports the DmdantocDataSourceDesigner class.
	/// </summary>
	internal class DmdantocDataSourceActionList : DesignerActionList
	{
		private DmdantocDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DmdantocDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DmdantocDataSourceActionList(DmdantocDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmdantocSelectMethod SelectMethod
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

	#endregion DmdantocDataSourceActionList
	
	#endregion DmdantocDataSourceDesigner
	
	#region DmdantocSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DmdantocDataSource.SelectMethod property.
	/// </summary>
	public enum DmdantocSelectMethod
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
		/// Represents the GetByIdDantoc method.
		/// </summary>
		GetByIdDantoc
	}
	
	#endregion DmdantocSelectMethod

	#region DmdantocFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmdantoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmdantocFilter : SqlFilter<DmdantocColumn>
	{
	}
	
	#endregion DmdantocFilter

	#region DmdantocExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmdantoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmdantocExpressionBuilder : SqlExpressionBuilder<DmdantocColumn>
	{
	}
	
	#endregion DmdantocExpressionBuilder	

	#region DmdantocProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DmdantocChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Dmdantoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmdantocProperty : ChildEntityProperty<DmdantocChildEntityTypes>
	{
	}
	
	#endregion DmdantocProperty
}

