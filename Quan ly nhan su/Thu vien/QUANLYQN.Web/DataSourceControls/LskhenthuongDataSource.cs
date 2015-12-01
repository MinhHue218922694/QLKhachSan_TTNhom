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
	/// Represents the DataRepository.LskhenthuongProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LskhenthuongDataSourceDesigner))]
	public class LskhenthuongDataSource : ProviderDataSource<Lskhenthuong, LskhenthuongKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LskhenthuongDataSource class.
		/// </summary>
		public LskhenthuongDataSource() : base(DataRepository.LskhenthuongProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LskhenthuongDataSourceView used by the LskhenthuongDataSource.
		/// </summary>
		protected LskhenthuongDataSourceView LskhenthuongView
		{
			get { return ( View as LskhenthuongDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LskhenthuongDataSource control invokes to retrieve data.
		/// </summary>
		public LskhenthuongSelectMethod SelectMethod
		{
			get
			{
				LskhenthuongSelectMethod selectMethod = LskhenthuongSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LskhenthuongSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LskhenthuongDataSourceView class that is to be
		/// used by the LskhenthuongDataSource.
		/// </summary>
		/// <returns>An instance of the LskhenthuongDataSourceView class.</returns>
		protected override BaseDataSourceView<Lskhenthuong, LskhenthuongKey> GetNewDataSourceView()
		{
			return new LskhenthuongDataSourceView(this, DefaultViewName);
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
	/// Supports the LskhenthuongDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LskhenthuongDataSourceView : ProviderDataSourceView<Lskhenthuong, LskhenthuongKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LskhenthuongDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LskhenthuongDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LskhenthuongDataSourceView(LskhenthuongDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LskhenthuongDataSource LskhenthuongOwner
		{
			get { return Owner as LskhenthuongDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LskhenthuongSelectMethod SelectMethod
		{
			get { return LskhenthuongOwner.SelectMethod; }
			set { LskhenthuongOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LskhenthuongProviderBase LskhenthuongProvider
		{
			get { return Provider as LskhenthuongProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Lskhenthuong> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Lskhenthuong> results = null;
			Lskhenthuong item;
			count = 0;
			
			System.Int64 idLichsukhenthuong;
			System.Int32 idQuannhan;
			System.Int32 idHinhthucKhenthuong;

			switch ( SelectMethod )
			{
				case LskhenthuongSelectMethod.Get:
					LskhenthuongKey entityKey  = new LskhenthuongKey();
					entityKey.Load(values);
					item = LskhenthuongProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Lskhenthuong>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LskhenthuongSelectMethod.GetAll:
                    results = LskhenthuongProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case LskhenthuongSelectMethod.GetPaged:
					results = LskhenthuongProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LskhenthuongSelectMethod.Find:
					if ( FilterParameters != null )
						results = LskhenthuongProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LskhenthuongProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LskhenthuongSelectMethod.GetByIdLichsukhenthuong:
					idLichsukhenthuong = ( values["IdLichsukhenthuong"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdLichsukhenthuong"], typeof(System.Int64)) : (long)0;
					item = LskhenthuongProvider.GetByIdLichsukhenthuong(GetTransactionManager(), idLichsukhenthuong);
					results = new TList<Lskhenthuong>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case LskhenthuongSelectMethod.GetByIdQuannhan:
					idQuannhan = ( values["IdQuannhan"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdQuannhan"], typeof(System.Int32)) : (int)0;
					results = LskhenthuongProvider.GetByIdQuannhan(GetTransactionManager(), idQuannhan, this.StartIndex, this.PageSize, out count);
					break;
				case LskhenthuongSelectMethod.GetByIdHinhthucKhenthuong:
					idHinhthucKhenthuong = ( values["IdHinhthucKhenthuong"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdHinhthucKhenthuong"], typeof(System.Int32)) : (int)0;
					results = LskhenthuongProvider.GetByIdHinhthucKhenthuong(GetTransactionManager(), idHinhthucKhenthuong, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == LskhenthuongSelectMethod.Get || SelectMethod == LskhenthuongSelectMethod.GetByIdLichsukhenthuong )
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
				Lskhenthuong entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					LskhenthuongProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Lskhenthuong> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			LskhenthuongProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LskhenthuongDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LskhenthuongDataSource class.
	/// </summary>
	public class LskhenthuongDataSourceDesigner : ProviderDataSourceDesigner<Lskhenthuong, LskhenthuongKey>
	{
		/// <summary>
		/// Initializes a new instance of the LskhenthuongDataSourceDesigner class.
		/// </summary>
		public LskhenthuongDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LskhenthuongSelectMethod SelectMethod
		{
			get { return ((LskhenthuongDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LskhenthuongDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LskhenthuongDataSourceActionList

	/// <summary>
	/// Supports the LskhenthuongDataSourceDesigner class.
	/// </summary>
	internal class LskhenthuongDataSourceActionList : DesignerActionList
	{
		private LskhenthuongDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LskhenthuongDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LskhenthuongDataSourceActionList(LskhenthuongDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LskhenthuongSelectMethod SelectMethod
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

	#endregion LskhenthuongDataSourceActionList
	
	#endregion LskhenthuongDataSourceDesigner
	
	#region LskhenthuongSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LskhenthuongDataSource.SelectMethod property.
	/// </summary>
	public enum LskhenthuongSelectMethod
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
		/// Represents the GetByIdLichsukhenthuong method.
		/// </summary>
		GetByIdLichsukhenthuong,
		/// <summary>
		/// Represents the GetByIdQuannhan method.
		/// </summary>
		GetByIdQuannhan,
		/// <summary>
		/// Represents the GetByIdHinhthucKhenthuong method.
		/// </summary>
		GetByIdHinhthucKhenthuong
	}
	
	#endregion LskhenthuongSelectMethod

	#region LskhenthuongFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lskhenthuong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LskhenthuongFilter : SqlFilter<LskhenthuongColumn>
	{
	}
	
	#endregion LskhenthuongFilter

	#region LskhenthuongExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lskhenthuong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LskhenthuongExpressionBuilder : SqlExpressionBuilder<LskhenthuongColumn>
	{
	}
	
	#endregion LskhenthuongExpressionBuilder	

	#region LskhenthuongProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LskhenthuongChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Lskhenthuong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LskhenthuongProperty : ChildEntityProperty<LskhenthuongChildEntityTypes>
	{
	}
	
	#endregion LskhenthuongProperty
}

