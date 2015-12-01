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
	/// Represents the DataRepository.QuannhanProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(QuannhanDataSourceDesigner))]
	public class QuannhanDataSource : ProviderDataSource<Quannhan, QuannhanKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuannhanDataSource class.
		/// </summary>
		public QuannhanDataSource() : base(DataRepository.QuannhanProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the QuannhanDataSourceView used by the QuannhanDataSource.
		/// </summary>
		protected QuannhanDataSourceView QuannhanView
		{
			get { return ( View as QuannhanDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the QuannhanDataSource control invokes to retrieve data.
		/// </summary>
		public QuannhanSelectMethod SelectMethod
		{
			get
			{
				QuannhanSelectMethod selectMethod = QuannhanSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (QuannhanSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the QuannhanDataSourceView class that is to be
		/// used by the QuannhanDataSource.
		/// </summary>
		/// <returns>An instance of the QuannhanDataSourceView class.</returns>
		protected override BaseDataSourceView<Quannhan, QuannhanKey> GetNewDataSourceView()
		{
			return new QuannhanDataSourceView(this, DefaultViewName);
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
	/// Supports the QuannhanDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class QuannhanDataSourceView : ProviderDataSourceView<Quannhan, QuannhanKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuannhanDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the QuannhanDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public QuannhanDataSourceView(QuannhanDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal QuannhanDataSource QuannhanOwner
		{
			get { return Owner as QuannhanDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal QuannhanSelectMethod SelectMethod
		{
			get { return QuannhanOwner.SelectMethod; }
			set { QuannhanOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal QuannhanProviderBase QuannhanProvider
		{
			get { return Provider as QuannhanProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Quannhan> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Quannhan> results = null;
			Quannhan item;
			count = 0;
			
			System.Int32 idQuannhan;
			System.Int32 idGioitinh;
			System.Int32 idLoaiquannhan;
			System.Int32 idDantoc;
			System.Int32 idTongiao;
			System.Int32 idDonvi;
			System.Int32 idCapbac;
			System.Int32 idChucvu;
			System.Int32 idLop;

			switch ( SelectMethod )
			{
				case QuannhanSelectMethod.Get:
					QuannhanKey entityKey  = new QuannhanKey();
					entityKey.Load(values);
					item = QuannhanProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Quannhan>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case QuannhanSelectMethod.GetAll:
                    results = QuannhanProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case QuannhanSelectMethod.GetPaged:
					results = QuannhanProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case QuannhanSelectMethod.Find:
					if ( FilterParameters != null )
						results = QuannhanProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = QuannhanProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case QuannhanSelectMethod.GetByIdQuannhan:
					idQuannhan = ( values["IdQuannhan"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdQuannhan"], typeof(System.Int32)) : (int)0;
					item = QuannhanProvider.GetByIdQuannhan(GetTransactionManager(), idQuannhan);
					results = new TList<Quannhan>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case QuannhanSelectMethod.GetByIdGioitinh:
					idGioitinh = ( values["IdGioitinh"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdGioitinh"], typeof(System.Int32)) : (int)0;
					results = QuannhanProvider.GetByIdGioitinh(GetTransactionManager(), idGioitinh, this.StartIndex, this.PageSize, out count);
					break;
				case QuannhanSelectMethod.GetByIdLoaiquannhan:
					idLoaiquannhan = ( values["IdLoaiquannhan"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdLoaiquannhan"], typeof(System.Int32)) : (int)0;
					results = QuannhanProvider.GetByIdLoaiquannhan(GetTransactionManager(), idLoaiquannhan, this.StartIndex, this.PageSize, out count);
					break;
				case QuannhanSelectMethod.GetByIdDantoc:
					idDantoc = ( values["IdDantoc"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdDantoc"], typeof(System.Int32)) : (int)0;
					results = QuannhanProvider.GetByIdDantoc(GetTransactionManager(), idDantoc, this.StartIndex, this.PageSize, out count);
					break;
				case QuannhanSelectMethod.GetByIdTongiao:
					idTongiao = ( values["IdTongiao"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdTongiao"], typeof(System.Int32)) : (int)0;
					results = QuannhanProvider.GetByIdTongiao(GetTransactionManager(), idTongiao, this.StartIndex, this.PageSize, out count);
					break;
				case QuannhanSelectMethod.GetByIdDonvi:
					idDonvi = ( values["IdDonvi"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdDonvi"], typeof(System.Int32)) : (int)0;
					results = QuannhanProvider.GetByIdDonvi(GetTransactionManager(), idDonvi, this.StartIndex, this.PageSize, out count);
					break;
				case QuannhanSelectMethod.GetByIdCapbac:
					idCapbac = ( values["IdCapbac"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdCapbac"], typeof(System.Int32)) : (int)0;
					results = QuannhanProvider.GetByIdCapbac(GetTransactionManager(), idCapbac, this.StartIndex, this.PageSize, out count);
					break;
				case QuannhanSelectMethod.GetByIdChucvu:
					idChucvu = ( values["IdChucvu"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdChucvu"], typeof(System.Int32)) : (int)0;
					results = QuannhanProvider.GetByIdChucvu(GetTransactionManager(), idChucvu, this.StartIndex, this.PageSize, out count);
					break;
				case QuannhanSelectMethod.GetByIdLop:
					idLop = ( values["IdLop"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdLop"], typeof(System.Int32)) : (int)0;
					results = QuannhanProvider.GetByIdLop(GetTransactionManager(), idLop, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == QuannhanSelectMethod.Get || SelectMethod == QuannhanSelectMethod.GetByIdQuannhan )
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
				Quannhan entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					QuannhanProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Quannhan> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			QuannhanProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region QuannhanDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the QuannhanDataSource class.
	/// </summary>
	public class QuannhanDataSourceDesigner : ProviderDataSourceDesigner<Quannhan, QuannhanKey>
	{
		/// <summary>
		/// Initializes a new instance of the QuannhanDataSourceDesigner class.
		/// </summary>
		public QuannhanDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public QuannhanSelectMethod SelectMethod
		{
			get { return ((QuannhanDataSource) DataSource).SelectMethod; }
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
				actions.Add(new QuannhanDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region QuannhanDataSourceActionList

	/// <summary>
	/// Supports the QuannhanDataSourceDesigner class.
	/// </summary>
	internal class QuannhanDataSourceActionList : DesignerActionList
	{
		private QuannhanDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the QuannhanDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public QuannhanDataSourceActionList(QuannhanDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public QuannhanSelectMethod SelectMethod
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

	#endregion QuannhanDataSourceActionList
	
	#endregion QuannhanDataSourceDesigner
	
	#region QuannhanSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the QuannhanDataSource.SelectMethod property.
	/// </summary>
	public enum QuannhanSelectMethod
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
		/// Represents the GetByIdQuannhan method.
		/// </summary>
		GetByIdQuannhan,
		/// <summary>
		/// Represents the GetByIdGioitinh method.
		/// </summary>
		GetByIdGioitinh,
		/// <summary>
		/// Represents the GetByIdLoaiquannhan method.
		/// </summary>
		GetByIdLoaiquannhan,
		/// <summary>
		/// Represents the GetByIdDantoc method.
		/// </summary>
		GetByIdDantoc,
		/// <summary>
		/// Represents the GetByIdTongiao method.
		/// </summary>
		GetByIdTongiao,
		/// <summary>
		/// Represents the GetByIdDonvi method.
		/// </summary>
		GetByIdDonvi,
		/// <summary>
		/// Represents the GetByIdCapbac method.
		/// </summary>
		GetByIdCapbac,
		/// <summary>
		/// Represents the GetByIdChucvu method.
		/// </summary>
		GetByIdChucvu,
		/// <summary>
		/// Represents the GetByIdLop method.
		/// </summary>
		GetByIdLop
	}
	
	#endregion QuannhanSelectMethod

	#region QuannhanFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Quannhan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuannhanFilter : SqlFilter<QuannhanColumn>
	{
	}
	
	#endregion QuannhanFilter

	#region QuannhanExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Quannhan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuannhanExpressionBuilder : SqlExpressionBuilder<QuannhanColumn>
	{
	}
	
	#endregion QuannhanExpressionBuilder	

	#region QuannhanProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;QuannhanChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Quannhan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuannhanProperty : ChildEntityProperty<QuannhanChildEntityTypes>
	{
	}
	
	#endregion QuannhanProperty
}

