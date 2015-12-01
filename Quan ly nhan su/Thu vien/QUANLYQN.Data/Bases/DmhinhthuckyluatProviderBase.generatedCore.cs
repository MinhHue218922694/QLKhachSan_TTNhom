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
	/// This class is the base class for any <see cref="DmhinhthuckyluatProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DmhinhthuckyluatProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.Dmhinhthuckyluat, QUANLYQN.Entities.DmhinhthuckyluatKey>
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
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.DmhinhthuckyluatKey key)
		{
			return Delete(transactionManager, key.IdHinhthucKyluat);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idHinhthucKyluat">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 idHinhthucKyluat)
		{
			return Delete(null, idHinhthucKyluat);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idHinhthucKyluat">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 idHinhthucKyluat);		
		
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
		public override QUANLYQN.Entities.Dmhinhthuckyluat Get(TransactionManager transactionManager, QUANLYQN.Entities.DmhinhthuckyluatKey key, int start, int pageLength)
		{
			return GetByIdHinhthucKyluat(transactionManager, key.IdHinhthucKyluat, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_DMHINHTHUCKYLUAT index.
		/// </summary>
		/// <param name="idHinhthucKyluat"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmhinhthuckyluat"/> class.</returns>
		public QUANLYQN.Entities.Dmhinhthuckyluat GetByIdHinhthucKyluat(System.Int32 idHinhthucKyluat)
		{
			int count = -1;
			return GetByIdHinhthucKyluat(null,idHinhthucKyluat, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMHINHTHUCKYLUAT index.
		/// </summary>
		/// <param name="idHinhthucKyluat"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmhinhthuckyluat"/> class.</returns>
		public QUANLYQN.Entities.Dmhinhthuckyluat GetByIdHinhthucKyluat(System.Int32 idHinhthucKyluat, int start, int pageLength)
		{
			int count = -1;
			return GetByIdHinhthucKyluat(null, idHinhthucKyluat, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMHINHTHUCKYLUAT index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idHinhthucKyluat"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmhinhthuckyluat"/> class.</returns>
		public QUANLYQN.Entities.Dmhinhthuckyluat GetByIdHinhthucKyluat(TransactionManager transactionManager, System.Int32 idHinhthucKyluat)
		{
			int count = -1;
			return GetByIdHinhthucKyluat(transactionManager, idHinhthucKyluat, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMHINHTHUCKYLUAT index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idHinhthucKyluat"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmhinhthuckyluat"/> class.</returns>
		public QUANLYQN.Entities.Dmhinhthuckyluat GetByIdHinhthucKyluat(TransactionManager transactionManager, System.Int32 idHinhthucKyluat, int start, int pageLength)
		{
			int count = -1;
			return GetByIdHinhthucKyluat(transactionManager, idHinhthucKyluat, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMHINHTHUCKYLUAT index.
		/// </summary>
		/// <param name="idHinhthucKyluat"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmhinhthuckyluat"/> class.</returns>
		public QUANLYQN.Entities.Dmhinhthuckyluat GetByIdHinhthucKyluat(System.Int32 idHinhthucKyluat, int start, int pageLength, out int count)
		{
			return GetByIdHinhthucKyluat(null, idHinhthucKyluat, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMHINHTHUCKYLUAT index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idHinhthucKyluat"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmhinhthuckyluat"/> class.</returns>
		public abstract QUANLYQN.Entities.Dmhinhthuckyluat GetByIdHinhthucKyluat(TransactionManager transactionManager, System.Int32 idHinhthucKyluat, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;Dmhinhthuckyluat&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;Dmhinhthuckyluat&gt;"/></returns>
		public static QUANLYQN.Entities.TList<Dmhinhthuckyluat> Fill(IDataReader reader, QUANLYQN.Entities.TList<Dmhinhthuckyluat> rows, int start, int pageLength)
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
			
			QUANLYQN.Entities.Dmhinhthuckyluat c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Dmhinhthuckyluat")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.DmhinhthuckyluatColumn.IdHinhthucKyluat - 1))?(int)0:(System.Int32)reader[((int)QUANLYQN.Entities.DmhinhthuckyluatColumn.IdHinhthucKyluat - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Dmhinhthuckyluat>(
			key.ToString(), // EntityTrackingKey
			"Dmhinhthuckyluat",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.Dmhinhthuckyluat();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdHinhthucKyluat = (System.Int32)reader["ID_HINHTHUC_KYLUAT"];
			c.HinhthucKyluat = (System.String)reader["HINHTHUC_KYLUAT"];
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
		/// Refreshes the <see cref="QUANLYQN.Entities.Dmhinhthuckyluat"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmhinhthuckyluat"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.Dmhinhthuckyluat entity)
		{
			if (!reader.Read()) return;
			
			entity.IdHinhthucKyluat = (System.Int32)reader["ID_HINHTHUC_KYLUAT"];
			entity.HinhthucKyluat = (System.String)reader["HINHTHUC_KYLUAT"];
			entity.Ghichu = reader.IsDBNull(reader.GetOrdinal("GHICHU")) ? null : (System.String)reader["GHICHU"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.Dmhinhthuckyluat"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmhinhthuckyluat"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.Dmhinhthuckyluat entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdHinhthucKyluat = (System.Int32)dataRow["ID_HINHTHUC_KYLUAT"];
			entity.HinhthucKyluat = (System.String)dataRow["HINHTHUC_KYLUAT"];
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
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmhinhthuckyluat"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Dmhinhthuckyluat Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.Dmhinhthuckyluat entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdHinhthucKyluat methods when available
			
			#region LskyluatCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Lskyluat>|LskyluatCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LskyluatCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.LskyluatCollection = DataRepository.LskyluatProvider.GetByIdHinhthucKyluat(transactionManager, entity.IdHinhthucKyluat);

				if (deep && entity.LskyluatCollection.Count > 0)
				{
					deepHandles.Add("LskyluatCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Lskyluat>) DataRepository.LskyluatProvider.DeepLoad,
						new object[] { transactionManager, entity.LskyluatCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the QUANLYQN.Entities.Dmhinhthuckyluat object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.Dmhinhthuckyluat instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Dmhinhthuckyluat Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.Dmhinhthuckyluat entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Lskyluat>
				if (CanDeepSave(entity.LskyluatCollection, "List<Lskyluat>|LskyluatCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Lskyluat child in entity.LskyluatCollection)
					{
						if(child.IdHinhthucKyluatSource != null)
							child.IdHinhthucKyluat = child.IdHinhthucKyluatSource.IdHinhthucKyluat;
						else
							child.IdHinhthucKyluat = entity.IdHinhthucKyluat;

					}

					if (entity.LskyluatCollection.Count > 0 || entity.LskyluatCollection.DeletedItems.Count > 0)
					{
						DataRepository.LskyluatProvider.Save(transactionManager, entity.LskyluatCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Lskyluat >) DataRepository.LskyluatProvider.DeepSave,
							new object[] { transactionManager, entity.LskyluatCollection, deepSaveType, childTypes, innerList }
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
	
	#region DmhinhthuckyluatChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.Dmhinhthuckyluat</c>
	///</summary>
	public enum DmhinhthuckyluatChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Dmhinhthuckyluat</c> as OneToMany for LskyluatCollection
		///</summary>
		[ChildEntityType(typeof(TList<Lskyluat>))]
		LskyluatCollection,
	}
	
	#endregion DmhinhthuckyluatChildEntityTypes
	
	#region DmhinhthuckyluatFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DmhinhthuckyluatColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmhinhthuckyluat"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmhinhthuckyluatFilterBuilder : SqlFilterBuilder<DmhinhthuckyluatColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckyluatFilterBuilder class.
		/// </summary>
		public DmhinhthuckyluatFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckyluatFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmhinhthuckyluatFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckyluatFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmhinhthuckyluatFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmhinhthuckyluatFilterBuilder
	
	#region DmhinhthuckyluatParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DmhinhthuckyluatColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmhinhthuckyluat"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmhinhthuckyluatParameterBuilder : ParameterizedSqlFilterBuilder<DmhinhthuckyluatColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckyluatParameterBuilder class.
		/// </summary>
		public DmhinhthuckyluatParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckyluatParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmhinhthuckyluatParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckyluatParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmhinhthuckyluatParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmhinhthuckyluatParameterBuilder
} // end namespace
