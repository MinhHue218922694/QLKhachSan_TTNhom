
#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using QUANLYQN.Entities;
using QUANLYQN.Data;
using QUANLYQN.Data.Bases;

#endregion

namespace QUANLYQN.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : QUANLYQN.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <c cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "DmlopProvider"
			
		private SqlDmlopProvider innerSqlDmlopProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Dmlop"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DmlopProviderBase DmlopProvider
		{
			get
			{
				if (innerSqlDmlopProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDmlopProvider == null)
						{
							this.innerSqlDmlopProvider = new SqlDmlopProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDmlopProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDmlopProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDmlopProvider SqlDmlopProvider
		{
			get {return DmlopProvider as SqlDmlopProvider;}
		}
		
		#endregion
		
		
		#region "AdminGroupmenusProvider"
			
		private SqlAdminGroupmenusProvider innerSqlAdminGroupmenusProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AdminGroupmenus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdminGroupmenusProviderBase AdminGroupmenusProvider
		{
			get
			{
				if (innerSqlAdminGroupmenusProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdminGroupmenusProvider == null)
						{
							this.innerSqlAdminGroupmenusProvider = new SqlAdminGroupmenusProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdminGroupmenusProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdminGroupmenusProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdminGroupmenusProvider SqlAdminGroupmenusProvider
		{
			get {return AdminGroupmenusProvider as SqlAdminGroupmenusProvider;}
		}
		
		#endregion
		
		
		#region "DmloaiquannhanProvider"
			
		private SqlDmloaiquannhanProvider innerSqlDmloaiquannhanProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Dmloaiquannhan"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DmloaiquannhanProviderBase DmloaiquannhanProvider
		{
			get
			{
				if (innerSqlDmloaiquannhanProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDmloaiquannhanProvider == null)
						{
							this.innerSqlDmloaiquannhanProvider = new SqlDmloaiquannhanProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDmloaiquannhanProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDmloaiquannhanProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDmloaiquannhanProvider SqlDmloaiquannhanProvider
		{
			get {return DmloaiquannhanProvider as SqlDmloaiquannhanProvider;}
		}
		
		#endregion
		
		
		#region "DmtongiaoProvider"
			
		private SqlDmtongiaoProvider innerSqlDmtongiaoProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Dmtongiao"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DmtongiaoProviderBase DmtongiaoProvider
		{
			get
			{
				if (innerSqlDmtongiaoProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDmtongiaoProvider == null)
						{
							this.innerSqlDmtongiaoProvider = new SqlDmtongiaoProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDmtongiaoProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDmtongiaoProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDmtongiaoProvider SqlDmtongiaoProvider
		{
			get {return DmtongiaoProvider as SqlDmtongiaoProvider;}
		}
		
		#endregion
		
		
		#region "DmhinhthuckyluatProvider"
			
		private SqlDmhinhthuckyluatProvider innerSqlDmhinhthuckyluatProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Dmhinhthuckyluat"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DmhinhthuckyluatProviderBase DmhinhthuckyluatProvider
		{
			get
			{
				if (innerSqlDmhinhthuckyluatProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDmhinhthuckyluatProvider == null)
						{
							this.innerSqlDmhinhthuckyluatProvider = new SqlDmhinhthuckyluatProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDmhinhthuckyluatProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDmhinhthuckyluatProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDmhinhthuckyluatProvider SqlDmhinhthuckyluatProvider
		{
			get {return DmhinhthuckyluatProvider as SqlDmhinhthuckyluatProvider;}
		}
		
		#endregion
		
		
		#region "DmtruongProvider"
			
		private SqlDmtruongProvider innerSqlDmtruongProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Dmtruong"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DmtruongProviderBase DmtruongProvider
		{
			get
			{
				if (innerSqlDmtruongProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDmtruongProvider == null)
						{
							this.innerSqlDmtruongProvider = new SqlDmtruongProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDmtruongProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDmtruongProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDmtruongProvider SqlDmtruongProvider
		{
			get {return DmtruongProvider as SqlDmtruongProvider;}
		}
		
		#endregion
		
		
		#region "LstruonglopProvider"
			
		private SqlLstruonglopProvider innerSqlLstruonglopProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Lstruonglop"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LstruonglopProviderBase LstruonglopProvider
		{
			get
			{
				if (innerSqlLstruonglopProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLstruonglopProvider == null)
						{
							this.innerSqlLstruonglopProvider = new SqlLstruonglopProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLstruonglopProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLstruonglopProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLstruonglopProvider SqlLstruonglopProvider
		{
			get {return LstruonglopProvider as SqlLstruonglopProvider;}
		}
		
		#endregion
		
		
		#region "LscapbacProvider"
			
		private SqlLscapbacProvider innerSqlLscapbacProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Lscapbac"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LscapbacProviderBase LscapbacProvider
		{
			get
			{
				if (innerSqlLscapbacProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLscapbacProvider == null)
						{
							this.innerSqlLscapbacProvider = new SqlLscapbacProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLscapbacProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLscapbacProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLscapbacProvider SqlLscapbacProvider
		{
			get {return LscapbacProvider as SqlLscapbacProvider;}
		}
		
		#endregion
		
		
		#region "LskyluatProvider"
			
		private SqlLskyluatProvider innerSqlLskyluatProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Lskyluat"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LskyluatProviderBase LskyluatProvider
		{
			get
			{
				if (innerSqlLskyluatProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLskyluatProvider == null)
						{
							this.innerSqlLskyluatProvider = new SqlLskyluatProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLskyluatProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLskyluatProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLskyluatProvider SqlLskyluatProvider
		{
			get {return LskyluatProvider as SqlLskyluatProvider;}
		}
		
		#endregion
		
		
		#region "DmhinhthuckhenthuongProvider"
			
		private SqlDmhinhthuckhenthuongProvider innerSqlDmhinhthuckhenthuongProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Dmhinhthuckhenthuong"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DmhinhthuckhenthuongProviderBase DmhinhthuckhenthuongProvider
		{
			get
			{
				if (innerSqlDmhinhthuckhenthuongProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDmhinhthuckhenthuongProvider == null)
						{
							this.innerSqlDmhinhthuckhenthuongProvider = new SqlDmhinhthuckhenthuongProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDmhinhthuckhenthuongProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDmhinhthuckhenthuongProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDmhinhthuckhenthuongProvider SqlDmhinhthuckhenthuongProvider
		{
			get {return DmhinhthuckhenthuongProvider as SqlDmhinhthuckhenthuongProvider;}
		}
		
		#endregion
		
		
		#region "LschucvuProvider"
			
		private SqlLschucvuProvider innerSqlLschucvuProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Lschucvu"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LschucvuProviderBase LschucvuProvider
		{
			get
			{
				if (innerSqlLschucvuProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLschucvuProvider == null)
						{
							this.innerSqlLschucvuProvider = new SqlLschucvuProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLschucvuProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLschucvuProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLschucvuProvider SqlLschucvuProvider
		{
			get {return LschucvuProvider as SqlLschucvuProvider;}
		}
		
		#endregion
		
		
		#region "AdminUsersProvider"
			
		private SqlAdminUsersProvider innerSqlAdminUsersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AdminUsers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdminUsersProviderBase AdminUsersProvider
		{
			get
			{
				if (innerSqlAdminUsersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdminUsersProvider == null)
						{
							this.innerSqlAdminUsersProvider = new SqlAdminUsersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdminUsersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdminUsersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdminUsersProvider SqlAdminUsersProvider
		{
			get {return AdminUsersProvider as SqlAdminUsersProvider;}
		}
		
		#endregion
		
		
		#region "AdminGroupsProvider"
			
		private SqlAdminGroupsProvider innerSqlAdminGroupsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AdminGroups"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdminGroupsProviderBase AdminGroupsProvider
		{
			get
			{
				if (innerSqlAdminGroupsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdminGroupsProvider == null)
						{
							this.innerSqlAdminGroupsProvider = new SqlAdminGroupsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdminGroupsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdminGroupsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdminGroupsProvider SqlAdminGroupsProvider
		{
			get {return AdminGroupsProvider as SqlAdminGroupsProvider;}
		}
		
		#endregion
		
		
		#region "AdminMenusProvider"
			
		private SqlAdminMenusProvider innerSqlAdminMenusProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AdminMenus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdminMenusProviderBase AdminMenusProvider
		{
			get
			{
				if (innerSqlAdminMenusProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdminMenusProvider == null)
						{
							this.innerSqlAdminMenusProvider = new SqlAdminMenusProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdminMenusProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdminMenusProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdminMenusProvider SqlAdminMenusProvider
		{
			get {return AdminMenusProvider as SqlAdminMenusProvider;}
		}
		
		#endregion
		
		
		#region "DmgioitinhProvider"
			
		private SqlDmgioitinhProvider innerSqlDmgioitinhProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Dmgioitinh"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DmgioitinhProviderBase DmgioitinhProvider
		{
			get
			{
				if (innerSqlDmgioitinhProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDmgioitinhProvider == null)
						{
							this.innerSqlDmgioitinhProvider = new SqlDmgioitinhProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDmgioitinhProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDmgioitinhProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDmgioitinhProvider SqlDmgioitinhProvider
		{
			get {return DmgioitinhProvider as SqlDmgioitinhProvider;}
		}
		
		#endregion
		
		
		#region "AdminGroupusersProvider"
			
		private SqlAdminGroupusersProvider innerSqlAdminGroupusersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AdminGroupusers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdminGroupusersProviderBase AdminGroupusersProvider
		{
			get
			{
				if (innerSqlAdminGroupusersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdminGroupusersProvider == null)
						{
							this.innerSqlAdminGroupusersProvider = new SqlAdminGroupusersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdminGroupusersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdminGroupusersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdminGroupusersProvider SqlAdminGroupusersProvider
		{
			get {return AdminGroupusersProvider as SqlAdminGroupusersProvider;}
		}
		
		#endregion
		
		
		#region "DmcaphocProvider"
			
		private SqlDmcaphocProvider innerSqlDmcaphocProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Dmcaphoc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DmcaphocProviderBase DmcaphocProvider
		{
			get
			{
				if (innerSqlDmcaphocProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDmcaphocProvider == null)
						{
							this.innerSqlDmcaphocProvider = new SqlDmcaphocProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDmcaphocProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDmcaphocProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDmcaphocProvider SqlDmcaphocProvider
		{
			get {return DmcaphocProvider as SqlDmcaphocProvider;}
		}
		
		#endregion
		
		
		#region "DmdonviProvider"
			
		private SqlDmdonviProvider innerSqlDmdonviProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Dmdonvi"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DmdonviProviderBase DmdonviProvider
		{
			get
			{
				if (innerSqlDmdonviProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDmdonviProvider == null)
						{
							this.innerSqlDmdonviProvider = new SqlDmdonviProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDmdonviProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDmdonviProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDmdonviProvider SqlDmdonviProvider
		{
			get {return DmdonviProvider as SqlDmdonviProvider;}
		}
		
		#endregion
		
		
		#region "DmdantocProvider"
			
		private SqlDmdantocProvider innerSqlDmdantocProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Dmdantoc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DmdantocProviderBase DmdantocProvider
		{
			get
			{
				if (innerSqlDmdantocProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDmdantocProvider == null)
						{
							this.innerSqlDmdantocProvider = new SqlDmdantocProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDmdantocProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDmdantocProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDmdantocProvider SqlDmdantocProvider
		{
			get {return DmdantocProvider as SqlDmdantocProvider;}
		}
		
		#endregion
		
		
		#region "DmchucvuProvider"
			
		private SqlDmchucvuProvider innerSqlDmchucvuProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Dmchucvu"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DmchucvuProviderBase DmchucvuProvider
		{
			get
			{
				if (innerSqlDmchucvuProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDmchucvuProvider == null)
						{
							this.innerSqlDmchucvuProvider = new SqlDmchucvuProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDmchucvuProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDmchucvuProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDmchucvuProvider SqlDmchucvuProvider
		{
			get {return DmchucvuProvider as SqlDmchucvuProvider;}
		}
		
		#endregion
		
		
		#region "DmcapbacProvider"
			
		private SqlDmcapbacProvider innerSqlDmcapbacProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Dmcapbac"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DmcapbacProviderBase DmcapbacProvider
		{
			get
			{
				if (innerSqlDmcapbacProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDmcapbacProvider == null)
						{
							this.innerSqlDmcapbacProvider = new SqlDmcapbacProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDmcapbacProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDmcapbacProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDmcapbacProvider SqlDmcapbacProvider
		{
			get {return DmcapbacProvider as SqlDmcapbacProvider;}
		}
		
		#endregion
		
		
		#region "QuannhanProvider"
			
		private SqlQuannhanProvider innerSqlQuannhanProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Quannhan"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override QuannhanProviderBase QuannhanProvider
		{
			get
			{
				if (innerSqlQuannhanProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlQuannhanProvider == null)
						{
							this.innerSqlQuannhanProvider = new SqlQuannhanProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlQuannhanProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlQuannhanProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlQuannhanProvider SqlQuannhanProvider
		{
			get {return QuannhanProvider as SqlQuannhanProvider;}
		}
		
		#endregion
		
		
		#region "LskhenthuongProvider"
			
		private SqlLskhenthuongProvider innerSqlLskhenthuongProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Lskhenthuong"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LskhenthuongProviderBase LskhenthuongProvider
		{
			get
			{
				if (innerSqlLskhenthuongProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLskhenthuongProvider == null)
						{
							this.innerSqlLskhenthuongProvider = new SqlLskhenthuongProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLskhenthuongProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLskhenthuongProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLskhenthuongProvider SqlLskhenthuongProvider
		{
			get {return LskhenthuongProvider as SqlLskhenthuongProvider;}
		}
		
		#endregion
		
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
