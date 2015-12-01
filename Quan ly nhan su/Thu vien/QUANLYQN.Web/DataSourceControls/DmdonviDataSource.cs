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
	/// Represents the DataRepository.DmdonviProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DmdonviDataSourceDesigner))]
	public class DmdonviDataSource : ProviderDataSource<Dmdonvi, DmdonviKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmdonviDataSource class.
		/// </summary>
		public DmdonviDataSource() : base(DataRepository.DmdonviProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DmdonviDataSourceView used by the DmdonviDataSource.
		/// </summary>
		protected DmdonviDataSourceView DmdonviView
		{
			get { return ( View as DmdonviDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DmdonviDataSource control invokes to retrieve data.
		/// </summary>
		public DmdonviSelectMethod SelectMethod
		{
			get
			{
				DmdonviSelectMethod selectMethod = DmdonviSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DmdonviSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DmdonviDataSourceView class that is to be
		/// used by the DmdonviDataSource.
		/// </summary>
		/// <returns>An instance of the DmdonviDataSourceView class.</returns>
		protected override BaseDataSourceView<Dmdonvi, DmdonviKey> GetNewDataSourceView()
		{
			return new DmdonviDataSourceView(this, DefaultViewName);
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
	/// Supports the DmdonviDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DmdonviDataSourceView : ProviderDataSourceView<Dmdonvi, DmdonviKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmdonviDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DmdonviDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DmdonviDataSourceView(DmdonviDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DmdonviDataSource DmdonviOwner
		{
			get { return Owner as DmdonviDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DmdonviSelectMethod SelectMethod
		{
			get { return DmdonviOwner.SelectMethod; }
			set { DmdonviOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DmdonviProviderBase DmdonviProvider
		{
			get { return Provider as DmdonviProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Dmdonvi> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Dmdonvi> results = null;
			Dmdonvi item;
			count = 0;
			
			System.Int32 idDonvi;

			switch ( SelectMethod )
			{
				case DmdonviSelectMethod.Get:
					DmdonviKey entityKey  = new DmdonviKey();
					entityKey.Load(values);
					item = DmdonviProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Dmdonvi>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DmdonviSelectMethod.GetAll:
                    results = DmdonviProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DmdonviSelectMethod.GetPaged:
					results = DmdonviProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DmdonviSelectMethod.Find:
					if ( FilterParameters != null )
						results = DmdonviProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DmdonviProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DmdonviSelectMethod.GetByIdDonvi:
					idDonvi = ( values["IdDonvi"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdDonvi"], typeof(System.Int32)) : (int)0;
					item = DmdonviProvider.GetByIdDonvi(GetTransactionManager(), idDonvi);
					results = new TList<Dmdonvi>();
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
			if ( SelectMethod == DmdonviSelectMethod.Get || SelectMethod == DmdonviSelectMethod.GetByIdDonvi )
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
				Dmdonvi entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DmdonviProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Dmdonvi> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DmdonviProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DmdonviDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DmdonviDataSource class.
	/// </summary>
	public class DmdonviDataSourceDesigner : ProviderDataSourceDesigner<Dmdonvi, DmdonviKey>
	{
		/// <summary>
		/// Initializes a new instance of the DmdonviDataSourceDesigner class.
		/// </summary>
		public DmdonviDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmdonviSelectMethod SelectMethod
		{
			get { return ((DmdonviDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DmdonviDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DmdonviDataSourceActionList

	/// <summary>
	/// Supports the DmdonviDataSourceDesigner class.
	/// </summary>
	internal class DmdonviDataSourceActionList : DesignerActionList
	{
		private DmdonviDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DmdonviDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DmdonviDataSourceActionList(DmdonviDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmdonviSelectMethod SelectMethod
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

	#endregion DmdonviDataSourceActionList
	
	#endregion DmdonviDataSourceDesigner
	
	#region DmdonviSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DmdonviDataSource.SelectMethod property.
	/// </summary>
	public enum DmdonviSelectMethod
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
		/// Represents the GetByIdDonvi method.
		/// </summary>
		GetByIdDonvi
	}
	
	#endregion DmdonviSelectMethod

	#region DmdonviFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmdonvi"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmdonviFilter : SqlFilter<DmdonviColumn>
	{
	}
	
	#endregion DmdonviFilter

	#region DmdonviExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmdonvi"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmdonviExpressionBuilder : SqlExpressionBuilder<DmdonviColumn>
	{
	}
	
	#endregion DmdonviExpressionBuilder	

	#region DmdonviProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DmdonviChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Dmdonvi"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmdonviProperty : ChildEntityProperty<DmdonviChildEntityTypes>
	{
	}
	
	#endregion DmdonviProperty
}

