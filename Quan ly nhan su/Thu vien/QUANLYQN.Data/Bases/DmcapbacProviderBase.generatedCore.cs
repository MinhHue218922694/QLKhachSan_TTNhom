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
	/// This class is the base class for any <see cref="DmcapbacProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DmcapbacProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.Dmcapbac, QUANLYQN.Entities.DmcapbacKey>
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
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.DmcapbacKey key)
		{
			return Delete(transactionManager, key.IdCapbac);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idCapbac">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 idCapbac)
		{
			return Delete(null, idCapbac);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCapbac">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 idCapbac);		
		
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
		public override QUANLYQN.Entities.Dmcapbac Get(TransactionManager transactionManager, QUANLYQN.Entities.DmcapbacKey key, int start, int pageLength)
		{
			return GetByIdCapbac(transactionManager, key.IdCapbac, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_DMCAPBAC index.
		/// </summary>
		/// <param name="idCapbac"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmcapbac"/> class.</returns>
		public QUANLYQN.Entities.Dmcapbac GetByIdCapbac(System.Int32 idCapbac)
		{
			int count = -1;
			return GetByIdCapbac(null,idCapbac, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMCAPBAC index.
		/// </summary>
		/// <param name="idCapbac"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmcapbac"/> class.</returns>
		public QUANLYQN.Entities.Dmcapbac GetByIdCapbac(System.Int32 idCapbac, int start, int pageLength)
		{
			int count = -1;
			return GetByIdCapbac(null, idCapbac, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMCAPBAC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCapbac"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmcapbac"/> class.</returns>
		public QUANLYQN.Entities.Dmcapbac GetByIdCapbac(TransactionManager transactionManager, System.Int32 idCapbac)
		{
			int count = -1;
			return GetByIdCapbac(transactionManager, idCapbac, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMCAPBAC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCapbac"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmcapbac"/> class.</returns>
		public QUANLYQN.Entities.Dmcapbac GetByIdCapbac(TransactionManager transactionManager, System.Int32 idCapbac, int start, int pageLength)
		{
			int count = -1;
			return GetByIdCapbac(transactionManager, idCapbac, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMCAPBAC index.
		/// </summary>
		/// <param name="idCapbac"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmcapbac"/> class.</returns>
		public QUANLYQN.Entities.Dmcapbac GetByIdCapbac(System.Int32 idCapbac, int start, int pageLength, out int count)
		{
			return GetByIdCapbac(null, idCapbac, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMCAPBAC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCapbac"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmcapbac"/> class.</returns>
		public abstract QUANLYQN.Entities.Dmcapbac GetByIdCapbac(TransactionManager transactionManager, System.Int32 idCapbac, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;Dmcapbac&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;Dmcapbac&gt;"/></returns>
		public static QUANLYQN.Entities.TList<Dmcapbac> Fill(IDataReader reader, QUANLYQN.Entities.TList<Dmcapbac> rows, int start, int pageLength)
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
			
			QUANLYQN.Entities.Dmcapbac c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Dmcapbac")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.DmcapbacColumn.IdCapbac - 1))?(int)0:(System.Int32)reader[((int)QUANLYQN.Entities.DmcapbacColumn.IdCapbac - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Dmcapbac>(
			key.ToString(), // EntityTrackingKey
			"Dmcapbac",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.Dmcapbac();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdCapbac = (System.Int32)reader["ID_CAPBAC"];
			c.Capbac = (System.String)reader["CAPBAC"];
			c.Ghichu = reader.IsDBNull(reader.GetOrdinal("GHICHU")) ? null : (System.String)reader["GHICHU"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.Dmcapbac"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmcapbac"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.Dmcapbac entity)
		{
			if (!reader.Read()) return;
			
			entity.IdCapbac = (System.Int32)reader["ID_CAPBAC"];
			entity.Capbac = (System.String)reader["CAPBAC"];
			entity.Ghichu = reader.IsDBNull(reader.GetOrdinal("GHICHU")) ? null : (System.String)reader["GHICHU"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.Dmcapbac"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmcapbac"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.Dmcapbac entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdCapbac = (System.Int32)dataRow["ID_CAPBAC"];
			entity.Capbac = (System.String)dataRow["CAPBAC"];
			entity.Ghichu = Convert.IsDBNull(dataRow["GHICHU"]) ? null : (System.String)dataRow["GHICHU"];
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
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmcapbac"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Dmcapbac Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.Dmcapbac entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdCapbac methods when available
			
			#region LscapbacCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Lscapbac>|LscapbacCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LscapbacCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.LscapbacCollection = DataRepository.LscapbacProvider.GetByIdCapbac(transactionManager, entity.IdCapbac);

				if (deep && entity.LscapbacCollection.Count > 0)
				{
					deepHandles.Add("LscapbacCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Lscapbac>) DataRepository.LscapbacProvider.DeepLoad,
						new object[] { transactionManager, entity.LscapbacCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region QuannhanCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Quannhan>|QuannhanCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuannhanCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuannhanCollection = DataRepository.QuannhanProvider.GetByIdCapbac(transactionManager, entity.IdCapbac);

				if (deep && entity.QuannhanCollection.Count > 0)
				{
					deepHandles.Add("QuannhanCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Quannhan>) DataRepository.QuannhanProvider.DeepLoad,
						new object[] { transactionManager, entity.QuannhanCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the QUANLYQN.Entities.Dmcapbac object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.Dmcapbac instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Dmcapbac Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.Dmcapbac entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Lscapbac>
				if (CanDeepSave(entity.LscapbacCollection, "List<Lscapbac>|LscapbacCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Lscapbac child in entity.LscapbacCollection)
					{
						if(child.IdCapbacSource != null)
							child.IdCapbac = child.IdCapbacSource.IdCapbac;
						else
							child.IdCapbac = entity.IdCapbac;

					}

					if (entity.LscapbacCollection.Count > 0 || entity.LscapbacCollection.DeletedItems.Count > 0)
					{
						DataRepository.LscapbacProvider.Save(transactionManager, entity.LscapbacCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Lscapbac >) DataRepository.LscapbacProvider.DeepSave,
							new object[] { transactionManager, entity.LscapbacCollection, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
	
			#region List<Quannhan>
				if (CanDeepSave(entity.QuannhanCollection, "List<Quannhan>|QuannhanCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Quannhan child in entity.QuannhanCollection)
					{
						if(child.IdCapbacSource != null)
							child.IdCapbac = child.IdCapbacSource.IdCapbac;
						else
							child.IdCapbac = entity.IdCapbac;

					}

					if (entity.QuannhanCollection.Count > 0 || entity.QuannhanCollection.DeletedItems.Count > 0)
					{
						DataRepository.QuannhanProvider.Save(transactionManager, entity.QuannhanCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Quannhan >) DataRepository.QuannhanProvider.DeepSave,
							new object[] { transactionManager, entity.QuannhanCollection, deepSaveType, childTypes, innerList }
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
	
	#region DmcapbacChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.Dmcapbac</c>
	///</summary>
	public enum DmcapbacChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Dmcapbac</c> as OneToMany for LscapbacCollection
		///</summary>
		[ChildEntityType(typeof(TList<Lscapbac>))]
		LscapbacCollection,

		///<summary>
		/// Collection of <c>Dmcapbac</c> as OneToMany for QuannhanCollection
		///</summary>
		[ChildEntityType(typeof(TList<Quannhan>))]
		QuannhanCollection,
	}
	
	#endregion DmcapbacChildEntityTypes
	
	#region DmcapbacFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DmcapbacColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmcapbac"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmcapbacFilterBuilder : SqlFilterBuilder<DmcapbacColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmcapbacFilterBuilder class.
		/// </summary>
		public DmcapbacFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmcapbacFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmcapbacFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmcapbacFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmcapbacFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmcapbacFilterBuilder
	
	#region DmcapbacParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DmcapbacColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmcapbac"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmcapbacParameterBuilder : ParameterizedSqlFilterBuilder<DmcapbacColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmcapbacParameterBuilder class.
		/// </summary>
		public DmcapbacParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmcapbacParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmcapbacParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmcapbacParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmcapbacParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmcapbacParameterBuilder
} // end namespace
