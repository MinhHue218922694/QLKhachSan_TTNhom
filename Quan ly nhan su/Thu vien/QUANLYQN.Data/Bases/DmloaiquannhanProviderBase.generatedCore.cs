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
	/// This class is the base class for any <see cref="DmloaiquannhanProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DmloaiquannhanProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.Dmloaiquannhan, QUANLYQN.Entities.DmloaiquannhanKey>
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
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.DmloaiquannhanKey key)
		{
			return Delete(transactionManager, key.IdLoaiqn);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idLoaiqn">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 idLoaiqn)
		{
			return Delete(null, idLoaiqn);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLoaiqn">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 idLoaiqn);		
		
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
		public override QUANLYQN.Entities.Dmloaiquannhan Get(TransactionManager transactionManager, QUANLYQN.Entities.DmloaiquannhanKey key, int start, int pageLength)
		{
			return GetByIdLoaiqn(transactionManager, key.IdLoaiqn, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_DMLOAIQUANNHAN index.
		/// </summary>
		/// <param name="idLoaiqn"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmloaiquannhan"/> class.</returns>
		public QUANLYQN.Entities.Dmloaiquannhan GetByIdLoaiqn(System.Int32 idLoaiqn)
		{
			int count = -1;
			return GetByIdLoaiqn(null,idLoaiqn, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMLOAIQUANNHAN index.
		/// </summary>
		/// <param name="idLoaiqn"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmloaiquannhan"/> class.</returns>
		public QUANLYQN.Entities.Dmloaiquannhan GetByIdLoaiqn(System.Int32 idLoaiqn, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLoaiqn(null, idLoaiqn, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMLOAIQUANNHAN index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLoaiqn"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmloaiquannhan"/> class.</returns>
		public QUANLYQN.Entities.Dmloaiquannhan GetByIdLoaiqn(TransactionManager transactionManager, System.Int32 idLoaiqn)
		{
			int count = -1;
			return GetByIdLoaiqn(transactionManager, idLoaiqn, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMLOAIQUANNHAN index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLoaiqn"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmloaiquannhan"/> class.</returns>
		public QUANLYQN.Entities.Dmloaiquannhan GetByIdLoaiqn(TransactionManager transactionManager, System.Int32 idLoaiqn, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLoaiqn(transactionManager, idLoaiqn, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMLOAIQUANNHAN index.
		/// </summary>
		/// <param name="idLoaiqn"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmloaiquannhan"/> class.</returns>
		public QUANLYQN.Entities.Dmloaiquannhan GetByIdLoaiqn(System.Int32 idLoaiqn, int start, int pageLength, out int count)
		{
			return GetByIdLoaiqn(null, idLoaiqn, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMLOAIQUANNHAN index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLoaiqn"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmloaiquannhan"/> class.</returns>
		public abstract QUANLYQN.Entities.Dmloaiquannhan GetByIdLoaiqn(TransactionManager transactionManager, System.Int32 idLoaiqn, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;Dmloaiquannhan&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;Dmloaiquannhan&gt;"/></returns>
		public static QUANLYQN.Entities.TList<Dmloaiquannhan> Fill(IDataReader reader, QUANLYQN.Entities.TList<Dmloaiquannhan> rows, int start, int pageLength)
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
			
			QUANLYQN.Entities.Dmloaiquannhan c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Dmloaiquannhan")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.DmloaiquannhanColumn.IdLoaiqn - 1))?(int)0:(System.Int32)reader[((int)QUANLYQN.Entities.DmloaiquannhanColumn.IdLoaiqn - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Dmloaiquannhan>(
			key.ToString(), // EntityTrackingKey
			"Dmloaiquannhan",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.Dmloaiquannhan();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdLoaiqn = (System.Int32)reader["ID_LOAIQN"];
			c.LoaiQuannhan = (System.String)reader["LOAI_QUANNHAN"];
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
		/// Refreshes the <see cref="QUANLYQN.Entities.Dmloaiquannhan"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmloaiquannhan"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.Dmloaiquannhan entity)
		{
			if (!reader.Read()) return;
			
			entity.IdLoaiqn = (System.Int32)reader["ID_LOAIQN"];
			entity.LoaiQuannhan = (System.String)reader["LOAI_QUANNHAN"];
			entity.Ghichu = reader.IsDBNull(reader.GetOrdinal("GHICHU")) ? null : (System.String)reader["GHICHU"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.Dmloaiquannhan"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmloaiquannhan"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.Dmloaiquannhan entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdLoaiqn = (System.Int32)dataRow["ID_LOAIQN"];
			entity.LoaiQuannhan = (System.String)dataRow["LOAI_QUANNHAN"];
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
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmloaiquannhan"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Dmloaiquannhan Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.Dmloaiquannhan entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdLoaiqn methods when available
			
			#region QuannhanCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Quannhan>|QuannhanCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuannhanCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuannhanCollection = DataRepository.QuannhanProvider.GetByIdLoaiquannhan(transactionManager, entity.IdLoaiqn);

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
		/// Deep Save the entire object graph of the QUANLYQN.Entities.Dmloaiquannhan object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.Dmloaiquannhan instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Dmloaiquannhan Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.Dmloaiquannhan entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Quannhan>
				if (CanDeepSave(entity.QuannhanCollection, "List<Quannhan>|QuannhanCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Quannhan child in entity.QuannhanCollection)
					{
						if(child.IdLoaiquannhanSource != null)
							child.IdLoaiquannhan = child.IdLoaiquannhanSource.IdLoaiqn;
						else
							child.IdLoaiquannhan = entity.IdLoaiqn;

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
	
	#region DmloaiquannhanChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.Dmloaiquannhan</c>
	///</summary>
	public enum DmloaiquannhanChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Dmloaiquannhan</c> as OneToMany for QuannhanCollection
		///</summary>
		[ChildEntityType(typeof(TList<Quannhan>))]
		QuannhanCollection,
	}
	
	#endregion DmloaiquannhanChildEntityTypes
	
	#region DmloaiquannhanFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DmloaiquannhanColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmloaiquannhan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmloaiquannhanFilterBuilder : SqlFilterBuilder<DmloaiquannhanColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmloaiquannhanFilterBuilder class.
		/// </summary>
		public DmloaiquannhanFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmloaiquannhanFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmloaiquannhanFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmloaiquannhanFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmloaiquannhanFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmloaiquannhanFilterBuilder
	
	#region DmloaiquannhanParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DmloaiquannhanColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmloaiquannhan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmloaiquannhanParameterBuilder : ParameterizedSqlFilterBuilder<DmloaiquannhanColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmloaiquannhanParameterBuilder class.
		/// </summary>
		public DmloaiquannhanParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmloaiquannhanParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmloaiquannhanParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmloaiquannhanParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmloaiquannhanParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmloaiquannhanParameterBuilder
} // end namespace
