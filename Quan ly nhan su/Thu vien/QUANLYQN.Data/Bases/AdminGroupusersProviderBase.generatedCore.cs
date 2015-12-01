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
	/// This class is the base class for any <see cref="AdminGroupusersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AdminGroupusersProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.AdminGroupusers, QUANLYQN.Entities.AdminGroupusersKey>
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
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.AdminGroupusersKey key)
		{
			return Delete(transactionManager, key.IdGroup, key.IdUser);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idGroup">. Primary Key.</param>
		/// <param name="idUser">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String idGroup, System.String idUser)
		{
			return Delete(null, idGroup, idUser);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup">. Primary Key.</param>
		/// <param name="idUser">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String idGroup, System.String idUser);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPUSERS_ADMIN_GROUPS key.
		///		FK_ADMIN_GROUPUSERS_ADMIN_GROUPS Description: 
		/// </summary>
		/// <param name="idGroup"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupusers objects.</returns>
		public QUANLYQN.Entities.TList<AdminGroupusers> GetByIdGroup(System.String idGroup)
		{
			int count = -1;
			return GetByIdGroup(idGroup, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPUSERS_ADMIN_GROUPS key.
		///		FK_ADMIN_GROUPUSERS_ADMIN_GROUPS Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupusers objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<AdminGroupusers> GetByIdGroup(TransactionManager transactionManager, System.String idGroup)
		{
			int count = -1;
			return GetByIdGroup(transactionManager, idGroup, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPUSERS_ADMIN_GROUPS key.
		///		FK_ADMIN_GROUPUSERS_ADMIN_GROUPS Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupusers objects.</returns>
		public QUANLYQN.Entities.TList<AdminGroupusers> GetByIdGroup(TransactionManager transactionManager, System.String idGroup, int start, int pageLength)
		{
			int count = -1;
			return GetByIdGroup(transactionManager, idGroup, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPUSERS_ADMIN_GROUPS key.
		///		fkAdminGroupusersAdminGroups Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idGroup"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupusers objects.</returns>
		public QUANLYQN.Entities.TList<AdminGroupusers> GetByIdGroup(System.String idGroup, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdGroup(null, idGroup, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPUSERS_ADMIN_GROUPS key.
		///		fkAdminGroupusersAdminGroups Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idGroup"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupusers objects.</returns>
		public QUANLYQN.Entities.TList<AdminGroupusers> GetByIdGroup(System.String idGroup, int start, int pageLength,out int count)
		{
			return GetByIdGroup(null, idGroup, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPUSERS_ADMIN_GROUPS key.
		///		FK_ADMIN_GROUPUSERS_ADMIN_GROUPS Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupusers objects.</returns>
		public abstract QUANLYQN.Entities.TList<AdminGroupusers> GetByIdGroup(TransactionManager transactionManager, System.String idGroup, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPUSERS_ADMIN_USERS key.
		///		FK_ADMIN_GROUPUSERS_ADMIN_USERS Description: 
		/// </summary>
		/// <param name="idUser"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupusers objects.</returns>
		public QUANLYQN.Entities.TList<AdminGroupusers> GetByIdUser(System.String idUser)
		{
			int count = -1;
			return GetByIdUser(idUser, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPUSERS_ADMIN_USERS key.
		///		FK_ADMIN_GROUPUSERS_ADMIN_USERS Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idUser"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupusers objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<AdminGroupusers> GetByIdUser(TransactionManager transactionManager, System.String idUser)
		{
			int count = -1;
			return GetByIdUser(transactionManager, idUser, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPUSERS_ADMIN_USERS key.
		///		FK_ADMIN_GROUPUSERS_ADMIN_USERS Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupusers objects.</returns>
		public QUANLYQN.Entities.TList<AdminGroupusers> GetByIdUser(TransactionManager transactionManager, System.String idUser, int start, int pageLength)
		{
			int count = -1;
			return GetByIdUser(transactionManager, idUser, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPUSERS_ADMIN_USERS key.
		///		fkAdminGroupusersAdminUsers Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idUser"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupusers objects.</returns>
		public QUANLYQN.Entities.TList<AdminGroupusers> GetByIdUser(System.String idUser, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdUser(null, idUser, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPUSERS_ADMIN_USERS key.
		///		fkAdminGroupusersAdminUsers Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idUser"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupusers objects.</returns>
		public QUANLYQN.Entities.TList<AdminGroupusers> GetByIdUser(System.String idUser, int start, int pageLength,out int count)
		{
			return GetByIdUser(null, idUser, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ADMIN_GROUPUSERS_ADMIN_USERS key.
		///		FK_ADMIN_GROUPUSERS_ADMIN_USERS Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.AdminGroupusers objects.</returns>
		public abstract QUANLYQN.Entities.TList<AdminGroupusers> GetByIdUser(TransactionManager transactionManager, System.String idUser, int start, int pageLength, out int count);
		
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
		public override QUANLYQN.Entities.AdminGroupusers Get(TransactionManager transactionManager, QUANLYQN.Entities.AdminGroupusersKey key, int start, int pageLength)
		{
			return GetByIdGroupIdUser(transactionManager, key.IdGroup, key.IdUser, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ADMIN_GROUPUSERS index.
		/// </summary>
		/// <param name="idGroup"></param>
		/// <param name="idUser"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroupusers"/> class.</returns>
		public QUANLYQN.Entities.AdminGroupusers GetByIdGroupIdUser(System.String idGroup, System.String idUser)
		{
			int count = -1;
			return GetByIdGroupIdUser(null,idGroup, idUser, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_GROUPUSERS index.
		/// </summary>
		/// <param name="idGroup"></param>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroupusers"/> class.</returns>
		public QUANLYQN.Entities.AdminGroupusers GetByIdGroupIdUser(System.String idGroup, System.String idUser, int start, int pageLength)
		{
			int count = -1;
			return GetByIdGroupIdUser(null, idGroup, idUser, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_GROUPUSERS index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup"></param>
		/// <param name="idUser"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroupusers"/> class.</returns>
		public QUANLYQN.Entities.AdminGroupusers GetByIdGroupIdUser(TransactionManager transactionManager, System.String idGroup, System.String idUser)
		{
			int count = -1;
			return GetByIdGroupIdUser(transactionManager, idGroup, idUser, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_GROUPUSERS index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup"></param>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroupusers"/> class.</returns>
		public QUANLYQN.Entities.AdminGroupusers GetByIdGroupIdUser(TransactionManager transactionManager, System.String idGroup, System.String idUser, int start, int pageLength)
		{
			int count = -1;
			return GetByIdGroupIdUser(transactionManager, idGroup, idUser, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_GROUPUSERS index.
		/// </summary>
		/// <param name="idGroup"></param>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroupusers"/> class.</returns>
		public QUANLYQN.Entities.AdminGroupusers GetByIdGroupIdUser(System.String idGroup, System.String idUser, int start, int pageLength, out int count)
		{
			return GetByIdGroupIdUser(null, idGroup, idUser, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_GROUPUSERS index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup"></param>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroupusers"/> class.</returns>
		public abstract QUANLYQN.Entities.AdminGroupusers GetByIdGroupIdUser(TransactionManager transactionManager, System.String idGroup, System.String idUser, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;AdminGroupusers&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;AdminGroupusers&gt;"/></returns>
		public static QUANLYQN.Entities.TList<AdminGroupusers> Fill(IDataReader reader, QUANLYQN.Entities.TList<AdminGroupusers> rows, int start, int pageLength)
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
			
			QUANLYQN.Entities.AdminGroupusers c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("AdminGroupusers")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.AdminGroupusersColumn.IdGroup - 1))?string.Empty:(System.String)reader[((int)QUANLYQN.Entities.AdminGroupusersColumn.IdGroup - 1)]).ToString())
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.AdminGroupusersColumn.IdUser - 1))?string.Empty:(System.String)reader[((int)QUANLYQN.Entities.AdminGroupusersColumn.IdUser - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<AdminGroupusers>(
			key.ToString(), // EntityTrackingKey
			"AdminGroupusers",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.AdminGroupusers();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdGroup = (System.String)reader["ID_GROUP"];
			c.OriginalIdGroup = c.IdGroup;
			c.IdUser = (System.String)reader["ID_USER"];
			c.OriginalIdUser = c.IdUser;
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.AdminGroupusers"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.AdminGroupusers"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.AdminGroupusers entity)
		{
			if (!reader.Read()) return;
			
			entity.IdGroup = (System.String)reader["ID_GROUP"];
			entity.OriginalIdGroup = (System.String)reader["ID_GROUP"];
			entity.IdUser = (System.String)reader["ID_USER"];
			entity.OriginalIdUser = (System.String)reader["ID_USER"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.AdminGroupusers"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.AdminGroupusers"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.AdminGroupusers entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdGroup = (System.String)dataRow["ID_GROUP"];
			entity.OriginalIdGroup = (System.String)dataRow["ID_GROUP"];
			entity.IdUser = (System.String)dataRow["ID_USER"];
			entity.OriginalIdUser = (System.String)dataRow["ID_USER"];
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
		/// <param name="entity">The <see cref="QUANLYQN.Entities.AdminGroupusers"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.AdminGroupusers Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.AdminGroupusers entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region IdUserSource	
			if (CanDeepLoad(entity, "AdminUsers|IdUserSource", deepLoadType, innerList) 
				&& entity.IdUserSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdUser;
				AdminUsers tmpEntity = EntityManager.LocateEntity<AdminUsers>(EntityLocator.ConstructKeyFromPkItems(typeof(AdminUsers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdUserSource = tmpEntity;
				else
					entity.IdUserSource = DataRepository.AdminUsersProvider.GetByIdUser(transactionManager, entity.IdUser);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdUserSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdUserSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdminUsersProvider.DeepLoad(transactionManager, entity.IdUserSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdUserSource
			
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
		/// Deep Save the entire object graph of the QUANLYQN.Entities.AdminGroupusers object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.AdminGroupusers instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.AdminGroupusers Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.AdminGroupusers entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region IdUserSource
			if (CanDeepSave(entity, "AdminUsers|IdUserSource", deepSaveType, innerList) 
				&& entity.IdUserSource != null)
			{
				DataRepository.AdminUsersProvider.Save(transactionManager, entity.IdUserSource);
				entity.IdUser = entity.IdUserSource.IdUser;
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
	
	#region AdminGroupusersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.AdminGroupusers</c>
	///</summary>
	public enum AdminGroupusersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdminGroups</c> at IdGroupSource
		///</summary>
		[ChildEntityType(typeof(AdminGroups))]
		AdminGroups,
			
		///<summary>
		/// Composite Property for <c>AdminUsers</c> at IdUserSource
		///</summary>
		[ChildEntityType(typeof(AdminUsers))]
		AdminUsers,
		}
	
	#endregion AdminGroupusersChildEntityTypes
	
	#region AdminGroupusersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AdminGroupusersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroupusers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupusersFilterBuilder : SqlFilterBuilder<AdminGroupusersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupusersFilterBuilder class.
		/// </summary>
		public AdminGroupusersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupusersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminGroupusersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupusersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminGroupusersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminGroupusersFilterBuilder
	
	#region AdminGroupusersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AdminGroupusersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroupusers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupusersParameterBuilder : ParameterizedSqlFilterBuilder<AdminGroupusersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupusersParameterBuilder class.
		/// </summary>
		public AdminGroupusersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupusersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminGroupusersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupusersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminGroupusersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminGroupusersParameterBuilder
} // end namespace
