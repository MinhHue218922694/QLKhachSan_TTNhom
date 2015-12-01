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
	/// Represents the DataRepository.DmhinhthuckyluatProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DmhinhthuckyluatDataSourceDesigner))]
	public class DmhinhthuckyluatDataSource : ProviderDataSource<Dmhinhthuckyluat, DmhinhthuckyluatKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckyluatDataSource class.
		/// </summary>
		public DmhinhthuckyluatDataSource() : base(DataRepository.DmhinhthuckyluatProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DmhinhthuckyluatDataSourceView used by the DmhinhthuckyluatDataSource.
		/// </summary>
		protected DmhinhthuckyluatDataSourceView DmhinhthuckyluatView
		{
			get { return ( View as DmhinhthuckyluatDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DmhinhthuckyluatDataSource control invokes to retrieve data.
		/// </summary>
		public DmhinhthuckyluatSelectMethod SelectMethod
		{
			get
			{
				DmhinhthuckyluatSelectMethod selectMethod = DmhinhthuckyluatSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DmhinhthuckyluatSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DmhinhthuckyluatDataSourceView class that is to be
		/// used by the DmhinhthuckyluatDataSource.
		/// </summary>
		/// <returns>An instance of the DmhinhthuckyluatDataSourceView class.</returns>
		protected override BaseDataSourceView<Dmhinhthuckyluat, DmhinhthuckyluatKey> GetNewDataSourceView()
		{
			return new DmhinhthuckyluatDataSourceView(this, DefaultViewName);
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
	/// Supports the DmhinhthuckyluatDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DmhinhthuckyluatDataSourceView : ProviderDataSourceView<Dmhinhthuckyluat, DmhinhthuckyluatKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckyluatDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DmhinhthuckyluatDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DmhinhthuckyluatDataSourceView(DmhinhthuckyluatDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DmhinhthuckyluatDataSource DmhinhthuckyluatOwner
		{
			get { return Owner as DmhinhthuckyluatDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DmhinhthuckyluatSelectMethod SelectMethod
		{
			get { return DmhinhthuckyluatOwner.SelectMethod; }
			set { DmhinhthuckyluatOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DmhinhthuckyluatProviderBase DmhinhthuckyluatProvider
		{
			get { return Provider as DmhinhthuckyluatProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Dmhinhthuckyluat> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Dmhinhthuckyluat> results = null;
			Dmhinhthuckyluat item;
			count = 0;
			
			System.Int32 idHinhthucKyluat;

			switch ( SelectMethod )
			{
				case DmhinhthuckyluatSelectMethod.Get:
					DmhinhthuckyluatKey entityKey  = new DmhinhthuckyluatKey();
					entityKey.Load(values);
					item = DmhinhthuckyluatProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Dmhinhthuckyluat>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DmhinhthuckyluatSelectMethod.GetAll:
                    results = DmhinhthuckyluatProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DmhinhthuckyluatSelectMethod.GetPaged:
					results = DmhinhthuckyluatProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DmhinhthuckyluatSelectMethod.Find:
					if ( FilterParameters != null )
						results = DmhinhthuckyluatProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DmhinhthuckyluatProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DmhinhthuckyluatSelectMethod.GetByIdHinhthucKyluat:
					idHinhthucKyluat = ( values["IdHinhthucKyluat"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdHinhthucKyluat"], typeof(System.Int32)) : (int)0;
					item = DmhinhthuckyluatProvider.GetByIdHinhthucKyluat(GetTransactionManager(), idHinhthucKyluat);
					results = new TList<Dmhinhthuckyluat>();
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
			if ( SelectMethod == DmhinhthuckyluatSelectMethod.Get || SelectMethod == DmhinhthuckyluatSelectMethod.GetByIdHinhthucKyluat )
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
				Dmhinhthuckyluat entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DmhinhthuckyluatProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Dmhinhthuckyluat> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DmhinhthuckyluatProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DmhinhthuckyluatDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DmhinhthuckyluatDataSource class.
	/// </summary>
	public class DmhinhthuckyluatDataSourceDesigner : ProviderDataSourceDesigner<Dmhinhthuckyluat, DmhinhthuckyluatKey>
	{
		/// <summary>
		/// Initializes a new instance of the DmhinhthuckyluatDataSourceDesigner class.
		/// </summary>
		public DmhinhthuckyluatDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmhinhthuckyluatSelectMethod SelectMethod
		{
			get { return ((DmhinhthuckyluatDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DmhinhthuckyluatDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DmhinhthuckyluatDataSourceActionList

	/// <summary>
	/// Supports the DmhinhthuckyluatDataSourceDesigner class.
	/// </summary>
	internal class DmhinhthuckyluatDataSourceActionList : DesignerActionList
	{
		private DmhinhthuckyluatDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckyluatDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DmhinhthuckyluatDataSourceActionList(DmhinhthuckyluatDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmhinhthuckyluatSelectMethod SelectMethod
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

	#endregion DmhinhthuckyluatDataSourceActionList
	
	#endregion DmhinhthuckyluatDataSourceDesigner
	
	#region DmhinhthuckyluatSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DmhinhthuckyluatDataSource.SelectMethod property.
	/// </summary>
	public enum DmhinhthuckyluatSelectMethod
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
		/// Represents the GetByIdHinhthucKyluat method.
		/// </summary>
		GetByIdHinhthucKyluat
	}
	
	#endregion DmhinhthuckyluatSelectMethod

	#region DmhinhthuckyluatFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmhinhthuckyluat"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmhinhthuckyluatFilter : SqlFilter<DmhinhthuckyluatColumn>
	{
	}
	
	#endregion DmhinhthuckyluatFilter

	#region DmhinhthuckyluatExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmhinhthuckyluat"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmhinhthuckyluatExpressionBuilder : SqlExpressionBuilder<DmhinhthuckyluatColumn>
	{
	}
	
	#endregion DmhinhthuckyluatExpressionBuilder	

	#region DmhinhthuckyluatProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DmhinhthuckyluatChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Dmhinhthuckyluat"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmhinhthuckyluatProperty : ChildEntityProperty<DmhinhthuckyluatChildEntityTypes>
	{
	}
	
	#endregion DmhinhthuckyluatProperty
}

