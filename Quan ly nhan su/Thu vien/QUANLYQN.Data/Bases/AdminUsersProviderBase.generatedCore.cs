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
	/// This class is the base class for any <see cref="AdminUsersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AdminUsersProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.AdminUsers, QUANLYQN.Entities.AdminUsersKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByIdGroupFromAdminGroupusers
		
		/// <summary>
		///		Gets ADMIN_USERS objects from the datasource by ID_GROUP in the
		///		ADMIN_GROUPUSERS table. Table ADMIN_USERS is related to table ADMIN_GROUPS
		///		through the (M:N) relationship defined in the ADMIN_GROUPUSERS table.
		/// </summary>
		/// <param name="idGroup"></param>
		/// <returns>Returns a typed collection of AdminUsers objects.</returns>
		public TList<AdminUsers> GetByIdGroupFromAdminGroupusers(System.String idGroup)
		{
			int count = -1;
			return GetByIdGroupFromAdminGroupusers(null,idGroup, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets QUANLYQN.Entities.AdminUsers objects from the datasource by ID_GROUP in the
		///		ADMIN_GROUPUSERS table. Table ADMIN_USERS is related to table ADMIN_GROUPS
		///		through the (M:N) relationship defined in the ADMIN_GROUPUSERS table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idGroup"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of AdminUsers objects.</returns>
		public TList<AdminUsers> GetByIdGroupFromAdminGroupusers(System.String idGroup, int start, int pageLength)
		{
			int count = -1;
			return GetByIdGroupFromAdminGroupusers(null, idGroup, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets AdminUsers objects from the datasource by ID_GROUP in the
		///		ADMIN_GROUPUSERS table. Table ADMIN_USERS is related to table ADMIN_GROUPS
		///		through the (M:N) relationship defined in the ADMIN_GROUPUSERS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ADMIN_USERS objects.</returns>
		public TList<AdminUsers> GetByIdGroupFromAdminGroupusers(TransactionManager transactionManager, System.String idGroup)
		{
			int count = -1;
			return GetByIdGroupFromAdminGroupusers(transactionManager, idGroup, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets AdminUsers objects from the datasource by ID_GROUP in the
		///		ADMIN_GROUPUSERS table. Table ADMIN_USERS is related to table ADMIN_GROUPS
		///		through the (M:N) relationship defined in the ADMIN_GROUPUSERS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ADMIN_USERS objects.</returns>
		public TList<AdminUsers> GetByIdGroupFromAdminGroupusers(TransactionManager transactionManager, System.String idGroup,int start, int pageLength)
		{
			int count = -1;
			return GetByIdGroupFromAdminGroupusers(transactionManager, idGroup, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets AdminUsers objects from the datasource by ID_GROUP in the
		///		ADMIN_GROUPUSERS table. Table ADMIN_USERS is related to table ADMIN_GROUPS
		///		through the (M:N) relationship defined in the ADMIN_GROUPUSERS table.
		/// </summary>
		/// <param name="idGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ADMIN_USERS objects.</returns>
		public TList<AdminUsers> GetByIdGroupFromAdminGroupusers(System.String idGroup,int start, int pageLength, out int count)
		{
			
			return GetByIdGroupFromAdminGroupusers(null, idGroup, start, pageLength, out count);
		}


		/// <summary>
		///		Gets ADMIN_USERS objects from the datasource by ID_GROUP in the
		///		ADMIN_GROUPUSERS table. Table ADMIN_USERS is related to table ADMIN_GROUPS
		///		through the (M:N) relationship defined in the ADMIN_GROUPUSERS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="idGroup"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of AdminUsers objects.</returns>
		public abstract TList<AdminUsers> GetByIdGroupFromAdminGroupusers(TransactionManager transactionManager,System.String idGroup, int start, int pageLength, out int count);
		
		#endregion GetByIdGroupFromAdminGroupusers
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.AdminUsersKey key)
		{
			return Delete(transactionManager, key.IdUser);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idUser">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String idUser)
		{
			return Delete(null, idUser);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idUser">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String idUser);		
		
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
		public override QUANLYQN.Entities.AdminUsers Get(TransactionManager transactionManager, QUANLYQN.Entities.AdminUsersKey key, int start, int pageLength)
		{
			return GetByIdUser(transactionManager, key.IdUser, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ADMIN_USERS index.
		/// </summary>
		/// <param name="idUser"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminUsers"/> class.</returns>
		public QUANLYQN.Entities.AdminUsers GetByIdUser(System.String idUser)
		{
			int count = -1;
			return GetByIdUser(null,idUser, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_USERS index.
		/// </summary>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminUsers"/> class.</returns>
		public QUANLYQN.Entities.AdminUsers GetByIdUser(System.String idUser, int start, int pageLength)
		{
			int count = -1;
			return GetByIdUser(null, idUser, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_USERS index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idUser"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminUsers"/> class.</returns>
		public QUANLYQN.Entities.AdminUsers GetByIdUser(TransactionManager transactionManager, System.String idUser)
		{
			int count = -1;
			return GetByIdUser(transactionManager, idUser, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_USERS index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminUsers"/> class.</returns>
		public QUANLYQN.Entities.AdminUsers GetByIdUser(TransactionManager transactionManager, System.String idUser, int start, int pageLength)
		{
			int count = -1;
			return GetByIdUser(transactionManager, idUser, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_USERS index.
		/// </summary>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminUsers"/> class.</returns>
		public QUANLYQN.Entities.AdminUsers GetByIdUser(System.String idUser, int start, int pageLength, out int count)
		{
			return GetByIdUser(null, idUser, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_USERS index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminUsers"/> class.</returns>
		public abstract QUANLYQN.Entities.AdminUsers GetByIdUser(TransactionManager transactionManager, System.String idUser, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;AdminUsers&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;AdminUsers&gt;"/></returns>
		public static QUANLYQN.Entities.TList<AdminUsers> Fill(IDataReader reader, QUANLYQN.Entities.TList<AdminUsers> rows, int start, int pageLength)
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
			
			QUANLYQN.Entities.AdminUsers c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("AdminUsers")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.AdminUsersColumn.IdUser - 1))?string.Empty:(System.String)reader[((int)QUANLYQN.Entities.AdminUsersColumn.IdUser - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<AdminUsers>(
			key.ToString(), // EntityTrackingKey
			"AdminUsers",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.AdminUsers();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdUser = (System.String)reader["ID_USER"];
			c.OriginalIdUser = c.IdUser;
			c.Password = (System.Byte[])reader["PASSWORD"];
			c.FullName = reader.IsDBNull(reader.GetOrdinal("FULL_NAME")) ? null : (System.String)reader["FULL_NAME"];
			c.Active = reader.IsDBNull(reader.GetOrdinal("ACTIVE")) ? null : (System.Int32?)reader["ACTIVE"];
			c.Modified = reader.IsDBNull(reader.GetOrdinal("MODIFIED")) ? null : (System.DateTime?)reader["MODIFIED"];
			c.Description = reader.IsDBNull(reader.GetOrdinal("DESCRIPTION")) ? null : (System.String)reader["DESCRIPTION"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.AdminUsers"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.AdminUsers"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.AdminUsers entity)
		{
			if (!reader.Read()) return;
			
			entity.IdUser = (System.String)reader["ID_USER"];
			entity.OriginalIdUser = (System.String)reader["ID_USER"];
			entity.Password = (System.Byte[])reader["PASSWORD"];
			entity.FullName = reader.IsDBNull(reader.GetOrdinal("FULL_NAME")) ? null : (System.String)reader["FULL_NAME"];
			entity.Active = reader.IsDBNull(reader.GetOrdinal("ACTIVE")) ? null : (System.Int32?)reader["ACTIVE"];
			entity.Modified = reader.IsDBNull(reader.GetOrdinal("MODIFIED")) ? null : (System.DateTime?)reader["MODIFIED"];
			entity.Description = reader.IsDBNull(reader.GetOrdinal("DESCRIPTION")) ? null : (System.String)reader["DESCRIPTION"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.AdminUsers"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.AdminUsers"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.AdminUsers entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdUser = (System.String)dataRow["ID_USER"];
			entity.OriginalIdUser = (System.String)dataRow["ID_USER"];
			entity.Password = (System.Byte[])dataRow["PASSWORD"];
			entity.FullName = Convert.IsDBNull(dataRow["FULL_NAME"]) ? null : (System.String)dataRow["FULL_NAME"];
			entity.Active = Convert.IsDBNull(dataRow["ACTIVE"]) ? null : (System.Int32?)dataRow["ACTIVE"];
			entity.Modified = Convert.IsDBNull(dataRow["MODIFIED"]) ? null : (System.DateTime?)dataRow["MODIFIED"];
			entity.Description = Convert.IsDBNull(dataRow["DESCRIPTION"]) ? null : (System.String)dataRow["DESCRIPTION"];
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
		/// <param name="entity">The <see cref="QUANLYQN.Entities.AdminUsers"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.AdminUsers Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.AdminUsers entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdUser methods when available
			
			#region AdminGroupsCollection_From_AdminGroupusers
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<AdminGroups>|AdminGroupsCollection_From_AdminGroupusers", deepLoadType, innerList))
			{
				entity.AdminGroupsCollection_From_AdminGroupusers = DataRepository.AdminGroupsProvider.GetByIdUserFromAdminGroupusers(transactionManager, entity.IdUser);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdminGroupsCollection_From_AdminGroupusers' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AdminGroupsCollection_From_AdminGroupusers != null)
				{
					deepHandles.Add("AdminGroupsCollection_From_AdminGroupusers",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< AdminGroups >) DataRepository.AdminGroupsProvider.DeepLoad,
						new object[] { transactionManager, entity.AdminGroupsCollection_From_AdminGroupusers, deep, deepLoadType, childTypes, innerList }
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

				entity.AdminGroupusersCollection = DataRepository.AdminGroupusersProvider.GetByIdUser(transactionManager, entity.IdUser);

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
		/// Deep Save the entire object graph of the QUANLYQN.Entities.AdminUsers object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.AdminUsers instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.AdminUsers Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.AdminUsers entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region AdminGroupsCollection_From_AdminGroupusers>
			if (CanDeepSave(entity.AdminGroupsCollection_From_AdminGroupusers, "List<AdminGroups>|AdminGroupsCollection_From_AdminGroupusers", deepSaveType, innerList))
			{
				if (entity.AdminGroupsCollection_From_AdminGroupusers.Count > 0 || entity.AdminGroupsCollection_From_AdminGroupusers.DeletedItems.Count > 0)
				{
					DataRepository.AdminGroupsProvider.Save(transactionManager, entity.AdminGroupsCollection_From_AdminGroupusers); 
					deepHandles.Add(
						(DeepSaveHandle<AdminGroups>) DataRepository.AdminGroupsProvider.DeepSave,
						new object[] { transactionManager, entity.AdminGroupsCollection_From_AdminGroupusers, deepSaveType, childTypes, innerList }
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
						if(child.IdUserSource != null)
							child.IdUser = child.IdUserSource.IdUser;
						else
							child.IdUser = entity.IdUser;

						//Handle right table of AdminGroupsCollection_From_AdminGroupusers
						if(child.IdGroupSource != null)
						{
								child.IdGroup = child.IdGroupSource.IdGroup;

						}

						//Handle right table of AdminGroupsCollection_From_AdminGroupusers
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
	
	#region AdminUsersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.AdminUsers</c>
	///</summary>
	public enum AdminUsersChildEntityTypes
	{

		///<summary>
		/// Collection of <c>AdminUsers</c> as ManyToMany for AdminGroupsCollection_From_AdminGroupusers
		///</summary>
		[ChildEntityType(typeof(TList<AdminGroups>))]
		AdminGroupsCollection_From_AdminGroupusers,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for AdminGroupusersCollection
		///</summary>
		[ChildEntityType(typeof(TList<AdminGroupusers>))]
		AdminGroupusersCollection,
	}
	
	#endregion AdminUsersChildEntityTypes
	
	#region AdminUsersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AdminUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminUsersFilterBuilder : SqlFilterBuilder<AdminUsersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminUsersFilterBuilder class.
		/// </summary>
		public AdminUsersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminUsersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminUsersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminUsersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminUsersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminUsersFilterBuilder
	
	#region AdminUsersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AdminUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminUsersParameterBuilder : ParameterizedSqlFilterBuilder<AdminUsersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminUsersParameterBuilder class.
		/// </summary>
		public AdminUsersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminUsersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminUsersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminUsersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminUsersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminUsersParameterBuilder
} // end namespace
