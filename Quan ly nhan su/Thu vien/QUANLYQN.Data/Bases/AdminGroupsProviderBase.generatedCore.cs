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
	/// This class is the base class for any <see cref="AdminGroupsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AdminGroupsProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.AdminGroups, QUANLYQN.Entities.AdminGroupsKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByIdUserFromAdminGroupusers
		
		/// <summary>
		///		Gets ADMIN_GROUPS objects from the datasource by ID_USER in the
		///		ADMIN_GROUPUSERS table. Table ADMIN_GROUPS is related to table ADMIN_USERS
		///		through the (M:N) relationship defined in the ADMIN_GROUPUSERS table.
		/// </summary>
		/// <param name="idUser"></param>
		/// <returns>Returns a typed collection of AdminGroups objects.</returns>
		public TList<AdminGroups> GetByIdUserFromAdminGroupusers(System.String idUser)
		{
			int count = -1;
			return GetByIdUserFromAdminGroupusers(null,idUser, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets QUANLYQN.Entities.AdminGroups objects from the datasource by ID_USER in the
		///		ADMIN_GROUPUSERS table. Table ADMIN_GROUPS is related to table ADMIN_USERS
		///		through the (M:N) relationship defined in the ADMIN_GROUPUSERS table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idUser"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of AdminGroups objects.</returns>
		public TList<AdminGroups> GetByIdUserFromAdminGroupusers(System.String idUser, int start, int pageLength)
		{
			int count = -1;
			return GetByIdUserFromAdminGroupusers(null, idUser, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets AdminGroups objects from the datasource by ID_USER in the
		///		ADMIN_GROUPUSERS table. Table ADMIN_GROUPS is related to table ADMIN_USERS
		///		through the (M:N) relationship defined in the ADMIN_GROUPUSERS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idUser"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ADMIN_GROUPS objects.</returns>
		public TList<AdminGroups> GetByIdUserFromAdminGroupusers(TransactionManager transactionManager, System.String idUser)
		{
			int count = -1;
			return GetByIdUserFromAdminGroupusers(transactionManager, idUser, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets AdminGroups objects from the datasource by ID_USER in the
		///		ADMIN_GROUPUSERS table. Table ADMIN_GROUPS is related to table ADMIN_USERS
		///		through the (M:N) relationship defined in the ADMIN_GROUPUSERS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ADMIN_GROUPS objects.</returns>
		public TList<AdminGroups> GetByIdUserFromAdminGroupusers(TransactionManager transactionManager, System.String idUser,int start, int pageLength)
		{
			int count = -1;
			return GetByIdUserFromAdminGroupusers(transactionManager, idUser, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets AdminGroups objects from the datasource by ID_USER in the
		///		ADMIN_GROUPUSERS table. Table ADMIN_GROUPS is related to table ADMIN_USERS
		///		through the (M:N) relationship defined in the ADMIN_GROUPUSERS table.
		/// </summary>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ADMIN_GROUPS objects.</returns>
		public TList<AdminGroups> GetByIdUserFromAdminGroupusers(System.String idUser,int start, int pageLength, out int count)
		{
			
			return GetByIdUserFromAdminGroupusers(null, idUser, start, pageLength, out count);
		}


		/// <summary>
		///		Gets ADMIN_GROUPS objects from the datasource by ID_USER in the
		///		ADMIN_GROUPUSERS table. Table ADMIN_GROUPS is related to table ADMIN_USERS
		///		through the (M:N) relationship defined in the ADMIN_GROUPUSERS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="idUser"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of AdminGroups objects.</returns>
		public abstract TList<AdminGroups> GetByIdUserFromAdminGroupusers(TransactionManager transactionManager,System.String idUser, int start, int pageLength, out int count);
		
		#endregion GetByIdUserFromAdminGroupusers
		
		#region GetByIdMenuFromAdminGroupmenus
		
		/// <summary>
		///		Gets ADMIN_GROUPS objects from the datasource by ID_MENU in the
		///		ADMIN_GROUPMENUS table. Table ADMIN_GROUPS is related to table ADMIN_MENUS
		///		through the (M:N) relationship defined in the ADMIN_GROUPMENUS table.
		/// </summary>
		/// <param name="idMenu"></param>
		/// <returns>Returns a typed collection of AdminGroups objects.</returns>
		public TList<AdminGroups> GetByIdMenuFromAdminGroupmenus(System.String idMenu)
		{
			int count = -1;
			return GetByIdMenuFromAdminGroupmenus(null,idMenu, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets QUANLYQN.Entities.AdminGroups objects from the datasource by ID_MENU in the
		///		ADMIN_GROUPMENUS table. Table ADMIN_GROUPS is related to table ADMIN_MENUS
		///		through the (M:N) relationship defined in the ADMIN_GROUPMENUS table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idMenu"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of AdminGroups objects.</returns>
		public TList<AdminGroups> GetByIdMenuFromAdminGroupmenus(System.String idMenu, int start, int pageLength)
		{
			int count = -1;
			return GetByIdMenuFromAdminGroupmenus(null, idMenu, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets AdminGroups objects from the datasource by ID_MENU in the
		///		ADMIN_GROUPMENUS table. Table ADMIN_GROUPS is related to table ADMIN_MENUS
		///		through the (M:N) relationship defined in the ADMIN_GROUPMENUS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idMenu"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ADMIN_GROUPS objects.</returns>
		public TList<AdminGroups> GetByIdMenuFromAdminGroupmenus(TransactionManager transactionManager, System.String idMenu)
		{
			int count = -1;
			return GetByIdMenuFromAdminGroupmenus(transactionManager, idMenu, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets AdminGroups objects from the datasource by ID_MENU in the
		///		ADMIN_GROUPMENUS table. Table ADMIN_GROUPS is related to table ADMIN_MENUS
		///		through the (M:N) relationship defined in the ADMIN_GROUPMENUS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idMenu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ADMIN_GROUPS objects.</returns>
		public TList<AdminGroups> GetByIdMenuFromAdminGroupmenus(TransactionManager transactionManager, System.String idMenu,int start, int pageLength)
		{
			int count = -1;
			return GetByIdMenuFromAdminGroupmenus(transactionManager, idMenu, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets AdminGroups objects from the datasource by ID_MENU in the
		///		ADMIN_GROUPMENUS table. Table ADMIN_GROUPS is related to table ADMIN_MENUS
		///		through the (M:N) relationship defined in the ADMIN_GROUPMENUS table.
		/// </summary>
		/// <param name="idMenu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ADMIN_GROUPS objects.</returns>
		public TList<AdminGroups> GetByIdMenuFromAdminGroupmenus(System.String idMenu,int start, int pageLength, out int count)
		{
			
			return GetByIdMenuFromAdminGroupmenus(null, idMenu, start, pageLength, out count);
		}


		/// <summary>
		///		Gets ADMIN_GROUPS objects from the datasource by ID_MENU in the
		///		ADMIN_GROUPMENUS table. Table ADMIN_GROUPS is related to table ADMIN_MENUS
		///		through the (M:N) relationship defined in the ADMIN_GROUPMENUS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="idMenu"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of AdminGroups objects.</returns>
		public abstract TList<AdminGroups> GetByIdMenuFromAdminGroupmenus(TransactionManager transactionManager,System.String idMenu, int start, int pageLength, out int count);
		
		#endregion GetByIdMenuFromAdminGroupmenus
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.AdminGroupsKey key)
		{
			return Delete(transactionManager, key.IdGroup);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idGroup">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String idGroup)
		{
			return Delete(null, idGroup);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String idGroup);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
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
		public override QUANLYQN.Entities.AdminGroups Get(TransactionManager transactionManager, QUANLYQN.Entities.AdminGroupsKey key, int start, int pageLength)
		{
			return GetByIdGroup(transactionManager, key.IdGroup, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ADMIN_GROUPS index.
		/// </summary>
		/// <param name="idGroup"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroups"/> class.</returns>
		public QUANLYQN.Entities.AdminGroups GetByIdGroup(System.String idGroup)
		{
			int count = -1;
			return GetByIdGroup(null,idGroup, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_GROUPS index.
		/// </summary>
		/// <param name="idGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroups"/> class.</returns>
		public QUANLYQN.Entities.AdminGroups GetByIdGroup(System.String idGroup, int start, int pageLength)
		{
			int count = -1;
			return GetByIdGroup(null, idGroup, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_GROUPS index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroups"/> class.</returns>
		public QUANLYQN.Entities.AdminGroups GetByIdGroup(TransactionManager transactionManager, System.String idGroup)
		{
			int count = -1;
			return GetByIdGroup(transactionManager, idGroup, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_GROUPS index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroups"/> class.</returns>
		public QUANLYQN.Entities.AdminGroups GetByIdGroup(TransactionManager transactionManager, System.String idGroup, int start, int pageLength)
		{
			int count = -1;
			return GetByIdGroup(transactionManager, idGroup, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_GROUPS index.
		/// </summary>
		/// <param name="idGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroups"/> class.</returns>
		public QUANLYQN.Entities.AdminGroups GetByIdGroup(System.String idGroup, int start, int pageLength, out int count)
		{
			return GetByIdGroup(null, idGroup, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_GROUPS index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminGroups"/> class.</returns>
		public abstract QUANLYQN.Entities.AdminGroups GetByIdGroup(TransactionManager transactionManager, System.String idGroup, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;AdminGroups&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;AdminGroups&gt;"/></returns>
		public static QUANLYQN.Entities.TList<AdminGroups> Fill(IDataReader reader, QUANLYQN.Entities.TList<AdminGroups> rows, int start, int pageLength)
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
			
			QUANLYQN.Entities.AdminGroups c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("AdminGroups")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.AdminGroupsColumn.IdGroup - 1))?string.Empty:(System.String)reader[((int)QUANLYQN.Entities.AdminGroupsColumn.IdGroup - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<AdminGroups>(
			key.ToString(), // EntityTrackingKey
			"AdminGroups",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.AdminGroups();
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
			c.GroupName = (System.String)reader["GROUP_NAME"];
			c.Active = reader.IsDBNull(reader.GetOrdinal("ACTIVE")) ? null : (System.Int32?)reader["ACTIVE"];
			c.Parent = (System.String)reader["PARENT"];
			c.Description = reader.IsDBNull(reader.GetOrdinal("DESCRIPTION")) ? null : (System.String)reader["DESCRIPTION"];
			c.Modified = reader.IsDBNull(reader.GetOrdinal("MODIFIED")) ? null : (System.DateTime?)reader["MODIFIED"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.AdminGroups"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.AdminGroups"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.AdminGroups entity)
		{
			if (!reader.Read()) return;
			
			entity.IdGroup = (System.String)reader["ID_GROUP"];
			entity.OriginalIdGroup = (System.String)reader["ID_GROUP"];
			entity.GroupName = (System.String)reader["GROUP_NAME"];
			entity.Active = reader.IsDBNull(reader.GetOrdinal("ACTIVE")) ? null : (System.Int32?)reader["ACTIVE"];
			entity.Parent = (System.String)reader["PARENT"];
			entity.Description = reader.IsDBNull(reader.GetOrdinal("DESCRIPTION")) ? null : (System.String)reader["DESCRIPTION"];
			entity.Modified = reader.IsDBNull(reader.GetOrdinal("MODIFIED")) ? null : (System.DateTime?)reader["MODIFIED"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.AdminGroups"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.AdminGroups"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.AdminGroups entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdGroup = (System.String)dataRow["ID_GROUP"];
			entity.OriginalIdGroup = (System.String)dataRow["ID_GROUP"];
			entity.GroupName = (System.String)dataRow["GROUP_NAME"];
			entity.Active = Convert.IsDBNull(dataRow["ACTIVE"]) ? null : (System.Int32?)dataRow["ACTIVE"];
			entity.Parent = (System.String)dataRow["PARENT"];
			entity.Description = Convert.IsDBNull(dataRow["DESCRIPTION"]) ? null : (System.String)dataRow["DESCRIPTION"];
			entity.Modified = Convert.IsDBNull(dataRow["MODIFIED"]) ? null : (System.DateTime?)dataRow["MODIFIED"];
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
		/// <param name="entity">The <see cref="QUANLYQN.Entities.AdminGroups"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.AdminGroups Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.AdminGroups entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdGroup methods when available
			
			#region AdminUsersCollection_From_AdminGroupusers
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<AdminUsers>|AdminUsersCollection_From_AdminGroupusers", deepLoadType, innerList))
			{
				entity.AdminUsersCollection_From_AdminGroupusers = DataRepository.AdminUsersProvider.GetByIdGroupFromAdminGroupusers(transactionManager, entity.IdGroup);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdminUsersCollection_From_AdminGroupusers' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AdminUsersCollection_From_AdminGroupusers != null)
				{
					deepHandles.Add("AdminUsersCollection_From_AdminGroupusers",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< AdminUsers >) DataRepository.AdminUsersProvider.DeepLoad,
						new object[] { transactionManager, entity.AdminUsersCollection_From_AdminGroupusers, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region AdminMenusCollection_From_AdminGroupmenus
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<AdminMenus>|AdminMenusCollection_From_AdminGroupmenus", deepLoadType, innerList))
			{
				entity.AdminMenusCollection_From_AdminGroupmenus = DataRepository.AdminMenusProvider.GetByIdGroupFromAdminGroupmenus(transactionManager, entity.IdGroup);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdminMenusCollection_From_AdminGroupmenus' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AdminMenusCollection_From_AdminGroupmenus != null)
				{
					deepHandles.Add("AdminMenusCollection_From_AdminGroupmenus",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< AdminMenus >) DataRepository.AdminMenusProvider.DeepLoad,
						new object[] { transactionManager, entity.AdminMenusCollection_From_AdminGroupmenus, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region AdminGroupmenusCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AdminGroupmenus>|AdminGroupmenusCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdminGroupmenusCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AdminGroupmenusCollection = DataRepository.AdminGroupmenusProvider.GetByIdGroup(transactionManager, entity.IdGroup);

				if (deep && entity.AdminGroupmenusCollection.Count > 0)
				{
					deepHandles.Add("AdminGroupmenusCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AdminGroupmenus>) DataRepository.AdminGroupmenusProvider.DeepLoad,
						new object[] { transactionManager, entity.AdminGroupmenusCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AdminGroupusersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AdminGroupusers>|AdminGroupusersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdminGroupusersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AdminGroupusersCollection = DataRepository.AdminGroupusersProvider.GetByIdGroup(transactionManager, entity.IdGroup);

				if (deep && entity.AdminGroupusersCollection.Count > 0)
				{
					deepHandles.Add("AdminGroupusersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AdminGroupusers>) DataRepository.AdminGroupusersProvider.DeepLoad,
						new object[] { transactionManager, entity.AdminGroupusersCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
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
		/// Deep Save the entire object graph of the QUANLYQN.Entities.AdminGroups object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.AdminGroups instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.AdminGroups Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.AdminGroups entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();

			#region AdminUsersCollection_From_AdminGroupusers>
			if (CanDeepSave(entity.AdminUsersCollection_From_AdminGroupusers, "List<AdminUsers>|AdminUsersCollection_From_AdminGroupusers", deepSaveType, innerList))
			{
				if (entity.AdminUsersCollection_From_AdminGroupusers.Count > 0 || entity.AdminUsersCollection_From_AdminGroupusers.DeletedItems.Count > 0)
				{
					DataRepository.AdminUsersProvider.Save(transactionManager, entity.AdminUsersCollection_From_AdminGroupusers); 
					deepHandles.Add(
						(DeepSaveHandle<AdminUsers>) DataRepository.AdminUsersProvider.DeepSave,
						new object[] { transactionManager, entity.AdminUsersCollection_From_AdminGroupusers, deepSaveType, childTypes, innerList }
					);
				}
			}
			#endregion 

			#region AdminMenusCollection_From_AdminGroupmenus>
			if (CanDeepSave(entity.AdminMenusCollection_From_AdminGroupmenus, "List<AdminMenus>|AdminMenusCollection_From_AdminGroupmenus", deepSaveType, innerList))
			{
				if (entity.AdminMenusCollection_From_AdminGroupmenus.Count > 0 || entity.AdminMenusCollection_From_AdminGroupmenus.DeletedItems.Count > 0)
				{
					DataRepository.AdminMenusProvider.Save(transactionManager, entity.AdminMenusCollection_From_AdminGroupmenus); 
					deepHandles.Add(
						(DeepSaveHandle<AdminMenus>) DataRepository.AdminMenusProvider.DeepSave,
						new object[] { transactionManager, entity.AdminMenusCollection_From_AdminGroupmenus, deepSaveType, childTypes, innerList }
					);
				}
			}
			#endregion 
	
			#region List<AdminGroupmenus>
				if (CanDeepSave(entity.AdminGroupmenusCollection, "List<AdminGroupmenus>|AdminGroupmenusCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AdminGroupmenus child in entity.AdminGroupmenusCollection)
					{
						if(child.IdGroupSource != null)
							child.IdGroup = child.IdGroupSource.IdGroup;
						else
							child.IdGroup = entity.IdGroup;

						//Handle right table of AdminMenusCollection_From_AdminGroupmenus
						if(child.IdMenuSource != null)
						{
								child.IdMenu = child.IdMenuSource.IdMenu;

						}

						//Handle right table of AdminMenusCollection_From_AdminGroupmenus
						if(child.IdGroupSource != null)
						{
								child.IdGroup = child.IdGroupSource.IdGroup;

						}

					}

					if (entity.AdminGroupmenusCollection.Count > 0 || entity.AdminGroupmenusCollection.DeletedItems.Count > 0)
					{
						DataRepository.AdminGroupmenusProvider.Save(transactionManager, entity.AdminGroupmenusCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< AdminGroupmenus >) DataRepository.AdminGroupmenusProvider.DeepSave,
							new object[] { transactionManager, entity.AdminGroupmenusCollection, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
	
			#region List<AdminGroupusers>
				if (CanDeepSave(entity.AdminGroupusersCollection, "List<AdminGroupusers>|AdminGroupusersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AdminGroupusers child in entity.AdminGroupusersCollection)
					{
						if(child.IdGroupSource != null)
							child.IdGroup = child.IdGroupSource.IdGroup;
						else
							child.IdGroup = entity.IdGroup;

						//Handle right table of AdminUsersCollection_From_AdminGroupusers
						if(child.IdGroupSource != null)
						{
								child.IdGroup = child.IdGroupSource.IdGroup;

						}

						//Handle right table of AdminUsersCollection_From_AdminGroupusers
						if(child.IdUserSource != null)
						{
								child.IdUser = child.IdUserSource.IdUser;

						}

					}

					if (entity.AdminGroupusersCollection.Count > 0 || entity.AdminGroupusersCollection.DeletedItems.Count > 0)
					{
						DataRepository.AdminGroupusersProvider.Save(transactionManager, entity.AdminGroupusersCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< AdminGroupusers >) DataRepository.AdminGroupusersProvider.DeepSave,
							new object[] { transactionManager, entity.AdminGroupusersCollection, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
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
	
	#region AdminGroupsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.AdminGroups</c>
	///</summary>
	public enum AdminGroupsChildEntityTypes
	{

		///<summary>
		/// Collection of <c>AdminGroups</c> as ManyToMany for AdminUsersCollection_From_AdminGroupusers
		///</summary>
		[ChildEntityType(typeof(TList<AdminUsers>))]
		AdminUsersCollection_From_AdminGroupusers,

		///<summary>
		/// Collection of <c>AdminGroups</c> as ManyToMany for AdminMenusCollection_From_AdminGroupmenus
		///</summary>
		[ChildEntityType(typeof(TList<AdminMenus>))]
		AdminMenusCollection_From_AdminGroupmenus,

		///<summary>
		/// Collection of <c>AdminGroups</c> as OneToMany for AdminGroupmenusCollection
		///</summary>
		[ChildEntityType(typeof(TList<AdminGroupmenus>))]
		AdminGroupmenusCollection,

		///<summary>
		/// Collection of <c>AdminGroups</c> as OneToMany for AdminGroupusersCollection
		///</summary>
		[ChildEntityType(typeof(TList<AdminGroupusers>))]
		AdminGroupusersCollection,
	}
	
	#endregion AdminGroupsChildEntityTypes
	
	#region AdminGroupsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AdminGroupsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroups"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupsFilterBuilder : SqlFilterBuilder<AdminGroupsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupsFilterBuilder class.
		/// </summary>
		public AdminGroupsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminGroupsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminGroupsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminGroupsFilterBuilder
	
	#region AdminGroupsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AdminGroupsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminGroups"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminGroupsParameterBuilder : ParameterizedSqlFilterBuilder<AdminGroupsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminGroupsParameterBuilder class.
		/// </summary>
		public AdminGroupsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminGroupsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminGroupsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminGroupsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminGroupsParameterBuilder
} // end namespace
