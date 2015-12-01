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
	/// Represents the DataRepository.LscapbacProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LscapbacDataSourceDesigner))]
	public class LscapbacDataSource : ProviderDataSource<Lscapbac, LscapbacKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LscapbacDataSource class.
		/// </summary>
		public LscapbacDataSource() : base(DataRepository.LscapbacProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LscapbacDataSourceView used by the LscapbacDataSource.
		/// </summary>
		protected LscapbacDataSourceView LscapbacView
		{
			get { return ( View as LscapbacDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LscapbacDataSource control invokes to retrieve data.
		/// </summary>
		public LscapbacSelectMethod SelectMethod
		{
			get
			{
				LscapbacSelectMethod selectMethod = LscapbacSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LscapbacSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LscapbacDataSourceView class that is to be
		/// used by the LscapbacDataSource.
		/// </summary>
		/// <returns>An instance of the LscapbacDataSourceView class.</returns>
		protected override BaseDataSourceView<Lscapbac, LscapbacKey> GetNewDataSourceView()
		{
			return new LscapbacDataSourceView(this, DefaultViewName);
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
	/// Supports the LscapbacDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LscapbacDataSourceView : ProviderDataSourceView<Lscapbac, LscapbacKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LscapbacDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LscapbacDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LscapbacDataSourceView(LscapbacDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LscapbacDataSource LscapbacOwner
		{
			get { return Owner as LscapbacDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LscapbacSelectMethod SelectMethod
		{
			get { return LscapbacOwner.SelectMethod; }
			set { LscapbacOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LscapbacProviderBase LscapbacProvider
		{
			get { return Provider as LscapbacProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Lscapbac> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Lscapbac> results = null;
			Lscapbac item;
			count = 0;
			
			System.Int64 idLichsucapbac;
			System.Int32 idQuannhan;
			System.Int32 idCapbac;

			switch ( SelectMethod )
			{
				case LscapbacSelectMethod.Get:
					LscapbacKey entityKey  = new LscapbacKey();
					entityKey.Load(values);
					item = LscapbacProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Lscapbac>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LscapbacSelectMethod.GetAll:
                    results = LscapbacProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case LscapbacSelectMethod.GetPaged:
					results = LscapbacProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LscapbacSelectMethod.Find:
					if ( FilterParameters != null )
						results = LscapbacProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LscapbacProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LscapbacSelectMethod.GetByIdLichsucapbac:
					idLichsucapbac = ( values["IdLichsucapbac"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdLichsucapbac"], typeof(System.Int64)) : (long)0;
					item = LscapbacProvider.GetByIdLichsucapbac(GetTransactionManager(), idLichsucapbac);
					results = new TList<Lscapbac>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case LscapbacSelectMethod.GetByIdQuannhan:
					idQuannhan = ( values["IdQuannhan"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdQuannhan"], typeof(System.Int32)) : (int)0;
					results = LscapbacProvider.GetByIdQuannhan(GetTransactionManager(), idQuannhan, this.StartIndex, this.PageSize, out count);
					break;
				case LscapbacSelectMethod.GetByIdCapbac:
					idCapbac = ( values["IdCapbac"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdCapbac"], typeof(System.Int32)) : (int)0;
					results = LscapbacProvider.GetByIdCapbac(GetTransactionManager(), idCapbac, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == LscapbacSelectMethod.Get || SelectMethod == LscapbacSelectMethod.GetByIdLichsucapbac )
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
				Lscapbac entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					LscapbacProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Lscapbac> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			LscapbacProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LscapbacDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LscapbacDataSource class.
	/// </summary>
	public class LscapbacDataSourceDesigner : ProviderDataSourceDesigner<Lscapbac, LscapbacKey>
	{
		/// <summary>
		/// Initializes a new instance of the LscapbacDataSourceDesigner class.
		/// </summary>
		public LscapbacDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LscapbacSelectMethod SelectMethod
		{
			get { return ((LscapbacDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LscapbacDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LscapbacDataSourceActionList

	/// <summary>
	/// Supports the LscapbacDataSourceDesigner class.
	/// </summary>
	internal class LscapbacDataSourceActionList : DesignerActionList
	{
		private LscapbacDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LscapbacDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LscapbacDataSourceActionList(LscapbacDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LscapbacSelectMethod SelectMethod
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

	#endregion LscapbacDataSourceActionList
	
	#endregion LscapbacDataSourceDesigner
	
	#region LscapbacSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LscapbacDataSource.SelectMethod property.
	/// </summary>
	public enum LscapbacSelectMethod
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
		/// Represents the GetByIdLichsucapbac method.
		/// </summary>
		GetByIdLichsucapbac,
		/// <summary>
		/// Represents the GetByIdQuannhan method.
		/// </summary>
		GetByIdQuannhan,
		/// <summary>
		/// Represents the GetByIdCapbac method.
		/// </summary>
		GetByIdCapbac
	}
	
	#endregion LscapbacSelectMethod

	#region LscapbacFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lscapbac"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LscapbacFilter : SqlFilter<LscapbacColumn>
	{
	}
	
	#endregion LscapbacFilter

	#region LscapbacExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lscapbac"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LscapbacExpressionBuilder : SqlExpressionBuilder<LscapbacColumn>
	{
	}
	
	#endregion LscapbacExpressionBuilder	

	#region LscapbacProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LscapbacChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Lscapbac"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LscapbacProperty : ChildEntityProperty<LscapbacChildEntityTypes>
	{
	}
	
	#endregion LscapbacProperty
}

