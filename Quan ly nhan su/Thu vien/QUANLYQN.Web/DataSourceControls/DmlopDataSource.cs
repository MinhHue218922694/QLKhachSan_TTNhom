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
	/// Represents the DataRepository.DmlopProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DmlopDataSourceDesigner))]
	public class DmlopDataSource : ProviderDataSource<Dmlop, DmlopKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmlopDataSource class.
		/// </summary>
		public DmlopDataSource() : base(DataRepository.DmlopProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DmlopDataSourceView used by the DmlopDataSource.
		/// </summary>
		protected DmlopDataSourceView DmlopView
		{
			get { return ( View as DmlopDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DmlopDataSource control invokes to retrieve data.
		/// </summary>
		public DmlopSelectMethod SelectMethod
		{
			get
			{
				DmlopSelectMethod selectMethod = DmlopSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DmlopSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DmlopDataSourceView class that is to be
		/// used by the DmlopDataSource.
		/// </summary>
		/// <returns>An instance of the DmlopDataSourceView class.</returns>
		protected override BaseDataSourceView<Dmlop, DmlopKey> GetNewDataSourceView()
		{
			return new DmlopDataSourceView(this, DefaultViewName);
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
	/// Supports the DmlopDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DmlopDataSourceView : ProviderDataSourceView<Dmlop, DmlopKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmlopDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DmlopDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DmlopDataSourceView(DmlopDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DmlopDataSource DmlopOwner
		{
			get { return Owner as DmlopDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DmlopSelectMethod SelectMethod
		{
			get { return DmlopOwner.SelectMethod; }
			set { DmlopOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DmlopProviderBase DmlopProvider
		{
			get { return Provider as DmlopProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Dmlop> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Dmlop> results = null;
			Dmlop item;
			count = 0;
			
			System.Int32 idLop;
			System.Int32 idDaidoi;

			switch ( SelectMethod )
			{
				case DmlopSelectMethod.Get:
					DmlopKey entityKey  = new DmlopKey();
					entityKey.Load(values);
					item = DmlopProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Dmlop>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DmlopSelectMethod.GetAll:
                    results = DmlopProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DmlopSelectMethod.GetPaged:
					results = DmlopProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DmlopSelectMethod.Find:
					if ( FilterParameters != null )
						results = DmlopProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DmlopProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DmlopSelectMethod.GetByIdLop:
					idLop = ( values["IdLop"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdLop"], typeof(System.Int32)) : (int)0;
					item = DmlopProvider.GetByIdLop(GetTransactionManager(), idLop);
					results = new TList<Dmlop>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case DmlopSelectMethod.GetByIdDaidoi:
					idDaidoi = ( values["IdDaidoi"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdDaidoi"], typeof(System.Int32)) : (int)0;
					results = DmlopProvider.GetByIdDaidoi(GetTransactionManager(), idDaidoi, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == DmlopSelectMethod.Get || SelectMethod == DmlopSelectMethod.GetByIdLop )
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
				Dmlop entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DmlopProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Dmlop> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DmlopProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DmlopDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DmlopDataSource class.
	/// </summary>
	public class DmlopDataSourceDesigner : ProviderDataSourceDesigner<Dmlop, DmlopKey>
	{
		/// <summary>
		/// Initializes a new instance of the DmlopDataSourceDesigner class.
		/// </summary>
		public DmlopDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmlopSelectMethod SelectMethod
		{
			get { return ((DmlopDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DmlopDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DmlopDataSourceActionList

	/// <summary>
	/// Supports the DmlopDataSourceDesigner class.
	/// </summary>
	internal class DmlopDataSourceActionList : DesignerActionList
	{
		private DmlopDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DmlopDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DmlopDataSourceActionList(DmlopDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmlopSelectMethod SelectMethod
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

	#endregion DmlopDataSourceActionList
	
	#endregion DmlopDataSourceDesigner
	
	#region DmlopSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DmlopDataSource.SelectMethod property.
	/// </summary>
	public enum DmlopSelectMethod
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
		/// Represents the GetByIdLop method.
		/// </summary>
		GetByIdLop,
		/// <summary>
		/// Represents the GetByIdDaidoi method.
		/// </summary>
		GetByIdDaidoi
	}
	
	#endregion DmlopSelectMethod

	#region DmlopFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmlop"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmlopFilter : SqlFilter<DmlopColumn>
	{
	}
	
	#endregion DmlopFilter

	#region DmlopExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmlop"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmlopExpressionBuilder : SqlExpressionBuilder<DmlopColumn>
	{
	}
	
	#endregion DmlopExpressionBuilder	

	#region DmlopProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DmlopChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Dmlop"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmlopProperty : ChildEntityProperty<DmlopChildEntityTypes>
	{
	}
	
	#endregion DmlopProperty
}

