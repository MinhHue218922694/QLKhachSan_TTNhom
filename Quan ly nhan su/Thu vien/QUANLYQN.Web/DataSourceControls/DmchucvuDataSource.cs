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
	/// Represents the DataRepository.DmchucvuProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DmchucvuDataSourceDesigner))]
	public class DmchucvuDataSource : ProviderDataSource<Dmchucvu, DmchucvuKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmchucvuDataSource class.
		/// </summary>
		public DmchucvuDataSource() : base(DataRepository.DmchucvuProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DmchucvuDataSourceView used by the DmchucvuDataSource.
		/// </summary>
		protected DmchucvuDataSourceView DmchucvuView
		{
			get { return ( View as DmchucvuDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DmchucvuDataSource control invokes to retrieve data.
		/// </summary>
		public DmchucvuSelectMethod SelectMethod
		{
			get
			{
				DmchucvuSelectMethod selectMethod = DmchucvuSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DmchucvuSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DmchucvuDataSourceView class that is to be
		/// used by the DmchucvuDataSource.
		/// </summary>
		/// <returns>An instance of the DmchucvuDataSourceView class.</returns>
		protected override BaseDataSourceView<Dmchucvu, DmchucvuKey> GetNewDataSourceView()
		{
			return new DmchucvuDataSourceView(this, DefaultViewName);
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
	/// Supports the DmchucvuDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DmchucvuDataSourceView : ProviderDataSourceView<Dmchucvu, DmchucvuKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmchucvuDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DmchucvuDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DmchucvuDataSourceView(DmchucvuDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DmchucvuDataSource DmchucvuOwner
		{
			get { return Owner as DmchucvuDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DmchucvuSelectMethod SelectMethod
		{
			get { return DmchucvuOwner.SelectMethod; }
			set { DmchucvuOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DmchucvuProviderBase DmchucvuProvider
		{
			get { return Provider as DmchucvuProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Dmchucvu> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Dmchucvu> results = null;
			Dmchucvu item;
			count = 0;
			
			System.Int32 idChucvu;

			switch ( SelectMethod )
			{
				case DmchucvuSelectMethod.Get:
					DmchucvuKey entityKey  = new DmchucvuKey();
					entityKey.Load(values);
					item = DmchucvuProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Dmchucvu>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DmchucvuSelectMethod.GetAll:
                    results = DmchucvuProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DmchucvuSelectMethod.GetPaged:
					results = DmchucvuProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DmchucvuSelectMethod.Find:
					if ( FilterParameters != null )
						results = DmchucvuProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DmchucvuProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DmchucvuSelectMethod.GetByIdChucvu:
					idChucvu = ( values["IdChucvu"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdChucvu"], typeof(System.Int32)) : (int)0;
					item = DmchucvuProvider.GetByIdChucvu(GetTransactionManager(), idChucvu);
					results = new TList<Dmchucvu>();
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
			if ( SelectMethod == DmchucvuSelectMethod.Get || SelectMethod == DmchucvuSelectMethod.GetByIdChucvu )
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
				Dmchucvu entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DmchucvuProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Dmchucvu> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DmchucvuProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DmchucvuDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DmchucvuDataSource class.
	/// </summary>
	public class DmchucvuDataSourceDesigner : ProviderDataSourceDesigner<Dmchucvu, DmchucvuKey>
	{
		/// <summary>
		/// Initializes a new instance of the DmchucvuDataSourceDesigner class.
		/// </summary>
		public DmchucvuDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmchucvuSelectMethod SelectMethod
		{
			get { return ((DmchucvuDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DmchucvuDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DmchucvuDataSourceActionList

	/// <summary>
	/// Supports the DmchucvuDataSourceDesigner class.
	/// </summary>
	internal class DmchucvuDataSourceActionList : DesignerActionList
	{
		private DmchucvuDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DmchucvuDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DmchucvuDataSourceActionList(DmchucvuDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmchucvuSelectMethod SelectMethod
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

	#endregion DmchucvuDataSourceActionList
	
	#endregion DmchucvuDataSourceDesigner
	
	#region DmchucvuSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DmchucvuDataSource.SelectMethod property.
	/// </summary>
	public enum DmchucvuSelectMethod
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
		/// Represents the GetByIdChucvu method.
		/// </summary>
		GetByIdChucvu
	}
	
	#endregion DmchucvuSelectMethod

	#region DmchucvuFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmchucvu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmchucvuFilter : SqlFilter<DmchucvuColumn>
	{
	}
	
	#endregion DmchucvuFilter

	#region DmchucvuExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmchucvu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmchucvuExpressionBuilder : SqlExpressionBuilder<DmchucvuColumn>
	{
	}
	
	#endregion DmchucvuExpressionBuilder	

	#region DmchucvuProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DmchucvuChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Dmchucvu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmchucvuProperty : ChildEntityProperty<DmchucvuChildEntityTypes>
	{
	}
	
	#endregion DmchucvuProperty
}

