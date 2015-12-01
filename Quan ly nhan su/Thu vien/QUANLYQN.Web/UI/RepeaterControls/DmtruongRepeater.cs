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
    /// A designer class for a strongly typed repeater <c>DmtruongRepeater</c>
    /// </summary>
	public class DmtruongRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:DmtruongRepeaterDesigner"/> class.
        /// </summary>
		public DmtruongRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is DmtruongRepeater))
			{ 
				throw new ArgumentException("Component is not a DmtruongRepeater."); 
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
			DmtruongRepeater z = (DmtruongRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="DmtruongRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(DmtruongRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:DmtruongRepeater runat=\"server\"></{0}:DmtruongRepeater>")]
	public class DmtruongRepeater : Control, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:DmtruongRepeater"/> class.
        /// </summary>
		public DmtruongRepeater()
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
		[TemplateContainer(typeof(DmtruongItem))]
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
		[TemplateContainer(typeof(DmtruongItem))]
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
		[TemplateContainer(typeof(DmtruongItem))]
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
		[TemplateContainer(typeof(DmtruongItem))]
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
				QUANLYQN.Web.Data.DmtruongDataSource datasource = null;
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
				datasource = ctl as QUANLYQN.Web.Data.DmtruongDataSource;
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
					QUANLYQN.Entities.Dmtruong entity = o as QUANLYQN.Entities.Dmtruong;
					DmtruongItem container = new DmtruongItem(entity);

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
	public class DmtruongItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private QUANLYQN.Entities.Dmtruong _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DmtruongItem"/> class.
        /// </summary>
		public DmtruongItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DmtruongItem"/> class.
        /// </summary>
		public DmtruongItem(QUANLYQN.Entities.Dmtruong entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the IdTruong
        /// </summary>
        /// <value>The IdTruong.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 IdTruong
		{
			get { return _entity.IdTruong; }
		}
        /// <summary>
        /// Gets the Tentruong
        /// </summary>
        /// <value>The Tentruong.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Tentruong
		{
			get { return _entity.Tentruong; }
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
        /// Gets a <see cref="T:QUANLYQN.Entities.Dmtruong"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public QUANLYQN.Entities.Dmtruong Entity
        {
            get { return _entity; }
        }
	}
}
