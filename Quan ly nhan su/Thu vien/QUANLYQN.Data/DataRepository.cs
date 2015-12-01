#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using QUANLYQN.Entities;
using QUANLYQN.Data;
using QUANLYQN.Data.Bases;

#endregion

namespace QUANLYQN.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
		private static volatile Configuration _config = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("QUANLYQN.Data") as NetTiersServiceSection;
				}

				#region Design-Time Support

				if ( _section == null )
				{
					// lastly, try to find the specific NetTiersServiceSection for this assembly
					foreach ( ConfigurationSection temp in Configuration.Sections )
					{
						if ( temp is NetTiersServiceSection )
						{
							_section = temp as NetTiersServiceSection;
							break;
						}
					}
				}

				#endregion Design-Time Support
				
				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#region Design-Time Support

		/// <summary>
		/// Gets a reference to the application configuration object.
		/// </summary>
		public static Configuration Configuration
		{
			get
			{
				if ( _config == null )
				{
					// load specific config file
					if ( HttpContext.Current != null )
					{
						_config = WebConfigurationManager.OpenWebConfiguration("~");
					}
					else
					{
						String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(".config", "").Replace(".temp", "");

						// check for design mode
						if ( configFile.ToLower().Contains("devenv.exe") )
						{
							_config = GetDesignTimeConfig();
						}
						else
						{
							_config = ConfigurationManager.OpenExeConfiguration(configFile);
						}
					}
				}

				return _config;
			}
		}

		private static Configuration GetDesignTimeConfig()
		{
			ExeConfigurationFileMap configMap = null;
			Configuration config = null;
			String path = null;

			// Get an instance of the currently running Visual Studio IDE.
			EnvDTE80.DTE2 dte = (EnvDTE80.DTE2) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.8.0");
			if ( dte != null )
			{
				dte.SuppressUI = true;

				EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
				if ( item != null )
				{
					if (!item.ContainingProject.FullName.ToLower().StartsWith("http:"))
               {
                  System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);
                  path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = path;
               }
               else
               {
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = item.get_FileNames(0);
               }}

				/*
				Array projects = (Array) dte2.ActiveSolutionProjects;
				EnvDTE.Project project = (EnvDTE.Project) projects.GetValue(0);
				System.IO.FileInfo info;

				foreach ( EnvDTE.ProjectItem item in project.ProjectItems )
				{
					if ( String.Compare(item.Name, "web.config", true) == 0 )
					{
						info = new System.IO.FileInfo(project.FullName);
						path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
						configMap = new ExeConfigurationFileMap();
						configMap.ExeConfigFilename = path;
						break;
					}
				}
				*/
			}

			config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			return config;
		}

		#endregion Design-Time Support

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
				// use default ConnectionStrings if _section has already been discovered
				if ( _config == null && _section != null )
				{
					return WebConfigurationManager.ConnectionStrings;
				}
				
				return Configuration.ConnectionStrings.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;

			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			public ConnectionProvider(String connectionStringName)
			{
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region DmlopProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Dmlop"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DmlopProviderBase DmlopProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DmlopProvider;
			}
		}
		
		#endregion
		
		#region AdminGroupmenusProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AdminGroupmenus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdminGroupmenusProviderBase AdminGroupmenusProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdminGroupmenusProvider;
			}
		}
		
		#endregion
		
		#region DmloaiquannhanProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Dmloaiquannhan"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DmloaiquannhanProviderBase DmloaiquannhanProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DmloaiquannhanProvider;
			}
		}
		
		#endregion
		
		#region DmtongiaoProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Dmtongiao"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DmtongiaoProviderBase DmtongiaoProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DmtongiaoProvider;
			}
		}
		
		#endregion
		
		#region DmhinhthuckyluatProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Dmhinhthuckyluat"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DmhinhthuckyluatProviderBase DmhinhthuckyluatProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DmhinhthuckyluatProvider;
			}
		}
		
		#endregion
		
		#region DmtruongProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Dmtruong"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DmtruongProviderBase DmtruongProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DmtruongProvider;
			}
		}
		
		#endregion
		
		#region LstruonglopProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Lstruonglop"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LstruonglopProviderBase LstruonglopProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LstruonglopProvider;
			}
		}
		
		#endregion
		
		#region LscapbacProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Lscapbac"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LscapbacProviderBase LscapbacProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LscapbacProvider;
			}
		}
		
		#endregion
		
		#region LskyluatProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Lskyluat"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LskyluatProviderBase LskyluatProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LskyluatProvider;
			}
		}
		
		#endregion
		
		#region DmhinhthuckhenthuongProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Dmhinhthuckhenthuong"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DmhinhthuckhenthuongProviderBase DmhinhthuckhenthuongProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DmhinhthuckhenthuongProvider;
			}
		}
		
		#endregion
		
		#region LschucvuProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Lschucvu"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LschucvuProviderBase LschucvuProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LschucvuProvider;
			}
		}
		
		#endregion
		
		#region AdminUsersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AdminUsers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdminUsersProviderBase AdminUsersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdminUsersProvider;
			}
		}
		
		#endregion
		
		#region AdminGroupsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AdminGroups"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdminGroupsProviderBase AdminGroupsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdminGroupsProvider;
			}
		}
		
		#endregion
		
		#region AdminMenusProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AdminMenus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdminMenusProviderBase AdminMenusProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdminMenusProvider;
			}
		}
		
		#endregion
		
		#region DmgioitinhProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Dmgioitinh"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DmgioitinhProviderBase DmgioitinhProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DmgioitinhProvider;
			}
		}
		
		#endregion
		
		#region AdminGroupusersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AdminGroupusers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdminGroupusersProviderBase AdminGroupusersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdminGroupusersProvider;
			}
		}
		
		#endregion
		
		#region DmcaphocProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Dmcaphoc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DmcaphocProviderBase DmcaphocProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DmcaphocProvider;
			}
		}
		
		#endregion
		
		#region DmdonviProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Dmdonvi"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DmdonviProviderBase DmdonviProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DmdonviProvider;
			}
		}
		
		#endregion
		
		#region DmdantocProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Dmdantoc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DmdantocProviderBase DmdantocProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DmdantocProvider;
			}
		}
		
		#endregion
		
		#region DmchucvuProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Dmchucvu"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DmchucvuProviderBase DmchucvuProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DmchucvuProvider;
			}
		}
		
		#endregion
		
		#region DmcapbacProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Dmcapbac"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DmcapbacProviderBase DmcapbacProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DmcapbacProvider;
			}
		}
		
		#endregion
		
		#region QuannhanProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Quannhan"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static QuannhanProviderBase QuannhanProvider
		{
			get 
			{
				LoadProviders();
				return _provider.QuannhanProvider;
			}
		}
		
		#endregion
		
		#region LskhenthuongProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Lskhenthuong"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LskhenthuongProviderBase LskhenthuongProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LskhenthuongProvider;
			}
		}
		
		#endregion
		
		
		#endregion
	}
	
	#region Query/Filters
		
	#region DmlopFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmlop"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmlopFilters : DmlopFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmlopFilters class.
		/// </summary>
		public DmlopFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmlopFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmlopFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmlopFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmlopFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmlopFilters
	
	#region DmlopQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DmlopParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Dmlop"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmlopQuery : DmlopParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmlopQuery class.
		/// </summary>
		public DmlopQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmlopQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmlopQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmlopQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmlopQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmlopQuery
		
	#region AdminGroupmenusFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroupmenus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupmenusFilters : AdminGroupmenusFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupmenusFilters class.
		/// </summary>
		public AdminGroupmenusFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupmenusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminGroupmenusFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupmenusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminGroupmenusFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminGroupmenusFilters
	
	#region AdminGroupmenusQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdminGroupmenusParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AdminGroupmenus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupmenusQuery : AdminGroupmenusParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupmenusQuery class.
		/// </summary>
		public AdminGroupmenusQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupmenusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminGroupmenusQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupmenusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminGroupmenusQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminGroupmenusQuery
		
	#region DmloaiquannhanFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmloaiquannhan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmloaiquannhanFilters : DmloaiquannhanFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmloaiquannhanFilters class.
		/// </summary>
		public DmloaiquannhanFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmloaiquannhanFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmloaiquannhanFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmloaiquannhanFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmloaiquannhanFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmloaiquannhanFilters
	
	#region DmloaiquannhanQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DmloaiquannhanParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Dmloaiquannhan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmloaiquannhanQuery : DmloaiquannhanParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmloaiquannhanQuery class.
		/// </summary>
		public DmloaiquannhanQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmloaiquannhanQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmloaiquannhanQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmloaiquannhanQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmloaiquannhanQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmloaiquannhanQuery
		
	#region DmtongiaoFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmtongiao"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmtongiaoFilters : DmtongiaoFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmtongiaoFilters class.
		/// </summary>
		public DmtongiaoFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmtongiaoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmtongiaoFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmtongiaoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmtongiaoFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmtongiaoFilters
	
	#region DmtongiaoQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DmtongiaoParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Dmtongiao"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmtongiaoQuery : DmtongiaoParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmtongiaoQuery class.
		/// </summary>
		public DmtongiaoQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmtongiaoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmtongiaoQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmtongiaoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmtongiaoQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmtongiaoQuery
		
	#region DmhinhthuckyluatFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmhinhthuckyluat"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmhinhthuckyluatFilters : DmhinhthuckyluatFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckyluatFilters class.
		/// </summary>
		public DmhinhthuckyluatFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckyluatFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmhinhthuckyluatFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckyluatFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmhinhthuckyluatFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmhinhthuckyluatFilters
	
	#region DmhinhthuckyluatQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DmhinhthuckyluatParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Dmhinhthuckyluat"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmhinhthuckyluatQuery : DmhinhthuckyluatParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckyluatQuery class.
		/// </summary>
		public DmhinhthuckyluatQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckyluatQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmhinhthuckyluatQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckyluatQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmhinhthuckyluatQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmhinhthuckyluatQuery
		
	#region DmtruongFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmtruong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmtruongFilters : DmtruongFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmtruongFilters class.
		/// </summary>
		public DmtruongFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmtruongFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmtruongFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmtruongFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmtruongFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmtruongFilters
	
	#region DmtruongQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DmtruongParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Dmtruong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmtruongQuery : DmtruongParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmtruongQuery class.
		/// </summary>
		public DmtruongQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmtruongQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmtruongQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmtruongQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmtruongQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmtruongQuery
		
	#region LstruonglopFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lstruonglop"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LstruonglopFilters : LstruonglopFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LstruonglopFilters class.
		/// </summary>
		public LstruonglopFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LstruonglopFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LstruonglopFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LstruonglopFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LstruonglopFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LstruonglopFilters
	
	#region LstruonglopQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LstruonglopParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Lstruonglop"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LstruonglopQuery : LstruonglopParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LstruonglopQuery class.
		/// </summary>
		public LstruonglopQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LstruonglopQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LstruonglopQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LstruonglopQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LstruonglopQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LstruonglopQuery
		
	#region LscapbacFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lscapbac"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LscapbacFilters : LscapbacFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LscapbacFilters class.
		/// </summary>
		public LscapbacFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LscapbacFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LscapbacFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LscapbacFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LscapbacFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LscapbacFilters
	
	#region LscapbacQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LscapbacParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Lscapbac"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LscapbacQuery : LscapbacParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LscapbacQuery class.
		/// </summary>
		public LscapbacQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LscapbacQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LscapbacQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LscapbacQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LscapbacQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LscapbacQuery
		
	#region LskyluatFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lskyluat"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LskyluatFilters : LskyluatFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LskyluatFilters class.
		/// </summary>
		public LskyluatFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LskyluatFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LskyluatFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LskyluatFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LskyluatFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LskyluatFilters
	
	#region LskyluatQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LskyluatParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Lskyluat"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LskyluatQuery : LskyluatParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LskyluatQuery class.
		/// </summary>
		public LskyluatQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LskyluatQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LskyluatQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LskyluatQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LskyluatQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LskyluatQuery
		
	#region DmhinhthuckhenthuongFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmhinhthuckhenthuong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmhinhthuckhenthuongFilters : DmhinhthuckhenthuongFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongFilters class.
		/// </summary>
		public DmhinhthuckhenthuongFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmhinhthuckhenthuongFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmhinhthuckhenthuongFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmhinhthuckhenthuongFilters
	
	#region DmhinhthuckhenthuongQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DmhinhthuckhenthuongParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Dmhinhthuckhenthuong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmhinhthuckhenthuongQuery : DmhinhthuckhenthuongParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongQuery class.
		/// </summary>
		public DmhinhthuckhenthuongQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmhinhthuckhenthuongQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmhinhthuckhenthuongQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmhinhthuckhenthuongQuery
		
	#region LschucvuFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lschucvu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LschucvuFilters : LschucvuFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LschucvuFilters class.
		/// </summary>
		public LschucvuFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LschucvuFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LschucvuFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LschucvuFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LschucvuFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LschucvuFilters
	
	#region LschucvuQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LschucvuParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Lschucvu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LschucvuQuery : LschucvuParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LschucvuQuery class.
		/// </summary>
		public LschucvuQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LschucvuQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LschucvuQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LschucvuQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LschucvuQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LschucvuQuery
		
	#region AdminUsersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminUsersFilters : AdminUsersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminUsersFilters class.
		/// </summary>
		public AdminUsersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminUsersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminUsersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminUsersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminUsersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminUsersFilters
	
	#region AdminUsersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdminUsersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AdminUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminUsersQuery : AdminUsersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminUsersQuery class.
		/// </summary>
		public AdminUsersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminUsersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminUsersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminUsersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminUsersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminUsersQuery
		
	#region AdminGroupsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroups"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupsFilters : AdminGroupsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupsFilters class.
		/// </summary>
		public AdminGroupsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminGroupsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminGroupsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminGroupsFilters
	
	#region AdminGroupsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdminGroupsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AdminGroups"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupsQuery : AdminGroupsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupsQuery class.
		/// </summary>
		public AdminGroupsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminGroupsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminGroupsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminGroupsQuery
		
	#region AdminMenusFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminMenus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminMenusFilters : AdminMenusFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminMenusFilters class.
		/// </summary>
		public AdminMenusFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminMenusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminMenusFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminMenusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminMenusFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminMenusFilters
	
	#region AdminMenusQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdminMenusParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AdminMenus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminMenusQuery : AdminMenusParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminMenusQuery class.
		/// </summary>
		public AdminMenusQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminMenusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminMenusQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminMenusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminMenusQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminMenusQuery
		
	#region DmgioitinhFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmgioitinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmgioitinhFilters : DmgioitinhFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmgioitinhFilters class.
		/// </summary>
		public DmgioitinhFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmgioitinhFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmgioitinhFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmgioitinhFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmgioitinhFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmgioitinhFilters
	
	#region DmgioitinhQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DmgioitinhParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Dmgioitinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmgioitinhQuery : DmgioitinhParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmgioitinhQuery class.
		/// </summary>
		public DmgioitinhQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmgioitinhQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmgioitinhQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmgioitinhQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmgioitinhQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmgioitinhQuery
		
	#region AdminGroupusersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroupusers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupusersFilters : AdminGroupusersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupusersFilters class.
		/// </summary>
		public AdminGroupusersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupusersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminGroupusersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupusersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminGroupusersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminGroupusersFilters
	
	#region AdminGroupusersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdminGroupusersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AdminGroupusers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupusersQuery : AdminGroupusersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupusersQuery class.
		/// </summary>
		public AdminGroupusersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupusersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminGroupusersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupusersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminGroupusersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminGroupusersQuery
		
	#region DmcaphocFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmcaphoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmcaphocFilters : DmcaphocFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmcaphocFilters class.
		/// </summary>
		public DmcaphocFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmcaphocFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmcaphocFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmcaphocFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmcaphocFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmcaphocFilters
	
	#region DmcaphocQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DmcaphocParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Dmcaphoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmcaphocQuery : DmcaphocParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmcaphocQuery class.
		/// </summary>
		public DmcaphocQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmcaphocQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmcaphocQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmcaphocQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmcaphocQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmcaphocQuery
		
	#region DmdonviFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmdonvi"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmdonviFilters : DmdonviFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmdonviFilters class.
		/// </summary>
		public DmdonviFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmdonviFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmdonviFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmdonviFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmdonviFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmdonviFilters
	
	#region DmdonviQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DmdonviParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Dmdonvi"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmdonviQuery : DmdonviParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmdonviQuery class.
		/// </summary>
		public DmdonviQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmdonviQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmdonviQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmdonviQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmdonviQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmdonviQuery
		
	#region DmdantocFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmdantoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmdantocFilters : DmdantocFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmdantocFilters class.
		/// </summary>
		public DmdantocFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmdantocFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmdantocFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmdantocFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmdantocFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmdantocFilters
	
	#region DmdantocQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DmdantocParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Dmdantoc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmdantocQuery : DmdantocParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmdantocQuery class.
		/// </summary>
		public DmdantocQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmdantocQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmdantocQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmdantocQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmdantocQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmdantocQuery
		
	#region DmchucvuFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmchucvu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmchucvuFilters : DmchucvuFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmchucvuFilters class.
		/// </summary>
		public DmchucvuFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmchucvuFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmchucvuFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmchucvuFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmchucvuFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmchucvuFilters
	
	#region DmchucvuQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DmchucvuParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Dmchucvu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmchucvuQuery : DmchucvuParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmchucvuQuery class.
		/// </summary>
		public DmchucvuQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmchucvuQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmchucvuQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmchucvuQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmchucvuQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmchucvuQuery
		
	#region DmcapbacFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmcapbac"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmcapbacFilters : DmcapbacFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmcapbacFilters class.
		/// </summary>
		public DmcapbacFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmcapbacFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmcapbacFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmcapbacFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmcapbacFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmcapbacFilters
	
	#region DmcapbacQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DmcapbacParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Dmcapbac"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmcapbacQuery : DmcapbacParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmcapbacQuery class.
		/// </summary>
		public DmcapbacQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmcapbacQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmcapbacQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmcapbacQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmcapbacQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmcapbacQuery
		
	#region QuannhanFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Quannhan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuannhanFilters : QuannhanFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuannhanFilters class.
		/// </summary>
		public QuannhanFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuannhanFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuannhanFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuannhanFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuannhanFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuannhanFilters
	
	#region QuannhanQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="QuannhanParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Quannhan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuannhanQuery : QuannhanParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuannhanQuery class.
		/// </summary>
		public QuannhanQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuannhanQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuannhanQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuannhanQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuannhanQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuannhanQuery
		
	#region LskhenthuongFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lskhenthuong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LskhenthuongFilters : LskhenthuongFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LskhenthuongFilters class.
		/// </summary>
		public LskhenthuongFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LskhenthuongFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LskhenthuongFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LskhenthuongFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LskhenthuongFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LskhenthuongFilters
	
	#region LskhenthuongQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LskhenthuongParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Lskhenthuong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LskhenthuongQuery : LskhenthuongParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LskhenthuongQuery class.
		/// </summary>
		public LskhenthuongQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LskhenthuongQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LskhenthuongQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LskhenthuongQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LskhenthuongQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LskhenthuongQuery
	#endregion

	
}
