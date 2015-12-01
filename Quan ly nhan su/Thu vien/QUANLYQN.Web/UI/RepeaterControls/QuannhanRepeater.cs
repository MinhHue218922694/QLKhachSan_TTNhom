using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;

namespace QUANLYQN.Web.UI
{
    /// <summary>
    /// A designer class for a strongly typed repeater <c>QuannhanRepeater</c>
    /// </summary>
	public class QuannhanRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:QuannhanRepeaterDesigner"/> class.
        /// </summary>
		public QuannhanRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is QuannhanRepeater))
			{ 
				throw new ArgumentException("Component is not a QuannhanRepeater."); 
			} 
			base.Initialize(component); 
			base.SetViewFlags(ViewFlags.TemplateEditing, true); 
		}


		/// <summary>
		/// Generate HTML for the designer
		/// </summary>
		/// <returns>a string of design time HTML</returns>
		public override string GetDesignTimeHtml()
		{

			// Get the instance this designer applies to
			//
			QuannhanRepeater z = (QuannhanRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();

			//return z.RenderAtDesignTime();

			//	ControlCollection c = z.Controls;
			//Totem z = (Totem) Component;
			//Totem z = (Totem) Component;
			//return ("<div style='border: 1px gray dotted; background-color: lightgray'><b>TagStat :</b> zae |  qsdds</div>");

		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <c cref="QuannhanRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(QuannhanRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:QuannhanRepeater runat=\"server\"></{0}:QuannhanRepeater>")]
	public class QuannhanRepeater : Control, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:QuannhanRepeater"/> class.
        /// </summary>
		public QuannhanRepeater()
		{
		}

		/// <summary>
        /// Gets a <see cref="T:System.Web.UI.ControlCollection"></see> object that represents the child controls for a specified server control in the UI hierarchy.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of child controls for the specified server control.</returns>
		public override ControlCollection Controls
		{
			get
			{
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		private ITemplate m_headerTemplate;
		/// <summary>
        /// Gets or sets the header template.
        /// </summary>
        /// <value>The header template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(QuannhanItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate HeaderTemplate
		{
			get { return m_headerTemplate; }
			set { m_headerTemplate = value; }
		}

		private ITemplate m_itemTemplate;
		/// <summary>
        /// Gets or sets the item template.
        /// </summary>
        /// <value>The item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(QuannhanItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate ItemTemplate
		{
			get { return m_itemTemplate; }
			set { m_itemTemplate = value; }
		}
			

		private ITemplate m_altenateItemTemplate;
        /// <summary>
        /// Gets or sets the alternating item template.
        /// </summary>
        /// <value>The alternating item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(QuannhanItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate AlternatingItemTemplate
		{
			get { return m_altenateItemTemplate; }
			set { m_altenateItemTemplate = value; }
		}

		private ITemplate m_footerTemplate;
        /// <summary>
        /// Gets or sets the footer template.
        /// </summary>
        /// <value>The footer template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(QuannhanItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}

        /// <summary>
        /// Gets or sets the data source ID.
        /// </summary>
        /// <value>The data source ID.</value>
		[Category("Data")]
		public virtual string DataSourceID
		{
			get
			{
				if (ViewState["DataSourceID"] == null)
				{
					return string.Empty;
				}
				return (string)ViewState["DataSourceID"];
			}
			set
			{
				ViewState["DataSourceID"] = value;
			}
		}

		//[Category("Data")]
		//public virtual string DataMember
		//{
		//    get
		//    {
		//        if (ViewState["DataMember"] == null)
		//        {
		//            return string.Empty;
		//        }
		//        return (string)ViewState["DataMember"];
		//    }
		//    set
		//    {
		//        ViewState["DataMember"] = value;
		//    }
		//}

		//private ProductDataSourceView m_currentView;

		System.Collections.IEnumerable m_currentView;
        /// <summary>
        /// Connects to data source view.
        /// </summary>
        /// <returns>an IEnumerable of DataSourceView</returns>
		private System.Collections.IEnumerable ConnectToDataSourceView()
		{
			if (m_currentView == null)
			{
				QUANLYQN.Web.Data.QuannhanDataSource datasource = null;
				//First look in the naming container
            Control ctl = this.NamingContainer.FindControl(DataSourceID);
            if (ctl == null)
            {
               //if not found, look at the page level
               ctl = this.Page.FindControl(DataSourceID);
               if (ctl == null)
               {
                  throw new System.Web.HttpException("Datasource does not exists");
               }
            }
				datasource = ctl as QUANLYQN.Web.Data.QuannhanDataSource;
				if (datasource == null)
				{
					throw new System.Web.HttpException("Datasource must be data control");
				}
				
				System.Collections.IEnumerable dsv = datasource.GetEntityList(); //this.DataMember);
				if (dsv == null)
				{
					throw new System.Web.HttpException("View not found");
				}
				m_currentView = dsv;
			}
			return m_currentView;
		}

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
		protected override void CreateChildControls()
		{
			if (ChildControlsCreated)
			{
				return;
			}
			Controls.Clear();

			System.Collections.IEnumerable datas = (System.Collections.IEnumerable)ConnectToDataSourceView();

			if (datas != null)
			{
				if (m_headerTemplate != null)
				{
					Control headerItem = new Control();
					m_headerTemplate.InstantiateIn(headerItem);
					Controls.Add(headerItem);
				}

				int pos = 0;
				foreach (object o in datas)
				{
					QUANLYQN.Entities.Quannhan entity = o as QUANLYQN.Entities.Quannhan;
					QuannhanItem container = new QuannhanItem(entity);

					if (m_itemTemplate != null && (pos % 2) == 0)
					{
						m_itemTemplate.InstantiateIn(container);
					}
					else
					{
						if (m_altenateItemTemplate != null)
						{
							m_altenateItemTemplate.InstantiateIn(container);
						}
						else if (m_itemTemplate != null)
						{
							m_itemTemplate.InstantiateIn(container);
						}
						else
						{
							// no template !!!
						}
					}
					Controls.Add(container);
					pos++;
				}

				if (m_footerTemplate != null)
				{
					Control footerItem = new Control();
					m_footerTemplate.InstantiateIn(footerItem);
					Controls.Add(footerItem);
				}
				ChildControlsCreated = true;
			}
		}

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.DataBind();
		}

		#region Design time
        /// <summary>
        /// Renders at design time.
        /// </summary>
        /// <returns>a  string of the Designed HTML</returns>
		internal string RenderAtDesignTime()
		{			
			return "Designer currently not implemented"; 
		}

		#endregion
	}

    /// <summary>
    /// A wrapper type for the entity
    /// </summary>
	[System.ComponentModel.ToolboxItem(false)]
	public class QuannhanItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private QUANLYQN.Entities.Quannhan _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuannhanItem"/> class.
        /// </summary>
		public QuannhanItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuannhanItem"/> class.
        /// </summary>
		public QuannhanItem(QUANLYQN.Entities.Quannhan entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the IdQuannhan
        /// </summary>
        /// <value>The IdQuannhan.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 IdQuannhan
		{
			get { return _entity.IdQuannhan; }
		}
        /// <summary>
        /// Gets the MaQuannhan
        /// </summary>
        /// <value>The MaQuannhan.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MaQuannhan
		{
			get { return _entity.MaQuannhan; }
		}
        /// <summary>
        /// Gets the HotenKhaisinh
        /// </summary>
        /// <value>The HotenKhaisinh.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String HotenKhaisinh
		{
			get { return _entity.HotenKhaisinh; }
		}
        /// <summary>
        /// Gets the HotenThuongdung
        /// </summary>
        /// <value>The HotenThuongdung.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String HotenThuongdung
		{
			get { return _entity.HotenThuongdung; }
		}
        /// <summary>
        /// Gets the SotheQuannhan
        /// </summary>
        /// <value>The SotheQuannhan.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 SotheQuannhan
		{
			get { return _entity.SotheQuannhan; }
		}
        /// <summary>
        /// Gets the CmtQuannhan
        /// </summary>
        /// <value>The CmtQuannhan.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 CmtQuannhan
		{
			get { return _entity.CmtQuannhan; }
		}
        /// <summary>
        /// Gets the AnhQuannhan
        /// </summary>
        /// <value>The AnhQuannhan.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Byte[] AnhQuannhan
		{
			get { return _entity.AnhQuannhan; }
		}
        /// <summary>
        /// Gets the Ngaysinh
        /// </summary>
        /// <value>The Ngaysinh.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime Ngaysinh
		{
			get { return _entity.Ngaysinh; }
		}
        /// <summary>
        /// Gets the Nguyenquan
        /// </summary>
        /// <value>The Nguyenquan.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Nguyenquan
		{
			get { return _entity.Nguyenquan; }
		}
        /// <summary>
        /// Gets the Sinhquan
        /// </summary>
        /// <value>The Sinhquan.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Sinhquan
		{
			get { return _entity.Sinhquan; }
		}
        /// <summary>
        /// Gets the Truquan
        /// </summary>
        /// <value>The Truquan.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Truquan
		{
			get { return _entity.Truquan; }
		}
        /// <summary>
        /// Gets the DcBaotin
        /// </summary>
        /// <value>The DcBaotin.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DcBaotin
		{
			get { return _entity.DcBaotin; }
		}
        /// <summary>
        /// Gets the HotenCha
        /// </summary>
        /// <value>The HotenCha.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String HotenCha
		{
			get { return _entity.HotenCha; }
		}
        /// <summary>
        /// Gets the HotenMe
        /// </summary>
        /// <value>The HotenMe.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String HotenMe
		{
			get { return _entity.HotenMe; }
		}
        /// <summary>
        /// Gets the SafeNameHotenVoChong
        /// </summary>
        /// <value>The SafeNameHotenVoChong.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SafeNameHotenVoChong
		{
			get { return _entity.SafeNameHotenVoChong; }
		}
        /// <summary>
        /// Gets the SoAnhchiem
        /// </summary>
        /// <value>The SoAnhchiem.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 SoAnhchiem
		{
			get { return _entity.SoAnhchiem; }
		}
        /// <summary>
        /// Gets the Socon
        /// </summary>
        /// <value>The Socon.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 Socon
		{
			get { return _entity.Socon; }
		}
        /// <summary>
        /// Gets the IdCapbac
        /// </summary>
        /// <value>The IdCapbac.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 IdCapbac
		{
			get { return _entity.IdCapbac; }
		}
        /// <summary>
        /// Gets the IdChucvu
        /// </summary>
        /// <value>The IdChucvu.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 IdChucvu
		{
			get { return _entity.IdChucvu; }
		}
        /// <summary>
        /// Gets the Cnqs
        /// </summary>
        /// <value>The Cnqs.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Cnqs
		{
			get { return _entity.Cnqs; }
		}
        /// <summary>
        /// Gets the Backythuat
        /// </summary>
        /// <value>The Backythuat.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Backythuat
		{
			get { return _entity.Backythuat; }
		}
        /// <summary>
        /// Gets the TrinhdoVanhoa
        /// </summary>
        /// <value>The TrinhdoVanhoa.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TrinhdoVanhoa
		{
			get { return _entity.TrinhdoVanhoa; }
		}
        /// <summary>
        /// Gets the Suckhoe
        /// </summary>
        /// <value>The Suckhoe.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Suckhoe
		{
			get { return _entity.Suckhoe; }
		}
        /// <summary>
        /// Gets the Ngoaingu
        /// </summary>
        /// <value>The Ngoaingu.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Ngoaingu
		{
			get { return _entity.Ngoaingu; }
		}
        /// <summary>
        /// Gets the HangThuongtat
        /// </summary>
        /// <value>The HangThuongtat.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String HangThuongtat
		{
			get { return _entity.HangThuongtat; }
		}
        /// <summary>
        /// Gets the TpGiadinh
        /// </summary>
        /// <value>The TpGiadinh.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TpGiadinh
		{
			get { return _entity.TpGiadinh; }
		}
        /// <summary>
        /// Gets the TpBanthan
        /// </summary>
        /// <value>The TpBanthan.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TpBanthan
		{
			get { return _entity.TpBanthan; }
		}
        /// <summary>
        /// Gets the IdDantoc
        /// </summary>
        /// <value>The IdDantoc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 IdDantoc
		{
			get { return _entity.IdDantoc; }
		}
        /// <summary>
        /// Gets the IdTongiao
        /// </summary>
        /// <value>The IdTongiao.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 IdTongiao
		{
			get { return _entity.IdTongiao; }
		}
        /// <summary>
        /// Gets the IdGioitinh
        /// </summary>
        /// <value>The IdGioitinh.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 IdGioitinh
		{
			get { return _entity.IdGioitinh; }
		}
        /// <summary>
        /// Gets the NgayNhapngu
        /// </summary>
        /// <value>The NgayNhapngu.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime NgayNhapngu
		{
			get { return _entity.NgayNhapngu; }
		}
        /// <summary>
        /// Gets the NgayXuatngu
        /// </summary>
        /// <value>The NgayXuatngu.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? NgayXuatngu
		{
			get { return _entity.NgayXuatngu; }
		}
        /// <summary>
        /// Gets the NgayTaingu
        /// </summary>
        /// <value>The NgayTaingu.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? NgayTaingu
		{
			get { return _entity.NgayTaingu; }
		}
        /// <summary>
        /// Gets the NgayVaodoan
        /// </summary>
        /// <value>The NgayVaodoan.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? NgayVaodoan
		{
			get { return _entity.NgayVaodoan; }
		}
        /// <summary>
        /// Gets the NgayVaodang
        /// </summary>
        /// <value>The NgayVaodang.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? NgayVaodang
		{
			get { return _entity.NgayVaodang; }
		}
        /// <summary>
        /// Gets the NgayvaodangChinhthuc
        /// </summary>
        /// <value>The NgayvaodangChinhthuc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? NgayvaodangChinhthuc
		{
			get { return _entity.NgayvaodangChinhthuc; }
		}
        /// <summary>
        /// Gets the NgaycaptheQn
        /// </summary>
        /// <value>The NgaycaptheQn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? NgaycaptheQn
		{
			get { return _entity.NgaycaptheQn; }
		}
        /// <summary>
        /// Gets the NgaychuyenQncn
        /// </summary>
        /// <value>The NgaychuyenQncn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? NgaychuyenQncn
		{
			get { return _entity.NgaychuyenQncn; }
		}
        /// <summary>
        /// Gets the NgaychuyenCnv
        /// </summary>
        /// <value>The NgaychuyenCnv.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? NgaychuyenCnv
		{
			get { return _entity.NgaychuyenCnv; }
		}
        /// <summary>
        /// Gets the IdDonvi
        /// </summary>
        /// <value>The IdDonvi.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 IdDonvi
		{
			get { return _entity.IdDonvi; }
		}
        /// <summary>
        /// Gets the IdLop
        /// </summary>
        /// <value>The IdLop.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 IdLop
		{
			get { return _entity.IdLop; }
		}
        /// <summary>
        /// Gets the IdLoaiquannhan
        /// </summary>
        /// <value>The IdLoaiquannhan.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 IdLoaiquannhan
		{
			get { return _entity.IdLoaiquannhan; }
		}
        /// <summary>
        /// Gets the Trangthai
        /// </summary>
        /// <value>The Trangthai.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Trangthai
		{
			get { return _entity.Trangthai; }
		}
        /// <summary>
        /// Gets the Ghichu
        /// </summary>
        /// <value>The Ghichu.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Ghichu
		{
			get { return _entity.Ghichu; }
		}

        /// <summary>
        /// Gets a <see cref="T:QUANLYQN.Entities.Quannhan"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public QUANLYQN.Entities.Quannhan Entity
        {
            get { return _entity; }
        }
	}
}
