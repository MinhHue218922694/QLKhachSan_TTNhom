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
	/// Represents the DataRepository.DmhinhthuckhenthuongProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DmhinhthuckhenthuongDataSourceDesigner))]
	public class DmhinhthuckhenthuongDataSource : ProviderDataSource<Dmhinhthuckhenthuong, DmhinhthuckhenthuongKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongDataSource class.
		/// </summary>
		public DmhinhthuckhenthuongDataSource() : base(DataRepository.DmhinhthuckhenthuongProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DmhinhthuckhenthuongDataSourceView used by the DmhinhthuckhenthuongDataSource.
		/// </summary>
		protected DmhinhthuckhenthuongDataSourceView DmhinhthuckhenthuongView
		{
			get { return ( View as DmhinhthuckhenthuongDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DmhinhthuckhenthuongDataSource control invokes to retrieve data.
		/// </summary>
		public DmhinhthuckhenthuongSelectMethod SelectMethod
		{
			get
			{
				DmhinhthuckhenthuongSelectMethod selectMethod = DmhinhthuckhenthuongSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DmhinhthuckhenthuongSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DmhinhthuckhenthuongDataSourceView class that is to be
		/// used by the DmhinhthuckhenthuongDataSource.
		/// </summary>
		/// <returns>An instance of the DmhinhthuckhenthuongDataSourceView class.</returns>
		protected override BaseDataSourceView<Dmhinhthuckhenthuong, DmhinhthuckhenthuongKey> GetNewDataSourceView()
		{
			return new DmhinhthuckhenthuongDataSourceView(this, DefaultViewName);
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
	/// Supports the DmhinhthuckhenthuongDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DmhinhthuckhenthuongDataSourceView : ProviderDataSourceView<Dmhinhthuckhenthuong, DmhinhthuckhenthuongKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DmhinhthuckhenthuongDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DmhinhthuckhenthuongDataSourceView(DmhinhthuckhenthuongDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DmhinhthuckhenthuongDataSource DmhinhthuckhenthuongOwner
		{
			get { return Owner as DmhinhthuckhenthuongDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DmhinhthuckhenthuongSelectMethod SelectMethod
		{
			get { return DmhinhthuckhenthuongOwner.SelectMethod; }
			set { DmhinhthuckhenthuongOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DmhinhthuckhenthuongProviderBase DmhinhthuckhenthuongProvider
		{
			get { return Provider as DmhinhthuckhenthuongProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Dmhinhthuckhenthuong> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Dmhinhthuckhenthuong> results = null;
			Dmhinhthuckhenthuong item;
			count = 0;
			
			System.Int32 idHinhthucKhenthuong;

			switch ( SelectMethod )
			{
				case DmhinhthuckhenthuongSelectMethod.Get:
					DmhinhthuckhenthuongKey entityKey  = new DmhinhthuckhenthuongKey();
					entityKey.Load(values);
					item = DmhinhthuckhenthuongProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Dmhinhthuckhenthuong>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DmhinhthuckhenthuongSelectMethod.GetAll:
                    results = DmhinhthuckhenthuongProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DmhinhthuckhenthuongSelectMethod.GetPaged:
					results = DmhinhthuckhenthuongProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DmhinhthuckhenthuongSelectMethod.Find:
					if ( FilterParameters != null )
						results = DmhinhthuckhenthuongProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DmhinhthuckhenthuongProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DmhinhthuckhenthuongSelectMethod.GetByIdHinhthucKhenthuong:
					idHinhthucKhenthuong = ( values["IdHinhthucKhenthuong"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdHinhthucKhenthuong"], typeof(System.Int32)) : (int)0;
					item = DmhinhthuckhenthuongProvider.GetByIdHinhthucKhenthuong(GetTransactionManager(), idHinhthucKhenthuong);
					results = new TList<Dmhinhthuckhenthuong>();
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
			if ( SelectMethod == DmhinhthuckhenthuongSelectMethod.Get || SelectMethod == DmhinhthuckhenthuongSelectMethod.GetByIdHinhthucKhenthuong )
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
				Dmhinhthuckhenthuong entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DmhinhthuckhenthuongProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Dmhinhthuckhenthuong> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DmhinhthuckhenthuongProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DmhinhthuckhenthuongDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DmhinhthuckhenthuongDataSource class.
	/// </summary>
	public class DmhinhthuckhenthuongDataSourceDesigner : ProviderDataSourceDesigner<Dmhinhthuckhenthuong, DmhinhthuckhenthuongKey>
	{
		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongDataSourceDesigner class.
		/// </summary>
		public DmhinhthuckhenthuongDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmhinhthuckhenthuongSelectMethod SelectMethod
		{
			get { return ((DmhinhthuckhenthuongDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DmhinhthuckhenthuongDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DmhinhthuckhenthuongDataSourceActionList

	/// <summary>
	/// Supports the DmhinhthuckhenthuongDataSourceDesigner class.
	/// </summary>
	internal class DmhinhthuckhenthuongDataSourceActionList : DesignerActionList
	{
		private DmhinhthuckhenthuongDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DmhinhthuckhenthuongDataSourceActionList(DmhinhthuckhenthuongDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DmhinhthuckhenthuongSelectMethod SelectMethod
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

	#endregion DmhinhthuckhenthuongDataSourceActionList
	
	#endregion DmhinhthuckhenthuongDataSourceDesigner
	
	#region DmhinhthuckhenthuongSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DmhinhthuckhenthuongDataSource.SelectMethod property.
	/// </summary>
	public enum DmhinhthuckhenthuongSelectMethod
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
		/// Represents the GetByIdHinhthucKhenthuong method.
		/// </summary>
		GetByIdHinhthucKhenthuong
	}
	
	#endregion DmhinhthuckhenthuongSelectMethod

	#region DmhinhthuckhenthuongFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmhinhthuckhenthuong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmhinhthuckhenthuongFilter : SqlFilter<DmhinhthuckhenthuongColumn>
	{
	}
	
	#endregion DmhinhthuckhenthuongFilter

	#region DmhinhthuckhenthuongExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmhinhthuckhenthuong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmhinhthuckhenthuongExpressionBuilder : SqlExpressionBuilder<DmhinhthuckhenthuongColumn>
	{
	}
	
	#endregion DmhinhthuckhenthuongExpressionBuilder	

	#region DmhinhthuckhenthuongProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DmhinhthuckhenthuongChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Dmhinhthuckhenthuong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmhinhthuckhenthuongProperty : ChildEntityProperty<DmhinhthuckhenthuongChildEntityTypes>
	{
	}
	
	#endregion DmhinhthuckhenthuongProperty
}

