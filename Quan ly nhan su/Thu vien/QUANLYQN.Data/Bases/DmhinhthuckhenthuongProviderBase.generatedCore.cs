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
	/// This class is the base class for any <see cref="DmhinhthuckhenthuongProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DmhinhthuckhenthuongProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.Dmhinhthuckhenthuong, QUANLYQN.Entities.DmhinhthuckhenthuongKey>
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
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.DmhinhthuckhenthuongKey key)
		{
			return Delete(transactionManager, key.IdHinhthucKhenthuong);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idHinhthucKhenthuong">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 idHinhthucKhenthuong)
		{
			return Delete(null, idHinhthucKhenthuong);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idHinhthucKhenthuong">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 idHinhthucKhenthuong);		
		
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
		public override QUANLYQN.Entities.Dmhinhthuckhenthuong Get(TransactionManager transactionManager, QUANLYQN.Entities.DmhinhthuckhenthuongKey key, int start, int pageLength)
		{
			return GetByIdHinhthucKhenthuong(transactionManager, key.IdHinhthucKhenthuong, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_DMHINHTHUCKHENTHUONG index.
		/// </summary>
		/// <param name="idHinhthucKhenthuong"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmhinhthuckhenthuong"/> class.</returns>
		public QUANLYQN.Entities.Dmhinhthuckhenthuong GetByIdHinhthucKhenthuong(System.Int32 idHinhthucKhenthuong)
		{
			int count = -1;
			return GetByIdHinhthucKhenthuong(null,idHinhthucKhenthuong, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMHINHTHUCKHENTHUONG index.
		/// </summary>
		/// <param name="idHinhthucKhenthuong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmhinhthuckhenthuong"/> class.</returns>
		public QUANLYQN.Entities.Dmhinhthuckhenthuong GetByIdHinhthucKhenthuong(System.Int32 idHinhthucKhenthuong, int start, int pageLength)
		{
			int count = -1;
			return GetByIdHinhthucKhenthuong(null, idHinhthucKhenthuong, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMHINHTHUCKHENTHUONG index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idHinhthucKhenthuong"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmhinhthuckhenthuong"/> class.</returns>
		public QUANLYQN.Entities.Dmhinhthuckhenthuong GetByIdHinhthucKhenthuong(TransactionManager transactionManager, System.Int32 idHinhthucKhenthuong)
		{
			int count = -1;
			return GetByIdHinhthucKhenthuong(transactionManager, idHinhthucKhenthuong, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMHINHTHUCKHENTHUONG index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idHinhthucKhenthuong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmhinhthuckhenthuong"/> class.</returns>
		public QUANLYQN.Entities.Dmhinhthuckhenthuong GetByIdHinhthucKhenthuong(TransactionManager transactionManager, System.Int32 idHinhthucKhenthuong, int start, int pageLength)
		{
			int count = -1;
			return GetByIdHinhthucKhenthuong(transactionManager, idHinhthucKhenthuong, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMHINHTHUCKHENTHUONG index.
		/// </summary>
		/// <param name="idHinhthucKhenthuong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmhinhthuckhenthuong"/> class.</returns>
		public QUANLYQN.Entities.Dmhinhthuckhenthuong GetByIdHinhthucKhenthuong(System.Int32 idHinhthucKhenthuong, int start, int pageLength, out int count)
		{
			return GetByIdHinhthucKhenthuong(null, idHinhthucKhenthuong, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DMHINHTHUCKHENTHUONG index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idHinhthucKhenthuong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Dmhinhthuckhenthuong"/> class.</returns>
		public abstract QUANLYQN.Entities.Dmhinhthuckhenthuong GetByIdHinhthucKhenthuong(TransactionManager transactionManager, System.Int32 idHinhthucKhenthuong, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;Dmhinhthuckhenthuong&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;Dmhinhthuckhenthuong&gt;"/></returns>
		public static QUANLYQN.Entities.TList<Dmhinhthuckhenthuong> Fill(IDataReader reader, QUANLYQN.Entities.TList<Dmhinhthuckhenthuong> rows, int start, int pageLength)
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
			
			QUANLYQN.Entities.Dmhinhthuckhenthuong c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Dmhinhthuckhenthuong")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.DmhinhthuckhenthuongColumn.IdHinhthucKhenthuong - 1))?(int)0:(System.Int32)reader[((int)QUANLYQN.Entities.DmhinhthuckhenthuongColumn.IdHinhthucKhenthuong - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Dmhinhthuckhenthuong>(
			key.ToString(), // EntityTrackingKey
			"Dmhinhthuckhenthuong",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.Dmhinhthuckhenthuong();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdHinhthucKhenthuong = (System.Int32)reader["ID_HINHTHUC_KHENTHUONG"];
			c.HinhthucKhenthuong = (System.String)reader["HINHTHUC_KHENTHUONG"];
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
		/// Refreshes the <see cref="QUANLYQN.Entities.Dmhinhthuckhenthuong"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmhinhthuckhenthuong"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.Dmhinhthuckhenthuong entity)
		{
			if (!reader.Read()) return;
			
			entity.IdHinhthucKhenthuong = (System.Int32)reader["ID_HINHTHUC_KHENTHUONG"];
			entity.HinhthucKhenthuong = (System.String)reader["HINHTHUC_KHENTHUONG"];
			entity.Ghichu = reader.IsDBNull(reader.GetOrdinal("GHICHU")) ? null : (System.String)reader["GHICHU"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.Dmhinhthuckhenthuong"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmhinhthuckhenthuong"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.Dmhinhthuckhenthuong entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdHinhthucKhenthuong = (System.Int32)dataRow["ID_HINHTHUC_KHENTHUONG"];
			entity.HinhthucKhenthuong = (System.String)dataRow["HINHTHUC_KHENTHUONG"];
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
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Dmhinhthuckhenthuong"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Dmhinhthuckhenthuong Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.Dmhinhthuckhenthuong entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdHinhthucKhenthuong methods when available
			
			#region LskhenthuongCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Lskhenthuong>|LskhenthuongCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LskhenthuongCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.LskhenthuongCollection = DataRepository.LskhenthuongProvider.GetByIdHinhthucKhenthuong(transactionManager, entity.IdHinhthucKhenthuong);

				if (deep && entity.LskhenthuongCollection.Count > 0)
				{
					deepHandles.Add("LskhenthuongCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Lskhenthuong>) DataRepository.LskhenthuongProvider.DeepLoad,
						new object[] { transactionManager, entity.LskhenthuongCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the QUANLYQN.Entities.Dmhinhthuckhenthuong object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.Dmhinhthuckhenthuong instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Dmhinhthuckhenthuong Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.Dmhinhthuckhenthuong entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Lskhenthuong>
				if (CanDeepSave(entity.LskhenthuongCollection, "List<Lskhenthuong>|LskhenthuongCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Lskhenthuong child in entity.LskhenthuongCollection)
					{
						if(child.IdHinhthucKhenthuongSource != null)
							child.IdHinhthucKhenthuong = child.IdHinhthucKhenthuongSource.IdHinhthucKhenthuong;
						else
							child.IdHinhthucKhenthuong = entity.IdHinhthucKhenthuong;

					}

					if (entity.LskhenthuongCollection.Count > 0 || entity.LskhenthuongCollection.DeletedItems.Count > 0)
					{
						DataRepository.LskhenthuongProvider.Save(transactionManager, entity.LskhenthuongCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Lskhenthuong >) DataRepository.LskhenthuongProvider.DeepSave,
							new object[] { transactionManager, entity.LskhenthuongCollection, deepSaveType, childTypes, innerList }
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
	
	#region DmhinhthuckhenthuongChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.Dmhinhthuckhenthuong</c>
	///</summary>
	public enum DmhinhthuckhenthuongChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Dmhinhthuckhenthuong</c> as OneToMany for LskhenthuongCollection
		///</summary>
		[ChildEntityType(typeof(TList<Lskhenthuong>))]
		LskhenthuongCollection,
	}
	
	#endregion DmhinhthuckhenthuongChildEntityTypes
	
	#region DmhinhthuckhenthuongFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DmhinhthuckhenthuongColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmhinhthuckhenthuong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmhinhthuckhenthuongFilterBuilder : SqlFilterBuilder<DmhinhthuckhenthuongColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongFilterBuilder class.
		/// </summary>
		public DmhinhthuckhenthuongFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmhinhthuckhenthuongFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmhinhthuckhenthuongFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmhinhthuckhenthuongFilterBuilder
	
	#region DmhinhthuckhenthuongParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DmhinhthuckhenthuongColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dmhinhthuckhenthuong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DmhinhthuckhenthuongParameterBuilder : ParameterizedSqlFilterBuilder<DmhinhthuckhenthuongColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongParameterBuilder class.
		/// </summary>
		public DmhinhthuckhenthuongParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DmhinhthuckhenthuongParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DmhinhthuckhenthuongParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DmhinhthuckhenthuongParameterBuilder
} // end namespace
