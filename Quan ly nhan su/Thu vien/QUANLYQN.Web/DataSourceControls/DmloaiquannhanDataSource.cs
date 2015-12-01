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
	/// Represents the DataRepository.DmloaiquannhanProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DmloaiquannhanDataSourceDesigner))]
	public class DmloaiquannhanDataSource : ProviderDataSource<Dmloaiquannhan, DmloaiquannhanKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmloaiquannhanDataSource class.
		/// </summary>
		public DmloaiquannhanDataSource() : base(DataRepository.DmloaiquannhanProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DmloaiquannhanDataSourceView used by the DmloaiquannhanDataSource.
		/// </summary>
		protected DmloaiquannhanDataSourceView DmloaiquannhanView
		{
			get { return ( View as DmloaiquannhanDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DmloaiquannhanDataSource control invokes to retrieve data.
		/// </summary>
		public DmloaiquannhanSelectMethod SelectMethod
		{
			get
			{
				DmloaiquannhanSelectMethod selectMethod = DmloaiquannhanSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DmloaiquannhanSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DmloaiquannhanDataSourceView class that is to be
		/// used by the DmloaiquannhanDataSource.
		/// </summary>
		/// <returns>An instance of the DmloaiquannhanDataSourceView class.</returns>
		protected override BaseDataSourceView<Dmloaiquannhan, DmloaiquannhanKey> GetNewDataSourceView()
		{
			return new DmloaiquannhanDataSourceView(this, DefaultViewName);
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
	/// Supports the DmloaiquannhanDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DmloaiquannhanDataSourceView : ProviderDataSourceView<Dmloaiquannhan, DmloaiquannhanKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmloaiquannhanDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DmloaiquannhanDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DmloaiquannhanDataSourceView(DmloaiquannhanDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DmloaiquannhanDataSource DmloaiquannhanOwner
		{
			get { return Owner as DmloaiquannhanDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DmloaiquannhanSelectMethod SelectMethod
		{
			get { return DmloaiquannhanOwner.SelectMethod; }
			set { DmloaiquannhanOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DmloaiquannhanProviderBase DmloaiquannhanProvider
		{
			get { return Provider as DmloaiquannhanProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Dmloaiquannhan> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Dmloaiquannhan> results = null;
			Dmloaiquannhan item;
			count = 0;
			
			System.Int32 idLoaiqn;

			switch ( SelectMethod )
			{
				case DmloaiquannhanSelectMethod.Get:
					DmloaiquannhanKey entityKey  = new DmloaiquannhanKey();
					entityKey.Load(values);
					item = DmloaiquannhanProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Dmloaiquannhan>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DmloaiquannhanSelectMethod.GetAll:
                    results = DmloaiquannhanProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DmloaiquannhanSelectMethod.GetPaged:
					results = DmloaiquannhanProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DmloaiquannhanSelectMethod.Find:
					if ( FilterParameters != null )
						results = DmloaiquannhanProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DmloaiquannhanProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DmloaiquannhanSelectMethod.GetByIdLoaiqn:
					idLoaiqn = ( values["IdLoaiqn"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdLoaiqn"], typeof(System.Int32)) : (int)0;
					item = DmloaiquannhanProvider.GetByIdLoaiqn(GetTransactionManager(), idLoaiqn);
					results = new TList<Dmloaiquannhan>();
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
			if ( SelectMethod == DmloaiquannhanSelectMethod.Get || SelectMethod == DmloaiquannhanSelectMethod.GetByIdLoaiqn )
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
				Dmloaiquannhan entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DmloaiquannhanProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Dmloaiquannhan> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DmloaiquannhanProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DmloaiquannhanDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DmloaiquannhanDataSource class.
	/// </summary>
	public class DmloaiquannhanDataSourceDesigner : ProviderDataSourceDesigner<Dmloaiquannhan, DmloaiquannhanKey>
	{
		/// <summary>
		/// Initializes a new instance of the DmloaiquannhanDataSourceDesigner class.
		/// </summary>
		public DmloaiquannhanDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmloaiquannhanSelectMethod SelectMethod
		{
			get { return ((DmloaiquannhanDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DmloaiquannhanDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DmloaiquannhanDataSourceActionList

	/// <summary>
	/// Supports the DmloaiquannhanDataSourceDesigner class.
	/// </summary>
	internal class DmloaiquannhanDataSourceActionList : DesignerActionList
	{
		private DmloaiquannhanDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DmloaiquannhanDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DmloaiquannhanDataSourceActionList(DmloaiquannhanDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmloaiquannhanSelectMethod SelectMethod
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

	#endregion DmloaiquannhanDataSourceActionList
	
	#endregion DmloaiquannhanDataSourceDesigner
	
	#region DmloaiquannhanSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DmloaiquannhanDataSource.SelectMethod property.
	/// </summary>
	public enum DmloaiquannhanSelectMethod
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
		/// Represents the GetByIdLoaiqn method.
		/// </summary>
		GetByIdLoaiqn
	}
	
	#endregion DmloaiquannhanSelectMethod

	#region DmloaiquannhanFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmloaiquannhan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmloaiquannhanFilter : SqlFilter<DmloaiquannhanColumn>
	{
	}
	
	#endregion DmloaiquannhanFilter

	#region DmloaiquannhanExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmloaiquannhan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmloaiquannhanExpressionBuilder : SqlExpressionBuilder<DmloaiquannhanColumn>
	{
	}
	
	#endregion DmloaiquannhanExpressionBuilder	

	#region DmloaiquannhanProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DmloaiquannhanChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Dmloaiquannhan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmloaiquannhanProperty : ChildEntityProperty<DmloaiquannhanChildEntityTypes>
	{
	}
	
	#endregion DmloaiquannhanProperty
}

