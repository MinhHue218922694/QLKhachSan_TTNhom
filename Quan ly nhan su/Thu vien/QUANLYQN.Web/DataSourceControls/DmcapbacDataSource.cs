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
	/// Represents the DataRepository.DmcapbacProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DmcapbacDataSourceDesigner))]
	public class DmcapbacDataSource : ProviderDataSource<Dmcapbac, DmcapbacKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmcapbacDataSource class.
		/// </summary>
		public DmcapbacDataSource() : base(DataRepository.DmcapbacProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DmcapbacDataSourceView used by the DmcapbacDataSource.
		/// </summary>
		protected DmcapbacDataSourceView DmcapbacView
		{
			get { return ( View as DmcapbacDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DmcapbacDataSource control invokes to retrieve data.
		/// </summary>
		public DmcapbacSelectMethod SelectMethod
		{
			get
			{
				DmcapbacSelectMethod selectMethod = DmcapbacSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DmcapbacSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DmcapbacDataSourceView class that is to be
		/// used by the DmcapbacDataSource.
		/// </summary>
		/// <returns>An instance of the DmcapbacDataSourceView class.</returns>
		protected override BaseDataSourceView<Dmcapbac, DmcapbacKey> GetNewDataSourceView()
		{
			return new DmcapbacDataSourceView(this, DefaultViewName);
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
	/// Supports the DmcapbacDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DmcapbacDataSourceView : ProviderDataSourceView<Dmcapbac, DmcapbacKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmcapbacDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DmcapbacDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DmcapbacDataSourceView(DmcapbacDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DmcapbacDataSource DmcapbacOwner
		{
			get { return Owner as DmcapbacDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DmcapbacSelectMethod SelectMethod
		{
			get { return DmcapbacOwner.SelectMethod; }
			set { DmcapbacOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DmcapbacProviderBase DmcapbacProvider
		{
			get { return Provider as DmcapbacProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Dmcapbac> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Dmcapbac> results = null;
			Dmcapbac item;
			count = 0;
			
			System.Int32 idCapbac;

			switch ( SelectMethod )
			{
				case DmcapbacSelectMethod.Get:
					DmcapbacKey entityKey  = new DmcapbacKey();
					entityKey.Load(values);
					item = DmcapbacProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Dmcapbac>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DmcapbacSelectMethod.GetAll:
                    results = DmcapbacProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DmcapbacSelectMethod.GetPaged:
					results = DmcapbacProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DmcapbacSelectMethod.Find:
					if ( FilterParameters != null )
						results = DmcapbacProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DmcapbacProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DmcapbacSelectMethod.GetByIdCapbac:
					idCapbac = ( values["IdCapbac"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdCapbac"], typeof(System.Int32)) : (int)0;
					item = DmcapbacProvider.GetByIdCapbac(GetTransactionManager(), idCapbac);
					results = new TList<Dmcapbac>();
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
			if ( SelectMethod == DmcapbacSelectMethod.Get || SelectMethod == DmcapbacSelectMethod.GetByIdCapbac )
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
				Dmcapbac entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DmcapbacProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Dmcapbac> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DmcapbacProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DmcapbacDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DmcapbacDataSource class.
	/// </summary>
	public class DmcapbacDataSourceDesigner : ProviderDataSourceDesigner<Dmcapbac, DmcapbacKey>
	{
		/// <summary>
		/// Initializes a new instance of the DmcapbacDataSourceDesigner class.
		/// </summary>
		public DmcapbacDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmcapbacSelectMethod SelectMethod
		{
			get { return ((DmcapbacDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DmcapbacDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DmcapbacDataSourceActionList

	/// <summary>
	/// Supports the DmcapbacDataSourceDesigner class.
	/// </summary>
	internal class DmcapbacDataSourceActionList : DesignerActionList
	{
		private DmcapbacDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DmcapbacDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DmcapbacDataSourceActionList(DmcapbacDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmcapbacSelectMethod SelectMethod
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

	#endregion DmcapbacDataSourceActionList
	
	#endregion DmcapbacDataSourceDesigner
	
	#region DmcapbacSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DmcapbacDataSource.SelectMethod property.
	/// </summary>
	public enum DmcapbacSelectMethod
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
		/// Represents the GetByIdCapbac method.
		/// </summary>
		GetByIdCapbac
	}
	
	#endregion DmcapbacSelectMethod

	#region DmcapbacFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmcapbac"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmcapbacFilter : SqlFilter<DmcapbacColumn>
	{
	}
	
	#endregion DmcapbacFilter

	#region DmcapbacExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmcapbac"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmcapbacExpressionBuilder : SqlExpressionBuilder<DmcapbacColumn>
	{
	}
	
	#endregion DmcapbacExpressionBuilder	

	#region DmcapbacProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DmcapbacChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Dmcapbac"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmcapbacProperty : ChildEntityProperty<DmcapbacChildEntityTypes>
	{
	}
	
	#endregion DmcapbacProperty
}

