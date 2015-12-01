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
	/// This class is the base class for any <see cref="LskhenthuongProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LskhenthuongProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.Lskhenthuong, QUANLYQN.Entities.LskhenthuongKey>
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
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.LskhenthuongKey key)
		{
			return Delete(transactionManager, key.IdLichsukhenthuong);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idLichsukhenthuong">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idLichsukhenthuong)
		{
			return Delete(null, idLichsukhenthuong);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLichsukhenthuong">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idLichsukhenthuong);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKHENTHUONG_QUANNHAN1 key.
		///		FK_LSKHENTHUONG_QUANNHAN1 Description: 
		/// </summary>
		/// <param name="idQuannhan"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskhenthuong objects.</returns>
		public QUANLYQN.Entities.TList<Lskhenthuong> GetByIdQuannhan(System.Int32 idQuannhan)
		{
			int count = -1;
			return GetByIdQuannhan(idQuannhan, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKHENTHUONG_QUANNHAN1 key.
		///		FK_LSKHENTHUONG_QUANNHAN1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuannhan"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskhenthuong objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Lskhenthuong> GetByIdQuannhan(TransactionManager transactionManager, System.Int32 idQuannhan)
		{
			int count = -1;
			return GetByIdQuannhan(transactionManager, idQuannhan, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKHENTHUONG_QUANNHAN1 key.
		///		FK_LSKHENTHUONG_QUANNHAN1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuannhan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskhenthuong objects.</returns>
		public QUANLYQN.Entities.TList<Lskhenthuong> GetByIdQuannhan(TransactionManager transactionManager, System.Int32 idQuannhan, int start, int pageLength)
		{
			int count = -1;
			return GetByIdQuannhan(transactionManager, idQuannhan, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKHENTHUONG_QUANNHAN1 key.
		///		fkLskhenthuongQuannhan1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idQuannhan"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskhenthuong objects.</returns>
		public QUANLYQN.Entities.TList<Lskhenthuong> GetByIdQuannhan(System.Int32 idQuannhan, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdQuannhan(null, idQuannhan, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKHENTHUONG_QUANNHAN1 key.
		///		fkLskhenthuongQuannhan1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idQuannhan"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskhenthuong objects.</returns>
		public QUANLYQN.Entities.TList<Lskhenthuong> GetByIdQuannhan(System.Int32 idQuannhan, int start, int pageLength,out int count)
		{
			return GetByIdQuannhan(null, idQuannhan, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKHENTHUONG_QUANNHAN1 key.
		///		FK_LSKHENTHUONG_QUANNHAN1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuannhan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskhenthuong objects.</returns>
		public abstract QUANLYQN.Entities.TList<Lskhenthuong> GetByIdQuannhan(TransactionManager transactionManager, System.Int32 idQuannhan, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKHENTHUONG_DMHINHTHUCKHENTHUONG1 key.
		///		FK_LSKHENTHUONG_DMHINHTHUCKHENTHUONG1 Description: 
		/// </summary>
		/// <param name="idHinhthucKhenthuong"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskhenthuong objects.</returns>
		public QUANLYQN.Entities.TList<Lskhenthuong> GetByIdHinhthucKhenthuong(System.Int32 idHinhthucKhenthuong)
		{
			int count = -1;
			return GetByIdHinhthucKhenthuong(idHinhthucKhenthuong, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKHENTHUONG_DMHINHTHUCKHENTHUONG1 key.
		///		FK_LSKHENTHUONG_DMHINHTHUCKHENTHUONG1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idHinhthucKhenthuong"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskhenthuong objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Lskhenthuong> GetByIdHinhthucKhenthuong(TransactionManager transactionManager, System.Int32 idHinhthucKhenthuong)
		{
			int count = -1;
			return GetByIdHinhthucKhenthuong(transactionManager, idHinhthucKhenthuong, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKHENTHUONG_DMHINHTHUCKHENTHUONG1 key.
		///		FK_LSKHENTHUONG_DMHINHTHUCKHENTHUONG1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idHinhthucKhenthuong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskhenthuong objects.</returns>
		public QUANLYQN.Entities.TList<Lskhenthuong> GetByIdHinhthucKhenthuong(TransactionManager transactionManager, System.Int32 idHinhthucKhenthuong, int start, int pageLength)
		{
			int count = -1;
			return GetByIdHinhthucKhenthuong(transactionManager, idHinhthucKhenthuong, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKHENTHUONG_DMHINHTHUCKHENTHUONG1 key.
		///		fkLskhenthuongDmhinhthuckhenthuong1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idHinhthucKhenthuong"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskhenthuong objects.</returns>
		public QUANLYQN.Entities.TList<Lskhenthuong> GetByIdHinhthucKhenthuong(System.Int32 idHinhthucKhenthuong, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdHinhthucKhenthuong(null, idHinhthucKhenthuong, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKHENTHUONG_DMHINHTHUCKHENTHUONG1 key.
		///		fkLskhenthuongDmhinhthuckhenthuong1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idHinhthucKhenthuong"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskhenthuong objects.</returns>
		public QUANLYQN.Entities.TList<Lskhenthuong> GetByIdHinhthucKhenthuong(System.Int32 idHinhthucKhenthuong, int start, int pageLength,out int count)
		{
			return GetByIdHinhthucKhenthuong(null, idHinhthucKhenthuong, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSKHENTHUONG_DMHINHTHUCKHENTHUONG1 key.
		///		FK_LSKHENTHUONG_DMHINHTHUCKHENTHUONG1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idHinhthucKhenthuong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lskhenthuong objects.</returns>
		public abstract QUANLYQN.Entities.TList<Lskhenthuong> GetByIdHinhthucKhenthuong(TransactionManager transactionManager, System.Int32 idHinhthucKhenthuong, int start, int pageLength, out int count);
		
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
		public override QUANLYQN.Entities.Lskhenthuong Get(TransactionManager transactionManager, QUANLYQN.Entities.LskhenthuongKey key, int start, int pageLength)
		{
			return GetByIdLichsukhenthuong(transactionManager, key.IdLichsukhenthuong, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_LSKHENTHUONG index.
		/// </summary>
		/// <param name="idLichsukhenthuong"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lskhenthuong"/> class.</returns>
		public QUANLYQN.Entities.Lskhenthuong GetByIdLichsukhenthuong(System.Int64 idLichsukhenthuong)
		{
			int count = -1;
			return GetByIdLichsukhenthuong(null,idLichsukhenthuong, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSKHENTHUONG index.
		/// </summary>
		/// <param name="idLichsukhenthuong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lskhenthuong"/> class.</returns>
		public QUANLYQN.Entities.Lskhenthuong GetByIdLichsukhenthuong(System.Int64 idLichsukhenthuong, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLichsukhenthuong(null, idLichsukhenthuong, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSKHENTHUONG index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLichsukhenthuong"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lskhenthuong"/> class.</returns>
		public QUANLYQN.Entities.Lskhenthuong GetByIdLichsukhenthuong(TransactionManager transactionManager, System.Int64 idLichsukhenthuong)
		{
			int count = -1;
			return GetByIdLichsukhenthuong(transactionManager, idLichsukhenthuong, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSKHENTHUONG index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLichsukhenthuong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lskhenthuong"/> class.</returns>
		public QUANLYQN.Entities.Lskhenthuong GetByIdLichsukhenthuong(TransactionManager transactionManager, System.Int64 idLichsukhenthuong, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLichsukhenthuong(transactionManager, idLichsukhenthuong, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSKHENTHUONG index.
		/// </summary>
		/// <param name="idLichsukhenthuong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lskhenthuong"/> class.</returns>
		public QUANLYQN.Entities.Lskhenthuong GetByIdLichsukhenthuong(System.Int64 idLichsukhenthuong, int start, int pageLength, out int count)
		{
			return GetByIdLichsukhenthuong(null, idLichsukhenthuong, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSKHENTHUONG index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLichsukhenthuong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lskhenthuong"/> class.</returns>
		public abstract QUANLYQN.Entities.Lskhenthuong GetByIdLichsukhenthuong(TransactionManager transactionManager, System.Int64 idLichsukhenthuong, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;Lskhenthuong&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;Lskhenthuong&gt;"/></returns>
		public static QUANLYQN.Entities.TList<Lskhenthuong> Fill(IDataReader reader, QUANLYQN.Entities.TList<Lskhenthuong> rows, int start, int pageLength)
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
			
			QUANLYQN.Entities.Lskhenthuong c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Lskhenthuong")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.LskhenthuongColumn.IdLichsukhenthuong - 1))?(long)0:(System.Int64)reader[((int)QUANLYQN.Entities.LskhenthuongColumn.IdLichsukhenthuong - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Lskhenthuong>(
			key.ToString(), // EntityTrackingKey
			"Lskhenthuong",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.Lskhenthuong();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdLichsukhenthuong = (System.Int64)reader["ID_LICHSUKHENTHUONG"];
			c.IdQuannhan = (System.Int32)reader["ID_QUANNHAN"];
			c.IdHinhthucKhenthuong = (System.Int32)reader["ID_HINHTHUC_KHENTHUONG"];
			c.CapKhenthuong = (System.String)reader["CAP_KHENTHUONG"];
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
		/// Refreshes the <see cref="QUANLYQN.Entities.Lskhenthuong"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Lskhenthuong"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.Lskhenthuong entity)
		{
			if (!reader.Read()) return;
			
			entity.IdLichsukhenthuong = (System.Int64)reader["ID_LICHSUKHENTHUONG"];
			entity.IdQuannhan = (System.Int32)reader["ID_QUANNHAN"];
			entity.IdHinhthucKhenthuong = (System.Int32)reader["ID_HINHTHUC_KHENTHUONG"];
			entity.CapKhenthuong = (System.String)reader["CAP_KHENTHUONG"];
			entity.Ngaynhan = reader.IsDBNull(reader.GetOrdinal("NGAYNHAN")) ? null : (System.DateTime?)reader["NGAYNHAN"];
			entity.Ghichu = reader.IsDBNull(reader.GetOrdinal("GHICHU")) ? null : (System.String)reader["GHICHU"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.Lskhenthuong"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Lskhenthuong"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.Lskhenthuong entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdLichsukhenthuong = (System.Int64)dataRow["ID_LICHSUKHENTHUONG"];
			entity.IdQuannhan = (System.Int32)dataRow["ID_QUANNHAN"];
			entity.IdHinhthucKhenthuong = (System.Int32)dataRow["ID_HINHTHUC_KHENTHUONG"];
			entity.CapKhenthuong = (System.String)dataRow["CAP_KHENTHUONG"];
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
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Lskhenthuong"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Lskhenthuong Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.Lskhenthuong entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region IdHinhthucKhenthuongSource	
			if (CanDeepLoad(entity, "Dmhinhthuckhenthuong|IdHinhthucKhenthuongSource", deepLoadType, innerList) 
				&& entity.IdHinhthucKhenthuongSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdHinhthucKhenthuong;
				Dmhinhthuckhenthuong tmpEntity = EntityManager.LocateEntity<Dmhinhthuckhenthuong>(EntityLocator.ConstructKeyFromPkItems(typeof(Dmhinhthuckhenthuong), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdHinhthucKhenthuongSource = tmpEntity;
				else
					entity.IdHinhthucKhenthuongSource = DataRepository.DmhinhthuckhenthuongProvider.GetByIdHinhthucKhenthuong(transactionManager, entity.IdHinhthucKhenthuong);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdHinhthucKhenthuongSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdHinhthucKhenthuongSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DmhinhthuckhenthuongProvider.DeepLoad(transactionManager, entity.IdHinhthucKhenthuongSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdHinhthucKhenthuongSource
			
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
		/// Deep Save the entire object graph of the QUANLYQN.Entities.Lskhenthuong object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.Lskhenthuong instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Lskhenthuong Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.Lskhenthuong entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region IdHinhthucKhenthuongSource
			if (CanDeepSave(entity, "Dmhinhthuckhenthuong|IdHinhthucKhenthuongSource", deepSaveType, innerList) 
				&& entity.IdHinhthucKhenthuongSource != null)
			{
				DataRepository.DmhinhthuckhenthuongProvider.Save(transactionManager, entity.IdHinhthucKhenthuongSource);
				entity.IdHinhthucKhenthuong = entity.IdHinhthucKhenthuongSource.IdHinhthucKhenthuong;
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
	
	#region LskhenthuongChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.Lskhenthuong</c>
	///</summary>
	public enum LskhenthuongChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Quannhan</c> at IdQuannhanSource
		///</summary>
		[ChildEntityType(typeof(Quannhan))]
		Quannhan,
			
		///<summary>
		/// Composite Property for <c>Dmhinhthuckhenthuong</c> at IdHinhthucKhenthuongSource
		///</summary>
		[ChildEntityType(typeof(Dmhinhthuckhenthuong))]
		Dmhinhthuckhenthuong,
		}
	
	#endregion LskhenthuongChildEntityTypes
	
	#region LskhenthuongFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LskhenthuongColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lskhenthuong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LskhenthuongFilterBuilder : SqlFilterBuilder<LskhenthuongColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LskhenthuongFilterBuilder class.
		/// </summary>
		public LskhenthuongFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LskhenthuongFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LskhenthuongFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LskhenthuongFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LskhenthuongFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LskhenthuongFilterBuilder
	
	#region LskhenthuongParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LskhenthuongColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lskhenthuong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LskhenthuongParameterBuilder : ParameterizedSqlFilterBuilder<LskhenthuongColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LskhenthuongParameterBuilder class.
		/// </summary>
		public LskhenthuongParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LskhenthuongParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LskhenthuongParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LskhenthuongParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LskhenthuongParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LskhenthuongParameterBuilder
} // end namespace
