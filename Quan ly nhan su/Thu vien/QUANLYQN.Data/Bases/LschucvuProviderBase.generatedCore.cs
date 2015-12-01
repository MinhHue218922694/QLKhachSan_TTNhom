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
	/// This class is the base class for any <see cref="LschucvuProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LschucvuProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.Lschucvu, QUANLYQN.Entities.LschucvuKey>
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
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.LschucvuKey key)
		{
			return Delete(transactionManager, key.IdLichsuchucvu);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idLichsuchucvu">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idLichsuchucvu)
		{
			return Delete(null, idLichsuchucvu);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLichsuchucvu">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idLichsuchucvu);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSCHUCVU_DMCHUCVU1 key.
		///		FK_LSCHUCVU_DMCHUCVU1 Description: 
		/// </summary>
		/// <param name="idChucvu"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lschucvu objects.</returns>
		public QUANLYQN.Entities.TList<Lschucvu> GetByIdChucvu(System.Int32 idChucvu)
		{
			int count = -1;
			return GetByIdChucvu(idChucvu, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSCHUCVU_DMCHUCVU1 key.
		///		FK_LSCHUCVU_DMCHUCVU1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idChucvu"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lschucvu objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Lschucvu> GetByIdChucvu(TransactionManager transactionManager, System.Int32 idChucvu)
		{
			int count = -1;
			return GetByIdChucvu(transactionManager, idChucvu, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSCHUCVU_DMCHUCVU1 key.
		///		FK_LSCHUCVU_DMCHUCVU1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idChucvu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lschucvu objects.</returns>
		public QUANLYQN.Entities.TList<Lschucvu> GetByIdChucvu(TransactionManager transactionManager, System.Int32 idChucvu, int start, int pageLength)
		{
			int count = -1;
			return GetByIdChucvu(transactionManager, idChucvu, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSCHUCVU_DMCHUCVU1 key.
		///		fkLschucvuDmchucvu1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idChucvu"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lschucvu objects.</returns>
		public QUANLYQN.Entities.TList<Lschucvu> GetByIdChucvu(System.Int32 idChucvu, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdChucvu(null, idChucvu, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSCHUCVU_DMCHUCVU1 key.
		///		fkLschucvuDmchucvu1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idChucvu"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lschucvu objects.</returns>
		public QUANLYQN.Entities.TList<Lschucvu> GetByIdChucvu(System.Int32 idChucvu, int start, int pageLength,out int count)
		{
			return GetByIdChucvu(null, idChucvu, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSCHUCVU_DMCHUCVU1 key.
		///		FK_LSCHUCVU_DMCHUCVU1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idChucvu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lschucvu objects.</returns>
		public abstract QUANLYQN.Entities.TList<Lschucvu> GetByIdChucvu(TransactionManager transactionManager, System.Int32 idChucvu, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSCHUCVU_QUANNHAN1 key.
		///		FK_LSCHUCVU_QUANNHAN1 Description: 
		/// </summary>
		/// <param name="idQuannhan"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lschucvu objects.</returns>
		public QUANLYQN.Entities.TList<Lschucvu> GetByIdQuannhan(System.Int32 idQuannhan)
		{
			int count = -1;
			return GetByIdQuannhan(idQuannhan, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSCHUCVU_QUANNHAN1 key.
		///		FK_LSCHUCVU_QUANNHAN1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuannhan"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lschucvu objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Lschucvu> GetByIdQuannhan(TransactionManager transactionManager, System.Int32 idQuannhan)
		{
			int count = -1;
			return GetByIdQuannhan(transactionManager, idQuannhan, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSCHUCVU_QUANNHAN1 key.
		///		FK_LSCHUCVU_QUANNHAN1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuannhan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lschucvu objects.</returns>
		public QUANLYQN.Entities.TList<Lschucvu> GetByIdQuannhan(TransactionManager transactionManager, System.Int32 idQuannhan, int start, int pageLength)
		{
			int count = -1;
			return GetByIdQuannhan(transactionManager, idQuannhan, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSCHUCVU_QUANNHAN1 key.
		///		fkLschucvuQuannhan1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idQuannhan"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lschucvu objects.</returns>
		public QUANLYQN.Entities.TList<Lschucvu> GetByIdQuannhan(System.Int32 idQuannhan, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdQuannhan(null, idQuannhan, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSCHUCVU_QUANNHAN1 key.
		///		fkLschucvuQuannhan1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idQuannhan"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lschucvu objects.</returns>
		public QUANLYQN.Entities.TList<Lschucvu> GetByIdQuannhan(System.Int32 idQuannhan, int start, int pageLength,out int count)
		{
			return GetByIdQuannhan(null, idQuannhan, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSCHUCVU_QUANNHAN1 key.
		///		FK_LSCHUCVU_QUANNHAN1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuannhan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lschucvu objects.</returns>
		public abstract QUANLYQN.Entities.TList<Lschucvu> GetByIdQuannhan(TransactionManager transactionManager, System.Int32 idQuannhan, int start, int pageLength, out int count);
		
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
		public override QUANLYQN.Entities.Lschucvu Get(TransactionManager transactionManager, QUANLYQN.Entities.LschucvuKey key, int start, int pageLength)
		{
			return GetByIdLichsuchucvu(transactionManager, key.IdLichsuchucvu, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_LSCHUCVU_1 index.
		/// </summary>
		/// <param name="idLichsuchucvu"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lschucvu"/> class.</returns>
		public QUANLYQN.Entities.Lschucvu GetByIdLichsuchucvu(System.Int64 idLichsuchucvu)
		{
			int count = -1;
			return GetByIdLichsuchucvu(null,idLichsuchucvu, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSCHUCVU_1 index.
		/// </summary>
		/// <param name="idLichsuchucvu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lschucvu"/> class.</returns>
		public QUANLYQN.Entities.Lschucvu GetByIdLichsuchucvu(System.Int64 idLichsuchucvu, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLichsuchucvu(null, idLichsuchucvu, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSCHUCVU_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLichsuchucvu"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lschucvu"/> class.</returns>
		public QUANLYQN.Entities.Lschucvu GetByIdLichsuchucvu(TransactionManager transactionManager, System.Int64 idLichsuchucvu)
		{
			int count = -1;
			return GetByIdLichsuchucvu(transactionManager, idLichsuchucvu, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSCHUCVU_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLichsuchucvu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lschucvu"/> class.</returns>
		public QUANLYQN.Entities.Lschucvu GetByIdLichsuchucvu(TransactionManager transactionManager, System.Int64 idLichsuchucvu, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLichsuchucvu(transactionManager, idLichsuchucvu, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSCHUCVU_1 index.
		/// </summary>
		/// <param name="idLichsuchucvu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lschucvu"/> class.</returns>
		public QUANLYQN.Entities.Lschucvu GetByIdLichsuchucvu(System.Int64 idLichsuchucvu, int start, int pageLength, out int count)
		{
			return GetByIdLichsuchucvu(null, idLichsuchucvu, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSCHUCVU_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLichsuchucvu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lschucvu"/> class.</returns>
		public abstract QUANLYQN.Entities.Lschucvu GetByIdLichsuchucvu(TransactionManager transactionManager, System.Int64 idLichsuchucvu, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;Lschucvu&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;Lschucvu&gt;"/></returns>
		public static QUANLYQN.Entities.TList<Lschucvu> Fill(IDataReader reader, QUANLYQN.Entities.TList<Lschucvu> rows, int start, int pageLength)
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
			
			QUANLYQN.Entities.Lschucvu c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Lschucvu")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.LschucvuColumn.IdLichsuchucvu - 1))?(long)0:(System.Int64)reader[((int)QUANLYQN.Entities.LschucvuColumn.IdLichsuchucvu - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Lschucvu>(
			key.ToString(), // EntityTrackingKey
			"Lschucvu",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.Lschucvu();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdLichsuchucvu = (System.Int64)reader["ID_LICHSUCHUCVU"];
			c.IdQuannhan = (System.Int32)reader["ID_QUANNHAN"];
			c.IdChucvu = (System.Int32)reader["ID_CHUCVU"];
			c.Ngaynhan = reader.IsDBNull(reader.GetOrdinal("NGAYNHAN")) ? null : (System.DateTime?)reader["NGAYNHAN"];
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
		/// Refreshes the <see cref="QUANLYQN.Entities.Lschucvu"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Lschucvu"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.Lschucvu entity)
		{
			if (!reader.Read()) return;
			
			entity.IdLichsuchucvu = (System.Int64)reader["ID_LICHSUCHUCVU"];
			entity.IdQuannhan = (System.Int32)reader["ID_QUANNHAN"];
			entity.IdChucvu = (System.Int32)reader["ID_CHUCVU"];
			entity.Ngaynhan = reader.IsDBNull(reader.GetOrdinal("NGAYNHAN")) ? null : (System.DateTime?)reader["NGAYNHAN"];
			entity.Ghichu = reader.IsDBNull(reader.GetOrdinal("GHICHU")) ? null : (System.String)reader["GHICHU"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.Lschucvu"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Lschucvu"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.Lschucvu entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdLichsuchucvu = (System.Int64)dataRow["ID_LICHSUCHUCVU"];
			entity.IdQuannhan = (System.Int32)dataRow["ID_QUANNHAN"];
			entity.IdChucvu = (System.Int32)dataRow["ID_CHUCVU"];
			entity.Ngaynhan = Convert.IsDBNull(dataRow["NGAYNHAN"]) ? null : (System.DateTime?)dataRow["NGAYNHAN"];
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
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Lschucvu"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Lschucvu Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.Lschucvu entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region IdChucvuSource	
			if (CanDeepLoad(entity, "Dmchucvu|IdChucvuSource", deepLoadType, innerList) 
				&& entity.IdChucvuSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdChucvu;
				Dmchucvu tmpEntity = EntityManager.LocateEntity<Dmchucvu>(EntityLocator.ConstructKeyFromPkItems(typeof(Dmchucvu), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdChucvuSource = tmpEntity;
				else
					entity.IdChucvuSource = DataRepository.DmchucvuProvider.GetByIdChucvu(transactionManager, entity.IdChucvu);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdChucvuSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdChucvuSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DmchucvuProvider.DeepLoad(transactionManager, entity.IdChucvuSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdChucvuSource

			#region IdQuannhanSource	
			if (CanDeepLoad(entity, "Quannhan|IdQuannhanSource", deepLoadType, innerList) 
				&& entity.IdQuannhanSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdQuannhan;
				Quannhan tmpEntity = EntityManager.LocateEntity<Quannhan>(EntityLocator.ConstructKeyFromPkItems(typeof(Quannhan), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdQuannhanSource = tmpEntity;
				else
					entity.IdQuannhanSource = DataRepository.QuannhanProvider.GetByIdQuannhan(transactionManager, entity.IdQuannhan);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdQuannhanSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdQuannhanSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.QuannhanProvider.DeepLoad(transactionManager, entity.IdQuannhanSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdQuannhanSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
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
		/// Deep Save the entire object graph of the QUANLYQN.Entities.Lschucvu object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.Lschucvu instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Lschucvu Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.Lschucvu entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IdChucvuSource
			if (CanDeepSave(entity, "Dmchucvu|IdChucvuSource", deepSaveType, innerList) 
				&& entity.IdChucvuSource != null)
			{
				DataRepository.DmchucvuProvider.Save(transactionManager, entity.IdChucvuSource);
				entity.IdChucvu = entity.IdChucvuSource.IdChucvu;
			}
			#endregion 
			
			#region IdQuannhanSource
			if (CanDeepSave(entity, "Quannhan|IdQuannhanSource", deepSaveType, innerList) 
				&& entity.IdQuannhanSource != null)
			{
				DataRepository.QuannhanProvider.Save(transactionManager, entity.IdQuannhanSource);
				entity.IdQuannhan = entity.IdQuannhanSource.IdQuannhan;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();
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
	
	#region LschucvuChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.Lschucvu</c>
	///</summary>
	public enum LschucvuChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Dmchucvu</c> at IdChucvuSource
		///</summary>
		[ChildEntityType(typeof(Dmchucvu))]
		Dmchucvu,
			
		///<summary>
		/// Composite Property for <c>Quannhan</c> at IdQuannhanSource
		///</summary>
		[ChildEntityType(typeof(Quannhan))]
		Quannhan,
		}
	
	#endregion LschucvuChildEntityTypes
	
	#region LschucvuFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LschucvuColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lschucvu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LschucvuFilterBuilder : SqlFilterBuilder<LschucvuColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LschucvuFilterBuilder class.
		/// </summary>
		public LschucvuFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LschucvuFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LschucvuFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LschucvuFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LschucvuFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LschucvuFilterBuilder
	
	#region LschucvuParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LschucvuColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lschucvu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LschucvuParameterBuilder : ParameterizedSqlFilterBuilder<LschucvuColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LschucvuParameterBuilder class.
		/// </summary>
		public LschucvuParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LschucvuParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LschucvuParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LschucvuParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LschucvuParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LschucvuParameterBuilder
} // end namespace
