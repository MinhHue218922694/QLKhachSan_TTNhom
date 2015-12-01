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
	/// Represents the DataRepository.DmtruongProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DmtruongDataSourceDesigner))]
	public class DmtruongDataSource : ProviderDataSource<Dmtruong, DmtruongKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmtruongDataSource class.
		/// </summary>
		public DmtruongDataSource() : base(DataRepository.DmtruongProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DmtruongDataSourceView used by the DmtruongDataSource.
		/// </summary>
		protected DmtruongDataSourceView DmtruongView
		{
			get { return ( View as DmtruongDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DmtruongDataSource control invokes to retrieve data.
		/// </summary>
		public DmtruongSelectMethod SelectMethod
		{
			get
			{
				DmtruongSelectMethod selectMethod = DmtruongSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DmtruongSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DmtruongDataSourceView class that is to be
		/// used by the DmtruongDataSource.
		/// </summary>
		/// <returns>An instance of the DmtruongDataSourceView class.</returns>
		protected override BaseDataSourceView<Dmtruong, DmtruongKey> GetNewDataSourceView()
		{
			return new DmtruongDataSourceView(this, DefaultViewName);
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
	/// Supports the DmtruongDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DmtruongDataSourceView : ProviderDataSourceView<Dmtruong, DmtruongKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmtruongDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DmtruongDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DmtruongDataSourceView(DmtruongDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DmtruongDataSource DmtruongOwner
		{
			get { return Owner as DmtruongDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DmtruongSelectMethod SelectMethod
		{
			get { return DmtruongOwner.SelectMethod; }
			set { DmtruongOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DmtruongProviderBase DmtruongProvider
		{
			get { return Provider as DmtruongProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Dmtruong> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Dmtruong> results = null;
			Dmtruong item;
			count = 0;
			
			System.Int32 idTruong;

			switch ( SelectMethod )
			{
				case DmtruongSelectMethod.Get:
					DmtruongKey entityKey  = new DmtruongKey();
					entityKey.Load(values);
					item = DmtruongProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Dmtruong>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DmtruongSelectMethod.GetAll:
                    results = DmtruongProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DmtruongSelectMethod.GetPaged:
					results = DmtruongProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DmtruongSelectMethod.Find:
					if ( FilterParameters != null )
						results = DmtruongProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DmtruongProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DmtruongSelectMethod.GetByIdTruong:
					idTruong = ( values["IdTruong"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdTruong"], typeof(System.Int32)) : (int)0;
					item = DmtruongProvider.GetByIdTruong(GetTransactionManager(), idTruong);
					results = new TList<Dmtruong>();
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
			if ( SelectMethod == DmtruongSelectMethod.Get || SelectMethod == DmtruongSelectMethod.GetByIdTruong )
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
				Dmtruong entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DmtruongProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Dmtruong> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DmtruongProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DmtruongDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DmtruongDataSource class.
	/// </summary>
	public class DmtruongDataSourceDesigner : ProviderDataSourceDesigner<Dmtruong, DmtruongKey>
	{
		/// <summary>
		/// Initializes a new instance of the DmtruongDataSourceDesigner class.
		/// </summary>
		public DmtruongDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmtruongSelectMethod SelectMethod
		{
			get { return ((DmtruongDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DmtruongDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DmtruongDataSourceActionList

	/// <summary>
	/// Supports the DmtruongDataSourceDesigner class.
	/// </summary>
	internal class DmtruongDataSourceActionList : DesignerActionList
	{
		private DmtruongDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DmtruongDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DmtruongDataSourceActionList(DmtruongDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmtruongSelectMethod SelectMethod
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

	#endregion DmtruongDataSourceActionList
	
	#endregion DmtruongDataSourceDesigner
	
	#region DmtruongSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DmtruongDataSource.SelectMethod property.
	/// </summary>
	public enum DmtruongSelectMethod
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
		/// Represents the GetByIdTruong method.
		/// </summary>
		GetByIdTruong
	}
	
	#endregion DmtruongSelectMethod

	#region DmtruongFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmtruong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmtruongFilter : SqlFilter<DmtruongColumn>
	{
	}
	
	#endregion DmtruongFilter

	#region DmtruongExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmtruong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmtruongExpressionBuilder : SqlExpressionBuilder<DmtruongColumn>
	{
	}
	
	#endregion DmtruongExpressionBuilder	

	#region DmtruongProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DmtruongChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Dmtruong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmtruongProperty : ChildEntityProperty<DmtruongChildEntityTypes>
	{
	}
	
	#endregion DmtruongProperty
}

