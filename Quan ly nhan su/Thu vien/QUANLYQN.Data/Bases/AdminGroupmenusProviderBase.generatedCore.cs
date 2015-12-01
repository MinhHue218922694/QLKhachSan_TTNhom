#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using QUANLYQN.Entities;
using QUANLYQN.Data;

#endregion

namespace QUANLYQN.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="AdminGroupmenusProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AdminGroupmenusProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.AdminGroupmenus, QUANLYQN.Entities.AdminGroupmenusKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.AdminGroupmenusKey key)
		{
			return Delete(transactionManager, key.IdMenu, key.IdGroup);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idMenu">. Primary Key.</param>
		/// <param name="idGroup">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String idMenu, System.String idGroup)
		{
			return Delete(null, idMenu, idGroup);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idMenu">. Primary Key.</param>
		/// <param name="idGroup">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String idMenu, System.String idGroup);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPMENUS_ADMIN_GROUPS key.
		///		FK_ADMIN_GROUPMENUS_ADMIN_GROUPS Description: 
		/// </summary>
		/// <param name="idGroup"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupmenus objects.</returns>
		public QUANLYQN.Entities.TList<AdminGroupmenus> GetByIdGroup(System.String idGroup)
		{
			int count = -1;
			return GetByIdGroup(idGroup, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPMENUS_ADMIN_GROUPS key.
		///		FK_ADMIN_GROUPMENUS_ADMIN_GROUPS Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupmenus objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<AdminGroupmenus> GetByIdGroup(TransactionManager transactionManager, System.String idGroup)
		{
			int count = -1;
			return GetByIdGroup(transactionManager, idGroup, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPMENUS_ADMIN_GROUPS key.
		///		FK_ADMIN_GROUPMENUS_ADMIN_GROUPS Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupmenus objects.</returns>
		public QUANLYQN.Entities.TList<AdminGroupmenus> GetByIdGroup(TransactionManager transactionManager, System.String idGroup, int start, int pageLength)
		{
			int count = -1;
			return GetByIdGroup(transactionManager, idGroup, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPMENUS_ADMIN_GROUPS key.
		///		fkAdminGroupmenusAdminGroups Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idGroup"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupmenus objects.</returns>
		public QUANLYQN.Entities.TList<AdminGroupmenus> GetByIdGroup(System.String idGroup, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdGroup(null, idGroup, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPMENUS_ADMIN_GROUPS key.
		///		fkAdminGroupmenusAdminGroups Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idGroup"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupmenus objects.</returns>
		public QUANLYQN.Entities.TList<AdminGroupmenus> GetByIdGroup(System.String idGroup, int start, int pageLength,out int count)
		{
			return GetByIdGroup(null, idGroup, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPMENUS_ADMIN_GROUPS key.
		///		FK_ADMIN_GROUPMENUS_ADMIN_GROUPS Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupmenus objects.</returns>
		public abstract QUANLYQN.Entities.TList<AdminGroupmenus> GetByIdGroup(TransactionManager transactionManager, System.String idGroup, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPMENUS_ADMIN_MENUS key.
		///		FK_ADMIN_GROUPMENUS_ADMIN_MENUS Description: 
		/// </summary>
		/// <param name="idMenu"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupmenus objects.</returns>
		public QUANLYQN.Entities.TList<AdminGroupmenus> GetByIdMenu(System.String idMenu)
		{
			int count = -1;
			return GetByIdMenu(idMenu, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPMENUS_ADMIN_MENUS key.
		///		FK_ADMIN_GROUPMENUS_ADMIN_MENUS Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idMenu"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupmenus objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<AdminGroupmenus> GetByIdMenu(TransactionManager transactionManager, System.String idMenu)
		{
			int count = -1;
			return GetByIdMenu(transactionManager, idMenu, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPMENUS_ADMIN_MENUS key.
		///		FK_ADMIN_GROUPMENUS_ADMIN_MENUS Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idMenu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupmenus objects.</returns>
		public QUANLYQN.Entities.TList<AdminGroupmenus> GetByIdMenu(TransactionManager transactionManager, System.String idMenu, int start, int pageLength)
		{
			int count = -1;
			return GetByIdMenu(transactionManager, idMenu, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPMENUS_ADMIN_MENUS key.
		///		fkAdminGroupmenusAdminMenus Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idMenu"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupmenus objects.</returns>
		public QUANLYQN.Entities.TList<AdminGroupmenus> GetByIdMenu(System.String idMenu, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdMenu(null, idMenu, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPMENUS_ADMIN_MENUS key.
		///		fkAdminGroupmenusAdminMenus Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idMenu"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupmenus objects.</returns>
		public QUANLYQN.Entities.TList<AdminGroupmenus> GetByIdMenu(System.String idMenu, int start, int pageLength,out int count)
		{
			return GetByIdMenu(null, idMenu, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPMENUS_ADMIN_MENUS key.
		///		FK_ADMIN_GROUPMENUS_ADMIN_MENUS Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idMenu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupmenus objects.</returns>
		public abstract QUANLYQN.Entities.TList<AdminGroupmenus> GetByIdMenu(TransactionManager transactionManager, System.String idMenu, int start, int pageLength, out int count);
		
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override QUANLYQN.Entities.AdminGroupmenus Get(TransactionManager transactionManager, QUANLYQN.Entities.AdminGroupmenusKey key, int start, int pageLength)
		{
			return GetByIdMenuIdGroup(transactionManager, key.IdMenu, key.IdGroup, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ADMIN_GROUPMENUS index.
		/// </summary>
		/// <param name="idMenu"></param>
		/// <param name="idGroup"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroupmenus"/> class.</returns>
		public QUANLYQN.Entities.AdminGroupmenus GetByIdMenuIdGroup(System.String idMenu, System.String idGroup)
		{
			int count = -1;
			return GetByIdMenuIdGroup(null,idMenu, idGroup, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_GROUPMENUS index.
		/// </summary>
		/// <param name="idMenu"></param>
		/// <param name="idGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroupmenus"/> class.</returns>
		public QUANLYQN.Entities.AdminGroupmenus GetByIdMenuIdGroup(System.String idMenu, System.String idGroup, int start, int pageLength)
		{
			int count = -1;
			return GetByIdMenuIdGroup(null, idMenu, idGroup, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_GROUPMENUS index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idMenu"></param>
		/// <param name="idGroup"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroupmenus"/> class.</returns>
		public QUANLYQN.Entities.AdminGroupmenus GetByIdMenuIdGroup(TransactionManager transactionManager, System.String idMenu, System.String idGroup)
		{
			int count = -1;
			return GetByIdMenuIdGroup(transactionManager, idMenu, idGroup, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_GROUPMENUS index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idMenu"></param>
		/// <param name="idGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroupmenus"/> class.</returns>
		public QUANLYQN.Entities.AdminGroupmenus GetByIdMenuIdGroup(TransactionManager transactionManager, System.String idMenu, System.String idGroup, int start, int pageLength)
		{
			int count = -1;
			return GetByIdMenuIdGroup(transactionManager, idMenu, idGroup, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_GROUPMENUS index.
		/// </summary>
		/// <param name="idMenu"></param>
		/// <param name="idGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroupmenus"/> class.</returns>
		public QUANLYQN.Entities.AdminGroupmenus GetByIdMenuIdGroup(System.String idMenu, System.String idGroup, int start, int pageLength, out int count)
		{
			return GetByIdMenuIdGroup(null, idMenu, idGroup, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_GROUPMENUS index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idMenu"></param>
		/// <param name="idGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroupmenus"/> class.</returns>
		public abstract QUANLYQN.Entities.AdminGroupmenus GetByIdMenuIdGroup(TransactionManager transactionManager, System.String idMenu, System.String idGroup, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;AdminGroupmenus&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;AdminGroupmenus&gt;"/></returns>
		public static QUANLYQN.Entities.TList<AdminGroupmenus> Fill(IDataReader reader, QUANLYQN.Entities.TList<AdminGroupmenus> rows, int start, int pageLength)
		{
		// advance to the starting row
		for (int i = 0; i < start; i++)
		{
			if (!reader.Read())
			return rows; // not enough rows, just return
		}
		for (int i = 0; i < pageLength; i++)
		{
			if (!reader.Read())
			break; // we are done
			string key = null;
			
			QUANLYQN.Entities.AdminGroupmenus c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("AdminGroupmenus")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.AdminGroupmenusColumn.IdMenu - 1))?string.Empty:(System.String)reader[((int)QUANLYQN.Entities.AdminGroupmenusColumn.IdMenu - 1)]).ToString())
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.AdminGroupmenusColumn.IdGroup - 1))?string.Empty:(System.String)reader[((int)QUANLYQN.Entities.AdminGroupmenusColumn.IdGroup - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<AdminGroupmenus>(
			key.ToString(), // EntityTrackingKey
			"AdminGroupmenus",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.AdminGroupmenus();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdMenu = (System.String)reader["ID_MENU"];
			c.OriginalIdMenu = c.IdMenu;
			c.IdGroup = (System.String)reader["ID_GROUP"];
			c.OriginalIdGroup = c.IdGroup;
			c.View = (System.Boolean)reader["VIEW"];
			c.Add = (System.Boolean)reader["ADD"];
			c.Edit = (System.Boolean)reader["EDIT"];
			c.Delete = (System.Boolean)reader["DELETE"];
			c.Control = (System.Boolean)reader["CONTROL"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.AdminGroupmenus"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.AdminGroupmenus"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.AdminGroupmenus entity)
		{
			if (!reader.Read()) return;
			
			entity.IdMenu = (System.String)reader["ID_MENU"];
			entity.OriginalIdMenu = (System.String)reader["ID_MENU"];
			entity.IdGroup = (System.String)reader["ID_GROUP"];
			entity.OriginalIdGroup = (System.String)reader["ID_GROUP"];
			entity.View = (System.Boolean)reader["VIEW"];
			entity.Add = (System.Boolean)reader["ADD"];
			entity.Edit = (System.Boolean)reader["EDIT"];
			entity.Delete = (System.Boolean)reader["DELETE"];
			entity.Control = (System.Boolean)reader["CONTROL"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.AdminGroupmenus"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.AdminGroupmenus"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.AdminGroupmenus entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdMenu = (System.String)dataRow["ID_MENU"];
			entity.OriginalIdMenu = (System.String)dataRow["ID_MENU"];
			entity.IdGroup = (System.String)dataRow["ID_GROUP"];
			entity.OriginalIdGroup = (System.String)dataRow["ID_GROUP"];
			entity.View = (System.Boolean)dataRow["VIEW"];
			entity.Add = (System.Boolean)dataRow["ADD"];
			entity.Edit = (System.Boolean)dataRow["EDIT"];
			entity.Delete = (System.Boolean)dataRow["DELETE"];
			entity.Control = (System.Boolean)dataRow["CONTROL"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.AdminGroupmenus"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.AdminGroupmenus Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.AdminGroupmenus entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region IdGroupSource	
			if (CanDeepLoad(entity, "AdminGroups|IdGroupSource", deepLoadType, innerList) 
				&& entity.IdGroupSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdGroup;
				AdminGroups tmpEntity = EntityManager.LocateEntity<AdminGroups>(EntityLocator.ConstructKeyFromPkItems(typeof(AdminGroups), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdGroupSource = tmpEntity;
				else
					entity.IdGroupSource = DataRepository.AdminGroupsProvider.GetByIdGroup(transactionManager, entity.IdGroup);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdGroupSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdGroupSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdminGroupsProvider.DeepLoad(transactionManager, entity.IdGroupSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdGroupSource

			#region IdMenuSource	
			if (CanDeepLoad(entity, "AdminMenus|IdMenuSource", deepLoadType, innerList) 
				&& entity.IdMenuSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdMenu;
				AdminMenus tmpEntity = EntityManager.LocateEntity<AdminMenus>(EntityLocator.ConstructKeyFromPkItems(typeof(AdminMenus), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdMenuSource = tmpEntity;
				else
					entity.IdMenuSource = DataRepository.AdminMenusProvider.GetByIdMenu(transactionManager, entity.IdMenu);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdMenuSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdMenuSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdminMenusProvider.DeepLoad(transactionManager, entity.IdMenuSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdMenuSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the QUANLYQN.Entities.AdminGroupmenus object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.AdminGroupmenus instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.AdminGroupmenus Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.AdminGroupmenus entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IdGroupSource
			if (CanDeepSave(entity, "AdminGroups|IdGroupSource", deepSaveType, innerList) 
				&& entity.IdGroupSource != null)
			{
				DataRepository.AdminGroupsProvider.Save(transactionManager, entity.IdGroupSource);
				entity.IdGroup = entity.IdGroupSource.IdGroup;
			}
			#endregion 
			
			#region IdMenuSource
			if (CanDeepSave(entity, "AdminMenus|IdMenuSource", deepSaveType, innerList) 
				&& entity.IdMenuSource != null)
			{
				DataRepository.AdminMenusProvider.Save(transactionManager, entity.IdMenuSource);
				entity.IdMenu = entity.IdMenuSource.IdMenu;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region AdminGroupmenusChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.AdminGroupmenus</c>
	///</summary>
	public enum AdminGroupmenusChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdminGroups</c> at IdGroupSource
		///</summary>
		[ChildEntityType(typeof(AdminGroups))]
		AdminGroups,
			
		///<summary>
		/// Composite Property for <c>AdminMenus</c> at IdMenuSource
		///</summary>
		[ChildEntityType(typeof(AdminMenus))]
		AdminMenus,
		}
	
	#endregion AdminGroupmenusChildEntityTypes
	
	#region AdminGroupmenusFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AdminGroupmenusColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroupmenus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupmenusFilterBuilder : SqlFilterBuilder<AdminGroupmenusColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupmenusFilterBuilder class.
		/// </summary>
		public AdminGroupmenusFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupmenusFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminGroupmenusFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupmenusFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminGroupmenusFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminGroupmenusFilterBuilder
	
	#region AdminGroupmenusParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AdminGroupmenusColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroupmenus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupmenusParameterBuilder : ParameterizedSqlFilterBuilder<AdminGroupmenusColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupmenusParameterBuilder class.
		/// </summary>
		public AdminGroupmenusParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupmenusParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminGroupmenusParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupmenusParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminGroupmenusParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminGroupmenusParameterBuilder
} // end namespace
