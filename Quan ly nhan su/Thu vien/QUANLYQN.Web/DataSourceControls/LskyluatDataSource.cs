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
	/// Represents the DataRepository.LskyluatProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LskyluatDataSourceDesigner))]
	public class LskyluatDataSource : ProviderDataSource<Lskyluat, LskyluatKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LskyluatDataSource class.
		/// </summary>
		public LskyluatDataSource() : base(DataRepository.LskyluatProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LskyluatDataSourceView used by the LskyluatDataSource.
		/// </summary>
		protected LskyluatDataSourceView LskyluatView
		{
			get { return ( View as LskyluatDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LskyluatDataSource control invokes to retrieve data.
		/// </summary>
		public LskyluatSelectMethod SelectMethod
		{
			get
			{
				LskyluatSelectMethod selectMethod = LskyluatSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LskyluatSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LskyluatDataSourceView class that is to be
		/// used by the LskyluatDataSource.
		/// </summary>
		/// <returns>An instance of the LskyluatDataSourceView class.</returns>
		protected override BaseDataSourceView<Lskyluat, LskyluatKey> GetNewDataSourceView()
		{
			return new LskyluatDataSourceView(this, DefaultViewName);
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
	/// Supports the LskyluatDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LskyluatDataSourceView : ProviderDataSourceView<Lskyluat, LskyluatKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LskyluatDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LskyluatDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LskyluatDataSourceView(LskyluatDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LskyluatDataSource LskyluatOwner
		{
			get { return Owner as LskyluatDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LskyluatSelectMethod SelectMethod
		{
			get { return LskyluatOwner.SelectMethod; }
			set { LskyluatOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LskyluatProviderBase LskyluatProvider
		{
			get { return Provider as LskyluatProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Lskyluat> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Lskyluat> results = null;
			Lskyluat item;
			count = 0;
			
			System.Int64 idLichsukyluat;
			System.Int32 idQuannhan;
			System.Int32 idHinhthucKyluat;

			switch ( SelectMethod )
			{
				case LskyluatSelectMethod.Get:
					LskyluatKey entityKey  = new LskyluatKey();
					entityKey.Load(values);
					item = LskyluatProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Lskyluat>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LskyluatSelectMethod.GetAll:
                    results = LskyluatProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case LskyluatSelectMethod.GetPaged:
					results = LskyluatProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LskyluatSelectMethod.Find:
					if ( FilterParameters != null )
						results = LskyluatProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LskyluatProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LskyluatSelectMethod.GetByIdLichsukyluat:
					idLichsukyluat = ( values["IdLichsukyluat"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdLichsukyluat"], typeof(System.Int64)) : (long)0;
					item = LskyluatProvider.GetByIdLichsukyluat(GetTransactionManager(), idLichsukyluat);
					results = new TList<Lskyluat>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case LskyluatSelectMethod.GetByIdQuannhan:
					idQuannhan = ( values["IdQuannhan"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdQuannhan"], typeof(System.Int32)) : (int)0;
					results = LskyluatProvider.GetByIdQuannhan(GetTransactionManager(), idQuannhan, this.StartIndex, this.PageSize, out count);
					break;
				case LskyluatSelectMethod.GetByIdHinhthucKyluat:
					idHinhthucKyluat = ( values["IdHinhthucKyluat"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdHinhthucKyluat"], typeof(System.Int32)) : (int)0;
					results = LskyluatProvider.GetByIdHinhthucKyluat(GetTransactionManager(), idHinhthucKyluat, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == LskyluatSelectMethod.Get || SelectMethod == LskyluatSelectMethod.GetByIdLichsukyluat )
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
				Lskyluat entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					LskyluatProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Lskyluat> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			LskyluatProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LskyluatDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LskyluatDataSource class.
	/// </summary>
	public class LskyluatDataSourceDesigner : ProviderDataSourceDesigner<Lskyluat, LskyluatKey>
	{
		/// <summary>
		/// Initializes a new instance of the LskyluatDataSourceDesigner class.
		/// </summary>
		public LskyluatDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LskyluatSelectMethod SelectMethod
		{
			get { return ((LskyluatDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LskyluatDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LskyluatDataSourceActionList

	/// <summary>
	/// Supports the LskyluatDataSourceDesigner class.
	/// </summary>
	internal class LskyluatDataSourceActionList : DesignerActionList
	{
		private LskyluatDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LskyluatDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LskyluatDataSourceActionList(LskyluatDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LskyluatSelectMethod SelectMethod
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

	#endregion LskyluatDataSourceActionList
	
	#endregion LskyluatDataSourceDesigner
	
	#region LskyluatSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LskyluatDataSource.SelectMethod property.
	/// </summary>
	public enum LskyluatSelectMethod
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
		/// Represents the GetByIdLichsukyluat method.
		/// </summary>
		GetByIdLichsukyluat,
		/// <summary>
		/// Represents the GetByIdQuannhan method.
		/// </summary>
		GetByIdQuannhan,
		/// <summary>
		/// Represents the GetByIdHinhthucKyluat method.
		/// </summary>
		GetByIdHinhthucKyluat
	}
	
	#endregion LskyluatSelectMethod

	#region LskyluatFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lskyluat"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LskyluatFilter : SqlFilter<LskyluatColumn>
	{
	}
	
	#endregion LskyluatFilter

	#region LskyluatExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lskyluat"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LskyluatExpressionBuilder : SqlExpressionBuilder<LskyluatColumn>
	{
	}
	
	#endregion LskyluatExpressionBuilder	

	#region LskyluatProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LskyluatChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Lskyluat"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LskyluatProperty : ChildEntityProperty<LskyluatChildEntityTypes>
	{
	}
	
	#endregion LskyluatProperty
}

