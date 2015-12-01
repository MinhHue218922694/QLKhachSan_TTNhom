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
	/// Represents the DataRepository.LstruonglopProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LstruonglopDataSourceDesigner))]
	public class LstruonglopDataSource : ProviderDataSource<Lstruonglop, LstruonglopKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LstruonglopDataSource class.
		/// </summary>
		public LstruonglopDataSource() : base(DataRepository.LstruonglopProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LstruonglopDataSourceView used by the LstruonglopDataSource.
		/// </summary>
		protected LstruonglopDataSourceView LstruonglopView
		{
			get { return ( View as LstruonglopDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LstruonglopDataSource control invokes to retrieve data.
		/// </summary>
		public LstruonglopSelectMethod SelectMethod
		{
			get
			{
				LstruonglopSelectMethod selectMethod = LstruonglopSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LstruonglopSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LstruonglopDataSourceView class that is to be
		/// used by the LstruonglopDataSource.
		/// </summary>
		/// <returns>An instance of the LstruonglopDataSourceView class.</returns>
		protected override BaseDataSourceView<Lstruonglop, LstruonglopKey> GetNewDataSourceView()
		{
			return new LstruonglopDataSourceView(this, DefaultViewName);
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
	/// Supports the LstruonglopDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LstruonglopDataSourceView : ProviderDataSourceView<Lstruonglop, LstruonglopKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LstruonglopDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LstruonglopDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LstruonglopDataSourceView(LstruonglopDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LstruonglopDataSource LstruonglopOwner
		{
			get { return Owner as LstruonglopDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LstruonglopSelectMethod SelectMethod
		{
			get { return LstruonglopOwner.SelectMethod; }
			set { LstruonglopOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LstruonglopProviderBase LstruonglopProvider
		{
			get { return Provider as LstruonglopProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Lstruonglop> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Lstruonglop> results = null;
			Lstruonglop item;
			count = 0;
			
			System.Int64 idLichsutruonglop;
			System.Int32 idTruong;
			System.Int32 idCaphoc;
			System.Int32 idQuannhan;

			switch ( SelectMethod )
			{
				case LstruonglopSelectMethod.Get:
					LstruonglopKey entityKey  = new LstruonglopKey();
					entityKey.Load(values);
					item = LstruonglopProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Lstruonglop>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LstruonglopSelectMethod.GetAll:
                    results = LstruonglopProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case LstruonglopSelectMethod.GetPaged:
					results = LstruonglopProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LstruonglopSelectMethod.Find:
					if ( FilterParameters != null )
						results = LstruonglopProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LstruonglopProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LstruonglopSelectMethod.GetByIdLichsutruonglop:
					idLichsutruonglop = ( values["IdLichsutruonglop"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdLichsutruonglop"], typeof(System.Int64)) : (long)0;
					item = LstruonglopProvider.GetByIdLichsutruonglop(GetTransactionManager(), idLichsutruonglop);
					results = new TList<Lstruonglop>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case LstruonglopSelectMethod.GetByIdTruong:
					idTruong = ( values["IdTruong"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdTruong"], typeof(System.Int32)) : (int)0;
					results = LstruonglopProvider.GetByIdTruong(GetTransactionManager(), idTruong, this.StartIndex, this.PageSize, out count);
					break;
				case LstruonglopSelectMethod.GetByIdCaphoc:
					idCaphoc = ( values["IdCaphoc"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdCaphoc"], typeof(System.Int32)) : (int)0;
					results = LstruonglopProvider.GetByIdCaphoc(GetTransactionManager(), idCaphoc, this.StartIndex, this.PageSize, out count);
					break;
				case LstruonglopSelectMethod.GetByIdQuannhan:
					idQuannhan = ( values["IdQuannhan"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdQuannhan"], typeof(System.Int32)) : (int)0;
					results = LstruonglopProvider.GetByIdQuannhan(GetTransactionManager(), idQuannhan, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == LstruonglopSelectMethod.Get || SelectMethod == LstruonglopSelectMethod.GetByIdLichsutruonglop )
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
				Lstruonglop entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					LstruonglopProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Lstruonglop> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			LstruonglopProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LstruonglopDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LstruonglopDataSource class.
	/// </summary>
	public class LstruonglopDataSourceDesigner : ProviderDataSourceDesigner<Lstruonglop, LstruonglopKey>
	{
		/// <summary>
		/// Initializes a new instance of the LstruonglopDataSourceDesigner class.
		/// </summary>
		public LstruonglopDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LstruonglopSelectMethod SelectMethod
		{
			get { return ((LstruonglopDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LstruonglopDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LstruonglopDataSourceActionList

	/// <summary>
	/// Supports the LstruonglopDataSourceDesigner class.
	/// </summary>
	internal class LstruonglopDataSourceActionList : DesignerActionList
	{
		private LstruonglopDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LstruonglopDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LstruonglopDataSourceActionList(LstruonglopDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LstruonglopSelectMethod SelectMethod
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

	#endregion LstruonglopDataSourceActionList
	
	#endregion LstruonglopDataSourceDesigner
	
	#region LstruonglopSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LstruonglopDataSource.SelectMethod property.
	/// </summary>
	public enum LstruonglopSelectMethod
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
		/// Represents the GetByIdLichsutruonglop method.
		/// </summary>
		GetByIdLichsutruonglop,
		/// <summary>
		/// Represents the GetByIdTruong method.
		/// </summary>
		GetByIdTruong,
		/// <summary>
		/// Represents the GetByIdCaphoc method.
		/// </summary>
		GetByIdCaphoc,
		/// <summary>
		/// Represents the GetByIdQuannhan method.
		/// </summary>
		GetByIdQuannhan
	}
	
	#endregion LstruonglopSelectMethod

	#region LstruonglopFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lstruonglop"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LstruonglopFilter : SqlFilter<LstruonglopColumn>
	{
	}
	
	#endregion LstruonglopFilter

	#region LstruonglopExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lstruonglop"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LstruonglopExpressionBuilder : SqlExpressionBuilder<LstruonglopColumn>
	{
	}
	
	#endregion LstruonglopExpressionBuilder	

	#region LstruonglopProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LstruonglopChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Lstruonglop"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LstruonglopProperty : ChildEntityProperty<LstruonglopChildEntityTypes>
	{
	}
	
	#endregion LstruonglopProperty
}

