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
	/// This class is the base class for any <see cref="DmlopProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DmlopProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.Dmlop, QUANLYQN.Entities.DmlopKey>
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
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.DmlopKey key)
		{
			return Delete(transactionManager, key.IdLop);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idLop">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 idLop)
		{
			return Delete(null, idLop);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLop">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 idLop);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DMLOP_DMDONVI key.
		///		FK_DMLOP_DMDONVI Description: 
		/// </summary>
		/// <param name="idDaidoi"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Dmlop objects.</returns>
		public QUANLYQN.Entities.TList<Dmlop> GetByIdDaidoi(System.Int32 idDaidoi)
		{
			int count = -1;
			return GetByIdDaidoi(idDaidoi, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DMLOP_DMDONVI key.
		///		FK_DMLOP_DMDONVI Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDaidoi"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Dmlop objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Dmlop> GetByIdDaidoi(TransactionManager transactionManager, System.Int32 idDaidoi)
		{
			int count = -1;
			return GetByIdDaidoi(transactionManager, idDaidoi, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_DMLOP_DMDONVI key.
		///		FK_DMLOP_DMDONVI Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDaidoi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Dmlop objects.</returns>
		public QUANLYQN.Entities.TList<Dmlop> GetByIdDaidoi(TransactionManager transactionManager, System.Int32 idDaidoi, int start, int pageLength)
		{
			int count = -1;
			return GetByIdDaidoi(transactionManager, idDaidoi, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DMLOP_DMDONVI key.
		///		fkDmlopDmdonvi Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idDaidoi"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Dmlop objects.</returns>
		public QUANLYQN.Entities.TList<Dmlop> GetByIdDaidoi(System.Int32 idDaidoi, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdDaidoi(null, idDaidoi, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DMLOP_DMDONVI key.
		///		fkDmlopDmdonvi Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idDaidoi"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Dmlop objects.</returns>
		public QUANLYQN.Entities.TList<Dmlop> GetByIdDaidoi(System.Int32 idDaidoi, int start, int pageLength,out int count)
		{
			return GetByIdDaidoi(null, idDaidoi, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DMLOP_DMDONVI key.
		///		FK_DMLOP_DMDONVI Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDaidoi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Dmlop objects.</returns>
		public abstract QUANLYQN.Entities.TList<Dmlop> GetByIdDaidoi(TransactionManager transactionManager, System.Int32 idDaidoi, int start, int pageLength, out int count);
		
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
		public override QUANLYQN.Entities.Dmlop Get(TransactionManager transactionManager, QUANLYQN.Entities.DmlopKey key, int start, int pageLength)
		{
			return GetByIdLop(transactionManager, key.IdLop, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_DMLOP index.
		/// </summary>
		/// <param name="idLop"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmlop"/> class.</returns>
		public QUANLYQN.Entities.Dmlop GetByIdLop(System.Int32 idLop)
		{
			int count = -1;
			return GetByIdLop(null,idLop, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMLOP index.
		/// </summary>
		/// <param name="idLop"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmlop"/> class.</returns>
		public QUANLYQN.Entities.Dmlop GetByIdLop(System.Int32 idLop, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLop(null, idLop, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMLOP index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLop"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmlop"/> class.</returns>
		public QUANLYQN.Entities.Dmlop GetByIdLop(TransactionManager transactionManager, System.Int32 idLop)
		{
			int count = -1;
			return GetByIdLop(transactionManager, idLop, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMLOP index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLop"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmlop"/> class.</returns>
		public QUANLYQN.Entities.Dmlop GetByIdLop(TransactionManager transactionManager, System.Int32 idLop, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLop(transactionManager, idLop, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMLOP index.
		/// </summary>
		/// <param name="idLop"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmlop"/> class.</returns>
		public QUANLYQN.Entities.Dmlop GetByIdLop(System.Int32 idLop, int start, int pageLength, out int count)
		{
			return GetByIdLop(null, idLop, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMLOP index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLop"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmlop"/> class.</returns>
		public abstract QUANLYQN.Entities.Dmlop GetByIdLop(TransactionManager transactionManager, System.Int32 idLop, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;Dmlop&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;Dmlop&gt;"/></returns>
		public static QUANLYQN.Entities.TList<Dmlop> Fill(IDataReader reader, QUANLYQN.Entities.TList<Dmlop> rows, int start, int pageLength)
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
			
			QUANLYQN.Entities.Dmlop c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Dmlop")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.DmlopColumn.IdLop - 1))?(int)0:(System.Int32)reader[((int)QUANLYQN.Entities.DmlopColumn.IdLop - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Dmlop>(
			key.ToString(), // EntityTrackingKey
			"Dmlop",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.Dmlop();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdLop = (System.Int32)reader["ID_LOP"];
			c.Malop = (System.String)reader["MALOP"];
			c.Tenlop = (System.String)reader["TENLOP"];
			c.IdDaidoi = (System.Int32)reader["ID_DAIDOI"];
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
		/// Refreshes the <see cref="QUANLYQN.Entities.Dmlop"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmlop"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.Dmlop entity)
		{
			if (!reader.Read()) return;
			
			entity.IdLop = (System.Int32)reader["ID_LOP"];
			entity.Malop = (System.String)reader["MALOP"];
			entity.Tenlop = (System.String)reader["TENLOP"];
			entity.IdDaidoi = (System.Int32)reader["ID_DAIDOI"];
			entity.Ghichu = reader.IsDBNull(reader.GetOrdinal("GHICHU")) ? null : (System.String)reader["GHICHU"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.Dmlop"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmlop"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.Dmlop entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdLop = (System.Int32)dataRow["ID_LOP"];
			entity.Malop = (System.String)dataRow["MALOP"];
			entity.Tenlop = (System.String)dataRow["TENLOP"];
			entity.IdDaidoi = (System.Int32)dataRow["ID_DAIDOI"];
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
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmlop"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Dmlop Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.Dmlop entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region IdDaidoiSource	
			if (CanDeepLoad(entity, "Dmdonvi|IdDaidoiSource", deepLoadType, innerList) 
				&& entity.IdDaidoiSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdDaidoi;
				Dmdonvi tmpEntity = EntityManager.LocateEntity<Dmdonvi>(EntityLocator.ConstructKeyFromPkItems(typeof(Dmdonvi), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdDaidoiSource = tmpEntity;
				else
					entity.IdDaidoiSource = DataRepository.DmdonviProvider.GetByIdDonvi(transactionManager, entity.IdDaidoi);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdDaidoiSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdDaidoiSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DmdonviProvider.DeepLoad(transactionManager, entity.IdDaidoiSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdDaidoiSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdLop methods when available
			
			#region QuannhanCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Quannhan>|QuannhanCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuannhanCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuannhanCollection = DataRepository.QuannhanProvider.GetByIdLop(transactionManager, entity.IdLop);

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
		/// Deep Save the entire object graph of the QUANLYQN.Entities.Dmlop object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.Dmlop instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Dmlop Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.Dmlop entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IdDaidoiSource
			if (CanDeepSave(entity, "Dmdonvi|IdDaidoiSource", deepSaveType, innerList) 
				&& entity.IdDaidoiSource != null)
			{
				DataRepository.DmdonviProvider.Save(transactionManager, entity.IdDaidoiSource);
				entity.IdDaidoi = entity.IdDaidoiSource.IdDonvi;
			}
			#endregion 
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
						if(child.IdLopSource != null)
							child.IdLop = child.IdLopSource.IdLop;
						else
							child.IdLop = entity.IdLop;

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
	
	#region DmlopChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.Dmlop</c>
	///</summary>
	public enum DmlopChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Dmdonvi</c> at IdDaidoiSource
		///</summary>
		[ChildEntityType(typeof(Dmdonvi))]
		Dmdonvi,
	
		///<summary>
		/// Collection of <c>Dmlop</c> as OneToMany for QuannhanCollection
		///</summary>
		[ChildEntityType(typeof(TList<Quannhan>))]
		QuannhanCollection,
	}
	
	#endregion DmlopChildEntityTypes
	
	#region DmlopFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DmlopColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmlop"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmlopFilterBuilder : SqlFilterBuilder<DmlopColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmlopFilterBuilder class.
		/// </summary>
		public DmlopFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmlopFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmlopFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmlopFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmlopFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmlopFilterBuilder
	
	#region DmlopParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DmlopColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmlop"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmlopParameterBuilder : ParameterizedSqlFilterBuilder<DmlopColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmlopParameterBuilder class.
		/// </summary>
		public DmlopParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmlopParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmlopParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmlopParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmlopParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmlopParameterBuilder
} // end namespace
