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
	/// This class is the base class for any <see cref="DmgioitinhProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DmgioitinhProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.Dmgioitinh, QUANLYQN.Entities.DmgioitinhKey>
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
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.DmgioitinhKey key)
		{
			return Delete(transactionManager, key.IdGioitinh);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idGioitinh">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 idGioitinh)
		{
			return Delete(null, idGioitinh);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGioitinh">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 idGioitinh);		
		
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
		public override QUANLYQN.Entities.Dmgioitinh Get(TransactionManager transactionManager, QUANLYQN.Entities.DmgioitinhKey key, int start, int pageLength)
		{
			return GetByIdGioitinh(transactionManager, key.IdGioitinh, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_DMGIOITINH index.
		/// </summary>
		/// <param name="idGioitinh"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmgioitinh"/> class.</returns>
		public QUANLYQN.Entities.Dmgioitinh GetByIdGioitinh(System.Int32 idGioitinh)
		{
			int count = -1;
			return GetByIdGioitinh(null,idGioitinh, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMGIOITINH index.
		/// </summary>
		/// <param name="idGioitinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmgioitinh"/> class.</returns>
		public QUANLYQN.Entities.Dmgioitinh GetByIdGioitinh(System.Int32 idGioitinh, int start, int pageLength)
		{
			int count = -1;
			return GetByIdGioitinh(null, idGioitinh, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMGIOITINH index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGioitinh"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmgioitinh"/> class.</returns>
		public QUANLYQN.Entities.Dmgioitinh GetByIdGioitinh(TransactionManager transactionManager, System.Int32 idGioitinh)
		{
			int count = -1;
			return GetByIdGioitinh(transactionManager, idGioitinh, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMGIOITINH index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGioitinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmgioitinh"/> class.</returns>
		public QUANLYQN.Entities.Dmgioitinh GetByIdGioitinh(TransactionManager transactionManager, System.Int32 idGioitinh, int start, int pageLength)
		{
			int count = -1;
			return GetByIdGioitinh(transactionManager, idGioitinh, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMGIOITINH index.
		/// </summary>
		/// <param name="idGioitinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmgioitinh"/> class.</returns>
		public QUANLYQN.Entities.Dmgioitinh GetByIdGioitinh(System.Int32 idGioitinh, int start, int pageLength, out int count)
		{
			return GetByIdGioitinh(null, idGioitinh, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMGIOITINH index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGioitinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmgioitinh"/> class.</returns>
		public abstract QUANLYQN.Entities.Dmgioitinh GetByIdGioitinh(TransactionManager transactionManager, System.Int32 idGioitinh, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;Dmgioitinh&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;Dmgioitinh&gt;"/></returns>
		public static QUANLYQN.Entities.TList<Dmgioitinh> Fill(IDataReader reader, QUANLYQN.Entities.TList<Dmgioitinh> rows, int start, int pageLength)
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
			
			QUANLYQN.Entities.Dmgioitinh c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Dmgioitinh")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.DmgioitinhColumn.IdGioitinh - 1))?(int)0:(System.Int32)reader[((int)QUANLYQN.Entities.DmgioitinhColumn.IdGioitinh - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Dmgioitinh>(
			key.ToString(), // EntityTrackingKey
			"Dmgioitinh",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.Dmgioitinh();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdGioitinh = (System.Int32)reader["ID_GIOITINH"];
			c.Gioitinh = (System.String)reader["GIOITINH"];
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
		/// Refreshes the <see cref="QUANLYQN.Entities.Dmgioitinh"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmgioitinh"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.Dmgioitinh entity)
		{
			if (!reader.Read()) return;
			
			entity.IdGioitinh = (System.Int32)reader["ID_GIOITINH"];
			entity.Gioitinh = (System.String)reader["GIOITINH"];
			entity.Ghichu = reader.IsDBNull(reader.GetOrdinal("GHICHU")) ? null : (System.String)reader["GHICHU"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.Dmgioitinh"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmgioitinh"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.Dmgioitinh entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdGioitinh = (System.Int32)dataRow["ID_GIOITINH"];
			entity.Gioitinh = (System.String)dataRow["GIOITINH"];
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
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmgioitinh"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Dmgioitinh Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.Dmgioitinh entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdGioitinh methods when available
			
			#region QuannhanCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Quannhan>|QuannhanCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuannhanCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuannhanCollection = DataRepository.QuannhanProvider.GetByIdGioitinh(transactionManager, entity.IdGioitinh);

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
		/// Deep Save the entire object graph of the QUANLYQN.Entities.Dmgioitinh object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.Dmgioitinh instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Dmgioitinh Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.Dmgioitinh entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.IdGioitinhSource != null)
							child.IdGioitinh = child.IdGioitinhSource.IdGioitinh;
						else
							child.IdGioitinh = entity.IdGioitinh;

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
	
	#region DmgioitinhChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.Dmgioitinh</c>
	///</summary>
	public enum DmgioitinhChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Dmgioitinh</c> as OneToMany for QuannhanCollection
		///</summary>
		[ChildEntityType(typeof(TList<Quannhan>))]
		QuannhanCollection,
	}
	
	#endregion DmgioitinhChildEntityTypes
	
	#region DmgioitinhFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DmgioitinhColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmgioitinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmgioitinhFilterBuilder : SqlFilterBuilder<DmgioitinhColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmgioitinhFilterBuilder class.
		/// </summary>
		public DmgioitinhFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmgioitinhFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmgioitinhFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmgioitinhFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmgioitinhFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmgioitinhFilterBuilder
	
	#region DmgioitinhParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DmgioitinhColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmgioitinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmgioitinhParameterBuilder : ParameterizedSqlFilterBuilder<DmgioitinhColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmgioitinhParameterBuilder class.
		/// </summary>
		public DmgioitinhParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmgioitinhParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmgioitinhParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmgioitinhParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmgioitinhParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmgioitinhParameterBuilder
} // end namespace
