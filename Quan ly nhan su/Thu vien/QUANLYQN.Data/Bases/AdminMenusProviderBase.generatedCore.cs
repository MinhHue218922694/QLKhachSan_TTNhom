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
	/// This class is the base class for any <see cref="AdminMenusProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AdminMenusProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.AdminMenus, QUANLYQN.Entities.AdminMenusKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByIdGroupFromAdminGroupmenus
		
		/// <summary>
		///		Gets ADMIN_MENUS objects from the datasource by ID_GROUP in the
		///		ADMIN_GROUPMENUS table. Table ADMIN_MENUS is related to table ADMIN_GROUPS
		///		through the (M:N) relationship defined in the ADMIN_GROUPMENUS table.
		/// </summary>
		/// <param name="idGroup"></param>
		/// <returns>Returns a typed collection of AdminMenus objects.</returns>
		public TList<AdminMenus> GetByIdGroupFromAdminGroupmenus(System.String idGroup)
		{
			int count = -1;
			return GetByIdGroupFromAdminGroupmenus(null,idGroup, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets QUANLYQN.Entities.AdminMenus objects from the datasource by ID_GROUP in the
		///		ADMIN_GROUPMENUS table. Table ADMIN_MENUS is related to table ADMIN_GROUPS
		///		through the (M:N) relationship defined in the ADMIN_GROUPMENUS table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idGroup"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of AdminMenus objects.</returns>
		public TList<AdminMenus> GetByIdGroupFromAdminGroupmenus(System.String idGroup, int start, int pageLength)
		{
			int count = -1;
			return GetByIdGroupFromAdminGroupmenus(null, idGroup, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets AdminMenus objects from the datasource by ID_GROUP in the
		///		ADMIN_GROUPMENUS table. Table ADMIN_MENUS is related to table ADMIN_GROUPS
		///		through the (M:N) relationship defined in the ADMIN_GROUPMENUS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ADMIN_MENUS objects.</returns>
		public TList<AdminMenus> GetByIdGroupFromAdminGroupmenus(TransactionManager transactionManager, System.String idGroup)
		{
			int count = -1;
			return GetByIdGroupFromAdminGroupmenus(transactionManager, idGroup, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets AdminMenus objects from the datasource by ID_GROUP in the
		///		ADMIN_GROUPMENUS table. Table ADMIN_MENUS is related to table ADMIN_GROUPS
		///		through the (M:N) relationship defined in the ADMIN_GROUPMENUS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ADMIN_MENUS objects.</returns>
		public TList<AdminMenus> GetByIdGroupFromAdminGroupmenus(TransactionManager transactionManager, System.String idGroup,int start, int pageLength)
		{
			int count = -1;
			return GetByIdGroupFromAdminGroupmenus(transactionManager, idGroup, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets AdminMenus objects from the datasource by ID_GROUP in the
		///		ADMIN_GROUPMENUS table. Table ADMIN_MENUS is related to table ADMIN_GROUPS
		///		through the (M:N) relationship defined in the ADMIN_GROUPMENUS table.
		/// </summary>
		/// <param name="idGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ADMIN_MENUS objects.</returns>
		public TList<AdminMenus> GetByIdGroupFromAdminGroupmenus(System.String idGroup,int start, int pageLength, out int count)
		{
			
			return GetByIdGroupFromAdminGroupmenus(null, idGroup, start, pageLength, out count);
		}


		/// <summary>
		///		Gets ADMIN_MENUS objects from the datasource by ID_GROUP in the
		///		ADMIN_GROUPMENUS table. Table ADMIN_MENUS is related to table ADMIN_GROUPS
		///		through the (M:N) relationship defined in the ADMIN_GROUPMENUS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="idGroup"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of AdminMenus objects.</returns>
		public abstract TList<AdminMenus> GetByIdGroupFromAdminGroupmenus(TransactionManager transactionManager,System.String idGroup, int start, int pageLength, out int count);
		
		#endregion GetByIdGroupFromAdminGroupmenus
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.AdminMenusKey key)
		{
			return Delete(transactionManager, key.IdMenu);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idMenu">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String idMenu)
		{
			return Delete(null, idMenu);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idMenu">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String idMenu);		
		
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
		public override QUANLYQN.Entities.AdminMenus Get(TransactionManager transactionManager, QUANLYQN.Entities.AdminMenusKey key, int start, int pageLength)
		{
			return GetByIdMenu(transactionManager, key.IdMenu, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ADMIN_MENUS index.
		/// </summary>
		/// <param name="idMenu"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminMenus"/> class.</returns>
		public QUANLYQN.Entities.AdminMenus GetByIdMenu(System.String idMenu)
		{
			int count = -1;
			return GetByIdMenu(null,idMenu, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_MENUS index.
		/// </summary>
		/// <param name="idMenu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminMenus"/> class.</returns>
		public QUANLYQN.Entities.AdminMenus GetByIdMenu(System.String idMenu, int start, int pageLength)
		{
			int count = -1;
			return GetByIdMenu(null, idMenu, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_MENUS index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idMenu"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminMenus"/> class.</returns>
		public QUANLYQN.Entities.AdminMenus GetByIdMenu(TransactionManager transactionManager, System.String idMenu)
		{
			int count = -1;
			return GetByIdMenu(transactionManager, idMenu, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_MENUS index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idMenu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminMenus"/> class.</returns>
		public QUANLYQN.Entities.AdminMenus GetByIdMenu(TransactionManager transactionManager, System.String idMenu, int start, int pageLength)
		{
			int count = -1;
			return GetByIdMenu(transactionManager, idMenu, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_MENUS index.
		/// </summary>
		/// <param name="idMenu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminMenus"/> class.</returns>
		public QUANLYQN.Entities.AdminMenus GetByIdMenu(System.String idMenu, int start, int pageLength, out int count)
		{
			return GetByIdMenu(null, idMenu, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ADMIN_MENUS index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idMenu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.AdminMenus"/> class.</returns>
		public abstract QUANLYQN.Entities.AdminMenus GetByIdMenu(TransactionManager transactionManager, System.String idMenu, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;AdminMenus&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;AdminMenus&gt;"/></returns>
		public static QUANLYQN.Entities.TList<AdminMenus> Fill(IDataReader reader, QUANLYQN.Entities.TList<AdminMenus> rows, int start, int pageLength)
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
			
			QUANLYQN.Entities.AdminMenus c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("AdminMenus")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.AdminMenusColumn.IdMenu - 1))?string.Empty:(System.String)reader[((int)QUANLYQN.Entities.AdminMenusColumn.IdMenu - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<AdminMenus>(
			key.ToString(), // EntityTrackingKey
			"AdminMenus",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.AdminMenus();
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
			c.MenuName = (System.String)reader["MENU_NAME"];
			c.Active = reader.IsDBNull(reader.GetOrdinal("ACTIVE")) ? null : (System.Int32?)reader["ACTIVE"];
			c.Parent = (System.String)reader["PARENT"];
			c.ImageName = reader.IsDBNull(reader.GetOrdinal("IMAGE_NAME")) ? null : (System.String)reader["IMAGE_NAME"];
			c.IsCreateIcon = reader.IsDBNull(reader.GetOrdinal("IS_CREATE_ICON")) ? null : (System.Int32?)reader["IS_CREATE_ICON"];
			c.Description = reader.IsDBNull(reader.GetOrdinal("DESCRIPTION")) ? null : (System.String)reader["DESCRIPTION"];
			c.SafeNameChecked = reader.IsDBNull(reader.GetOrdinal("CHECKED")) ? null : (System.Int32?)reader["CHECKED"];
			c.Modified = reader.IsDBNull(reader.GetOrdinal("MODIFIED")) ? null : (System.DateTime?)reader["MODIFIED"];
			c.MenuOrder = reader.IsDBNull(reader.GetOrdinal("MENU_ORDER")) ? null : (System.Int32?)reader["MENU_ORDER"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.AdminMenus"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.AdminMenus"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.AdminMenus entity)
		{
			if (!reader.Read()) return;
			
			entity.IdMenu = (System.String)reader["ID_MENU"];
			entity.OriginalIdMenu = (System.String)reader["ID_MENU"];
			entity.MenuName = (System.String)reader["MENU_NAME"];
			entity.Active = reader.IsDBNull(reader.GetOrdinal("ACTIVE")) ? null : (System.Int32?)reader["ACTIVE"];
			entity.Parent = (System.String)reader["PARENT"];
			entity.ImageName = reader.IsDBNull(reader.GetOrdinal("IMAGE_NAME")) ? null : (System.String)reader["IMAGE_NAME"];
			entity.IsCreateIcon = reader.IsDBNull(reader.GetOrdinal("IS_CREATE_ICON")) ? null : (System.Int32?)reader["IS_CREATE_ICON"];
			entity.Description = reader.IsDBNull(reader.GetOrdinal("DESCRIPTION")) ? null : (System.String)reader["DESCRIPTION"];
			entity.SafeNameChecked = reader.IsDBNull(reader.GetOrdinal("CHECKED")) ? null : (System.Int32?)reader["CHECKED"];
			entity.Modified = reader.IsDBNull(reader.GetOrdinal("MODIFIED")) ? null : (System.DateTime?)reader["MODIFIED"];
			entity.MenuOrder = reader.IsDBNull(reader.GetOrdinal("MENU_ORDER")) ? null : (System.Int32?)reader["MENU_ORDER"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.AdminMenus"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.AdminMenus"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.AdminMenus entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdMenu = (System.String)dataRow["ID_MENU"];
			entity.OriginalIdMenu = (System.String)dataRow["ID_MENU"];
			entity.MenuName = (System.String)dataRow["MENU_NAME"];
			entity.Active = Convert.IsDBNull(dataRow["ACTIVE"]) ? null : (System.Int32?)dataRow["ACTIVE"];
			entity.Parent = (System.String)dataRow["PARENT"];
			entity.ImageName = Convert.IsDBNull(dataRow["IMAGE_NAME"]) ? null : (System.String)dataRow["IMAGE_NAME"];
			entity.IsCreateIcon = Convert.IsDBNull(dataRow["IS_CREATE_ICON"]) ? null : (System.Int32?)dataRow["IS_CREATE_ICON"];
			entity.Description = Convert.IsDBNull(dataRow["DESCRIPTION"]) ? null : (System.String)dataRow["DESCRIPTION"];
			entity.SafeNameChecked = Convert.IsDBNull(dataRow["CHECKED"]) ? null : (System.Int32?)dataRow["CHECKED"];
			entity.Modified = Convert.IsDBNull(dataRow["MODIFIED"]) ? null : (System.DateTime?)dataRow["MODIFIED"];
			entity.MenuOrder = Convert.IsDBNull(dataRow["MENU_ORDER"]) ? null : (System.Int32?)dataRow["MENU_ORDER"];
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
		/// <param name="entity">The <see cref="QUANLYQN.Entities.AdminMenus"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.AdminMenus Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.AdminMenus entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdMenu methods when available
			
			#region AdminGroupsCollection_From_AdminGroupmenus
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<AdminGroups>|AdminGroupsCollection_From_AdminGroupmenus", deepLoadType, innerList))
			{
				entity.AdminGroupsCollection_From_AdminGroupmenus = DataRepository.AdminGroupsProvider.GetByIdMenuFromAdminGroupmenus(transactionManager, entity.IdMenu);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdminGroupsCollection_From_AdminGroupmenus' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AdminGroupsCollection_From_AdminGroupmenus != null)
				{
					deepHandles.Add("AdminGroupsCollection_From_AdminGroupmenus",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< AdminGroups >) DataRepository.AdminGroupsProvider.DeepLoad,
						new object[] { transactionManager, entity.AdminGroupsCollection_From_AdminGroupmenus, deep, deepLoadType, childTypes, innerList }
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

				entity.AdminGroupmenusCollection = DataRepository.AdminGroupmenusProvider.GetByIdMenu(transactionManager, entity.IdMenu);

				if (deep && entity.AdminGroupmenusCollection.Count > 0)
				{
					deepHandles.Add("AdminGroupmenusCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AdminGroupmenus>) DataRepository.AdminGroupmenusProvider.DeepLoad,
						new object[] { transactionManager, entity.AdminGroupmenusCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the QUANLYQN.Entities.AdminMenus object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.AdminMenus instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.AdminMenus Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.AdminMenus entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region AdminGroupsCollection_From_AdminGroupmenus>
			if (CanDeepSave(entity.AdminGroupsCollection_From_AdminGroupmenus, "List<AdminGroups>|AdminGroupsCollection_From_AdminGroupmenus", deepSaveType, innerList))
			{
				if (entity.AdminGroupsCollection_From_AdminGroupmenus.Count > 0 || entity.AdminGroupsCollection_From_AdminGroupmenus.DeletedItems.Count > 0)
				{
					DataRepository.AdminGroupsProvider.Save(transactionManager, entity.AdminGroupsCollection_From_AdminGroupmenus); 
					deepHandles.Add(
						(DeepSaveHandle<AdminGroups>) DataRepository.AdminGroupsProvider.DeepSave,
						new object[] { transactionManager, entity.AdminGroupsCollection_From_AdminGroupmenus, deepSaveType, childTypes, innerList }
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
						if(child.IdMenuSource != null)
							child.IdMenu = child.IdMenuSource.IdMenu;
						else
							child.IdMenu = entity.IdMenu;

						//Handle right table of AdminGroupsCollection_From_AdminGroupmenus
						if(child.IdMenuSource != null)
						{
								child.IdMenu = child.IdMenuSource.IdMenu;

						}

						//Handle right table of AdminGroupsCollection_From_AdminGroupmenus
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
	
	#region AdminMenusChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.AdminMenus</c>
	///</summary>
	public enum AdminMenusChildEntityTypes
	{

		///<summary>
		/// Collection of <c>AdminMenus</c> as ManyToMany for AdminGroupsCollection_From_AdminGroupmenus
		///</summary>
		[ChildEntityType(typeof(TList<AdminGroups>))]
		AdminGroupsCollection_From_AdminGroupmenus,

		///<summary>
		/// Collection of <c>AdminMenus</c> as OneToMany for AdminGroupmenusCollection
		///</summary>
		[ChildEntityType(typeof(TList<AdminGroupmenus>))]
		AdminGroupmenusCollection,
	}
	
	#endregion AdminMenusChildEntityTypes
	
	#region AdminMenusFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AdminMenusColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminMenus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminMenusFilterBuilder : SqlFilterBuilder<AdminMenusColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminMenusFilterBuilder class.
		/// </summary>
		public AdminMenusFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminMenusFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminMenusFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminMenusFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminMenusFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminMenusFilterBuilder
	
	#region AdminMenusParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AdminMenusColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminMenus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminMenusParameterBuilder : ParameterizedSqlFilterBuilder<AdminMenusColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminMenusParameterBuilder class.
		/// </summary>
		public AdminMenusParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminMenusParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminMenusParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminMenusParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminMenusParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminMenusParameterBuilder
} // end namespace
