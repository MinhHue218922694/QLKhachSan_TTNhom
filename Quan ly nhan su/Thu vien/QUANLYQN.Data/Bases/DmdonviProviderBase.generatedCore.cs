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
	/// This class is the base class for any <see cref="DmdonviProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DmdonviProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.Dmdonvi, QUANLYQN.Entities.DmdonviKey>
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
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.DmdonviKey key)
		{
			return Delete(transactionManager, key.IdDonvi);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idDonvi">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 idDonvi)
		{
			return Delete(null, idDonvi);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDonvi">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 idDonvi);		
		
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
		public override QUANLYQN.Entities.Dmdonvi Get(TransactionManager transactionManager, QUANLYQN.Entities.DmdonviKey key, int start, int pageLength)
		{
			return GetByIdDonvi(transactionManager, key.IdDonvi, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_DMDONVI index.
		/// </summary>
		/// <param name="idDonvi"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmdonvi"/> class.</returns>
		public QUANLYQN.Entities.Dmdonvi GetByIdDonvi(System.Int32 idDonvi)
		{
			int count = -1;
			return GetByIdDonvi(null,idDonvi, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMDONVI index.
		/// </summary>
		/// <param name="idDonvi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmdonvi"/> class.</returns>
		public QUANLYQN.Entities.Dmdonvi GetByIdDonvi(System.Int32 idDonvi, int start, int pageLength)
		{
			int count = -1;
			return GetByIdDonvi(null, idDonvi, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMDONVI index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDonvi"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmdonvi"/> class.</returns>
		public QUANLYQN.Entities.Dmdonvi GetByIdDonvi(TransactionManager transactionManager, System.Int32 idDonvi)
		{
			int count = -1;
			return GetByIdDonvi(transactionManager, idDonvi, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMDONVI index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDonvi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmdonvi"/> class.</returns>
		public QUANLYQN.Entities.Dmdonvi GetByIdDonvi(TransactionManager transactionManager, System.Int32 idDonvi, int start, int pageLength)
		{
			int count = -1;
			return GetByIdDonvi(transactionManager, idDonvi, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMDONVI index.
		/// </summary>
		/// <param name="idDonvi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmdonvi"/> class.</returns>
		public QUANLYQN.Entities.Dmdonvi GetByIdDonvi(System.Int32 idDonvi, int start, int pageLength, out int count)
		{
			return GetByIdDonvi(null, idDonvi, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMDONVI index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDonvi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmdonvi"/> class.</returns>
		public abstract QUANLYQN.Entities.Dmdonvi GetByIdDonvi(TransactionManager transactionManager, System.Int32 idDonvi, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;Dmdonvi&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;Dmdonvi&gt;"/></returns>
		public static QUANLYQN.Entities.TList<Dmdonvi> Fill(IDataReader reader, QUANLYQN.Entities.TList<Dmdonvi> rows, int start, int pageLength)
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
			
			QUANLYQN.Entities.Dmdonvi c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Dmdonvi")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.DmdonviColumn.IdDonvi - 1))?(int)0:(System.Int32)reader[((int)QUANLYQN.Entities.DmdonviColumn.IdDonvi - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Dmdonvi>(
			key.ToString(), // EntityTrackingKey
			"Dmdonvi",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.Dmdonvi();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdDonvi = (System.Int32)reader["ID_DONVI"];
			c.MaDonvi = reader.IsDBNull(reader.GetOrdinal("MA_DONVI")) ? null : (System.String)reader["MA_DONVI"];
			c.TenDonvi = reader.IsDBNull(reader.GetOrdinal("TEN_DONVI")) ? null : (System.String)reader["TEN_DONVI"];
			c.IdDonvicha = reader.IsDBNull(reader.GetOrdinal("ID_DONVICHA")) ? null : (System.Int32?)reader["ID_DONVICHA"];
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
		/// Refreshes the <see cref="QUANLYQN.Entities.Dmdonvi"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmdonvi"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.Dmdonvi entity)
		{
			if (!reader.Read()) return;
			
			entity.IdDonvi = (System.Int32)reader["ID_DONVI"];
			entity.MaDonvi = reader.IsDBNull(reader.GetOrdinal("MA_DONVI")) ? null : (System.String)reader["MA_DONVI"];
			entity.TenDonvi = reader.IsDBNull(reader.GetOrdinal("TEN_DONVI")) ? null : (System.String)reader["TEN_DONVI"];
			entity.IdDonvicha = reader.IsDBNull(reader.GetOrdinal("ID_DONVICHA")) ? null : (System.Int32?)reader["ID_DONVICHA"];
			entity.Ghichu = reader.IsDBNull(reader.GetOrdinal("GHICHU")) ? null : (System.String)reader["GHICHU"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.Dmdonvi"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmdonvi"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.Dmdonvi entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdDonvi = (System.Int32)dataRow["ID_DONVI"];
			entity.MaDonvi = Convert.IsDBNull(dataRow["MA_DONVI"]) ? null : (System.String)dataRow["MA_DONVI"];
			entity.TenDonvi = Convert.IsDBNull(dataRow["TEN_DONVI"]) ? null : (System.String)dataRow["TEN_DONVI"];
			entity.IdDonvicha = Convert.IsDBNull(dataRow["ID_DONVICHA"]) ? null : (System.Int32?)dataRow["ID_DONVICHA"];
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
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmdonvi"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Dmdonvi Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.Dmdonvi entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdDonvi methods when available
			
			#region QuannhanCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Quannhan>|QuannhanCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuannhanCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuannhanCollection = DataRepository.QuannhanProvider.GetByIdDonvi(transactionManager, entity.IdDonvi);

				if (deep && entity.QuannhanCollection.Count > 0)
				{
					deepHandles.Add("QuannhanCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Quannhan>) DataRepository.QuannhanProvider.DeepLoad,
						new object[] { transactionManager, entity.QuannhanCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DmlopCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Dmlop>|DmlopCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DmlopCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DmlopCollection = DataRepository.DmlopProvider.GetByIdDaidoi(transactionManager, entity.IdDonvi);

				if (deep && entity.DmlopCollection.Count > 0)
				{
					deepHandles.Add("DmlopCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Dmlop>) DataRepository.DmlopProvider.DeepLoad,
						new object[] { transactionManager, entity.DmlopCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the QUANLYQN.Entities.Dmdonvi object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.Dmdonvi instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Dmdonvi Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.Dmdonvi entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.IdDonviSource != null)
							child.IdDonvi = child.IdDonviSource.IdDonvi;
						else
							child.IdDonvi = entity.IdDonvi;

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
				
	
			#region List<Dmlop>
				if (CanDeepSave(entity.DmlopCollection, "List<Dmlop>|DmlopCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Dmlop child in entity.DmlopCollection)
					{
						if(child.IdDaidoiSource != null)
							child.IdDaidoi = child.IdDaidoiSource.IdDonvi;
						else
							child.IdDaidoi = entity.IdDonvi;

					}

					if (entity.DmlopCollection.Count > 0 || entity.DmlopCollection.DeletedItems.Count > 0)
					{
						DataRepository.DmlopProvider.Save(transactionManager, entity.DmlopCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Dmlop >) DataRepository.DmlopProvider.DeepSave,
							new object[] { transactionManager, entity.DmlopCollection, deepSaveType, childTypes, innerList }
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
	
	#region DmdonviChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.Dmdonvi</c>
	///</summary>
	public enum DmdonviChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Dmdonvi</c> as OneToMany for QuannhanCollection
		///</summary>
		[ChildEntityType(typeof(TList<Quannhan>))]
		QuannhanCollection,

		///<summary>
		/// Collection of <c>Dmdonvi</c> as OneToMany for DmlopCollection
		///</summary>
		[ChildEntityType(typeof(TList<Dmlop>))]
		DmlopCollection,
	}
	
	#endregion DmdonviChildEntityTypes
	
	#region DmdonviFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DmdonviColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmdonvi"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmdonviFilterBuilder : SqlFilterBuilder<DmdonviColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmdonviFilterBuilder class.
		/// </summary>
		public DmdonviFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmdonviFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmdonviFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmdonviFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmdonviFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmdonviFilterBuilder
	
	#region DmdonviParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DmdonviColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmdonvi"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmdonviParameterBuilder : ParameterizedSqlFilterBuilder<DmdonviColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmdonviParameterBuilder class.
		/// </summary>
		public DmdonviParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmdonviParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmdonviParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmdonviParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmdonviParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmdonviParameterBuilder
} // end namespace
