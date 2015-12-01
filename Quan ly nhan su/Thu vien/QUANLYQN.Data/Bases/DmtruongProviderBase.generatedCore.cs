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
	/// This class is the base class for any <see cref="DmtruongProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DmtruongProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.Dmtruong, QUANLYQN.Entities.DmtruongKey>
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
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.DmtruongKey key)
		{
			return Delete(transactionManager, key.IdTruong);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idTruong">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 idTruong)
		{
			return Delete(null, idTruong);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTruong">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 idTruong);		
		
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
		public override QUANLYQN.Entities.Dmtruong Get(TransactionManager transactionManager, QUANLYQN.Entities.DmtruongKey key, int start, int pageLength)
		{
			return GetByIdTruong(transactionManager, key.IdTruong, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_DMTRUONG index.
		/// </summary>
		/// <param name="idTruong"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmtruong"/> class.</returns>
		public QUANLYQN.Entities.Dmtruong GetByIdTruong(System.Int32 idTruong)
		{
			int count = -1;
			return GetByIdTruong(null,idTruong, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMTRUONG index.
		/// </summary>
		/// <param name="idTruong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmtruong"/> class.</returns>
		public QUANLYQN.Entities.Dmtruong GetByIdTruong(System.Int32 idTruong, int start, int pageLength)
		{
			int count = -1;
			return GetByIdTruong(null, idTruong, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMTRUONG index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTruong"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmtruong"/> class.</returns>
		public QUANLYQN.Entities.Dmtruong GetByIdTruong(TransactionManager transactionManager, System.Int32 idTruong)
		{
			int count = -1;
			return GetByIdTruong(transactionManager, idTruong, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMTRUONG index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTruong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmtruong"/> class.</returns>
		public QUANLYQN.Entities.Dmtruong GetByIdTruong(TransactionManager transactionManager, System.Int32 idTruong, int start, int pageLength)
		{
			int count = -1;
			return GetByIdTruong(transactionManager, idTruong, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMTRUONG index.
		/// </summary>
		/// <param name="idTruong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmtruong"/> class.</returns>
		public QUANLYQN.Entities.Dmtruong GetByIdTruong(System.Int32 idTruong, int start, int pageLength, out int count)
		{
			return GetByIdTruong(null, idTruong, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMTRUONG index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTruong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmtruong"/> class.</returns>
		public abstract QUANLYQN.Entities.Dmtruong GetByIdTruong(TransactionManager transactionManager, System.Int32 idTruong, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;Dmtruong&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;Dmtruong&gt;"/></returns>
		public static QUANLYQN.Entities.TList<Dmtruong> Fill(IDataReader reader, QUANLYQN.Entities.TList<Dmtruong> rows, int start, int pageLength)
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
			
			QUANLYQN.Entities.Dmtruong c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Dmtruong")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.DmtruongColumn.IdTruong - 1))?(int)0:(System.Int32)reader[((int)QUANLYQN.Entities.DmtruongColumn.IdTruong - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Dmtruong>(
			key.ToString(), // EntityTrackingKey
			"Dmtruong",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.Dmtruong();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdTruong = (System.Int32)reader["ID_TRUONG"];
			c.Tentruong = (System.String)reader["TENTRUONG"];
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
		/// Refreshes the <see cref="QUANLYQN.Entities.Dmtruong"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmtruong"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.Dmtruong entity)
		{
			if (!reader.Read()) return;
			
			entity.IdTruong = (System.Int32)reader["ID_TRUONG"];
			entity.Tentruong = (System.String)reader["TENTRUONG"];
			entity.Ghichu = reader.IsDBNull(reader.GetOrdinal("GHICHU")) ? null : (System.String)reader["GHICHU"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.Dmtruong"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmtruong"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.Dmtruong entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdTruong = (System.Int32)dataRow["ID_TRUONG"];
			entity.Tentruong = (System.String)dataRow["TENTRUONG"];
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
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmtruong"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Dmtruong Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.Dmtruong entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdTruong methods when available
			
			#region LstruonglopCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Lstruonglop>|LstruonglopCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LstruonglopCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.LstruonglopCollection = DataRepository.LstruonglopProvider.GetByIdTruong(transactionManager, entity.IdTruong);

				if (deep && entity.LstruonglopCollection.Count > 0)
				{
					deepHandles.Add("LstruonglopCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Lstruonglop>) DataRepository.LstruonglopProvider.DeepLoad,
						new object[] { transactionManager, entity.LstruonglopCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the QUANLYQN.Entities.Dmtruong object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.Dmtruong instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Dmtruong Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.Dmtruong entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Lstruonglop>
				if (CanDeepSave(entity.LstruonglopCollection, "List<Lstruonglop>|LstruonglopCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Lstruonglop child in entity.LstruonglopCollection)
					{
						if(child.IdTruongSource != null)
							child.IdTruong = child.IdTruongSource.IdTruong;
						else
							child.IdTruong = entity.IdTruong;

					}

					if (entity.LstruonglopCollection.Count > 0 || entity.LstruonglopCollection.DeletedItems.Count > 0)
					{
						DataRepository.LstruonglopProvider.Save(transactionManager, entity.LstruonglopCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Lstruonglop >) DataRepository.LstruonglopProvider.DeepSave,
							new object[] { transactionManager, entity.LstruonglopCollection, deepSaveType, childTypes, innerList }
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
	
	#region DmtruongChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.Dmtruong</c>
	///</summary>
	public enum DmtruongChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Dmtruong</c> as OneToMany for LstruonglopCollection
		///</summary>
		[ChildEntityType(typeof(TList<Lstruonglop>))]
		LstruonglopCollection,
	}
	
	#endregion DmtruongChildEntityTypes
	
	#region DmtruongFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DmtruongColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmtruong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmtruongFilterBuilder : SqlFilterBuilder<DmtruongColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmtruongFilterBuilder class.
		/// </summary>
		public DmtruongFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmtruongFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmtruongFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmtruongFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmtruongFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmtruongFilterBuilder
	
	#region DmtruongParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DmtruongColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmtruong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmtruongParameterBuilder : ParameterizedSqlFilterBuilder<DmtruongColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmtruongParameterBuilder class.
		/// </summary>
		public DmtruongParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmtruongParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmtruongParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmtruongParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmtruongParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmtruongParameterBuilder
} // end namespace
