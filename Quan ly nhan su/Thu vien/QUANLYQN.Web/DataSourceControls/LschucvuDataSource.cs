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
	/// Represents the DataRepository.LschucvuProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LschucvuDataSourceDesigner))]
	public class LschucvuDataSource : ProviderDataSource<Lschucvu, LschucvuKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LschucvuDataSource class.
		/// </summary>
		public LschucvuDataSource() : base(DataRepository.LschucvuProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LschucvuDataSourceView used by the LschucvuDataSource.
		/// </summary>
		protected LschucvuDataSourceView LschucvuView
		{
			get { return ( View as LschucvuDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LschucvuDataSource control invokes to retrieve data.
		/// </summary>
		public LschucvuSelectMethod SelectMethod
		{
			get
			{
				LschucvuSelectMethod selectMethod = LschucvuSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LschucvuSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LschucvuDataSourceView class that is to be
		/// used by the LschucvuDataSource.
		/// </summary>
		/// <returns>An instance of the LschucvuDataSourceView class.</returns>
		protected override BaseDataSourceView<Lschucvu, LschucvuKey> GetNewDataSourceView()
		{
			return new LschucvuDataSourceView(this, DefaultViewName);
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
	/// Supports the LschucvuDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LschucvuDataSourceView : ProviderDataSourceView<Lschucvu, LschucvuKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LschucvuDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LschucvuDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LschucvuDataSourceView(LschucvuDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LschucvuDataSource LschucvuOwner
		{
			get { return Owner as LschucvuDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LschucvuSelectMethod SelectMethod
		{
			get { return LschucvuOwner.SelectMethod; }
			set { LschucvuOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LschucvuProviderBase LschucvuProvider
		{
			get { return Provider as LschucvuProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Lschucvu> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Lschucvu> results = null;
			Lschucvu item;
			count = 0;
			
			System.Int64 idLichsuchucvu;
			System.Int32 idChucvu;
			System.Int32 idQuannhan;

			switch ( SelectMethod )
			{
				case LschucvuSelectMethod.Get:
					LschucvuKey entityKey  = new LschucvuKey();
					entityKey.Load(values);
					item = LschucvuProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Lschucvu>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LschucvuSelectMethod.GetAll:
                    results = LschucvuProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case LschucvuSelectMethod.GetPaged:
					results = LschucvuProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LschucvuSelectMethod.Find:
					if ( FilterParameters != null )
						results = LschucvuProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LschucvuProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LschucvuSelectMethod.GetByIdLichsuchucvu:
					idLichsuchucvu = ( values["IdLichsuchucvu"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdLichsuchucvu"], typeof(System.Int64)) : (long)0;
					item = LschucvuProvider.GetByIdLichsuchucvu(GetTransactionManager(), idLichsuchucvu);
					results = new TList<Lschucvu>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case LschucvuSelectMethod.GetByIdChucvu:
					idChucvu = ( values["IdChucvu"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdChucvu"], typeof(System.Int32)) : (int)0;
					results = LschucvuProvider.GetByIdChucvu(GetTransactionManager(), idChucvu, this.StartIndex, this.PageSize, out count);
					break;
				case LschucvuSelectMethod.GetByIdQuannhan:
					idQuannhan = ( values["IdQuannhan"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdQuannhan"], typeof(System.Int32)) : (int)0;
					results = LschucvuProvider.GetByIdQuannhan(GetTransactionManager(), idQuannhan, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == LschucvuSelectMethod.Get || SelectMethod == LschucvuSelectMethod.GetByIdLichsuchucvu )
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
				Lschucvu entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					LschucvuProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Lschucvu> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			LschucvuProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LschucvuDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LschucvuDataSource class.
	/// </summary>
	public class LschucvuDataSourceDesigner : ProviderDataSourceDesigner<Lschucvu, LschucvuKey>
	{
		/// <summary>
		/// Initializes a new instance of the LschucvuDataSourceDesigner class.
		/// </summary>
		public LschucvuDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LschucvuSelectMethod SelectMethod
		{
			get { return ((LschucvuDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LschucvuDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LschucvuDataSourceActionList

	/// <summary>
	/// Supports the LschucvuDataSourceDesigner class.
	/// </summary>
	internal class LschucvuDataSourceActionList : DesignerActionList
	{
		private LschucvuDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LschucvuDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LschucvuDataSourceActionList(LschucvuDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LschucvuSelectMethod SelectMethod
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

	#endregion LschucvuDataSourceActionList
	
	#endregion LschucvuDataSourceDesigner
	
	#region LschucvuSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LschucvuDataSource.SelectMethod property.
	/// </summary>
	public enum LschucvuSelectMethod
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
		/// Represents the GetByIdLichsuchucvu method.
		/// </summary>
		GetByIdLichsuchucvu,
		/// <summary>
		/// Represents the GetByIdChucvu method.
		/// </summary>
		GetByIdChucvu,
		/// <summary>
		/// Represents the GetByIdQuannhan method.
		/// </summary>
		GetByIdQuannhan
	}
	
	#endregion LschucvuSelectMethod

	#region LschucvuFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lschucvu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LschucvuFilter : SqlFilter<LschucvuColumn>
	{
	}
	
	#endregion LschucvuFilter

	#region LschucvuExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lschucvu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LschucvuExpressionBuilder : SqlExpressionBuilder<LschucvuColumn>
	{
	}
	
	#endregion LschucvuExpressionBuilder	

	#region LschucvuProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LschucvuChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Lschucvu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LschucvuProperty : ChildEntityProperty<LschucvuChildEntityTypes>
	{
	}
	
	#endregion LschucvuProperty
}

