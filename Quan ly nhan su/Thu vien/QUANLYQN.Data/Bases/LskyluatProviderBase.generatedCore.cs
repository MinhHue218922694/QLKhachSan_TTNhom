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
	/// This class is the base class for any <see cref="LskyluatProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LskyluatProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.Lskyluat, QUANLYQN.Entities.LskyluatKey>
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
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.LskyluatKey key)
		{
			return Delete(transactionManager, key.IdLichsukyluat);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idLichsukyluat">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idLichsukyluat)
		{
			return Delete(null, idLichsukyluat);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLichsukyluat">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idLichsukyluat);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKYLUAT_QUANNHAN1 key.
		///		FK_LSKYLUAT_QUANNHAN1 Description: 
		/// </summary>
		/// <param name="idQuannhan"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskyluat objects.</returns>
		public QUANLYQN.Entities.TList<Lskyluat> GetByIdQuannhan(System.Int32 idQuannhan)
		{
			int count = -1;
			return GetByIdQuannhan(idQuannhan, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKYLUAT_QUANNHAN1 key.
		///		FK_LSKYLUAT_QUANNHAN1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuannhan"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskyluat objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Lskyluat> GetByIdQuannhan(TransactionManager transactionManager, System.Int32 idQuannhan)
		{
			int count = -1;
			return GetByIdQuannhan(transactionManager, idQuannhan, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKYLUAT_QUANNHAN1 key.
		///		FK_LSKYLUAT_QUANNHAN1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuannhan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskyluat objects.</returns>
		public QUANLYQN.Entities.TList<Lskyluat> GetByIdQuannhan(TransactionManager transactionManager, System.Int32 idQuannhan, int start, int pageLength)
		{
			int count = -1;
			return GetByIdQuannhan(transactionManager, idQuannhan, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKYLUAT_QUANNHAN1 key.
		///		fkLskyluatQuannhan1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idQuannhan"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskyluat objects.</returns>
		public QUANLYQN.Entities.TList<Lskyluat> GetByIdQuannhan(System.Int32 idQuannhan, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdQuannhan(null, idQuannhan, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKYLUAT_QUANNHAN1 key.
		///		fkLskyluatQuannhan1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idQuannhan"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskyluat objects.</returns>
		public QUANLYQN.Entities.TList<Lskyluat> GetByIdQuannhan(System.Int32 idQuannhan, int start, int pageLength,out int count)
		{
			return GetByIdQuannhan(null, idQuannhan, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKYLUAT_QUANNHAN1 key.
		///		FK_LSKYLUAT_QUANNHAN1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuannhan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskyluat objects.</returns>
		public abstract QUANLYQN.Entities.TList<Lskyluat> GetByIdQuannhan(TransactionManager transactionManager, System.Int32 idQuannhan, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKYLUAT_DMHINHTHUCKYLUAT1 key.
		///		FK_LSKYLUAT_DMHINHTHUCKYLUAT1 Description: 
		/// </summary>
		/// <param name="idHinhthucKyluat"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskyluat objects.</returns>
		public QUANLYQN.Entities.TList<Lskyluat> GetByIdHinhthucKyluat(System.Int32 idHinhthucKyluat)
		{
			int count = -1;
			return GetByIdHinhthucKyluat(idHinhthucKyluat, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKYLUAT_DMHINHTHUCKYLUAT1 key.
		///		FK_LSKYLUAT_DMHINHTHUCKYLUAT1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idHinhthucKyluat"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskyluat objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Lskyluat> GetByIdHinhthucKyluat(TransactionManager transactionManager, System.Int32 idHinhthucKyluat)
		{
			int count = -1;
			return GetByIdHinhthucKyluat(transactionManager, idHinhthucKyluat, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKYLUAT_DMHINHTHUCKYLUAT1 key.
		///		FK_LSKYLUAT_DMHINHTHUCKYLUAT1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idHinhthucKyluat"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskyluat objects.</returns>
		public QUANLYQN.Entities.TList<Lskyluat> GetByIdHinhthucKyluat(TransactionManager transactionManager, System.Int32 idHinhthucKyluat, int start, int pageLength)
		{
			int count = -1;
			return GetByIdHinhthucKyluat(transactionManager, idHinhthucKyluat, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKYLUAT_DMHINHTHUCKYLUAT1 key.
		///		fkLskyluatDmhinhthuckyluat1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idHinhthucKyluat"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskyluat objects.</returns>
		public QUANLYQN.Entities.TList<Lskyluat> GetByIdHinhthucKyluat(System.Int32 idHinhthucKyluat, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdHinhthucKyluat(null, idHinhthucKyluat, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKYLUAT_DMHINHTHUCKYLUAT1 key.
		///		fkLskyluatDmhinhthuckyluat1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idHinhthucKyluat"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskyluat objects.</returns>
		public QUANLYQN.Entities.TList<Lskyluat> GetByIdHinhthucKyluat(System.Int32 idHinhthucKyluat, int start, int pageLength,out int count)
		{
			return GetByIdHinhthucKyluat(null, idHinhthucKyluat, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKYLUAT_DMHINHTHUCKYLUAT1 key.
		///		FK_LSKYLUAT_DMHINHTHUCKYLUAT1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idHinhthucKyluat"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskyluat objects.</returns>
		public abstract QUANLYQN.Entities.TList<Lskyluat> GetByIdHinhthucKyluat(TransactionManager transactionManager, System.Int32 idHinhthucKyluat, int start, int pageLength, out int count);
		
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
		public override QUANLYQN.Entities.Lskyluat Get(TransactionManager transactionManager, QUANLYQN.Entities.LskyluatKey key, int start, int pageLength)
		{
			return GetByIdLichsukyluat(transactionManager, key.IdLichsukyluat, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_LSKYLUAT index.
		/// </summary>
		/// <param name="idLichsukyluat"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lskyluat"/> class.</returns>
		public QUANLYQN.Entities.Lskyluat GetByIdLichsukyluat(System.Int64 idLichsukyluat)
		{
			int count = -1;
			return GetByIdLichsukyluat(null,idLichsukyluat, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSKYLUAT index.
		/// </summary>
		/// <param name="idLichsukyluat"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lskyluat"/> class.</returns>
		public QUANLYQN.Entities.Lskyluat GetByIdLichsukyluat(System.Int64 idLichsukyluat, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLichsukyluat(null, idLichsukyluat, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSKYLUAT index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLichsukyluat"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lskyluat"/> class.</returns>
		public QUANLYQN.Entities.Lskyluat GetByIdLichsukyluat(TransactionManager transactionManager, System.Int64 idLichsukyluat)
		{
			int count = -1;
			return GetByIdLichsukyluat(transactionManager, idLichsukyluat, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSKYLUAT index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLichsukyluat"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lskyluat"/> class.</returns>
		public QUANLYQN.Entities.Lskyluat GetByIdLichsukyluat(TransactionManager transactionManager, System.Int64 idLichsukyluat, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLichsukyluat(transactionManager, idLichsukyluat, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSKYLUAT index.
		/// </summary>
		/// <param name="idLichsukyluat"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lskyluat"/> class.</returns>
		public QUANLYQN.Entities.Lskyluat GetByIdLichsukyluat(System.Int64 idLichsukyluat, int start, int pageLength, out int count)
		{
			return GetByIdLichsukyluat(null, idLichsukyluat, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSKYLUAT index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLichsukyluat"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lskyluat"/> class.</returns>
		public abstract QUANLYQN.Entities.Lskyluat GetByIdLichsukyluat(TransactionManager transactionManager, System.Int64 idLichsukyluat, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;Lskyluat&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;Lskyluat&gt;"/></returns>
		public static QUANLYQN.Entities.TList<Lskyluat> Fill(IDataReader reader, QUANLYQN.Entities.TList<Lskyluat> rows, int start, int pageLength)
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
			
			QUANLYQN.Entities.Lskyluat c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Lskyluat")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.LskyluatColumn.IdLichsukyluat - 1))?(long)0:(System.Int64)reader[((int)QUANLYQN.Entities.LskyluatColumn.IdLichsukyluat - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Lskyluat>(
			key.ToString(), // EntityTrackingKey
			"Lskyluat",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.Lskyluat();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdLichsukyluat = (System.Int64)reader["ID_LICHSUKYLUAT"];
			c.IdQuannhan = (System.Int32)reader["ID_QUANNHAN"];
			c.IdHinhthucKyluat = (System.Int32)reader["ID_HINHTHUC_KYLUAT"];
			c.CapKyluat = (System.String)reader["CAP_KYLUAT"];
			c.NgayQuyetdinh = reader.IsDBNull(reader.GetOrdinal("NGAY_QUYETDINH")) ? null : (System.DateTime?)reader["NGAY_QUYETDINH"];
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
		/// Refreshes the <see cref="QUANLYQN.Entities.Lskyluat"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Lskyluat"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.Lskyluat entity)
		{
			if (!reader.Read()) return;
			
			entity.IdLichsukyluat = (System.Int64)reader["ID_LICHSUKYLUAT"];
			entity.IdQuannhan = (System.Int32)reader["ID_QUANNHAN"];
			entity.IdHinhthucKyluat = (System.Int32)reader["ID_HINHTHUC_KYLUAT"];
			entity.CapKyluat = (System.String)reader["CAP_KYLUAT"];
			entity.NgayQuyetdinh = reader.IsDBNull(reader.GetOrdinal("NGAY_QUYETDINH")) ? null : (System.DateTime?)reader["NGAY_QUYETDINH"];
			entity.Ghichu = reader.IsDBNull(reader.GetOrdinal("GHICHU")) ? null : (System.String)reader["GHICHU"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.Lskyluat"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Lskyluat"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.Lskyluat entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdLichsukyluat = (System.Int64)dataRow["ID_LICHSUKYLUAT"];
			entity.IdQuannhan = (System.Int32)dataRow["ID_QUANNHAN"];
			entity.IdHinhthucKyluat = (System.Int32)dataRow["ID_HINHTHUC_KYLUAT"];
			entity.CapKyluat = (System.String)dataRow["CAP_KYLUAT"];
			entity.NgayQuyetdinh = Convert.IsDBNull(dataRow["NGAY_QUYETDINH"]) ? null : (System.DateTime?)dataRow["NGAY_QUYETDINH"];
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
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Lskyluat"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Lskyluat Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.Lskyluat entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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

			#region IdHinhthucKyluatSource	
			if (CanDeepLoad(entity, "Dmhinhthuckyluat|IdHinhthucKyluatSource", deepLoadType, innerList) 
				&& entity.IdHinhthucKyluatSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdHinhthucKyluat;
				Dmhinhthuckyluat tmpEntity = EntityManager.LocateEntity<Dmhinhthuckyluat>(EntityLocator.ConstructKeyFromPkItems(typeof(Dmhinhthuckyluat), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdHinhthucKyluatSource = tmpEntity;
				else
					entity.IdHinhthucKyluatSource = DataRepository.DmhinhthuckyluatProvider.GetByIdHinhthucKyluat(transactionManager, entity.IdHinhthucKyluat);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdHinhthucKyluatSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdHinhthucKyluatSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DmhinhthuckyluatProvider.DeepLoad(transactionManager, entity.IdHinhthucKyluatSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdHinhthucKyluatSource
			
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
		/// Deep Save the entire object graph of the QUANLYQN.Entities.Lskyluat object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.Lskyluat instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Lskyluat Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.Lskyluat entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IdQuannhanSource
			if (CanDeepSave(entity, "Quannhan|IdQuannhanSource", deepSaveType, innerList) 
				&& entity.IdQuannhanSource != null)
			{
				DataRepository.QuannhanProvider.Save(transactionManager, entity.IdQuannhanSource);
				entity.IdQuannhan = entity.IdQuannhanSource.IdQuannhan;
			}
			#endregion 
			
			#region IdHinhthucKyluatSource
			if (CanDeepSave(entity, "Dmhinhthuckyluat|IdHinhthucKyluatSource", deepSaveType, innerList) 
				&& entity.IdHinhthucKyluatSource != null)
			{
				DataRepository.DmhinhthuckyluatProvider.Save(transactionManager, entity.IdHinhthucKyluatSource);
				entity.IdHinhthucKyluat = entity.IdHinhthucKyluatSource.IdHinhthucKyluat;
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
	
	#region LskyluatChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.Lskyluat</c>
	///</summary>
	public enum LskyluatChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Quannhan</c> at IdQuannhanSource
		///</summary>
		[ChildEntityType(typeof(Quannhan))]
		Quannhan,
			
		///<summary>
		/// Composite Property for <c>Dmhinhthuckyluat</c> at IdHinhthucKyluatSource
		///</summary>
		[ChildEntityType(typeof(Dmhinhthuckyluat))]
		Dmhinhthuckyluat,
		}
	
	#endregion LskyluatChildEntityTypes
	
	#region LskyluatFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LskyluatColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lskyluat"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LskyluatFilterBuilder : SqlFilterBuilder<LskyluatColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LskyluatFilterBuilder class.
		/// </summary>
		public LskyluatFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LskyluatFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LskyluatFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LskyluatFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LskyluatFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LskyluatFilterBuilder
	
	#region LskyluatParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LskyluatColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lskyluat"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LskyluatParameterBuilder : ParameterizedSqlFilterBuilder<LskyluatColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LskyluatParameterBuilder class.
		/// </summary>
		public LskyluatParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LskyluatParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LskyluatParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LskyluatParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LskyluatParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LskyluatParameterBuilder
} // end namespace
