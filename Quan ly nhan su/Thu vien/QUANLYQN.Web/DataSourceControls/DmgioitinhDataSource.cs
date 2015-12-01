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
	/// Represents the DataRepository.DmgioitinhProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DmgioitinhDataSourceDesigner))]
	public class DmgioitinhDataSource : ProviderDataSource<Dmgioitinh, DmgioitinhKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmgioitinhDataSource class.
		/// </summary>
		public DmgioitinhDataSource() : base(DataRepository.DmgioitinhProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DmgioitinhDataSourceView used by the DmgioitinhDataSource.
		/// </summary>
		protected DmgioitinhDataSourceView DmgioitinhView
		{
			get { return ( View as DmgioitinhDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DmgioitinhDataSource control invokes to retrieve data.
		/// </summary>
		public DmgioitinhSelectMethod SelectMethod
		{
			get
			{
				DmgioitinhSelectMethod selectMethod = DmgioitinhSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DmgioitinhSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DmgioitinhDataSourceView class that is to be
		/// used by the DmgioitinhDataSource.
		/// </summary>
		/// <returns>An instance of the DmgioitinhDataSourceView class.</returns>
		protected override BaseDataSourceView<Dmgioitinh, DmgioitinhKey> GetNewDataSourceView()
		{
			return new DmgioitinhDataSourceView(this, DefaultViewName);
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
	/// Supports the DmgioitinhDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DmgioitinhDataSourceView : ProviderDataSourceView<Dmgioitinh, DmgioitinhKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmgioitinhDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DmgioitinhDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DmgioitinhDataSourceView(DmgioitinhDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DmgioitinhDataSource DmgioitinhOwner
		{
			get { return Owner as DmgioitinhDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DmgioitinhSelectMethod SelectMethod
		{
			get { return DmgioitinhOwner.SelectMethod; }
			set { DmgioitinhOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DmgioitinhProviderBase DmgioitinhProvider
		{
			get { return Provider as DmgioitinhProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Dmgioitinh> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Dmgioitinh> results = null;
			Dmgioitinh item;
			count = 0;
			
			System.Int32 idGioitinh;

			switch ( SelectMethod )
			{
				case DmgioitinhSelectMethod.Get:
					DmgioitinhKey entityKey  = new DmgioitinhKey();
					entityKey.Load(values);
					item = DmgioitinhProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Dmgioitinh>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DmgioitinhSelectMethod.GetAll:
                    results = DmgioitinhProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DmgioitinhSelectMethod.GetPaged:
					results = DmgioitinhProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DmgioitinhSelectMethod.Find:
					if ( FilterParameters != null )
						results = DmgioitinhProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DmgioitinhProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DmgioitinhSelectMethod.GetByIdGioitinh:
					idGioitinh = ( values["IdGioitinh"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdGioitinh"], typeof(System.Int32)) : (int)0;
					item = DmgioitinhProvider.GetByIdGioitinh(GetTransactionManager(), idGioitinh);
					results = new TList<Dmgioitinh>();
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
			if ( SelectMethod == DmgioitinhSelectMethod.Get || SelectMethod == DmgioitinhSelectMethod.GetByIdGioitinh )
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
				Dmgioitinh entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DmgioitinhProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Dmgioitinh> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DmgioitinhProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DmgioitinhDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DmgioitinhDataSource class.
	/// </summary>
	public class DmgioitinhDataSourceDesigner : ProviderDataSourceDesigner<Dmgioitinh, DmgioitinhKey>
	{
		/// <summary>
		/// Initializes a new instance of the DmgioitinhDataSourceDesigner class.
		/// </summary>
		public DmgioitinhDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmgioitinhSelectMethod SelectMethod
		{
			get { return ((DmgioitinhDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DmgioitinhDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DmgioitinhDataSourceActionList

	/// <summary>
	/// Supports the DmgioitinhDataSourceDesigner class.
	/// </summary>
	internal class DmgioitinhDataSourceActionList : DesignerActionList
	{
		private DmgioitinhDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DmgioitinhDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DmgioitinhDataSourceActionList(DmgioitinhDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmgioitinhSelectMethod SelectMethod
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

	#endregion DmgioitinhDataSourceActionList
	
	#endregion DmgioitinhDataSourceDesigner
	
	#region DmgioitinhSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DmgioitinhDataSource.SelectMethod property.
	/// </summary>
	public enum DmgioitinhSelectMethod
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
		/// Represents the GetByIdGioitinh method.
		/// </summary>
		GetByIdGioitinh
	}
	
	#endregion DmgioitinhSelectMethod

	#region DmgioitinhFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmgioitinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmgioitinhFilter : SqlFilter<DmgioitinhColumn>
	{
	}
	
	#endregion DmgioitinhFilter

	#region DmgioitinhExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmgioitinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmgioitinhExpressionBuilder : SqlExpressionBuilder<DmgioitinhColumn>
	{
	}
	
	#endregion DmgioitinhExpressionBuilder	

	#region DmgioitinhProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DmgioitinhChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Dmgioitinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmgioitinhProperty : ChildEntityProperty<DmgioitinhChildEntityTypes>
	{
	}
	
	#endregion DmgioitinhProperty
}

