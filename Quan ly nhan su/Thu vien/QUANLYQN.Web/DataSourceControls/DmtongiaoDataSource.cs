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
	/// Represents the DataRepository.DmtongiaoProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DmtongiaoDataSourceDesigner))]
	public class DmtongiaoDataSource : ProviderDataSource<Dmtongiao, DmtongiaoKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmtongiaoDataSource class.
		/// </summary>
		public DmtongiaoDataSource() : base(DataRepository.DmtongiaoProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DmtongiaoDataSourceView used by the DmtongiaoDataSource.
		/// </summary>
		protected DmtongiaoDataSourceView DmtongiaoView
		{
			get { return ( View as DmtongiaoDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DmtongiaoDataSource control invokes to retrieve data.
		/// </summary>
		public DmtongiaoSelectMethod SelectMethod
		{
			get
			{
				DmtongiaoSelectMethod selectMethod = DmtongiaoSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DmtongiaoSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DmtongiaoDataSourceView class that is to be
		/// used by the DmtongiaoDataSource.
		/// </summary>
		/// <returns>An instance of the DmtongiaoDataSourceView class.</returns>
		protected override BaseDataSourceView<Dmtongiao, DmtongiaoKey> GetNewDataSourceView()
		{
			return new DmtongiaoDataSourceView(this, DefaultViewName);
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
	/// Supports the DmtongiaoDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DmtongiaoDataSourceView : ProviderDataSourceView<Dmtongiao, DmtongiaoKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmtongiaoDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DmtongiaoDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DmtongiaoDataSourceView(DmtongiaoDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DmtongiaoDataSource DmtongiaoOwner
		{
			get { return Owner as DmtongiaoDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DmtongiaoSelectMethod SelectMethod
		{
			get { return DmtongiaoOwner.SelectMethod; }
			set { DmtongiaoOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DmtongiaoProviderBase DmtongiaoProvider
		{
			get { return Provider as DmtongiaoProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Dmtongiao> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Dmtongiao> results = null;
			Dmtongiao item;
			count = 0;
			
			System.Int32 idTongiao;

			switch ( SelectMethod )
			{
				case DmtongiaoSelectMethod.Get:
					DmtongiaoKey entityKey  = new DmtongiaoKey();
					entityKey.Load(values);
					item = DmtongiaoProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Dmtongiao>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DmtongiaoSelectMethod.GetAll:
                    results = DmtongiaoProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DmtongiaoSelectMethod.GetPaged:
					results = DmtongiaoProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DmtongiaoSelectMethod.Find:
					if ( FilterParameters != null )
						results = DmtongiaoProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DmtongiaoProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DmtongiaoSelectMethod.GetByIdTongiao:
					idTongiao = ( values["IdTongiao"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdTongiao"], typeof(System.Int32)) : (int)0;
					item = DmtongiaoProvider.GetByIdTongiao(GetTransactionManager(), idTongiao);
					results = new TList<Dmtongiao>();
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
			if ( SelectMethod == DmtongiaoSelectMethod.Get || SelectMethod == DmtongiaoSelectMethod.GetByIdTongiao )
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
				Dmtongiao entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DmtongiaoProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Dmtongiao> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DmtongiaoProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DmtongiaoDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DmtongiaoDataSource class.
	/// </summary>
	public class DmtongiaoDataSourceDesigner : ProviderDataSourceDesigner<Dmtongiao, DmtongiaoKey>
	{
		/// <summary>
		/// Initializes a new instance of the DmtongiaoDataSourceDesigner class.
		/// </summary>
		public DmtongiaoDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmtongiaoSelectMethod SelectMethod
		{
			get { return ((DmtongiaoDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DmtongiaoDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DmtongiaoDataSourceActionList

	/// <summary>
	/// Supports the DmtongiaoDataSourceDesigner class.
	/// </summary>
	internal class DmtongiaoDataSourceActionList : DesignerActionList
	{
		private DmtongiaoDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DmtongiaoDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DmtongiaoDataSourceActionList(DmtongiaoDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmtongiaoSelectMethod SelectMethod
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

	#endregion DmtongiaoDataSourceActionList
	
	#endregion DmtongiaoDataSourceDesigner
	
	#region DmtongiaoSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DmtongiaoDataSource.SelectMethod property.
	/// </summary>
	public enum DmtongiaoSelectMethod
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
		/// Represents the GetByIdTongiao method.
		/// </summary>
		GetByIdTongiao
	}
	
	#endregion DmtongiaoSelectMethod

	#region DmtongiaoFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmtongiao"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmtongiaoFilter : SqlFilter<DmtongiaoColumn>
	{
	}
	
	#endregion DmtongiaoFilter

	#region DmtongiaoExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmtongiao"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmtongiaoExpressionBuilder : SqlExpressionBuilder<DmtongiaoColumn>
	{
	}
	
	#endregion DmtongiaoExpressionBuilder	

	#region DmtongiaoProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DmtongiaoChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Dmtongiao"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmtongiaoProperty : ChildEntityProperty<DmtongiaoChildEntityTypes>
	{
	}
	
	#endregion DmtongiaoProperty
}

